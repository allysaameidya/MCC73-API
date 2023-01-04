using API2.Base;
using API2.Models;
using API2.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class RoleController : BaseController<Role, int>
{
    //private RoleRepositories _repositories;
    public RoleController(RoleRepositories repositories) : base(repositories)
    {
        //_repositories = repositories;
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
    [Route("ByID")]
    public ActionResult GetById(int id)
    {
        try
        {
            var result = _repositories.Get(id);
            return result == null
                ? Ok(new { statusCode = 200, message = "Data Not Found!" })
                : Ok(new { statusCode = 200, message = "ID is Found!", data = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { statusCode = 500, message = $"Error: {ex.Message}" });
        }

    }

    [HttpPost]
    public ActionResult Insert(Role roles)
    {
        try
        {
            var result = _repositories.Insert(roles);
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
    public ActionResult Update(Role roles)
    {
        try
        {
            _repositories.Update(roles);
            return Ok(new { statusCode = 200, message = "Data Has Been Changed!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { statusCode = 500, message = $"Error: {ex.Message}" });
        }

    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        try
        {
            var result = _repositories.Delete(id);
            return result == null
                ? Ok(new { statusCode = 200, message = $"ID With {id} Not Found!" })
                : Ok(new { statusCode = 200, message = "Data Has Been Deleted!" });

        }
        catch (Exception ex)
        {
            return BadRequest(new { statusCode = 500, message = $"Error: {ex.Message}" });
        }

    }*/
}
