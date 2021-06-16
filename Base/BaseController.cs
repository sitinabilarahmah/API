using API.Repository.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
    where Entity : class
    where Repository : IRepository<Entity, Key>
    {
        Repository repo;
        public BaseController(Repository repo)
        {
            this.repo =  repo;
        }
        [HttpPost]
        public ActionResult<Entity>Post(Entity entity)
        {
            var post = repo.Insert(entity);
            if (post > 0)
            {
                return Ok("Data Ditambahkan");
            }
            else
            {
                return BadRequest("Data Gagal Ditambahkan");
            }
        }
        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var get = repo.Get();
            if (get != null)
            {
                return Ok(get);
            }
            else
                return NotFound("No Record");
        }
        [EnableCors("AllowOrigin")]
        [HttpGet("{key}")]
        public ActionResult<Entity>Get(Key key)
        {
            var get = repo.Get(key);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data Tidak Ditemukan");
            }
        }
        [EnableCors("AllowOrigin")]
        [HttpPut]
        public ActionResult<Entity> Update(Entity entity)
        {
            var get = repo.Update(entity);
            if (get > 0)
            {
                return Ok("Data Diupdate");
            }
            else
            {
                return BadRequest("Data Gagal Diupdate");
            }
        }
        [HttpDelete("{key}")]
        public ActionResult Delete(Key key)
        {
            var get = repo.Delete(key);
            if (get > 0) 
            {
                return Ok("Data Berhasil Dihapus");
            }
            else
            {
                return BadRequest("Data Gagal Dihapus");
            }
        }
    }
}
