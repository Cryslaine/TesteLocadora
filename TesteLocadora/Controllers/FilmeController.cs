 using Microsoft.AspNetCore.Mvc;
using TesteLocadora.Model;
using TesteLocadora.Model.Lista;
using TesteLocadora.View.Produtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteLocadora.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private static ListaCadastroFilme lista = new ListaCadastroFilme();

        [HttpGet(Name = "GetFilme")]
        public List<Filme> Get()
        {
            //ListaCadastroFilme lista = new ListaCadastroFilme();
            return lista.ListaFilme.Where(x => x.Ativo).ToList();
        }

        [HttpPost(Name = "PostFilme")]
        public Mensagem Post(Filme filme)
        {
            List<Filme> listafilmeAtivos = lista.ListaFilme.Where(x => x.Ativo).ToList();
            if (filme.IdProduto == 0)
            {
                //Verifica se o Nome é igual se sim ele retornal else 
                if (listafilmeAtivos.FindAll(x => x.Nome == filme.Nome).Count() == 0)
                {
                    // Se o Id for null ele ira inserrir um novo registro
                    Filme ultimoFilme = lista.ListaFilme.OrderBy(x => x.IdProduto).Last();
                    filme.setId(ultimoFilme.IdProduto + 1);
                    lista.ListaFilme.Add(filme);

                    return new Mensagem(true, "Registro inserido com sucesso!");

                }
                else
                {
                    return new Mensagem(false, "Filme Já cadastrado!");
                }
            }
            // Se o Id não for null ele ira Atualizar 
            else
            {
                if (listafilmeAtivos.FindAll(x => x.Nome == filme.Nome && x.IdProduto != filme.IdProduto).Count() == 0)
                {
                    int index = lista.ListaFilme.FindIndex(x => x.IdProduto == filme.IdProduto);
                    lista.ListaFilme[index] = filme;

                    return new Mensagem(true, "Registro Atualizado com sucesso!");
                }
                else
                {
                    return new Mensagem(false, "Filme Já cadastrado!");
                }
            }

            return null;

        }

        [HttpDelete(Name = "DeleteFilme")]
        public void Delete(int id)
        {
            //O registro não sera deletado da base de dados, apenas sera atualizado o status para false
            List<Filme> listaFilmesAtivos = lista.ListaFilme.Where(x => x.Ativo).ToList();
            Filme filme = lista.ListaFilme.Where(x => x.IdProduto == id).FirstOrDefault();
            if (filme != null)
            {
                if (listaFilmesAtivos.FindAll(x => x.Nome == filme.Nome && x.IdProduto != filme.IdProduto).Count() == 0)
                {
                    int index = lista.ListaFilme.FindIndex(x => x.IdProduto == filme.IdProduto);
                    filme.setAtivo(false);
                    lista.ListaFilme[index] = filme;
                }
            }
        }
    }
}



