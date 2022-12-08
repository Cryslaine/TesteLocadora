using TesteLocadora.Model.Produtos;
using TesteLocadora.View.Produtos;

namespace TesteLocadora.Model.Lista
{
    public class ListaCadastroFilme
    {
        public List<Filme> ListaFilme { get; set; }
        public ListaCadastroFilme()
        {
            if (ListaFilme == null)
                ListaFilme = new List<Filme>();
            Filme cadastrofilme = new Filme();
            cadastrofilme.IdProduto = 1;
            cadastrofilme.Nome = "Pantera Negra";
            cadastrofilme.ClassificacaoIdade = "Maior de 14";
            cadastrofilme.Ativo = true;


            ListaFilme.Add(cadastrofilme);
            cadastrofilme=new Filme();
            cadastrofilme.IdProduto = 1;
            cadastrofilme.Nome = "Cinderela";
            cadastrofilme.ClassificacaoIdade = "Todas as Idades";
            cadastrofilme.Ativo = true;

            ListaFilme.Add(cadastrofilme);
        }
    }
}
