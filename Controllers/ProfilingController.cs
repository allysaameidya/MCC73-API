using API2.Base;
using API2.Models;
using API2.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Manager")]
public class ProfilingController : BaseController<Profiling, string>
{
    //private ProfilingRepositories _repositories;
    public ProfilingController(ProfilingRepositories repositories) : base(repositories)
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
    public ActionResult Insert(Profiling profiles)
    {
        try
        {
            var result = _repositories.Insert(profiles);
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
    public ActionResult Update(Profiling profiles)
    {
        try
        {
            //if (_repositories.Get(profiles.NIK) == null)
            //{
            //    return Ok(new { statusCode = 200, message = "Data Didn't Changed or NIK Not Found!" });
            //}

            _repositories.Update(profiles);
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
