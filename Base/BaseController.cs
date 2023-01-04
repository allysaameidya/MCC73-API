using API2.Models;
using API2.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController<Entity, T> : ControllerBase
    where Entity: class
{
    private GeneralRepository<Entity,T> _repo;

    public BaseController(GeneralRepository<Entity,T> repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        try
        {
            var result = _repo.GetAll();
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
    public ActionResult GetByNik(T nik)
    {
        try
        {
            var result = _repo.Get(nik);
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
    public ActionResult Insert(Entity entity)
    {
        try
        {
            var result = _repo.Insert(entity);
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
    public ActionResult Update(Entity entity)
    {
        try
        {
            //if (_repositories.Get(account.NIK) == null)
            //{
            //    return Ok(new { statusCode = 200, message = "Data Didn't Changed or NIK Not Found!" });
            //}

            _repo.Update(entity);
            return Ok(new { statusCode = 200, message = "Data Has Been Changed!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { statusCode = 500, message = $"Error: {ex.Message}" });
        }

    }

    [HttpDelete]
    public ActionResult Delete(T nik)
    {
        try
        {
            var result = _repo.Delete(nik);
            return result == null
                ? Ok(new { statusCode = 200, message = $"NIK With {nik} Not Found!" })
                : Ok(new { statusCode = 200, message = "Data Has Been Deleted!" });

        }
        catch (Exception ex)
        {
            return BadRequest(new { statusCode = 500, message = $"Error: {ex.Message}" });
        }
    }

}
