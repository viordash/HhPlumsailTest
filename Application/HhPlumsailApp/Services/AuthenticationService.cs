using System.Diagnostics;
using System.Threading.Tasks;
using GuardNet;
using HhPlumsailApp.DataAccess;
using HhPlumsailApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HhPlumsailApp.Services {
	public class AuthenticationService : IAuthenticationService {
		readonly ApplicationDbContext applicationDbContext;
		readonly UserManager<IdentityUser> userManager;

		public AuthenticationService(ApplicationDbContext applicationDbContext) {
			Guard.NotNull(applicationDbContext, nameof(applicationDbContext));
			this.applicationDbContext = applicationDbContext;
			this.userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(applicationDbContext));
		}

		public async Task<IdentityUser> FindUser(string userName, string password) {
			IdentityUser user = await userManager.FindAsync(userName, password);
			return user;
		}

		public async Task<IdentityResult> RegisterUser(UserModel userModel) {
			var user = new IdentityUser {
				UserName = userModel.UserName
			};

			var result = await userManager.CreateAsync(user, userModel.Password);
			return result;
		}
	}
}