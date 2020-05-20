using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Skoll.Data;
using IonicServer.Entities;

namespace IonicServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorsController : ControllerBase
    {
        private IUnitOfWork uow;

        public SetorsController(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        // GET: api/Setors
        [HttpGet]
        public IActionResult GetSetor()
        {
            return new ObjectResult(uow.SetorRepositorio.GetAll());
        }

        // GET: api/Setors/5
        [HttpGet("{id}")]
        public IActionResult GetSetor(int id)
        {
            var item = uow.SetorRepositorio.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // PUT: api/Setors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutSetor(int id, Setor item)
        {

            if (id != item.Id)
            {
                return BadRequest();
            }

            try
            {
                uow.SetorRepositorio.Atualizar(item);
                uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (uow.SetorRepositorio.Existe(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Setors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostSetor(Setor item)
        {
            uow.SetorRepositorio.Adicionar(item);
            uow.Commit();

            return CreatedAtAction("GetSetor", new { id = item.Id }, item);
        }

        // DELETE: api/Setors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSetor(int id)
        {
            var item = uow.SetorRepositorio.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            uow.SetorRepositorio.Deletar(item);
            uow.Commit();

            return new ObjectResult(item);
        }

    }
}
