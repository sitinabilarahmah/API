using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class PersonRepository_Old : IPersonRepository
    {
        private readonly MyContext conn;
        public PersonRepository_Old(MyContext conn)
        {
            this.conn = conn;
        }

        public int Delete(int nik)
        {
            Person person = conn.Persons.Find(nik);
            conn.Remove(person);
            int result = conn.SaveChanges();
            return result;
        }

        public IEnumerable<Person> Get()
        {
            return conn.Persons.ToList();
        }

        public Person Get(int nik)
        {
            return conn.Persons.Find(nik);
        }

        public int Insert(Person person)
        {
            conn.Persons.Add(person);
            var result = conn.SaveChanges();
            return result;
        }

        public int Update(Person person)
        {
            conn.Entry(person).State = EntityState.Modified;
            int result = conn.SaveChanges();
            return result;
            //int update = 0;
            //conn.Persons.Where(x => x.NIK == nik).FirstOrDefault();
            //if (person != null)
            //{

            //    update = 1;
            //}
            //else

            //    update = 0;

            //try
            //{
            //    var data = conn.Persons.Where(x => x.NIK == person.NIK).ToList();
            //    foreach (var item in data)
            //    {
            //        var id = conn.Persons.Where(x => x.NIK == person.NIK).SingleOrDefault().NIK;
            //        Person p = conn.Persons.Find(id);
            //        p.FirstName = item.FirstName;
            //        p.LastName = item.LastName;
            //        p.Phone = item.Phone;
            //        p.BirthDate = item.BirthDate;
            //        p.Salary = item.Salary;
            //        p.Email = item.Email;
            //        conn.Entry(p).State = EntityState.Modified;
            //        var result = conn.SaveChanges();
            //        return result;

            //    }
            //var result = conn.SaveChanges();
            //return result;
            //if(person.FirstName != null) {
            //    data.FirstName = person.FirstName;
            //}
            //if (person.LastName != null)
            //{
            //    data.LastName = person.LastName;
            //}
            //if (person.Phone != null)
            //{
            //    data.Phone = person.Phone;
            //}
            //if (person.BirthDate != null)
            //{
            //    data.BirthDate = person.BirthDate;
            //}
            //if (person.Salary != null)
            //{
            //    data.Salary = person.Salary;
            //}
            //if (person.Email != null)
            //{
            //    data.Email = person.Email;
            //}


        }
            //catch (Exception e)
            //{
            //    return 0;
            //}

        //}
    }
}
