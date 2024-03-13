using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocation;

public class GetLeaveAllocationQueryHandler : IRequestHandler<GetLeaveAllocationQuery,List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;
    
    public GetLeaveAllocationQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }
    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationQuery request, CancellationToken cancellationToken)
    {
        /* TODO:
         - Get records for a specific user
         - get allocations per employee
         */

        var leaveTypeAllocations = await _leaveAllocationRepository.GetAllLeaveAllocationWithDetails();
        var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveTypeAllocations);
        return allocations;
    }
}