using Microsoft.AspNetCore.Mvc;
using System.Globalization;
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
        public static ListaCadastroFilme listaFilme = new ListaCadastroFilme();
        public static ListaCadastrolocacao listaCadastrolocacao = new ListaCadastrolocacao();


        private Mensagem AlugarFilme(Locacao locacao)
        {

            Mensagem mensagem = AlterarQuantidade(locacao.Filme, true);
            if (mensagem.Resultado)
            {
                Locacao ultimaLocacao = lista.Locacao.OrderBy(x => x.IdLocacao).Last();
                locacao.setId(ultimaLocacao.IdLocacao + 1);
                lista.Locacao.Add(locacao);
                return new Mensagem(true, "Registro inserido com sucesso!");
            }
            else
                return mensagem;
        }

        private Mensagem DevolverFilme(Locacao locacao)
        {
            Mensagem mensagem = AlterarQuantidade(locacao.Filme, false);
            if (mensagem.Resultado)
            {
                Locacao loc = lista.Locacao.Where(x => x.IdLocacao == locacao.IdLocacao).FirstOrDefault();
                int index = lista.Locacao.FindIndex(x => x.IdLocacao == locacao.IdLocacao);
                lista.Locacao[index] = locacao;
                if (locacao.DataEntrega >= DateTime.Now)
                
                    return new Mensagem(true, "Filme devolvido sem atraso!");                
                else                                   
                    return new Mensagem(false, "Devolução atrasada!");
                
            }else
                return mensagem;
        }

        private Mensagem AlterarQuantidade(string nomeFilme, bool alugar)
        {
            Filme filme = listaFilme.ListaFilme.Where(x => x.Nome == nomeFilme.Trim()).FirstOrDefault();
            if (alugar)
            {
                if (filme.QuantidadeDisponivel == 0)                
                    return new Mensagem(false, "Não existe filme disponivel!");

                filme.setQuantidadeDisponivel(filme.QuantidadeDisponivel - 1);
            }else
            {
                filme.setQuantidadeDisponivel(filme.QuantidadeDisponivel + 1);
            }
            return new Mensagem(true, "");
        }

        [HttpGet(Name = "GetLocacao")]
        public List<Locacao> Get()
        {
            return lista.Locacao.Where(x => x.Ativo).ToList();
        }

        [HttpPost(Name = "PostLocacao")]
        public Mensagem Post(Locacao locacao)
        {
            if (locacao.IdLocacao == 0)
            {
                return AlugarFilme(locacao);
            }
            // Se o Id não for null ele ira Atualizar 
            else
            {
                return DevolverFilme(locacao);
            }
            return null;

        }

        [HttpDelete(Name = "DeleteLocacao")]
        public Mensagem Delete(int id)
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
            return new Mensagem(true, "Registro excluido com sucesso!");
        }
    }
}
