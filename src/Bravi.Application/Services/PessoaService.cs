using AutoMapper;
using Bravi.Application.DTOs;
using Bravi.Application.Responses;
using Bravi.Application.Services.Interfaces;
using Bravi.Domain.Interfaces;
using Bravi.Domain.Models;
using Bravi.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bravi.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenericResponse<PessoaDTO> response = new GenericResponse<PessoaDTO>();
        public PessoaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GenericResponse<PessoaDTO>> Adicionar(PessoaDTO pessoaDto)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDto);

            _unitOfWork.PessoaRepository.Adicionar(pessoa);

            if (!await _unitOfWork.Commit())
            {
                response.ErroAoAdicionar();
                return response;
            }
            
            response.Data = _mapper.Map<PessoaDTO>(pessoa);
            return response;
        }

        public async Task<GenericResponse<PessoaDTO>> Atualizar(PessoaDTO pessoaDto)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDto);
            _unitOfWork.PessoaRepository.Atualizar(pessoa);
            if(!await _unitOfWork.Commit())
            {
                response.ErroAoAtualizar();
                return response;
            }
            response.Data = _mapper.Map<PessoaDTO>(pessoa);
            return response;
        }

        public async Task<GenericResponse<PessoaDTO>> ObeterPorId(int id)
        {
            response.Data = _mapper.Map<PessoaDTO>(await _unitOfWork.PessoaRepository.ObterPorId(id));
            if(response.Data is null) 
                response.ErroRegistroNaoEncontrado();
            return response;
        }
        public async Task<GenericResponse<PessoaDTO>> ObterPorIdNoTracking(int id)
        {
            response.Data = _mapper.Map<PessoaDTO>(await _unitOfWork.PessoaRepository.ObterPorIdNoTracking(id));
            if (response.Data is null)
                response.ErroRegistroNaoEncontrado();
            return response;
        }

        public async Task<GenericResponseList<PessoaDTO>> ObterTodos()
        {
            var responseList = new GenericResponseList<PessoaDTO>();
            responseList.Data = _mapper.Map<IEnumerable<PessoaDTO>>(await _unitOfWork.PessoaRepository.ObterTodos());
            return responseList;
        }

        public async Task<GenericResponse<PessoaDTO>> Remover(int id)
        {
            _unitOfWork.PessoaRepository.Excluir(id);
            if(!await _unitOfWork.Commit())
                response.ErroAoDeletar();
            return response;
        }

        public void Dispose()
        {
            _unitOfWork.PessoaRepository?.Dispose();
        }
    }
}
