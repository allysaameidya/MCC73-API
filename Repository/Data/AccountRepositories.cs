using API2.Context;
using API2.Models;
using API2.Repository.Interface;
using API2.ViewModels;
using Microsoft.EntityFrameworkCore;
using API2.Handlers;
using Microsoft.Win32;

namespace API2.Repository.Data;

public class AccountRepositories : GeneralRepository<Account, string>
{
    private readonly MyContext _context; //dependency injection
    private readonly DbSet<Account> _account;
    //private readonly DbSet<Employee> _employees;
    //private readonly DbSet<Profiling> _profilings;
    //private readonly DbSet<Education> _educations;
    //private readonly DbSet<University> _universities;

    public AccountRepositories(MyContext context) : base(context)
    {
        _context = context;
        _account = context.Set<Account>();
        //_employees = context.Set<Employee>();
        //_profilings = context.Set<Profiling>();
        //_educations = context.Set<Education>();
        //_universities = context.Set<University>(); //dependency injection
    }

    public int Register(RegisterVM reg)
    {
        var cekEmail = _context.Employees.Where(e => e.Email == reg.Email);
        var cekPhone = _context.Employees.Where(e => e.Phone == reg.Phone);
        if (cekEmail.Count() == 1)
        {
            return 0;
        }
        else if (cekPhone.Count() == 1)
        {
            return 1;
        }

        var emp = new Employee()
        {
            NIK = reg.NIK,
            FirstName = reg.FirstName,
            LastName = reg.LastName,
            Gender = (Jk)reg.Gender,
            BirthDate = reg.BirthDate,
            Email = reg.Email,
            Phone = reg.Phone,
            Salary = reg.Salary,
            Account = new Account()
            {
                NIK = reg.NIK,
                Password = Hashing.HashPassword(reg.Password),
                OTP = 67324,
                IsUsed = true,
                ExpiredToken = DateTime.Now
            }
        };
        _context.Employees.Add(emp);
        _context.SaveChanges();

        var university = new University()
        {
            Name = reg.UniversityName
        };
        _context.Universities.Add(university);
        _context.SaveChanges();

        var education = new Education()
        {
            Degree = reg.Degree,
            GPA = reg.GPA,
            UniversityId = university.Id
        };
        _context.Educations.Add(education);
        _context.SaveChanges();

        var profiling = new Profiling()
        {
            NIK = reg.NIK,
            EducationId = education.Id,
        };
        _context.Profilings.Add(profiling);
        _context.SaveChanges();

        AccountRole accountRole = new AccountRole()
        {
            AccountNIK = reg.NIK,
            RoleId = 1
        };
        _context.AccountRoles.Add(accountRole);
        _context.SaveChanges();

        return 2;
    }

    public int Login(LoginVM login)
    {
        var result = _account.Join(_context.Employees, a => a.NIK, e => e.NIK, (a,e) => new LoginVM
        {
            Email = e.Email,
            Password = a.Password
        }).SingleOrDefault(c => c.Email == login.Email);

        if(result == null)
        {
            return 0; //Email Tidak Terdaftar
        }
        if(!Hashing.ValidatePassword(login.Password, result.Password))
        {
            return 1; //Password Salah
        }
        return 2; //Email dan Password Benar
    }

    /*public int Delete(string nik)
    {
        var data = _account.Find(nik);
        if (data == null)
        {
            return 0;
        }
        _account.Remove(data);
        var result = _context.SaveChanges();
        return result;
    }

    public Account Get(string nik)
    {
        return _account.Find(nik);
    }

    public IEnumerable<Account> GetAll()
    {
        var accounts = _account.ToList();
        return accounts;
    }

    public int Insert(Account entity)
    {
        _account.Add(entity);
        //setiap ada penambahan Add, harus selalu di Save Changes() dengan nama variable yg sm buat direturn
        var result = _context.SaveChanges();
        return result;
    }

    public int Update(Account entity)
    {
        _account.Entry(entity).State = EntityState.Modified;
        var result = _context.SaveChanges(); //SaveChanges = SqlCommit
        return result;
    }*/

    public List<string> UserRoles(string email)
    {
        var result = (from e in _context.Employees
                      join a in _context.AccountRoles on e.NIK equals a.AccountNIK
                      join r in _context.Roles on a.RoleId equals r.Id
                      where e.Email == email
                      select r.Name.ToString())
                      .ToList();

        return result;

        //{"Employee", "Manager"}
        //{"Employee"}
    }
}
