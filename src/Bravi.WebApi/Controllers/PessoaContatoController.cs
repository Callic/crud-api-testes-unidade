using AutoMapper;
using Bravi.Application.DTOs;
using Bravi.Application.Services.Interfaces;
using Bravi.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bravi.WebApi.Controllers
{
    [Route("api/pessoas/contatos")]
    public class PessoaContatoController : MainController
    {
        private readonly IContatoService _contatoService;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;
        public PessoaContatoController(IContatoService contatoService, IMapper mapper, IPessoaService pessoaService)
        {
            _contatoService = contatoService;
            _mapper = mapper;
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _contatoService.ObterTodos();
            return RespostaPadrao(_mapper.Map<IEnumerable<ContatoDTO>>(result));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var result = await _contatoService.ObterPorId(id);
            if (result == null)
                return NotFound();
            return RespostaPadrao(_mapper.Map<ContatoDTO>(result));
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ContatoDTO contatoDTO)
        {
            if (!ModelState.IsValid) return RespostaPadrao(ModelState);


            var pessoa = await _pessoaService.ObterPorIdNoTracking(contatoDTO.PessoaId);
            if (pessoa == null)
            {
                AdicionarErroProcessamento("Não foi possível adicionar o contato, verifique se o PessoaId está correto");
                return RespostaPadrao();
            }

            var result = await _contatoService.Adicionar(_mapper.Map<Contato>(contatoDTO));
            if (result == null)
                AdicionarErroProcessamento("Não foi possível adicionar o contato");

            return RespostaPadrao(_mapper.Map<ContatoDTO>(result));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, ContatoDTO contatoDTO)
        {
            if(id != contatoDTO.Id)
            {
                AdicionarErroProcessamento("O id informado não é o mesmo que foi passado na query");
                return RespostaPadrao();
            }


            var result = await _pessoaService.ObterPorIdNoTracking(contatoDTO.PessoaId);
            if (result == null)
            {
                AdicionarErroProcessamento("Pessoa não encontrada, verifique se o PessoaId é válido");
                return RespostaPadrao();
            }

            if (!ModelState.IsValid) return RespostaPadrao(contatoDTO);
                       

            if (!await _contatoService.Atualizar(_mapper.Map<Contato>(contatoDTO)))
                AdicionarErroProcessamento("Não foi possível atualizar o contato");

            return RespostaPadrao(contatoDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remover(int id)
        {
            var result = await _contatoService.ObterPorIdNoTracking(id);
            if (result == null)
                return NotFound();

            if (!await _contatoService.Remover(id))
                AdicionarErroProcessamento("Não foi possível excluir o contato");

            return RespostaPadrao(_mapper.Map<ContatoDTO>(result));
        }
    }
}
