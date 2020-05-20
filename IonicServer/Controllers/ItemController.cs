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
    public class ItemsController : ControllerBase
    {
        private IUnitOfWork uow;

        public ItemsController(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        // GET: api/Items
        [HttpGet]
        public IActionResult GetItem()
        {
            return new ObjectResult(uow.ItemRepositorio.GetAll());
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = uow.ItemRepositorio.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // PUT: api/Items/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutItem(int id, Item item)
        {

            if (id != item.Id)
            {
                return BadRequest();
            }

            try
            {
                uow.ItemRepositorio.Atualizar(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (uow.ItemRepositorio.Existe(id))
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

        // POST: api/Items
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostItem(Item item)
        {
            uow.ItemRepositorio.Adicionar(item);


            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = uow.ItemRepositorio.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            uow.ItemRepositorio.Deletar(item);
            uow.Commit();

            return new ObjectResult(item);
        }

    }
}
