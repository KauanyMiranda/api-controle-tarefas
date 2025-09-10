namespace AtividadeApiTarefa.Models
{
    public class Tarefas
    {
        public int Id { get; set; }
        public string NomeTarefa { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public DateTime? DataFechamento { get; set; }
        public string Situacao { get; set; } = "Aberto";
    }
}
