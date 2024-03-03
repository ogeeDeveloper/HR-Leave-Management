using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery
{
    public class GetAllLeaveTypeQueryHandler : IRequestHandler<GetAllLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetAllLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetAllLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            // Convert data objects to DTOs
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            // Return list of LeaveType DTOs
            return data;
        }
    }
}
