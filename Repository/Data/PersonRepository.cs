using API.Context;
using API.Models;
using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, int>
    {
        public PersonRepository(MyContext myContext) : base(myContext) { }
    }
    
}
