using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetail;

public class GetLeaveAllocationDetailQueryHandler: IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDetailDto>
{
    private readonly ILeaveAllocationRepository _leaveAllocationRepository;
    private readonly IMapper _mapper;
    
    public GetLeaveAllocationDetailQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }
    public async Task<LeaveAllocationDetailDto> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocationDetails = await _leaveAllocationRepository.GetAllLeaveAllocationWithDetails(request.Id);
        return _mapper.Map<LeaveAllocationDetailDto>(leaveAllocationDetails);
    }
}