using System;
namespace FizzBuzzer.Interfaces
{
    public interface IFizzBuzz
    {
        string Generate(int x, System.Collections.Generic.IList<FizzBuzzer.Models.Rule> rules);

        void Start(FizzBuzzer.Models.Filter filter);
    }
}
