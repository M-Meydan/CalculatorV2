using  CalculatorV2;
using  CalculatorV2.Models;
using FileHelpers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace TDD_BestPractices
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            try
            {
               await Init();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            Console.ReadLine();
        }

        private static async Task Init()
        {
            var serviceProvider = BuildServiceCollection();

            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "InputFiles", "file.txt");

            var calculator = serviceProvider.GetService<ICalculator>();

            if (calculator.LoadInstructions(filePath))
            {
                var result = await calculator.ExecuteInstructions();

                Console.WriteLine($"Result: {result}");
            }
        }

    public static ServiceProvider BuildServiceCollection()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient<ICalculator, Calculator>();
            serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();
            serviceCollection.AddSingleton<IFileHelperEngine<Instruction>, FileHelperEngine<Instruction>>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
