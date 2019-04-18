using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HhPlumsailApp.Services {
	public interface IAuthorizationService {
		Task<IEnumerable<Claim>> AuthorizeUserAsync(string userName, string password);
	}
}
