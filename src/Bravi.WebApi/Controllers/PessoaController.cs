using AutoMapper;
using Bravi.Application.DTOs;
using Bravi.Application.Services;
using Bravi.Application.Services.Interfaces;
using Bravi.Domain.Models;
using Bravi.Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bravi.WebApi.Controllers
{
    [Route("api/pessoas")]
    public class PessoaController : MainController
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _pessoaService.ObterTodos();
            return RespostaPadrao(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var result = await _pessoaService.ObeterPorId(id);
            if (!result.Sucesso)
               return NotFound(result);
            return RespostaPadrao(result);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarPessoa(PessoaDTO pessoa)
        {
            if(!ModelState.IsValid) 
                return RespostaPadrao(ModelState);

            var result = await _pessoaService.Adicionar(pessoa);
            
            return RespostaPadrao(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, PessoaDTO pessoa)
        {
            if(id != pessoa.Id)
            {
                AdicionarErroProcessamento("O id informado não é o mesmo que foi passado na query");
                return RespostaPadrao();
            }
            if(pessoa.Contatos.Any(x => x.Id.Equals(0)))
            {
                AdicionarErroProcessamento("O id do contato deve ser informado");
                return RespostaPadrao();
            }

            if (!ModelState.IsValid) return RespostaPadrao(pessoa);

            return RespostaPadrao(await _pessoaService.Atualizar(pessoa));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult>Remover(int id)
        {
            var pessoa = await _pessoaService.ObterPorIdNoTracking(id);
            if (pessoa == null)
                return NotFound(); 

           

            return RespostaPadrao(await _pessoaService.Remover(id));
        }
        [HttpGet("Teste")]
        public async Task<IActionResult> Teste()
        {
            var pessoa = new PessoaDTO();
            var x = await _pessoaService.Adicionar(pessoa);
            return RespostaPadrao();
        }
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError() => Problem();

    }
}
