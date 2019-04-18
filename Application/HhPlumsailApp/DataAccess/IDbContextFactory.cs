namespace HhPlumsailApp.DataAccess {
	public interface IDbContextFactory {
		ApplicationDbContext CreateDbContext();
	}
}
