using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Http;
using GuardNet;
using HhPlumsailApp.Extensions;
using HhPlumsailApp.Models;
using HhPlumsailApp.Services;

namespace HhPlumsailApp.Controllers {
	[Authorize]
	[RoutePrefix("api/Account")]
	public class AccountController : ApiController {
		readonly IUserManagerService userManagerService;

		public AccountController(IUserManagerService userManagerService) {
			Guard.NotNull(userManagerService, nameof(userManagerService));
			this.userManagerService = userManagerService;
		}

		// POST api/Account/Register
		[AllowAnonymous]
		[Route("Register")]
		public async Task<IHttpActionResult> Register(UserModel userModel) {
			ModelState.Validate();

			await userManagerService.RegisterUser(userModel);
			return Ok();
		}
	}
}
