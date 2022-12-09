namespace TesteLocadora.Model.Produtos
{
    public class Locacao
    {
        public int IdLocacao { get; private set; }
        public string NomeCliente { get; private set; }
        public string Filme { get; set; }
        public DateTime DataRetirada { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public bool Ativo { get; private set; }

        public void setId(int id) { IdLocacao = id; }
        public void setAtivo(bool ativo) { Ativo = ativo; }

        public Locacao (int idLocacao, string nomeCliente, string filme, DateTime dataRetirada, DateTime dataEntrega, bool ativo)
        {
            IdLocacao = idLocacao;
            NomeCliente = nomeCliente;
            Filme = filme;
            DataRetirada = dataRetirada;
            DataEntrega = dataEntrega;
            Ativo = ativo;
        }
    }

}
