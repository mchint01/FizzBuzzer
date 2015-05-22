using FizzBuzzer.Interfaces;
using FizzBuzzer.Models;
using StructureMap;
using System;

namespace FizzBuzzer
{
    public class Program
    {     
        public static void Main()
        {
            using(var container = new Container())
            {
                // Configure dependencies     
                InitializeDependencies(container);

                // Take user input's from command line args: validate and parse them to Model
                var parser = container.GetInstance<IParser>();
                var writer = container.GetInstance<IWriter>();
                var reader = container.GetInstance<IReader>();
                var fizzBuzzer = container.GetInstance<IFizzBuzz>();

                var validationResult = parser.Validate(Environment.GetCommandLineArgs());

                if (validationResult == null || !validationResult.IsValid)
                {
                    writer.Write(validationResult != null ? validationResult.Message : "Invalid Arguments");
                    reader.Read();

                    return;
                }

                fizzBuzzer.Start(parser.Parse(Environment.GetCommandLineArgs()));

                // Read: to not make console window close after running the application so user can see the output
                reader.Read();
            };                        
        }

        #region Private Members

        private static void InitializeDependencies(IContainer container)
        {
            container.Configure(x =>
            {
                x.For<IReader>().Use<ConsoleReader>();
                x.For<IWriter>().Use<ConsoleWriter>();
                x.For<IParser>().Use<Parser>();
                x.For<IFizzBuzz>().Use<FizzBuzz>();
            });
        }

        #endregion
    }
}
