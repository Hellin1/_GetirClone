using GetirClone.Application.Responses;
using MediatR;

namespace GetirClone.Application.Interfaces
{
    public interface ITransactionManager
    {
        Task<ResultModel<TResult>> SendCommand<TResult>(IRequest<TResult> cmd);
        Task<ResultModel<TResult>> SendQuery<TResult>(IRequest<TResult> query);
    }
}
