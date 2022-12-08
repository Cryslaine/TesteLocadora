using TesteLocadora.Model.Produtos;
using TesteLocadora.View.Produtos;

namespace TesteLocadora.Model.Lista
{
    public class ListaCadastrolocacao
    {
       public List<Locacao> Locacao { get; set; }
        public ListaCadastrolocacao()
        {
            if (Locacao == null)
                Locacao = new List<Locacao>();
            Locacao cadastroLocacao = new Locacao();
            cadastroLocacao.IdLocacao = 1;
            cadastroLocacao.NomeCliente = "Cryslaine";
            cadastroLocacao.Filme = "Pantera Negra";
            cadastroLocacao.DataRetirada = Convert.ToDateTime("2022/11/21");
            cadastroLocacao.DataEntrega = Convert.ToDateTime("2022/11/25");
            cadastroLocacao.Ativo = true;


            Locacao.Add(cadastroLocacao);
            cadastroLocacao = new Locacao();
            cadastroLocacao.IdLocacao = 2;
            cadastroLocacao.NomeCliente = "Diego";
            cadastroLocacao.Filme = "Cinderela";
            cadastroLocacao.DataRetirada = Convert.ToDateTime("2022/11/21");
            cadastroLocacao.DataEntrega = Convert.ToDateTime("2022/11/25");
            cadastroLocacao.Ativo = true;


            Locacao.Add(cadastroLocacao);
        }
    }
}
