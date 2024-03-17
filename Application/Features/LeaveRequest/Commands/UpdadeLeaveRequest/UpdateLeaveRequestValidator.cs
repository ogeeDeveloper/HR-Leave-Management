using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Features.LeaveRequest.Shared;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.UpdadeLeaveRequest;

public class UpdateLeaveRequestValidator : AbstractValidator<UpdateLeaveRequestCommand>
{
   private readonly ILeaveRequestRepository _leaveRequestRepository;
   private readonly ILeaveTypeRepository _leaveTypeRepository;

   public UpdateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
   {
      _leaveTypeRepository = leaveTypeRepository;
      _leaveRequestRepository = leaveRequestRepository;
      
      Include(new BaseLeaveRequestValidator(_leaveTypeRepository));

      RuleFor(p => p.Id)
         .NotNull()
         .MustAsync(LeaveRequestMustExist)
         .WithMessage("{PropertyName} must be present");
   }

   private async Task<bool> LeaveRequestMustExist(int id, CancellationToken arg2)
   {
      var leaveAllocation = await _leaveRequestRepository.GetByIdAsync(id);
      return leaveAllocation != null;
   }
}