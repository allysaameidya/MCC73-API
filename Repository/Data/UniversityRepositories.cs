using API2.Context;
using API2.Models;
using API2.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API2.Repository.Data;

public class UniversityRepositories : GeneralRepository<University, int>
{
    public UniversityRepositories(MyContext context) : base(context)
    {

    }

    /*private MyContext _context;
    private DbSet<University> _univ;

    public UniversityRepositories(MyContext context)
    {
        _context = context;
        _univ = _context.Set<University>();
    }

    public int Delete(int id)
    {
        var data = _univ.Find(id);
        if (data == null)
        {
            return 0;
        }
        _univ.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public University Get(int id)
    {
        return _univ.Find(id);
    }

    public IEnumerable<University> GetAll()
    {
        var universities = _univ.ToList();
        return universities;
    }

    public int Insert(University entity)
    {
        _univ.Add(entity);
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(University entity)
    {
        _univ.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges(); //SaveChanges = SqlCommit
        return result;
    } */
}
