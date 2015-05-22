using FizzBuzzer.Interfaces;
using FizzBuzzer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace FizzBuzzer.Tests
{
    [TestClass]
    public class FizzBuzzerTests
    {
        private IFizzBuzz _fizzBuzz;
        private IList<Rule> _rules;
        private Mock<IWriter> _writer;

        [TestInitialize]
        public void Initialize()
        {
            _writer = new Mock<IWriter>();            
            _fizzBuzz = new FizzBuzz(_writer.Object);

            _rules = new List<Rule>
            {
                new Rule {Divisor = 3, Word = "Fizz"},
                new Rule {Divisor = 5, Word = "Buzz"}
            };
        }

        [TestMethod]
        public void Should_Result_Fizz_When_Divisble_By_Three()
        {
            var result = _fizzBuzz.Generate(3, _rules);

            Assert.AreEqual("Fizz", result, true);
        }


        [TestMethod]
        public void Should_Result_Buzz_When_Divisble_By_Five()
        {
            var result = _fizzBuzz.Generate(5, _rules);

            Assert.AreEqual("Buzz", result, true);
        }

        [TestMethod]
        public void Should_Result_InputNumber_When_Not_Divisble_By_Either_Three_Or_Five()
        {
            const int number = 2;

            var result = _fizzBuzz.Generate(number, _rules);

            Assert.AreEqual(number.ToString(), result);
        }

        [TestMethod]
        public void Should_Result_FizzBuzz_When_Divisble_By_Three_And_Five()
        {
            var result = _fizzBuzz.Generate(15, _rules);

            Assert.AreEqual("FizzBuzz", result, true);
        }

        [TestMethod]
        public void Should_Result_InputNumber_On_BoundaryConditions()
        {
            Assert.AreEqual(int.MaxValue.ToString(), _fizzBuzz.Generate(int.MaxValue, _rules));
            Assert.AreEqual(int.MinValue.ToString(), _fizzBuzz.Generate(int.MinValue, _rules));
        }
    }
}
