using Microsoft.AspNetCore.Mvc;
using TesteLocadora.Model;
using TesteLocadora.Model.Lista;
using TesteLocadora.Model.Produtos;
using TesteLocadora.View.Produtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteLocadora.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        public static ListaCadastrolocacao lista = new ListaCadastrolocacao();

        [HttpGet(Name = "GetLocacao")]
        public List<Locacao> Get()
        {
            return lista.Locacao.Where(x => x.Ativo).ToList();
        }

        // POST api/<ValuesController>
        [HttpPost(Name = "PostLocacao")]
        public Locacao Post(Locacao locacao)
        {
            var lista = new ListaCadastrolocacao();

            return null;
        }

        [HttpPut(Name ="PutLocacao")]
        public Mensagem Put(Locacao locacao,Filme listFilme)
        {
            ListaCadastroFilme listaFilme = new ListaCadastroFilme();
            listaFilme.ListaFilme.Where(x => x.Ativo).ToList();

            ListaCadastrolocacao listaCadastrolocacao = new ListaCadastrolocacao();
            List<Locacao> listaLocacaoAtivos = lista.Locacao.Where(x => x.Ativo).ToList();
            if (locacao.IdLocacao == 0)
            {
                if (listaLocacaoAtivos.FindAll(x => x.Filme == locacao.Filme && x.Filme != listFilme.Nome).Count() == 0)
                {
                    Locacao ultimaLocacao = lista.Locacao.OrderBy(x => x.IdLocacao).Last();
                    locacao.setId(ultimaLocacao.IdLocacao + 1);
                    listaLocacaoAtivos.Add(locacao);
                    return new Mensagem(true, "Registro inserido com sucesso!");
                }
                else
                {
                    return new Mensagem(true, "Filme não encontrado!");
                }
            }
            return null;

        }

        [HttpDelete(Name = "DeleteLocacao")]
        public void Delete(int id)
        {
            //O registro não sera deletado da base de dados, apenas sera atualizado o status para false
            List<Locacao> listaLocacaoAtivos = lista.Locacao.Where(x => x.Ativo).ToList();
            Locacao loc = lista.Locacao.Where(x => x.IdLocacao == id).FirstOrDefault();
            if (loc != null)
            {
                if (listaLocacaoAtivos.FindAll(x => x.IdLocacao == loc.IdLocacao && x.IdLocacao != loc.IdLocacao).Count() == 0)
                {
                    int index = lista.Locacao.FindIndex(x => x.IdLocacao == loc.IdLocacao);
                    loc.setAtivo(false);
                    lista.Locacao[index] = loc;
                }
            }
        }
    }
}
