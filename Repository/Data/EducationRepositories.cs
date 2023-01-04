using API2.Context;
using API2.Models;
using API2.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API2.Repository.Data;

public class EducationRepositories : GeneralRepository<Education, int>
{
    public EducationRepositories(MyContext context) : base(context)
    {

    }
    /*private MyContext _context;
    private DbSet<Education> _edu;

    public EducationRepositories(MyContext context)
    {
        _context = context;
        _edu = _context.Set<Education>();
    }

    public int Delete(int id)
    {
        var data = _edu.Find(id);
        if (data == null)
        {
            return 0;
        }
        _edu.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public Education Get(int id)
    {
        return _edu.Find(id);
    }

    public IEnumerable<Education> GetAll()
    {
        var educations = _edu.ToList();
        return educations;
    }

    public int Insert(Education entity)
    {
        _edu.Add(entity);
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(Education entity)
    {
        _edu.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges(); //SaveChanges = SqlCommit
        return result;
    }*/
}
