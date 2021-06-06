using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, int>
    {
        private readonly MyContext _context;
        private readonly DbSet<RegisterVM> _register;
        public IConfiguration _configuration;
        public PersonRepository(MyContext myContext, IConfiguration _configuration) : base(myContext)
        {
            this._context = myContext;
            _register = _context.Set<RegisterVM>();
            this._configuration = _configuration;
        }
        public int Register(RegisterVM registerVM)
        {
            var result = 0;
            var cek = _context.Persons.FirstOrDefault(p => p.Email == registerVM.Email);
            if (cek == null)
            {
                Person person = new Person()
                {
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Phone = registerVM.Phone,
                    BirthDate = registerVM.BirthDate,
                    Salary = registerVM.Salary,
                    Email = registerVM.Email

                };
                _context.Add(person);
                result = _context.SaveChanges();

                Account account = new Account()
                {
                    Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password),
                    NIK = person.NIK
                };
                _context.Add(account);
                result = _context.SaveChanges();
                Education education = new Education()
                {
                    Degree = registerVM.Degree,
                    GPA = registerVM.GPA,
                    Universityid = registerVM.Universityid
                };
                _context.Add(education);
                result = _context.SaveChanges();
                Profiling profiling = new Profiling()
                {
                    NIK = person.NIK,
                    Educationid = education.id
                };
                _context.Add(profiling);
                result = _context.SaveChanges();
                AccountRole accountRole = new AccountRole()
                {
                    NIK = account.NIK,
                    Roleid = registerVM.Roleid
                };
                _context.Add(accountRole);
                result = _context.SaveChanges();
                return result;
                //Role role = new Role()
                //{
                //    Id = registerVM.Roleid
                //};
                //_context.Add(role);
                //result = _context.SaveChanges();
                
            }
            return result;
        }
        public IEnumerable<RegisterVM> GetAllprofile()
        {
            Person person = new Person();
            //University university = new University();
            var all = (
                from p in _context.Persons
                join a in _context.Accounts on p.NIK equals a.NIK
                join pr in _context.Profilings on a.NIK equals pr.NIK
                join e in _context.Educations on pr.Educationid equals e.id
                join u in _context.Universities on e.Universityid equals u.id
                select new RegisterVM
                {
                    NIK = p.NIK,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Phone = p.Phone,
                    BirthDate = p.BirthDate,
                    Salary = p.Salary,
                    Email = p.Email,
                    Degree = e.Degree,
                    GPA = e.GPA,
                    Universityid = u.id
                }).ToList();
            return all;
        }
        public RegisterVM GetProfilebyId(int nik)
        {
            //Person person = new Person();
            //University university = new University();
            var all = (
                from p in _context.Persons
                join a in _context.Accounts on p.NIK equals a.NIK
                join pr in _context.Profilings on a.NIK equals pr.NIK
                join e in _context.Educations on pr.Educationid equals e.id
                join u in _context.Universities on e.Universityid equals u.id
                select new RegisterVM
                {
                    NIK = p.NIK,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Phone = p.Phone,
                    BirthDate = p.BirthDate,
                    Salary = p.Salary,
                    Email = p.Email,
                    Password = a.Password,
                    Degree = e.Degree,
                    GPA = e.GPA,
                    Universityid = u.id
                }).ToList();
            return all.FirstOrDefault(p => p.NIK == nik);
        }

        public int Login(LoginVM loginVM)
        {
            var result = 0;
            var search = _context.Persons.FirstOrDefault(p => p.Email == loginVM.Email);
            if (search != null && BCrypt.Net.BCrypt.Verify(loginVM.Password, search.Account.Password))
            {
                return 1;
            }
            return result;
        }
        public string GenerateToken(LoginVM loginVM)
        {
            {
                var person = _context.Persons.Single(p => p.Email == loginVM.Email);
                var accountRole = _context.accountRoles.Single(ar => ar.NIK == person.NIK);
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Email", loginVM.Email.ToString()),
                    new Claim("Role", accountRole.Role.Rolename.ToString()),
                    //new Claim("NIK", person.NIK.ToString()),
                    //new Claim("Email", person.Email),
                    new Claim(ClaimTypes.Role, accountRole.Role.Rolename)
                   };

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
        //public int ChangePass(int NIK, ChangePassVM model)
        //{
        //    Account account = new Account();
        //    account.Password = model.NewPassword;
        //    _context.Entry(account).State = EntityState.Modified;
        //    _context.SaveChanges();
        //    return Ok("Password Changed");
        //}

        // var search = _context.Persons.Where(p => p.Email == (loginVM.Email)
        //&& p.Account.Password == (loginVM.Password));
        //_context.Persons.FirstOrDefault(p => p.Email == loginVM.Email);
        //var list = _context.Accounts.FirstOrDefault(a => a.Password == loginVM.Password);
        //if (search != null && BCrypt.Net.BCrypt.Verify(loginVM.Password, list.Password) )
        //{
        //    return 1;
        //}
        //return result;

    }
}
