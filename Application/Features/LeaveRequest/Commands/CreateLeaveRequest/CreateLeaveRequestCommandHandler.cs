using AutoMapper;
using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Models.Email;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
{
    private readonly IEmailSender _emailSender;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private IMapper _mapper;
    private ILeaveRequestRepository _leaveRequestRepository;
    private IAppLogger<CreateLeaveRequestCommandHandler> _appLogger;

    public CreateLeaveRequestCommandHandler(IEmailSender emailSender, ILeaveTypeRepository leaveTypeRepository, IMapper mapper, ILeaveRequestRepository leaveRequestRepository, IAppLogger<CreateLeaveRequestCommandHandler> appLogger)
    {
        _emailSender = emailSender;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _appLogger = appLogger;
    }
    public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("invalid Leave Request", validationResult);
        }
        
        // Get requesting employee's id
        
        // Check on employee's allocation
        
        // if allocation aren't enough return validation error with message
        
        // Create leave request
        var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request);
        await _leaveRequestRepository.CreateAsync(leaveRequest);

        try
        {
            var email = new EmailMessage
            {
                To = string.Empty,
                Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D}" +
                       $"has been created successfully.",
                Subjecct = "Leave Request Created"
            };
        }
        catch (Exception ex)
        {
            _appLogger.LogWarning(ex.Message);
        }

        return Unit.Value;
    }
}