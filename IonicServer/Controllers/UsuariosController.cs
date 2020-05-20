using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Skoll.Data;

namespace IonicServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUnitOfWork uow;

        public UsuariosController(IUnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IActionResult GetUsuario()
        {
            return  new ObjectResult(uow.UsuarioRepositorio.GetAll());
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = uow.UsuarioRepositorio.Get(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return new ObjectResult(usuario);
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuario)
        {
            var senhaUsuario = uow.UsuarioRepositorio.Get(id)?.Senha;

            if (id != usuario.Id || senhaUsuario == null)
            {
                return BadRequest();
            }

            if (usuario.Senha == "")
                usuario.Senha = senhaUsuario;

            try
            {
                uow.UsuarioRepositorio.Atualizar(usuario);
                uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (uow.UsuarioRepositorio.Existe(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostUsuario(Usuario usuario)
        {
            uow.UsuarioRepositorio.Adicionar(usuario);
            uow.Commit();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = uow.UsuarioRepositorio.Get(id);
            if (usuario == null)
            {
                return NotFound();
            }

            uow.UsuarioRepositorio.Deletar(usuario);
            uow.Commit();

            return new ObjectResult(usuario);
        }

    }
}
