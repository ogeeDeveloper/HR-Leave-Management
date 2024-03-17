using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveTypeCommand;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
{
   private readonly ILeaveAllocationRepository _leaveAllocationRepository;

   public CreateLeaveAllocationCommandValidator(ILeaveAllocationRepository leaveAllocationRepository)
   {
      _leaveAllocationRepository = leaveAllocationRepository;

      RuleFor(p => p.LeaveTypeId)
         .GreaterThan(0)
         .MustAsync(LeaveTypeMustExist)
         .WithMessage("{PropertyName} does not exist");
   }
   
   private async Task<bool> LeaveTypeMustExist(int id, CancellationToken cancellationToken)
   {
      var leaveType = await _leaveAllocationRepository.GetByIdAsync(id);
      return leaveType != null;
   }
   
   // Check if Leave type name is unique
   /*private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
   {
      return await _leaveAllocationRepository.IsLeaveTypeUnique(command.Name);
   }*/
}