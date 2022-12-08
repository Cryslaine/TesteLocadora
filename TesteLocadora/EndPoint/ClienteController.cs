using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using TesteLocadora.Model.Lista;
using TesteLocadora.Model.Produtos;

namespace TesteLocadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public ClienteController(ILogger<ClienteController> logger)
        {
            //_logger = logger;
        }

        [HttpGet(Name = "GetCliente")]
        public List<Cliente> Get()
        {
            ListaDadosCliente lista = new ListaDadosCliente();
            return lista.ListaCliente.Where(x => x.Ativo).ToList();
        }

        [HttpPost(Name = "PostCliente")]
        public Cliente Post(Cliente cliente)
        {
            ListaDadosCliente lista = new ListaDadosCliente();
            List<Cliente> listaClientesAtivos = lista.ListaCliente.Where(x => x.Ativo).ToList();
            if (cliente.Cpf != cliente.Cpf)
            {
                if (listaClientesAtivos.FindAll(x => x.Cpf == cliente.Cpf).Count() == 0)
                {
                    listaClientesAtivos.Add(cliente);
                }
            }
            else
            {
                if (listaClientesAtivos.FindAll(x => x.Cpf == cliente.Cpf && x.IdCliente != cliente.IdCliente).Count() == 0)
                {
                   
                }
            }
            return cliente;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ListaDadosCliente lista = new ListaDadosCliente();
            Cliente cliente = lista.ListaCliente.Where(x => x.IdCliente == id).FirstOrDefault();
            if(cliente != null)
            {

            }

        }
    }
}