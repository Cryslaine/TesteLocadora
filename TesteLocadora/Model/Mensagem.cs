namespace TesteLocadora.Model
{
    public class Mensagem
    {
        public bool Resultado { get; private set; }
        public string Descricao { get; private set; }

        public Mensagem(bool resultado, string descricao)
        {
            Resultado = resultado;
            Descricao = descricao;
        }

    }
}
