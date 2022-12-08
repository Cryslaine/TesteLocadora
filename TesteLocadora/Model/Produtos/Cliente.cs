namespace TesteLocadora.Model.Produtos
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public long Cpf { get; set; }
        public string Endereço { get; set; }
        public bool Ativo { get; set; }

    }
}
