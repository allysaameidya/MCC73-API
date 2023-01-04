using API2.Context;
using API2.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API2.Repository;

public class GeneralRepository<Entity, T> : IRepository<Entity, T> where Entity : class
{
    private MyContext _context;
    private DbSet<Entity> _entity;

    public GeneralRepository(MyContext context)
    {
        _context = context;
        _entity = _context.Set<Entity>();
    }
    public int Delete(T id)
    {
        var data = _entity.Find(id);
        if (data == null)
        {
            return 0;
        }
        _entity.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public Entity Get(T id)
    {
        return _entity.Find(id);
    }

    public IEnumerable<Entity> GetAll()
    {
        var entity = _entity.ToList();
        return entity;
    }

    public int Insert(Entity entity)
    {
        _entity.Add(entity);
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(Entity entity)
    {
        _entity.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges(); //SaveChanges = SqlCommit
        return result;
    }
}
