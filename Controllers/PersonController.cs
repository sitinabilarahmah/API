using API.Base;
using API.Context;
using API.Models;
using API.Repository.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly MyContext _context;
        private readonly PersonRepository _personRepository;
        private readonly IConfiguration _configuration;

        public PersonController(PersonRepository person, MyContext myContext, IConfiguration configuration) : base(person) 
        {
            _context = myContext;
            _personRepository = person;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register (RegisterVM registerVM)
        {
            Person person = new Person()
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Phone = registerVM.Phone,
                BirthDate = registerVM.BirthDate,
                Salary = registerVM.Salary,
                Email = registerVM.Email

            };
            _context.Persons.AddAsync(person);
            Account account = new Account()
            {
                Password = registerVM.Password,
                NIK = registerVM.NIK
            };
            //_context.Accounts.AddAsync(account);
            var acc = _personRepository.Insert(account);
            Education education = new Education()
            {
                Degree = registerVM.Degree,
                GPA = registerVM.GPA,
                Universityid = registerVM.Universityid
            };
            _context.Educations.AddAsync(education);
            _context.SaveChanges();
            return Ok("Registered Succesfully");
        }
    }
}
