using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CalculatorV2.Commands
{
    public class AddCommand : BaseCommand { }

    internal class AddCommandHandler : IRequestHandler<AddCommand, double>
    {
        public Task<double> Handle(AddCommand command, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(command.LeftOperand + command.RightOperand);
        }
    }
}
