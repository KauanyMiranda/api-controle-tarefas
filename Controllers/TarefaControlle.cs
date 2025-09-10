using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AtividadeApiTarefa.Models;
using AtividadeApiTarefa.Models.Dtos;

namespace AtividadeApiTarefa.Controllers
{
    [Route("/")]
    [ApiController]
    public class TarefaControlle : ControllerBase
    {
        private static List<Tarefas> _ListaTarefas = new List<Tarefas>
        {
            new Tarefas() { Id = 1, NomeTarefa = "Calculadora IMC", Descricao = "Fazer com React"},
            new Tarefas() { Id = 2, NomeTarefa = "API Tarefa", Descricao = "Fazer uma API"}
        };

        private static int _proximoId = 3;

        [HttpGet("/BurcarTodos")]
        public IActionResult BuscarTodos()
        {
            return Ok(_ListaTarefas);
        }

        [HttpGet("{id}/BuscarId")]
        public IActionResult BuscarPorId(int id)
        {
            var tarefa = _ListaTarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPost("/Criar")]
        public IActionResult Criar([FromBody] TarefasDto novaTarefa)
        {
            var tarefa = new Tarefas() { NomeTarefa = novaTarefa.NomeTarefa ,Descricao = novaTarefa.Descricao};
            tarefa.Id = _proximoId++;
            tarefa.Situacao = "Aberto";
            _ListaTarefas.Add(tarefa);

            return Created("", tarefa);
        }

        [HttpPut("{id}/Atualizar")]
        public IActionResult Atualizar (int id, [FromBody] TarefasDto novaTarefa)
        {
            var tarefa = _ListaTarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa is null)
            {
                return NotFound();
            }

            tarefa.NomeTarefa = novaTarefa.NomeTarefa;
            tarefa.Descricao = novaTarefa.Descricao;

            return Ok(tarefa);
        }


        [HttpDelete("{id}/Remover")]
        public IActionResult Remover(int id)
        {
            var tarefa = _ListaTarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa is null)
            {
                return NotFound();
            }

            _ListaTarefas.Remove(tarefa);
            return NoContent();
        }

        [HttpPut("{id}/Fechamento")]
        public IActionResult FecharChamado(int id)
        {
            var tarefa = _ListaTarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa is null)
            {
                return NotFound();
            }

            tarefa.Situacao = "Fechado";

            return Ok(tarefa);
        }
    }
}
