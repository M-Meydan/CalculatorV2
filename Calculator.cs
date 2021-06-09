using  CalculatorV2.Models;
using FileHelpers;
using MediatR;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorV2
{
    public interface ICalculator
    {
        bool LoadInstructions(string filePath);
        Task<double> ExecuteInstructions();
    }

    public class Calculator : ICalculator
    {
        Instruction[] _instructions;
        Instruction _lastInstruction;
        
        readonly IMediator _mediator;
        readonly ICommandFactory _commandFactory;
        readonly IFileHelperEngine<Instruction> _fileHelper;


        public Calculator(IMediator mediator, ICommandFactory commandFactory, IFileHelperEngine<Instruction> fileHelper)
        { _mediator = mediator; _commandFactory = commandFactory; _fileHelper = fileHelper; }

        /// <summary>
        /// Load input data from file.
        /// </summary>
        public bool LoadInstructions(string filePath)
        {
            if (!File.Exists(filePath)) { Console.WriteLine("File not exist!"); return false; } 
        
            try
            {
                _instructions = _fileHelper.ReadFile(filePath);

                return (InstructionsExist() && StartsWithApply());
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); return false; } // file cannot be processed!
        }

        /// <summary>
        /// Executes all the instructions read from file
        /// </summary>
        public async Task<double> ExecuteInstructions()
        {
            Instruction instruction;

            double leftOperand = _instructions.Last().Number.Value; // holds the result of all calculations and initial value
            
            for (int i = 0; i < _instructions.Length - 1; i++) // skips last instruction
            {
                instruction = _instructions[i];

                leftOperand = await _mediator.Send(_commandFactory.Create(instruction, leftOperand));
            }

            return leftOperand;
        }

        private bool InstructionsExist()
        {
            if (_instructions != null && _instructions.Length != 0) return true;

            Console.WriteLine("File is empty!"); return false;
        }

        private bool StartsWithApply()
        {
            _lastInstruction = _instructions.Last();

            if (_lastInstruction.Keyword.Value == Operation.Apply) return true;

            Console.WriteLine("Last instruction is not 'apply'!"); return false;
        }
    }
}