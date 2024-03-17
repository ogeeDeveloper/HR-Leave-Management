using AutoMapper;
using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Models.Email;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IAppLogger<ChangeLeaveRequestApprovalCommandHandler> _appLogger;

    public ChangeLeaveRequestApprovalCommandHandler(IMapper mapper, IEmailSender emailSender, ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository, IAppLogger<ChangeLeaveRequestApprovalCommandHandler> appLogger)
    {
        _mapper = mapper;
        _emailSender = emailSender;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _appLogger = appLogger;
    }
    
    
    public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

        if (leaveRequest is null)
            throw new NotFoundException(nameof(LeaveType), request.Id);
        
        // Update its approval status
        leaveRequest.Approved = request.Approved;
        
        // Update the leave request in the database
        await _leaveRequestRepository.UpdatedAsync(leaveRequest);
        
        // if request is approved, get and update the employee's allocation

        try
        {
            // send email
            var email = new EmailMessage
            {
                To = String.Empty,
                Body = $"The approval status for your leave request for {leaveRequest.StartDate:D}" +
                       $"to {leaveRequest.EndDate:D}" +
                       $"has been approved",
                Subjecct = "Leave Request Approval Updated"
            };
            await _emailSender.SendEmil(email);
        }
        catch (Exception e)
        {
            _appLogger.LogInformation("Failed to send email ", e.Message);
        }
        return Unit.Value;
    }
}