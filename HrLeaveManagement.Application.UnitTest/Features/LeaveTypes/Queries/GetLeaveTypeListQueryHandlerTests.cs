using AutoMapper;
using HrLeaveManagement.Application.UnitTest.Mocks;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypeQuery;
using HRLeaveManagement.Application.MappingProfiles;
using Moq;
using Shouldly;

namespace HrLeaveManagement.Application.UnitTest.Features.LeaveTypes.Queries;

public class GetLeaveTypeListQueryHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private IMapper _mapper;
    private Mock<IAppLogger<GetAllLeaveTypeQueryHandler>> _mockAppLogger;

    public GetLeaveTypeListQueryHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetAllLeaveTypeQueryHandler>>();
    }

    // Carry out the test
    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetAllLeaveTypeQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

        var result = await handler.Handle(new GetAllLeaveTypeQuery(), CancellationToken.None);

        // Validate errors
        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(3);
    }
}
