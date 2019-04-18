using System.Threading.Tasks;
using HhPlumsailApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HhPlumsailApp.Services {
	public class UserManagerService : UserManager<IdentityUser>, IUserManagerService {

		static PasswordValidator passwordValidator = new PasswordValidator {
			RequiredLength = UserModel.PasswordMinimumLength,
			RequireNonLetterOrDigit = false,
			RequireDigit = false,
			RequireLowercase = false,
			RequireUppercase = false,
		};

		public UserManagerService(UserStoreService userStoreService) : base(userStoreService) {
			PasswordValidator = passwordValidator;
		}

		public async Task<IdentityUser> FindUser(string userName, string password) {
			var user = await FindAsync(userName, password);
			return user;
		}

		public async Task<IdentityResult> RegisterUser(UserModel userModel) {
			var user = new IdentityUser {
				UserName = userModel.UserName
			};

			var result = await CreateAsync(user, userModel.Password);
			return result;
		}
	}
}