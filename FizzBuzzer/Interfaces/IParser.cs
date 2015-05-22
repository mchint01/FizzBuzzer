using FizzBuzzer.Models;
using System;
namespace FizzBuzzer.Interfaces
{
    public interface IParser
    {
        Filter Parse(string[] args);

        ValidationResult Validate(string[] args);
    }
}
