using Bravi.Application.DTOs;
using Bravi.Application.Responses;

namespace Bravi.Application.Services.Interfaces
{
    public interface IPessoaService : IDisposable
    {
        Task<GenericResponse<PessoaDTO>> ObeterPorId(int id);
        Task<GenericResponse<PessoaDTO>> ObterPorIdNoTracking(int id);
        Task<GenericResponseList<PessoaDTO>> ObterTodos();
        Task<GenericResponse<PessoaDTO>> Adicionar(PessoaDTO pessoa);
        Task<GenericResponse<PessoaDTO>> Atualizar(PessoaDTO pessoa);
        Task<GenericResponse<PessoaDTO>> Remover(int id);
    }
}
