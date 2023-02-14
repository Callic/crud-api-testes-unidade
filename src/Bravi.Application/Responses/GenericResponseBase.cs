using Bravi.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bravi.Application.Responses
{

    public abstract class GenericResponseBase<T> where T : class
    {
        public bool Sucesso { get; set; } = true;
        public List<Erro> Erros { get; set; } = new List<Erro>();


        public ValidationProblemDetails MyProperty { get; set; }

        public void ErroRegistroNaoEncontrado()
        {
            this.Sucesso = false;
            this.Erros.Add(new Erro("Registro não encontrado"));
        }

        /// <summary>
        /// Método de retorno genérico em casos de erro ao adicionar registro
        /// </summary>
        public void ErroAoAdicionar()
        {
            this.Sucesso = false;
            
            MyProperty = new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Erro", new string[] {"Não foi possível adicionar o registro. Contate o administrador do sistema" } }
            });

            this.Erros.Add(new Erro("Não foi possível adicionar o registro. Contate o administrador do sistema"));
        }
        public void ErroAoAtualizar()
        {
            this.Sucesso = false;
            this.Erros.Add(new Erro("Não foi possível atualizar o registro. Contate o administrador do sistema"));
        }
        public void ErroAoDeletar()
        {
            this.Sucesso = false;
            this.Erros.Add(new Erro("Não foi possível apagar o registro. Contate o administrador do sistema"));
        }
    }
}
