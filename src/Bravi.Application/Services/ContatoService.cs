using AutoMapper;
using Bravi.Application.Services.Interfaces;
using Bravi.Domain.Models;
using Bravi.Infra.Repositories.Interfaces;


namespace Bravi.Application.Services
{
    public class ContatoService 
        //: IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;
        public ContatoService(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }
        public async Task<Contato> Adicionar(Contato contato)
        {
            var result = await _contatoRepository.Adicionar(contato);

            //if (!await _contatoRepository.UnitOfWork.Commit())
            //    return null;
            return result;
        }

        //public async Task<bool> Atualizar(Contato contato)
        //{
        //    _contatoRepository.Atualizar(contato);
        //    return await _contatoRepository.UnitOfWork.Commit();
        //}

        public async Task<Contato> ObterPorId(int id)
        {
            return await _contatoRepository.ObterPorId(id);
        }

        public async Task<Contato> ObterPorIdNoTracking(int id)
        {
            return await _contatoRepository.ObterPorIdNoTracking(id);
        }

        public async Task<IEnumerable<Contato>> ObterPorPessoaId(int pessoaId)
        {
            return await _contatoRepository.ObterPorPessoaId(pessoaId);
        }

        public async Task<IEnumerable<Contato>> ObterTodos()
        {
            return await _contatoRepository.ObterTodos();
        }

        //public async Task<bool> Remover(int id)
        //{
        //    _contatoRepository.Excluir(id);
        //    return await _contatoRepository.UnitOfWork.Commit();
        //}
        public void Dispose()
        {
            _contatoRepository?.Dispose();
        }
    }
}
