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
    public class PersonRepository : IPersonRepository
    {
        private readonly MyContext conn;
        public PersonRepository(MyContext conn)
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
        }

    }
}
