using API.Base;
using API.Context;
using API.Models;
using API.Repository.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PersonController : BaseController<Person, PersonRepository, int>
    {
        //private readonly MyContext _context;
        PersonRepository _personRepository;
        //private readonly IConfiguration _configuration;

        public PersonController(PersonRepository person) : base(person) 
        {
            this._personRepository = person;
            //_context = myContext;
            //_personRepository = person;
            //_configuration = configuration;
        }
        
        [Route("Register")]
        [HttpPost]
        public IActionResult Register (RegisterVM registerVM)
        {
            var register = _personRepository.Register(registerVM);
            if (register > 0)
            {
                return Ok("Registered Succesfull");
            }
            else
            {
                return BadRequest("Registeres Unsuccesfull");
            }  
        }
        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            var login = _personRepository.Login(loginVM);
            if (login > 0)
            {
                return Ok($"Login Succesfull \n Token:{_personRepository.GenerateToken(loginVM)}");
            }
            else
            {
                return BadRequest("Invalid Email or Password");
            }
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        [Route("GetAllProfile")]
        [EnableCors("AllowOrigin")]
        public ActionResult GetAllprofile ()
        {
            var get = _personRepository.GetAllprofile();
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data Not Found");
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("GetProfilebyId/{nik}")]
        public ActionResult GetProfilebyId(int nik)
        {
            var get = _personRepository.GetProfilebyId(nik);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data Not Found");
            }

        }

        
            //[HttpPost]
            //public ActionResult<Entity> Post(Entity entity)
            //{
            //    var post = repo.Insert(entity);
            //    if (post > 0)
            //    {
            //        return Ok("Data Ditambahkan");
            //    }
            //    else
            //    {
            //        return BadRequest("Data Gagal Ditambahkan");
            //    }
            //}
            //{
            //    Person person = new Person()
            //    {
            //        FirstName = registerVM.FirstName,
            //        LastName = registerVM.LastName,
            //        Phone = registerVM.Phone,
            //        BirthDate = registerVM.BirthDate,
            //        Salary = registerVM.Salary,
            //        Email = registerVM.Email

            //    };
            //    var persons = _personRepository.Insert(person);
            //    Account account = new Account()
            //    {
            //        Password = registerVM.Password,
            //        NIK = person.NIK
            //    };
            //    _context.Accounts.AddAsync(account);
            //    Education education = new Education()
            //    {
            //        Degree = registerVM.Degree,
            //        GPA = registerVM.GPA,
            //        Universityid = registerVM.Universityid
            //    };
            //    _context.Educations.AddAsync(education);
            //    Profiling profiling = new Profiling()
            //    {
            //        NIK = person.NIK,
            //        Educationid = education.id
            //    };
            //    _context.Profilings.AddAsync(profiling);
            //    _context.SaveChanges();
            //    return Ok("Registered Succesfully");
            //}
            //[Route("Login")]
            //public IActionResult Login (LoginVM loginVM)
            //{
            //    var search = _context.Persons.Where(p => p.Email.Equals(loginVM.Email)
            //    && p.Account.Password.Equals(loginVM.Password));
            //    return Ok("Login Succesfull");
            //}
            //[HttpPut]
            //[Route("{NIK}")]
            //public IActionResult ChangePass (int NIK, ChangePassVM model)
            //{
            //    Account account = new Account()
            //    {
            //        Password = model.NewPassword
            //        _context.Entry(ChangePass).State = EntityState.Modified;
            //        _context.SaveChanges();
            //        return Ok("Password Changed");
            //}

            //}

        }
}
