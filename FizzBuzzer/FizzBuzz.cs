using FizzBuzzer.Interfaces;
using FizzBuzzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzer
{
    public class FizzBuzz : FizzBuzzer.Interfaces.IFizzBuzz
    {
        #region Private Members

        private readonly IWriter _writer;

        #endregion

        #region Constructor

        public FizzBuzz(IWriter writer)
        {
            _writer = writer;
        }

        #endregion

        #region Public Members

        public string Generate(int x, IList<Rule> rules)
        {
            var fizz = x % rules.First().Divisor == 0;

            var buzz = x % rules.Last().Divisor == 0;

            var output = x.ToString();

            if (fizz && buzz)
            {
                output = string.Concat(rules.First().Word, rules.Last().Word);
            }

            else if (fizz)
            {
                output = rules.First().Word;
            }

            else if (buzz)
            {
                output = rules.Last().Word;
            }

            return output;
        }

        public void Start(Filter filter)
        {
            for (var i = filter.SequenceStart; i <= filter.SequenceEnd; i++)
            {
                _writer.Write(
                    string.Format("S.No: {0} - Data:{1}", i, Generate(i, filter.Rules)));
            }
        }

        #endregion
    }
}
