using API2.Context;
using API2.Models;
using API2.Repository.Interface;
using API2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API2.Repository.Data;

public class EmployeeRepositories : GeneralRepository<Employee, string>
{
    public MyContext _context;
    //private readonly DbSet<Employee> _employees;
    //private readonly DbSet<Account> _accounts;
    //private readonly DbSet<Profiling> _profilings;
    //private readonly DbSet<Education> _educations;
    //private readonly DbSet<University> _universities;

    public EmployeeRepositories(MyContext context) : base(context)
    { 
        _context = context;
        //_employees = context.Set<Employee>();
        //_accounts = context.Set<Account>();
        //_profilings = context.Set<Profiling>();
        //_educations = context.Set<Education>();
        //_universities= context.Set<University>();
    }

    public IEnumerable<MasterEmployeeVM> MasterEmployeeData()
    {
        var result = from emp in _context.Employees
                     join acc in _context.Accounts on emp.NIK equals acc.NIK
                     join pro in _context.Profilings on acc.NIK equals pro.NIK
                     join edu in _context.Educations on pro.EducationId equals edu.Id
                     join univ in _context.Universities on edu.UniversityId equals univ.Id
                     select new MasterEmployeeVM
                     {
                         NIK = emp.NIK,
                         FullName = emp.FirstName + " " + emp.LastName,
                         Phone = emp.Phone,
                         Gender = emp.Gender.ToString(),
                         Email = emp.Email,
                         BirthDate = emp.BirthDate,
                         Salary = emp.Salary,
                         EducationId = edu.Id,
                         GPA = edu.GPA,
                         Degree = edu.Degree,
                         UniversityName = univ.Name
                     };

        return result;
    }


    /*public int Delete(string nik)
    {
        var data = _employees.Find(nik);
        if (data == null)
        {
            return 0;
        }
        _employees.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public Employee Get(string nik)
    {
        return _employees.Find(nik);
    }

    public IEnumerable<Employee> GetAll()
    {
        var employees = _employees.ToList();
        return employees;
    }

    public int Insert(Employee entity)
    {
        _employees.Add(entity);
        //setiap ada penambahan Add, harus selalu di Save Changes() dengan nama variable yg sm buat direturn
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(Employee entity)
    {
        _employees.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges(); //SaveChanges = SqlCommit
        return result;
    }*/
}
