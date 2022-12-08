using Microsoft.AspNetCore.Mvc;
using TesteLocadora.Model.Lista;
using TesteLocadora.View.Produtos;
using TesteLocadora.Controllers;
using TesteLocadora.Model.Produtos;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteLocadora.EndPoint
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {


        // GET: api/<FilmeController>
        [HttpGet]
        public List<Filme> Get()
        {
            ListaCadastroFilme lista = new ListaCadastroFilme();
            return lista.ListaFilme.Where(x => x.Ativo).ToList();
        }

        // GET api/<FilmeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FilmeController>
        [HttpPost(Name = "PostFilme")]
        public Filme Post(Filme filme)
        {
            ListaCadastroFilme lista = new ListaCadastroFilme();
            List<Filme> ListaFilmesAtivos = lista.ListaFilme.Where(x => x.Ativo).ToList();
            if (filme.IdProduto != null)
            {
                if (ListaFilmesAtivos.FindAll(x => x.Nome == filme.Nome).Count() == 0)
                {
                    //inserir
                }
            }
            else
            {
                //return HttpResponseMessage(Request.<string>(HttpStatusCode.Conflict,



            }
            return filme;
        }

        // PUT api/<FilmeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FilmeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

       

