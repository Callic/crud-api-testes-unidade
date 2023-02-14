namespace Bravi.Application.DTOs
{
    public class Erro
    {
        public Erro()
        {

        }
        public Erro(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; set; }
    }
}
