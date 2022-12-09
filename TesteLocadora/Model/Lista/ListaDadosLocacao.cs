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
            {
                Locacao = new List<Locacao>();
                Locacao locacaos1 = new Locacao(1, "Cryslaine", "Pantera Negra", Convert.ToDateTime("2022/11/21"),
                    Convert.ToDateTime("2022/11/25"), true);

                Locacao locacaos2 = new Locacao(1, "Diego", " Cinderela", Convert.ToDateTime("2022/11/21"),
                   Convert.ToDateTime("2022/11/25"), true);


                Locacao.Add(locacaos1);
                Locacao.Add(locacaos2);
            }

        }
    }
}
