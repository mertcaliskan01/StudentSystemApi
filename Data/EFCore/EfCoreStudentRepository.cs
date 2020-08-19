using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentSystemAPI.Model;

namespace StudentSystemAPI.Data.EFCore
{
    public class EfCoreStudentRepository : EfCoreRepository<Student, StudentSystemAPIContext>
    {
        public EfCoreStudentRepository(StudentSystemAPIContext context) : base(context)
        {

        }
    }
}
