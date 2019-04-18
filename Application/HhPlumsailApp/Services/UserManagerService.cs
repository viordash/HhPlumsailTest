using System.Threading.Tasks;
using GuardNet;
using HhPlumsailApp.DataAccess;
using HhPlumsailApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HhPlumsailApp.Services {
	public class UserManagerService : IUserManagerService {
		readonly ApplicationDbContext applicationDbContext;
		readonly UserManager<IdentityUser> userManager;

		static PasswordValidator passwordValidator = new PasswordValidator {
			RequiredLength = UserModel.PasswordMinimumLength,
			RequireNonLetterOrDigit = false,
			RequireDigit = false,
			RequireLowercase = false,
			RequireUppercase = false,
		};

		public UserManagerService(ApplicationDbContext applicationDbContext) {
			Guard.NotNull(applicationDbContext, nameof(applicationDbContext));
			this.applicationDbContext = applicationDbContext;
			userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(applicationDbContext));
			this.userManager.PasswordValidator = passwordValidator;
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