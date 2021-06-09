using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorV2.Commands
{
    public class MultiplyCommand : BaseCommand { }

    internal class MultiplyCommandHandler : IRequestHandler<MultiplyCommand, double>
    {
        public Task<double> Handle(MultiplyCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(command.LeftOperand * command.RightOperand);
        }
    }
}
