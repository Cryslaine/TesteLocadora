using Microsoft.AspNetCore.Mvc;
using TesteLocadora.Model.Lista;
using TesteLocadora.Model.Produtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TesteLocadora.EndPoint
{
    [Route("[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet(Name = "GetLocacao")]
        public List<Locacao> Get()
        {
            ListaCadastrolocacao lista = new ListaCadastrolocacao();
            return lista.Locacao.Where(x => x.Ativo).ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost (Name = "PostLocacao")]
        public Locacao Post(Locacao locacao)
        {
            var lista = new ListaCadastrolocacao();

            return null;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
