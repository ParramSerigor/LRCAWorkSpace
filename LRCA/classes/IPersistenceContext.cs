using System.Threading.Tasks;

namespace LRCA.classes
{
	public interface IPersistenceContext
	{
		TEntity Insert<TEntity>(TEntity entity) where TEntity : class;
		Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class;
		TEntity Update<TEntity>(TEntity entity) where TEntity : class;
		TEntity Delete<TEntity>(TEntity entity, bool force = false) where TEntity : class;
		int SaveChanges();
	}
}