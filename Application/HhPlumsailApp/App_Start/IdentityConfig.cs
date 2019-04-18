using HhPlumsailApp.DataAccess;
using HhPlumsailApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace HhPlumsailApp {
	// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

	public class ApplicationUserManager : UserManager<IdentityUser> {
		public ApplicationUserManager(IUserStore<IdentityUser> store)
			: base(store) {
		}

		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) {
			var manager = new ApplicationUserManager(new UserStore<IdentityUser>(context.Get<ApplicationDbContext>()));
			// Configure validation logic for usernames
			manager.UserValidator = new UserValidator<IdentityUser>(manager) {
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = true
			};
			// Configure validation logic for passwords
			manager.PasswordValidator = new PasswordValidator {
				RequiredLength = UserModel.PasswordMinimumLength,
				RequireNonLetterOrDigit = false,
				RequireDigit = false,
				RequireLowercase = false,
				RequireUppercase = false,
			};
			var dataProtectionProvider = options.DataProtectionProvider;
			if(dataProtectionProvider != null) {
				manager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(dataProtectionProvider.Create("ASP.NET Identity"));
			}
			return manager;
		}
	}
}
