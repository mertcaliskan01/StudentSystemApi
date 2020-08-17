using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentSystemAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace StudentSystemAPI.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)  : base(options)
        {

        }
        public DbSet<Student> students { get; set; }
    }
}
