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
        private static List<Tarefas> _ListaTarefas = new List<Tarefas>();

        private static int _proximoId = 1;

        [HttpGet("{id}")]
        public IActionResult BuscarTodos(int id)
        {
            var tarefa = _ListaTarefas.FirstOrDefault(t => t.Id == id);
            if (tarefa is null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Criar([FromBody] TarefasDto novaTarefa)
        {
            var tarefa = new Tarefas() { NomeTarefa = novaTarefa.NomeTarefa ,Descricao = novaTarefa.Descricao};
            tarefa.Id = _proximoId++;
            tarefa.Status = "Aberto";
            _ListaTarefas.Add(tarefa);

            return Created("", tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar (int id, [FromBody] TarefasDto novaTarefa)
        {
            var tarefa = _ListaTarefas.Find(t => t.Id == id);
            if (tarefa is null)
            {
                return NotFound();
            }

            tarefa.NomeTarefa = novaTarefa.NomeTarefa;
            tarefa.Descricao = novaTarefa.Descricao;

            return Ok(tarefa);
        }


        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var tarefa = _ListaTarefas.Find(t => t.Id == id);
            if (tarefa is null)
            {
                return NotFound();
            }

            _ListaTarefas.Remove(tarefa);
            return NoContent();
        }
    }
}
