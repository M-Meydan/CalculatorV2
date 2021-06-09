using MediatR;

namespace CalculatorV2.Commands
{
    public interface ICommand : IRequest<double> {
        abstract void SetOperands(double leftOperand, double rightOperand);
    }
}
