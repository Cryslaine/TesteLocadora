using Moq;
using TesteLocadora.Controllers;
using TesteLocadora.Model.Produtos;

namespace TestProjectLocadora
{
    public class Teste
    {
        Mock<Cliente> clienteMock;
        ClienteController clienteController;

        public Teste()
        {
            clienteMock = new Mock<Cliente>();
            clienteController = new ClienteController(clienteMock.Object);

        }
        [Fact]
        public void GetCadastroCliente()
        {
            var cliente = new List<Cliente>
            {
              new Cliente (idCliente:1,nomeCliente: "Diego",cpf: "47186326187",endereco:"Rua Mirante",ativo: true),
              new Cliente (idCliente:2,nomeCliente: "Diego", cpf:"47186326177",endereco: "Rua Mirante",ativo: true)

            };

        }


    }
}