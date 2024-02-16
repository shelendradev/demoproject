using DemoDAL.Interfaces;
using DemoDAL.Models;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using DemoBAL.interfaces;
namespace DemoApplicationTest
{
    public class DemoAPIBALTests
    {
         private readonly Mock<IDemoAPIBAL> _demoAPIBALMock;

        public DemoAPIBALTests()
        {
            _demoAPIBALMock = new Mock<IDemoAPIBAL>();
        }

        [Fact]
        public async Task CreateUser_WithValidData_ReturnsTrue()
        {
            var user = new UserModel() { FirstName = "John", LastName = "Doe",RoleID=1 };

            _demoAPIBALMock.Setup(x => x.CreateUser(user))
                .ReturnsAsync(true);

            var result = await _demoAPIBALMock.Object.CreateUser(user);

            Assert.True(result);
        }

        [Fact]
        public async Task CreateUser_WithInvalidData_ReturnsFalse()
        {
            UserModel user = null;

            _demoAPIBALMock.Setup(x => x.CreateUser(user))
                .ReturnsAsync(false);

            var result = await _demoAPIBALMock.Object.CreateUser(user);

            Assert.False(result);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsUsersList()
        {
            var users = new List<UserModel>
           {
               new UserModel{ FirstName = "John", LastName = "Doe", RoleID=1 },
               new UserModel{FirstName = "Jane", LastName = "Doe", RoleID = 1}
           };

            _demoAPIBALMock.Setup(x => x.GetAllUsers())
                .ReturnsAsync(users);

            var result = await _demoAPIBALMock.Object.GetAllUsers();

            Assert.Equal(2, result.Count);
            Assert.Contains(users, u => u.FirstName == "John");
            Assert.Contains(users, u => u.FirstName == "Jane");
        }
    }
}
