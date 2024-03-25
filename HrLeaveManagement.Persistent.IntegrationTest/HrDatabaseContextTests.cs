using HRLeaveManagement.Domain;
using HRLeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HrLeaveManagement.Persistent.IntegrationTest
{
    public class HrDatabaseContextTests
    {
        private readonly HRDatabaseContext _hrDatabaseContext;

        public HrDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HRDatabaseContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _hrDatabaseContext = new HRDatabaseContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 6,
                Name = "Test Vacation"
            };

            // Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            // Assert
            leaveType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedAtValue()
        {
            // Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 6,
                Name = "Test Vacation"
            };

            // Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            // Assert
            leaveType.DateModified.ShouldNotBeNull();
        }
    }
}