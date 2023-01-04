using API2.Context;
using API2.Models;
using API2.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API2.Repository.Data;

public class AccountRoleRepositories : GeneralRepository<AccountRole, int>
{
    public AccountRoleRepositories(MyContext context) : base(context)
    {

    }

    /*private MyContext _context;
    private DbSet<AccountRole> _acc_role;

    public AccountRoleRepositories(MyContext context)
    {
        _context = context;
        _acc_role = _context.Set<AccountRole>();
    }

    public int Delete(int id)
    {
        var data = _acc_role.Find(id);
        if (data == null)
        {
            return 0;
        }
        _acc_role.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public AccountRole Get(int id)
    {
        return _acc_role.Find(id);
    }

    public IEnumerable<AccountRole> GetAll()
    {
        var acc_roles = _acc_role.ToList();
        return acc_roles;
    }

    public int Insert(AccountRole entity)
    {
        _acc_role.Add(entity);
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(AccountRole entity)
    {
        _acc_role.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges(); //SaveChanges = SqlCommit
        return result;
    }*/
}
