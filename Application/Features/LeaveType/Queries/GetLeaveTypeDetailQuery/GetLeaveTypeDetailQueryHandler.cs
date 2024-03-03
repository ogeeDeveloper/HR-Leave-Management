using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetailQuery
{
    public class GetLeaveTypeDetailQueryHandler : IRequestHandler<GetLeaveTypeDetailQuery, LeaveTypeDetailDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeDetailQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDetailDto> Handle(GetLeaveTypeDetailQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id) ?? throw new NotFoundException(nameof(LeaveType), request.Id);

            // Perform the mapping
            var data = _mapper.Map<LeaveTypeDetailDto>(leaveType);

            // Return the leave type detail for that Leave Type
            return data;
        }
    }
}
