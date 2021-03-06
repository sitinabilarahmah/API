using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController_Old : ControllerBase
    {
        private readonly PersonRepository_Old personRepository;
        public PersonsController_Old(PersonRepository_Old personRepository)
        {
            this.personRepository = personRepository;
        }
        [HttpPost]
        public ActionResult Post(Person person)
        {
            var post = personRepository.Insert(person);
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
        public ActionResult Get()
        {
            var get = personRepository.Get();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data Tidak Ditemukan");
            }
            
        }
        [HttpGet("{nik}")]
        public ActionResult Get(int nik)
        {
            var get = personRepository.Get(nik);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return NotFound("Data Tidak Ditemukan");
            }
        }
        [HttpPut]
        public ActionResult Update(Person person)
        {
            var get = personRepository.Update(person);
            if (get > 0)
            {
                return Ok("Data Diupdate");
            }
            else
            {
                return BadRequest("Data Gagal Diupdate");
            }
        }
        [HttpDelete("{nik}")]
        public ActionResult Delete(int nik)
        {
            var get = personRepository.Delete(nik);
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
