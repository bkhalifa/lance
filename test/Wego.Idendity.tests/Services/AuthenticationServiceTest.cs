//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using System.IdentityModel.Tokens.Jwt;
//using Wego.Application.Contracts.Common;
//using Wego.Application.Contracts.Context;
//using Wego.Application.Contracts.Identity;
//using Wego.Application.Exceptions;
//using Wego.Application.Models.Authentification;
//using Wego.Application.Models.Mail;
//using Wego.Identity.Service;

//namespace Wego.Idendity.tests.Services
//{
//    public class AuthenticationServiceTest
//    {
//        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
//        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;
//        private readonly Mock<IJwtTokenService> _jwtTokenServiceMock;
//        private readonly Mock<ILogger<IAuthenticationService>> _loggerMock;
//        private readonly Mock<IEmailSender> _emailSenderMock;
//        private readonly Mock<ICurrentContext> _currentContextMock;
//        private readonly Mock<IIdentityContext> _identityContextMock;
//        private readonly Mock<IPasswordHasher<ApplicationUser>> _passwordHasherMock;

//        public AuthenticationServiceTest()
//        {
//            _userManagerMock = new Mock<UserManager<ApplicationUser>>(new Mock<IUserStore<ApplicationUser>>().Object,
//              new Mock<IOptions<IdentityOptions>>().Object,
//              new Mock<IPasswordHasher<ApplicationUser>>().Object,
//              new IUserValidator<ApplicationUser>[0],
//              new IPasswordValidator<ApplicationUser>[0],
//              new Mock<ILookupNormalizer>().Object,
//              new Mock<IdentityErrorDescriber>().Object,
//              new Mock<IServiceProvider>().Object,
//              new Mock<ILogger<UserManager<ApplicationUser>>>().Object);

//            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(_userManagerMock.Object,
//                     new Mock<IHttpContextAccessor>().Object,
//                     new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
//                     new Mock<IOptions<IdentityOptions>>().Object,
//                     new Mock<ILogger<SignInManager<ApplicationUser>>>().Object,
//                     new Mock<Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider>().Object,
//                     new Mock<IUserConfirmation<ApplicationUser>>().Object);

//            _jwtTokenServiceMock = new Mock<IJwtTokenService>();
//            _emailSenderMock = new Mock<IEmailSender>();
//            _loggerMock = new Mock<ILogger<IAuthenticationService>>();
//            _currentContextMock = new Mock<ICurrentContext>();
//            _identityContextMock = new Mock<IIdentityContext>();
//            _passwordHasherMock = new Mock<IPasswordHasher<ApplicationUser>>();
//        }


//        [Theory]
//        [InlineData("test@test.com", "P@ssword123", "test1237")]
//        public async Task Authenticate_IsSuccessful(string email, string password, string userName)
//        {
//            // Arrange
//            var expectedUser = new ApplicationUser() { Email = email, UserName = userName, Id = "1" };
//            _userManagerMock.Setup(x => x.FindByEmailAsync(email)).ReturnsAsync(expectedUser);
//            _signInManagerMock.Setup(x => x.PasswordSignInAsync(expectedUser.UserName, password, false, false)).ReturnsAsync(SignInResult.Success);

//            var expectedToken = new JwtSecurityToken();
//           // _jwtTokenServiceMock.Setup(x => x.GenerateTokenAsync(expectedUser)).ReturnsAsync(expectedToken);

//            var emailParam = new Email("to@to.com", "User Created");
//            _emailSenderMock.Setup(x => x.SendMailAsync(emailParam, default)).ReturnsAsync(true);

//            // Act
//            var sut = new AuthenticationService(_userManagerMock.Object, _signInManagerMock.Object, _jwtTokenServiceMock.Object, _loggerMock.Object, _emailSenderMock.Object, _currentContextMock.Object);
//            var result = await sut.LoginAsync(new AuthenticationRequest { Email = email, Password = password });

//            //Assert
//            Assert.NotNull(result);
//            Assert.IsType<AuthenticationResponse>(result);
//        }
//        [Theory]
//        [InlineData("test@test2.com", "P@ssword123")]
//        public void Authenticate_WrongEmail_Throw_UserNotFoundException(string email, string password)
//        {
//            // Arrange
//            _userManagerMock.Setup(x => x.FindByEmailAsync(email)).ReturnsAsync(() => null);

//            // Act
//            var sut = new AuthenticationService(_userManagerMock.Object, _signInManagerMock.Object, _jwtTokenServiceMock.Object, _loggerMock.Object, _emailSenderMock.Object, _currentContextMock.Object);

//            //Assert
//            Assert.ThrowsAsync<UserNotFoundException>(async () => await sut.LoginAsync(new AuthenticationRequest { Email = email, Password = password }));
//        }

//        [Theory]
//        [InlineData("test@test.com", "P@ssword1234", "test1237")]
//        public void Authenticate_WrongPassword_Throw_CredentialInvalidException(string email, string password, string userName)
//        {
//            // Arrange
//            var expectedUser = new ApplicationUser() { Email = email, UserName = userName };
//            _userManagerMock.Setup(x => x.FindByEmailAsync(email)).ReturnsAsync(() => null);
//            _signInManagerMock.Setup(x => x.PasswordSignInAsync(expectedUser.UserName, password, false, false)).ReturnsAsync(SignInResult.Failed);
//            // Act
//            var sut = new AuthenticationService(_userManagerMock.Object, _signInManagerMock.Object, _jwtTokenServiceMock.Object, _loggerMock.Object, _emailSenderMock.Object, _currentContextMock.Object);
//            //Assert
//            Assert.ThrowsAsync<CredentialInvalidException>(async () => await sut.LoginAsync(new AuthenticationRequest { Email = email, Password = password }));
//        }


//        [Theory]
//        [InlineData("test@test.com", "P@ssword1234", "test1237")]
//        public async Task Register_IsSuccessful(string email, string password, string userName)
//        {
//            // Arrange

//            _userManagerMock.Setup(x => x.FindByNameAsync(userName)).ReturnsAsync(() => null);

//            _userManagerMock.Setup(x => x.FindByEmailAsync(userName)).ReturnsAsync(() => null);

//            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), password)).ReturnsAsync(IdentityResult.Success);

//            // Act
//            var sut = new AuthenticationService(_userManagerMock.Object, _signInManagerMock.Object, _jwtTokenServiceMock.Object, _loggerMock.Object, _emailSenderMock.Object, _currentContextMock.Object);
//            var result = await sut.RegisterAsync(new RegistrationRequest { Email = email, Password = password });

//            //Assert
//            Assert.NotNull(result);
//            Assert.IsType<RegistrationResponse>(result);
//        }

//        [Theory]
//        [InlineData("test@test.com", "P@ssword1234", "test")]
//        public void Register_WrongUsername_Throw_UserNotFoundException(string email, string password, string userName)
//        {
//            // Arrange
//            var expectedUser = new ApplicationUser() { Email = email, UserName = userName };
//            _userManagerMock.Setup(x => x.FindByNameAsync(userName)).ReturnsAsync(() => expectedUser);

//            // Act
//            var sut = new AuthenticationService(_userManagerMock.Object, _signInManagerMock.Object, _jwtTokenServiceMock.Object, _loggerMock.Object, _emailSenderMock.Object, _currentContextMock.Object);

//            //Assert
//            Assert.ThrowsAsync<UserNotFoundException>(async () => await sut.RegisterAsync(new RegistrationRequest { Email = email, Password = password }));
//        }


//        [Theory]
//        [InlineData("test@test.com", "P@ssword1234", "test")]
//        public void Register_WrongUsername_Throw_UserAlreadyExistsException(string email, string password, string userName)
//        {
//            // Arrange
//            var expectedUser = new ApplicationUser() { Email = email, UserName = userName };
//            _userManagerMock.Setup(x => x.FindByNameAsync(userName)).ReturnsAsync(() => null);
//            _userManagerMock.Setup(x => x.FindByEmailAsync(userName)).ReturnsAsync(expectedUser);

//            // Act
//            var sut = new AuthenticationService(_userManagerMock.Object, _signInManagerMock.Object, _jwtTokenServiceMock.Object, _loggerMock.Object, _emailSenderMock.Object, _currentContextMock.Object);

//            //Assert
//            Assert.ThrowsAsync<UserAlreadyExistsException>(async () => await sut.RegisterAsync(new RegistrationRequest { Email = email, Password = password }));
//        }

//        [Theory]
//        [InlineData("test@test.com", "P@ssword", "test")]
//        public void Register_WrongUsername_Throw_ValidationException(string email, string password, string userName)
//        {
//            // Arrange
//            _userManagerMock.Setup(x => x.FindByNameAsync(userName)).ReturnsAsync(() => null);

//            _userManagerMock.Setup(x => x.FindByEmailAsync(userName)).ReturnsAsync(() => null);

//            var expectedResult = IdentityResult.Failed(new IdentityError()
//            {
//                Description = "Invalid Password"
//            });

//            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), password)).ReturnsAsync(expectedResult);

//            // Act
//            var sut = new AuthenticationService(_userManagerMock.Object, _signInManagerMock.Object, _jwtTokenServiceMock.Object, _loggerMock.Object, _emailSenderMock.Object, _currentContextMock.Object);

//            //Assert
//            Assert.ThrowsAsync<ValidationException>(async () => await sut.RegisterAsync(new RegistrationRequest { Email = email, Password = password }));
//        }

//        //[Theory]
//        //[InlineData("test@test.com", "P@ssword123", "P@ssword1234")]
//        //public async Task ChangePassword_IsSuccessful(string email, string oldPassword, string newPassword)
//        //{
//        //    // Arrange
//        //    _identityContextMock.Setup(x => x.Email).Returns(email);
//        //    _currentContextMock.Setup(x => x.Identity).Returns(_identityContextMock.Object);

//        //    var expectedUser = new ApplicationUser() { Email = email, PasswordHash = "azerty" };
//        //    _userManagerMock.Setup(x => x.FindByEmailAsync(email)).ReturnsAsync(expectedUser);

//        //    _userManagerMock.Setup(x => x.PasswordHasher).Returns(_passwordHasherMock.Object);
//        //    _userManagerMock.Setup(x => x.PasswordHasher.VerifyHashedPassword(expectedUser, It.IsAny<string>(), It.IsAny<string>()))
//        //        .Returns(PasswordVerificationResult.Success);

//        //    _userManagerMock.Setup(x => x.ChangePasswordAsync(expectedUser, oldPassword, newPassword)).ReturnsAsync(IdentityResult.Success);
//        //    var emailParam = new Email(email, "PasswordChanged");
//        //    _emailSenderMock.Setup(x => x.SendMailAsync(emailParam, default)).ReturnsAsync(true);

//        //    // Act
//        //    var sut = new AuthenticationService(_userManagerMock.Object, _signInManagerMock.Object, _jwtTokenServiceMock.Object, _loggerMock.Object, _emailSenderMock.Object, _currentContextMock.Object);
//        //    var result = await sut.ChangePasswordAsync(oldPassword, newPassword);

//        //    //Assert
//        //    Assert.IsType<bool>(result);
//        //    Assert.True(result);
//        //}

//    }
//}
