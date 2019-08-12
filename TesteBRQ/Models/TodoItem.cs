namespace TesteBRQ.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public long ContaOrigem { get; set; }
        public long ContaDestino { get; set; }
        public decimal Valor { get; set; }
        public bool Selecionar { get; set; }
    }
}