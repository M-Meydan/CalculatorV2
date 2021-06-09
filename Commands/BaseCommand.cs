namespace CalculatorV2.Commands
{
    public class BaseCommand: ICommand
    {
        public virtual double LeftOperand { get; set; }
        public virtual double RightOperand { get; set; }

        public virtual void SetOperands(double leftOperand, double rightOperand)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
        }
    }
}