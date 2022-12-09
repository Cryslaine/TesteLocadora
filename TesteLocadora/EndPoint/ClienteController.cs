using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using TesteLocadora.Model;
using TesteLocadora.Model.Lista;
using TesteLocadora.Model.Produtos;

namespace TesteLocadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private static ListaDadosCliente lista = new ListaDadosCliente();
        

        [HttpGet(Name = "GetCliente")]
        public List<Cliente> Get()
        {
            return lista.ListaCliente.Where(x => x.Ativo).ToList();
        }

        [HttpPost(Name = "PostCliente")]
        public Mensagem Post(Cliente cliente)
        {
            List<Cliente> listaClientesAtivos = lista.ListaCliente.Where(x => x.Ativo).ToList();
            if(cliente.IdCliente == 0)
            {
                //Verifica se o CPF é igual 
                if (listaClientesAtivos.FindAll(x => x.Cpf == cliente.Cpf).Count() == 0)
                {
                    // Se o Id for null ele ira inserrir um novo registro
                    Cliente ultimoCliente = lista.ListaCliente.OrderBy(x=> x.IdCliente).Last();
                    cliente.setId(ultimoCliente.IdCliente+1);
                    lista.ListaCliente.Add(cliente);
                    
                   return new Mensagem(true, "Registro inserido com sucesso!");
                    
                }
                else
                {
                    //Se o CPF ja exu
                    return new Mensagem(false, "CPF Já cadastrado!");                    
                } 
            }
            // Se o Id não for null ele ira Atualizar 
            else
            {
                if (listaClientesAtivos.FindAll(x => x.Cpf == cliente.Cpf && x.IdCliente != cliente.IdCliente).Count() == 0)
                {
                    int index = lista.ListaCliente.FindIndex(x => x.IdCliente == cliente.IdCliente);
                    lista.ListaCliente[index] = cliente;

                    return new Mensagem(true, "Registro Atualizado com sucesso!");
                }
                else
                {
                    return new Mensagem(false, "CPF Já cadastrado!");
                }
            }
            return null;
        }        

        // DELETE api/<ValuesController>/5
        [HttpDelete(Name = "DeleteCliente")]
        public Mensagem Delete(int id)
        {   
            //Altera o status para false, assim o registro ira permanecer porem não ira aparecer
            ListaDadosCliente lista = new ListaDadosCliente();
            Cliente cliente = lista.ListaCliente.Where(x => x.IdCliente == id).FirstOrDefault();
            if (cliente != null)
            {                
                lista.ListaCliente.Remove(cliente);
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