using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorV2.Commands
{
    public class SubtractCommand : BaseCommand { }

    internal class SubtractCommandHandler : IRequestHandler<SubtractCommand, double>
    {
        public Task<double> Handle(SubtractCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(command.LeftOperand - command.RightOperand);
        }
    }
}
