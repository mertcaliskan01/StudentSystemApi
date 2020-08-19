using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSystemAPI.Data;
using StudentSystemAPI.Data.EFCore;
using StudentSystemAPI.Model;

namespace StudentSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : MyMDBController<Student, EfCoreStudentRepository>
    {
        public StudentsController(EfCoreStudentRepository repository) : base(repository)
        {

        }
    }
}
