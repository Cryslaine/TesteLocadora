using TesteLocadora.Model.Produtos;

namespace TesteLocadora.Model.Lista
{
    public class ListaDadosCliente
    {
        public List<Cliente> ListaCliente { get; set; }
        public ListaDadosCliente()
        {
            if (ListaCliente == null)
            {
                ListaCliente = new List<Cliente>();
                Cliente cadastroCliente1 = new Cliente(1, "Cryslaine", "37586326177", "Rua Mirante", true);
                Cliente cadastroCliente2 = new Cliente(2, "Diego", "47186326177", "Rua Mirante", true);

                ListaCliente.Add(cadastroCliente1);
                ListaCliente.Add(cadastroCliente2);
            }
        }
    }
}
