using System.Threading.Tasks;
using System.Web.Http;
using HhPlumsailApp.Controllers;
using HhPlumsailApp.Models;
using HhPlumsailApp.Services;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;

namespace HhPlumsailApp.Tests.Controllers {
	[TestFixture]
	public class AccountControllerTest {
		AccountController testable;
		Mock<IUserManagerService> userManagerServiceMock;

		[SetUp]
		public virtual void SetUp() {
			userManagerServiceMock = new Mock<IUserManagerService>();
			testable = new AccountController(userManagerServiceMock.Object);
		}

		[TearDown]
		public virtual void TearDown() {
			testable.Dispose();
		}

		[Test]
		public void Register_ReturnsResultOk() {
			userManagerServiceMock
				.Setup(x => x.RegisterUser(It.IsAny<UserModel>()))
				.Returns(() => {
					return Task.FromResult(IdentityResult.Success);
				});

			testable.ModelState.Clear();
			var result = testable.Register(new UserModel() {
				UserName = "test",
				Password = "123456",
				ConfirmPassword = "123456"
			});
			Assert.That(result, Is.TypeOf<Task<IHttpActionResult>>());
			Assert.That(result.Result, Is.TypeOf<System.Web.Http.Results.OkResult>());
		}

		[Test]
		public void Register_ReturnsBadRequest() {
			testable.ModelState.AddModelError("password", "minimal lenght");
			var result = testable.Register(new UserModel() {
				UserName = "test",
				Password = "123456",
				ConfirmPassword = "123456"
			});
			Assert.That(result, Is.TypeOf<Task<IHttpActionResult>>());
			Assert.That(result.Result, Is.TypeOf<System.Web.Http.Results.InvalidModelStateResult>());
		}
	}
}
