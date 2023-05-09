using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Wego.Application.Exceptions;
using Wego.Application.Models.Authentification;
using Wego.Application.Models.Mail;
using Wego.Identity.Service;

namespace Wego.Idendity.tests.Services
{
    public class JwtTokenServiceTest
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly IOptions<JwtSettings> _jwtSettings;
        public JwtTokenServiceTest()
        {
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(new Mock<IUserStore<ApplicationUser>>().Object,
             new Mock<IOptions<IdentityOptions>>().Object,
             new Mock<IPasswordHasher<ApplicationUser>>().Object,
             new IUserValidator<ApplicationUser>[0],
             new IPasswordValidator<ApplicationUser>[0],
             new Mock<ILookupNormalizer>().Object,
             new Mock<IdentityErrorDescriber>().Object,
             new Mock<IServiceProvider>().Object,
             new Mock<ILogger<UserManager<ApplicationUser>>>().Object);
            _jwtSettings = Options.Create(new JwtSettings()
            {
                Key = "123"
            });
        }
        [Fact]
        public async Task GenerateToken_IsSuccessful()
        {
            // Arrange
            var user = new ApplicationUser() { Email = "test@test.com", UserName= "test134"};

            var expectedClaims = new List<Claim>()
            {
                new Claim("type", "value")
            };
            _userManagerMock.Setup(x => x.GetClaimsAsync(user)).ReturnsAsync(expectedClaims);
       

            var expectedRoles = new List<string> { "role1", "role2"};
            _userManagerMock.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(expectedRoles);

            // Act
            var sut = new JwtTokenService(_userManagerMock.Object, _jwtSettings);
            var result = await sut.GenerateTokenAsync(user);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<JwtSecurityToken>(result);
        }

        [Fact]
        public  void GenerateToken_UsernameNull_Throw_UserNotFoundException()
        {
            // Arrange
            ApplicationUser user = new ApplicationUser() { Email = "test@test.com", UserName = null };
           
            // Act
            var sut = new JwtTokenService(_userManagerMock.Object, _jwtSettings);

            //Assert
            Assert.ThrowsAsync<UserNotFoundException>(async () => await sut.GenerateTokenAsync(user));
        }
        [Fact]
        public void GenerateToken_EmailNull_Throw_UserNotFoundException()
        {
            // Arrange
            ApplicationUser user = new ApplicationUser() { Email = null, UserName = "test13" };

            // Act
            var sut = new JwtTokenService(_userManagerMock.Object, _jwtSettings);

            //Assert
            Assert.ThrowsAsync<UserNotFoundException>(async () => await sut.GenerateTokenAsync(user));
        }
    }
}
