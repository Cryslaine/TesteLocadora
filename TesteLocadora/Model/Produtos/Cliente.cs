using Microsoft.Graph.TermStore;
using System.ComponentModel.DataAnnotations;

namespace TesteLocadora.Model.Produtos
{

    public class Cliente
    {
        public int IdCliente { get; private set; }
        public string NomeCliente { get; private set; }
        public string Cpf { get; private set; }
        public string Endereco { get; private set; }
        public bool Ativo { get; private set; }

        public void setId(int id) { IdCliente = id; }
        public void setAtivo (bool ativo) { Ativo = ativo; }

        public Cliente(int idCliente, string nomeCliente, string cpf, string endereco, bool ativo)
        {
           IdCliente = idCliente;
           NomeCliente = nomeCliente;
           Cpf = cpf ;
           Endereco = endereco;
           Ativo = ativo ;
        }

        
    }
}
