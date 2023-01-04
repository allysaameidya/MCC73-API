using API2.Context;
using API2.Models;
using API2.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API2.Repository.Data;

public class ProfilingRepositories : GeneralRepository<Profiling, string>
{
    public ProfilingRepositories(MyContext context) : base(context)
    {

    }
    /*private MyContext _context;
    private DbSet<Profiling> _profiles;

    public ProfilingRepositories(MyContext context)
    {
        _context = context;
        _profiles = _context.Set<Profiling>();
    }

    public int Delete(string nik)
    {
        var data = _profiles.Find(nik);
        if (data == null)
        {
            return 0;
        }
        _profiles.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public Profiling Get(string nik)
    {
        return _profiles.Find(nik);
    }

    public IEnumerable<Profiling> GetAll()
    {
        var profiles = _profiles.ToList();
        return profiles;
    }

    public int Insert(Profiling entity)
    {
        _profiles.Add(entity);
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(Profiling entity)
    {
        _profiles.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges(); //SaveChanges = SqlCommit
        return result;
    }*/
}
