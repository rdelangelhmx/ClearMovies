namespace Application.Common.Interfaces
{
    public interface IRepositoryFactory
    {
        IEntityRepository<TEntity> EntityRepository<TEntity>() where TEntity : class;
    }
}
