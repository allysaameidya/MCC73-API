using API2.Base;
using API2.Models;
using API2.Repository.Data;
using API2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountController : BaseController<Account, string>
{
    private AccountRepositories _repositories;
    private IConfiguration _con;
    public AccountController(AccountRepositories repositories, IConfiguration con) : base(repositories)
    {
        _repositories = repositories;
        _con = con;
    }

    [HttpPost]
    [Route("Register")]
    [AllowAnonymous]
    public ActionResult Register(RegisterVM reg)
    {
        try
        {
            var result = _repositories.Register(reg);

            if (result == 0)
            {
                return Ok(new { statusCode = 200, message = "Email Has Registered!" });
            }
            else if (result == 1)
            {
                return Ok(new { statusCode = 200, message = "Phone Number Has Registered!" });
            }
            else
            {
                return Ok(new { statusCode = 200, message = "Data Saved Succesfully!" });
            }
        }
        catch
        {
            return BadRequest(new { statusCode = 500, message = "Check Property!" });
        }
    }

    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]
    public ActionResult Login(LoginVM login)
    {
        try
        {
            var result = _repositories.Login(login);
            switch(result)
            {
                case 0:
                    return Ok(new { statusCode = 200, message = "Account Not Found!" });
                case 1:
                    return Ok(new { statusCode = 200, message = "Wrong Password!" });
                default:
                    //bikin method untuk mendapatkan role-nya si user yang login
                    var roles = _repositories.UserRoles(login.Email);

                    var claims = new List<Claim>()
                    {
                        new Claim("email", login.Email)
                        //new Claim(ClaimTypes.Email, LoginVM.Email)
                    };

                    foreach (var item in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_con["JWT:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _con["JWT:Issuer"],
                        _con["JWT:Audience"],
                        claims,
                        expires : DateTime.Now.AddMinutes(5), //session
                        signingCredentials: signIn
                        );

                    var generateToken = new JwtSecurityTokenHandler().WriteToken(token);
                    claims.Add(new Claim("Token Security", generateToken.ToString()));

                    return Ok(new { statusCode = 200, message = "Login Success!", data = generateToken });
                
            }
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
        }

    }

    /*[HttpGet]
    public ActionResult GetAll()
    {
        try
        {
            var result = _repositories.GetAll();
            return result.Count() == 0
                ? Ok(new { statusCode = 200, message = "Data Not Found!" })
                : Ok(new { statusCode = 200, message = "Success!", data = result });
        }
        catch (Exception ex)
        {

            return BadRequest(new { statusCode = 500, message = $"Something Wrong : {ex.Message}" });
        }

    }

    [HttpGet]
    [Route("ByNIK")]
    public ActionResult GetByNik(string nik)
    {
        try
        {
            var result = _repositories.Get(nik);
            return result == null
                ? Ok(new { statusCode = 200, message = "Data Not Found!" })
                : Ok(new { statusCode = 200, message = "NIK is Found!", data = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { statusCode = 500, message = $"Error: {ex.Message}" });
        }

    }

    [HttpPost]
    public ActionResult Insert(Account account)
    {
        try
        {
            var result = _repositories.Insert(account);
            return result == 0
                ? Ok(new { statusCode = 200, message = "Failed to Add Data!" })
                : Ok(new { statusCode = 200, message = "Data Saved Succesfully!" });

        }
        catch
        {
            return BadRequest(new { statusCode = 500, message = "Check Property!" });
        }

    }

    [HttpPut]
    public ActionResult Update(Account account)
    {
        try
        {
            //if (_repositories.Get(account.NIK) == null)
            //{
            //    return Ok(new { statusCode = 200, message = "Data Didn't Changed or NIK Not Found!" });
            //}

            _repositories.Update(account);
            return Ok(new { statusCode = 200, message = "Data Has Been Changed!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { statusCode = 500, message = $"Error: {ex.Message}" });
        }

    }

    [HttpDelete]
    public ActionResult Delete(string nik)
    {
        try
        {
            var result = _repositories.Delete(nik);
            return result == null
                ? Ok(new { statusCode = 200, message = $"NIK With {nik} Not Found!" })
                : Ok(new { statusCode = 200, message = "Data Has Been Deleted!" });

        }
        catch (Exception ex)
        {
            return BadRequest(new { statusCode = 500, message = $"Error: {ex.Message}" });
        }

    }*/
}
