using TesteLocadora.Model.Produtos;

namespace TesteLocadora.View.Produtos
{
    public class Filme
    {
        public  int IdProduto { get; private set;}
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        public void setId(int id) { IdProduto = id; }
        public void setAtivo(bool ativo) { Ativo = ativo; }

        public Filme(int idProduto, string nome, bool ativo)
        {
            IdProduto = idProduto;
            Nome = nome;
            Ativo = ativo;
        }
    }
}
