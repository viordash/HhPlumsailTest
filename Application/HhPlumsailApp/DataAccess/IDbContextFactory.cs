using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HhPlumsailApp.DataAccess {
	public interface IDbContextFactory : IDisposable {
		ApplicationDbContext CreateDbContext();
	}
}
