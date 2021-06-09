using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorV2.Commands
{
    public class DivideCommand : BaseCommand { }

    internal class DivideCommandHandler : IRequestHandler<DivideCommand, double>
    {
        public Task<double> Handle(DivideCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(command.LeftOperand / command.RightOperand);
        }
    }
}
