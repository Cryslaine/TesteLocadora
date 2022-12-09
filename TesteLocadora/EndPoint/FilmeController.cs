using Microsoft.AspNetCore.Mvc;
using TesteLocadora.Model.Lista;
using TesteLocadora.View.Produtos;
using TesteLocadora.Model;
using Microsoft.Win32;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteLocadora.EndPoint
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        ListaCadastroFilme lista = new ListaCadastroFilme();

        [HttpGet (Name = "GetFilme")]
        public List<Filme> Get()
        {
            return lista.ListaFilme.Where(x => x.Ativo).ToList();
        }
        [HttpPost(Name = "PostFilme")]
        public Mensagem Post(Filme filme)
        {
            List<Filme> listaFilmesAtivos = lista.ListaFilme.Where(x => x.Ativo).ToList();

            if (filme.IdProduto == 0)
            {
                //Verifica se o CPF é igual 
                if (listaFilmesAtivos.FindAll(x => x.Nome == filme.Nome).Count() == 0)
                {
                    // Se o Id for null ele ira inserrir um novo registro
                    Filme ultimoFilme = lista.ListaFilme.OrderBy(x => x.IdProduto).Last();
                    filme.setId(ultimoFilme.IdProduto + 1);
                    lista.ListaFilme.Add(filme);

                    return new Mensagem(true, "Filme inserido com sucesso!");
                }
                else
                {
                    //Se o filme ja existir
                    return new Mensagem(false, "Filme Já cadastrado!");

                }
            }
            // Se o Id não for null ele ira Atualizar 
            else
            {
                if(listaFilmesAtivos.FindAll(x => x.Nome == filme.Nome && x.IdProduto != filme.IdProduto).Count() == 0)
                { 
                    int index = lista.ListaFilme.FindIndex(x => x.IdProduto == filme.IdProduto);
                    lista.ListaFilme[index] = filme;

                    return new Mensagem(true, "Filme atualizado com sucesso!");
                }
                
            }
            return null;

        }

        [HttpDelete("{id}")]
        public Mensagem Delete(int id)
        {
            //Altera o status para false, assim o registro ira permanecer porem não ira aparecer
            Filme filme = lista.ListaFilme.Where(x => x.IdProduto == id).FirstOrDefault();
            if (filme != null)
            {
                lista.ListaFilme.Remove(filme);
                return new Mensagem(true, "Registro excluido com sucesso!");
            }
            else
            {
                return new Mensagem(false, "Registro não encontrado!");
            }
            return null;
        }
    }
}

       

