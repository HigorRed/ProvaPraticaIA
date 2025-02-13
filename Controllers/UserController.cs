using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiCsharp.Data;
using ApiCsharp.Models;
using System.Globalization;

namespace ApiCsharp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("test")]
        public IActionResult TestApi()
        {
            return Ok("A API está funcionando corretamente!");
        }


        [HttpPost("import-csv")]
        public async Task<IActionResult> ImportCsv([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Arquivo CSV inválido!");

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                bool isHeader = true;

                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (isHeader)
                    {
                        isHeader = false;
                        continue;
                    }

                    var values = line.Split(',');

                    if (values.Length == 5 && int.TryParse(values[2], out int idade))
                    {
                        var user = new User
                        {
                            Nome = values[1],
                            Idade = idade,
                            Cidade = values[3],
                            Profissao = values[4]
                        };


                        _context.Users.Add(user);
                    }
                }

                await _context.SaveChangesAsync();
            }

            return Ok(new { message = "Dados importados com sucesso!" });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Users
                                     .Where(u => u.Id == id)
                                     .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { message = "Usuário não encontrado!" });

            return Ok(user);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}
