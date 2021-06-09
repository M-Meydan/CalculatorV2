using  CalculatorV2.Commands;
using  CalculatorV2.Models;
using System;
using System.Collections.Generic;

namespace CalculatorV2
{
    public interface ICommandFactory
    {
        ICommand Create(Instruction instruction, double leftOperandValue);
    }

    /// <summary>
    /// Creates commands from instructions
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        readonly IDictionary<Operation, ICommand> Commands = new Dictionary<Operation, ICommand>()
        {
            //{ Operation.Apply, null }, //this command doesnt invoke any handler
            { Operation.Add, new AddCommand() },
            { Operation.Subtract, new SubtractCommand() },
            { Operation.Divide, new DivideCommand() },
            { Operation.Multiply, new MultiplyCommand() },
        };

        public ICommand Create(Instruction instruction, double leftOperandValue)
        {
            if (Commands.TryGetValue(instruction.Keyword.Value, out ICommand command))
            {
                command.SetOperands(leftOperandValue, instruction.Number.Value);
                return command;
            }

            throw new ArgumentException("Couldn't find command: " + instruction.Keyword.Value);
        }
    }
}
