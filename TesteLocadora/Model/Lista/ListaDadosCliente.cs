using TesteLocadora.Model.Produtos;

namespace TesteLocadora.Model.Lista
{
    public class ListaDadosCliente
    {
        public List<Cliente> ListaCliente { get; set; }
        public ListaDadosCliente()
        {
            if (ListaCliente == null)
                ListaCliente = new List<Cliente>();
            Cliente cadastroCliente = new Cliente();
            cadastroCliente.IdCliente = 1;
            cadastroCliente.NomeCliente = "Cryslaine";
            cadastroCliente.Cpf = 37586326177;
            cadastroCliente.Endereço = "Rua Mirante";
            cadastroCliente.Ativo = true;

            ListaCliente.Add(cadastroCliente);
            cadastroCliente = new Cliente();
            cadastroCliente.IdCliente = 2;
            cadastroCliente.NomeCliente = "Diego";
            cadastroCliente.Cpf = 47186326177;
            cadastroCliente.Endereço = "Rua Mirante";
            cadastroCliente.Ativo = true;

            ListaCliente.Add(cadastroCliente);
        }
    }
}
