using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bravi.WebApi.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected ICollection<string> Erros = new List<string>();
        protected IActionResult RespostaPadrao(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens", Erros.ToArray() }
            }));
        }

        protected IActionResult RespostaPadrao(ModelStateDictionary modelState)
        {
            var erros = ModelState.Values.SelectMany(e => e.Errors);
            foreach (var item in erros)
            {
                AdicionarErroProcessamento(item.ErrorMessage);
            }
            return RespostaPadrao();
        }
        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }
        protected void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }
        protected void LimparErrosProcessamento()
        {
            Erros.Clear();
        }

    }
}
