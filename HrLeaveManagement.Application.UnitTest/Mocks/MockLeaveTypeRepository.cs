using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Moq;

namespace HrLeaveManagement.Application.UnitTest.Mocks;

public class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
    {
        var leavTypes = new List<LeaveType>
        {
            new LeaveType{
                Id = 1,
                DefaultDays = 6,
                Name = "Test Vacation"
            },
            new LeaveType{
                Id = 2,
                DefaultDays = 10,
                Name = "Test Sick"
            },
            new LeaveType{
                Id = 3,
                DefaultDays = 15,
                Name = "Test Matternity"
            },
        };

        var mockRepo = new Mock<ILeaveTypeRepository>(); // This is a mock of the real repo

        // Setup
        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leavTypes); // Return the control list of leave types above

        mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>()))
            .Returns((LeaveType leaveType) =>
            {
                leavTypes.Add(leaveType);
                return Task.CompletedTask;
            });

        return mockRepo;
    }
}
