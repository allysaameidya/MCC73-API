namespace API2.Repository.Interface;

public interface IRepository<Entity, T> where Entity : class
{
    public IEnumerable<Entity> GetAll();
    public Entity Get(T id);
    public int Insert(Entity entity);
    public int Update(Entity entity);
    public int Delete(T id);
}
