using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;

public class GetLeaveRequestListQueryHandler :IRequestHandler<GetLeaveRequestListQuery, List<GetLeaveRequestListDto>>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestListQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
    }
    public async Task<List<GetLeaveRequestListDto>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _leaveRequestRepository.GetLeaveRequestWithDtails();
        var requests = _mapper.Map<List<GetLeaveRequestListDto>>(request);

        return requests;
    }
}