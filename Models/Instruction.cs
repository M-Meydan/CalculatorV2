using FileHelpers;
using FileHelpers.Events;

namespace CalculatorV2.Models
{
    public enum Operation
    {
        Apply,
        Add,
        Subtract,
        Multiply,
        Divide      
    }


    [DelimitedRecord(" ")]
    [IgnoreEmptyLines()]
    public class Instruction : INotifyRead
    {
        public Instruction(){}
        public Instruction(Operation keyword, double number) { Keyword = keyword; Number = number; }

        /// <summary>
        /// Instruction keyword.
        /// </summary>
        public Operation? Keyword { get; set; }

        /// <summary>
        /// Instruction number.
        /// </summary>
        public double? Number { get; set; }
       

        public void AfterRead(AfterReadEventArgs e){ }

        public void BeforeRead(BeforeReadEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.RecordLine))    e.SkipThisRecord = true;
        }
    }
}
