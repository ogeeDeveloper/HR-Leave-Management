using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;

public class GetLeaveRequestQueryHandler : IRequestHandler<GetLeaveRequestQuery, LeaveRequestDetailDto>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;

    public GetLeaveRequestQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
    {
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
    }
    public async Task<LeaveRequestDetailDto> Handle(GetLeaveRequestQuery request, CancellationToken cancellationToken)
    {
        var leaveRequest = _mapper.Map<LeaveRequestDetailDto>(await _leaveRequestRepository.GetLeaveRequestWithDtails(request.Id));
        return leaveRequest;
    }
}