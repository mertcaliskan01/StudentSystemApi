using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentSystemAPI.Model;

namespace StudentSystemAPI.Data
{
    public class StudentSystemAPIContext : DbContext
    {
        public StudentSystemAPIContext (DbContextOptions<StudentSystemAPIContext> options)
            : base(options)
        {
        }

        public DbSet<StudentSystemAPI.Model.Student> Student { get; set; }
    }
}
