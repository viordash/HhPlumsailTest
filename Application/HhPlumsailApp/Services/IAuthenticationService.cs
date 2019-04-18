using System.Threading.Tasks;
using HhPlumsailApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HhPlumsailApp.Services {
	public interface IAuthenticationService {
		Task<IdentityResult> RegisterUser(UserModel userModel);
		Task<IdentityUser> FindUser(string userName, string password);
	}
}
