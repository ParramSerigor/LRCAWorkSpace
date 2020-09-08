namespace LRCA.classes
{
	public interface IAuditor
	{
		void Audit(IPersistenceContext persistenceContext);
	}
}
