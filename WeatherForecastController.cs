using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
       
        private static List<Pessoa> pessoas = new List<Pessoa>();

        
        [HttpPost]
        public IActionResult Adicionar([FromBody] Pessoa pessoa)
        {
            pessoas.Add(pessoa);
            return Ok("Pessoa adicionada com sucesso!");
        }

     
        [HttpPut("{cpf}")]
        public IActionResult Atualizar(string cpf, [FromBody] Pessoa pessoaAtualizada)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);
            if (pessoa == null) return NotFound("Pessoa não encontrada.");

            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Peso = pessoaAtualizada.Peso;
            pessoa.Altura = pessoaAtualizada.Altura;

            return Ok("Pessoa atualizada com sucesso!");
        }

      
        [HttpDelete("{cpf}")]
        public IActionResult Remover(string cpf)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);
            if (pessoa == null) return NotFound("Pessoa não encontrada.");

            pessoas.Remove(pessoa);
            return Ok("Pessoa removida com sucesso!");
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            return Ok(pessoas);
        }

     
        [HttpGet("{cpf}")]
        public IActionResult BuscarPorCpf(string cpf)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Cpf == cpf);
            if (pessoa == null) return NotFound("Pessoa não encontrada.");

            return Ok(pessoa);
        }

        
        [HttpGet("imc-bom")]
        public IActionResult BuscarImcBom()
        {
            var resultado = pessoas.Where(p => p.Imc >= 18 && p.Imc <= 24).ToList();
            return Ok(resultado);
        }

        [HttpGet("buscar-nome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            var resultado = pessoas
                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
                .ToList();

            return Ok(resultado);
        }
    }
}
