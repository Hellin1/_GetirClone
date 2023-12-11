using FluentValidation;
using GetirClone.Application.Helpers;
using GetirClone.Application.Interfaces;
using GetirClone.Application.Responses;
using GetirClone.Persistance.Context;
using MediatR;

namespace GetirClone.Persistance
{
    public class TransactionManager : ITransactionManager
    {
        private readonly GetirCloneContext _context;
        private readonly IMediator _mediator;

        public TransactionManager(GetirCloneContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResultModel<TResult>> SendCommand<TResult>(IRequest<TResult> cmd)
        {
            var output = new ResultModel<TResult>();
            using var trn = await _context.Database.BeginTransactionAsync();
            try
            {
                var result = await _mediator.Send(cmd);
                await _context.SaveChangesAsync(CancellationToken.None);
                await trn.CommitAsync();
                output.IsSuccessful = true;
                output.Result = result;
            }
            catch (ValidationException ex)
            {
                output.IsSuccessful = false;
                if (ex.Errors.Any())
                {
                    output.Errors = ex.Errors.ToErrorModel();
                }
                else
                {
                    output.Errors.Add(new ErrorModel
                    {
                        ErrorCode = "1001",
                        ErrorMessage = ex.Message.ToString(),
                    });
                }
                await trn.RollbackAsync();
            }
            catch (Exception ex)
            {
                output.IsSuccessful = false;
                output.Errors = new List<ErrorModel>() { (new ErrorModel() { ErrorCode = "1001", ErrorMessage = ex.Message.ToString() }) };
                await trn.RollbackAsync();
            }

            return output;
        }

        public async Task<ResultModel<TResult>> SendQuery<TResult>(IRequest<TResult> query)
        {
            var output = new ResultModel<TResult>();
            try
            {
                var result = await _mediator.Send(query);

                output.IsSuccessful = true;
                output.Result = result;
            }
            catch (ValidationException ex)
            {
                output.IsSuccessful = false;
                if (ex.Errors.Any())
                {
                    output.Errors = ex.Errors.ToErrorModel();
                }
                else
                {
                    output.Errors.Add(new ErrorModel
                    {
                        ErrorCode = "1001",
                        ErrorMessage = ex.Message.ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                output.IsSuccessful = false;
                output.Errors = new List<ErrorModel>() { new ErrorModel() { ErrorCode = "1001", ErrorMessage = ex.Message.ToString() } };
            }
            return output;
        }
    }
}
