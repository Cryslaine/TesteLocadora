namespace TesteLocadora.Model.Produtos
{
    public class Locacao
    {
        public int IdLocacao { get; set; }
        public string NomeCliente { get; set; }
        public string Filme { get; set; }
        public DateTime DataRetirada { get; set; }
        public DateTime DataEntrega { get; set; }
        public string StatusLocacao { get; set; }
        public bool Ativo { get; set; }
    }

}
