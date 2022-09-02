using login_autenticacao.Data;
using login_autenticacao.Models;
using login_autenticacao.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace login_autenticacao.Controllers
{
    [Authorize]
    [Route("v1/usuarios")]
    public class UsuarioController : ControllerBase
    {

        private readonly DataContext _context;
        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            var usuarios = await _context
                .Usuarios
                .AsNoTracking()
                .ToListAsync();

            return Ok(usuarios);
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario model)
        {
            //verifica se os dados sao validos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Usuarios.Add(model);
                await _context.SaveChangesAsync();

                //esconde a senha quando retorna o model pra tela
                model.Password = "";
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Usuario>> Put(int id, [FromBody] Usuario model)
        {
            //verifica se os dados são validos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //verifica se o ID informado é o mesmo do modelo
            if (id != model.Id)
                return NotFound(new { message = "Usuário não encontrado" });

            try
            {
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar o usuario" });
            }
        }

        [AllowAnonymous]
        [HttpPost, Route("login")]
        //dynamic: as vezes retorna usuario e as vezes nao retorna nada
        public async Task<ActionResult<dynamic>> Login([FromBody] Usuario model)
        {

            var usuario = await _context.Usuarios
                .AsNoTracking()
                .Where(x => x.Username == model.Username && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(usuario);

            //esconde senha
            usuario.Password = "";
            return new
            {
                usuario = usuario,
                token = token
            };
        }

    }
}
