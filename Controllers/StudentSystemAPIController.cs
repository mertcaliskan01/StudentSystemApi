﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentSystemAPI.Data;

namespace StudentSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class MyMDBController<TEntity, TRepository> : ControllerBase
            where TEntity : class, IEntity
            where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public MyMDBController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var student = await repository.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            await repository.Update(student);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity student)
        {
            await repository.Add(student);
            return CreatedAtAction("Get", new { id = student.Id }, student);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var student = await repository.Delete(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

    }
}
