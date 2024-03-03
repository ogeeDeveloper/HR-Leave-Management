using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveTypeCommand
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // retrueve domain entity object
            var leaveTypeToBeDeleted = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // Verify if leave type exist
            if (leaveTypeToBeDeleted == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            // remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToBeDeleted);


            return Unit.Value;
        }
    }
}
