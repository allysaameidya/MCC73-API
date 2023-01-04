using API2.Context;
using API2.Models;
using API2.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API2.Repository.Data;

public class RoleRepositories : GeneralRepository<Role, int>
{
    public RoleRepositories(MyContext context) : base(context)
    {

    }

    /*private MyContext _context;
    private DbSet<Role> _roles;

    public RoleRepositories(MyContext context)
    {
        _context = context;
        _roles = _context.Set<Role>();
    }

    public int Delete(int id)
    {
        var data = _roles.Find(id);
        if (data == null)
        {
            return 0;
        }
        _roles.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public Role Get(int id)
    {
        return _roles.Find(id);
    }

    public IEnumerable<Role> GetAll()
    {
        var roles = _roles.ToList();
        return roles;
    }

    public int Insert(Role entity)
    {
        _roles.Add(entity);
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(Role entity)
    {
        _roles.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges(); //SaveChanges = SqlCommit
        return result;
    }*/
}
