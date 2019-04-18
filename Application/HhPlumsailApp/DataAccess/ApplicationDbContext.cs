using HhPlumsailApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HhPlumsailApp.DataAccess {
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false) {
		}
	}
}