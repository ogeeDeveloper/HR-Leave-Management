using FluentValidation;
using HRLeaveManagement.Application.Contracts.Persistence;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Shared;

public class BaseLeaveRequestValidator : AbstractValidator<BaseLeaveRequest>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public BaseLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.StartDate)
            .LessThan(p => p.EndDate)
            .WithMessage("{PropertyName} must be fore {ComparisonValue}");

        RuleFor(p => p.EndDate)
            .GreaterThan(p => p.StartDate)
            .WithMessage("{PropertyName} must be after {ComparisonValue}");

        RuleFor(p => p.LeaveTypeId)
            .GreaterThan(0)
            .MustAsync(LeaveTypeExist)
            .WithMessage("{PropertyName} does not exist.");
    }

    private async Task<bool> LeaveTypeExist(int id, CancellationToken arg2)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
        return leaveType != null;
    }
}