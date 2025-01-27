namespace AplicacaoWebCantina.Models.Pedido
{
    public class Pedido
    {
        public int Id { get; set; }
        public string? NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco {  get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now; // Data padrão agora
        public decimal Total => Quantidade * Preco; // Valor total do pedido
    }
}
