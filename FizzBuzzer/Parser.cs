using FizzBuzzer.Models;
using FizzBuzzer.Resources;
using System;
using System.Linq;

namespace FizzBuzzer
{
    public class Parser : FizzBuzzer.Interfaces.IParser
    {
        /*
         * args[0]: executable path
         * args[1]: start of number sequence
         * args[2]: end of number sequence
         * args[3]: first divisor:word, second divisor:word format         
         */

        #region Public Members

        public ValidationResult Validate(string[] args)
        {
            var validationResult = new ValidationResult();

            // Argument checks
            #region Argument Checks

            if (!args.Any() || args.Count() < 4)
            {
                validationResult.Message = ValidationMessages.InputArgsMissing;

                return validationResult;
            }

            #endregion

            // Parsing sequence number Arguments
            #region Sequence number Checks

            var startSequence = 0;
            var endSequence = 0;

            if (!int.TryParse(args[1], out startSequence))
            {
                validationResult.Message = string.Format(ValidationMessages.NotAnInteger, "Start of a Sequence");

                return validationResult;
            }

            if (!int.TryParse(args[2], out endSequence))
            {
                validationResult.Message = string.Format(ValidationMessages.NotAnInteger, "End of a Sequence");

                return validationResult;
            }

            // End should be > Start number
            if (startSequence > endSequence)
            {
                validationResult.Message = ValidationMessages.InvalidSequence;

                return validationResult;
            }

            #endregion

            // Parsing rule Arguments
            #region Rule Checks

            // Make sure rules are in correct format
            if (!args[3].Contains(',') || args[3].Split(',').Count() > 2)
            {
                validationResult.Message = ValidationMessages.InvalidRule;

                return validationResult;
            }

            var firstRule = args[3].Split(',')[0];
            var secondRule = args[3].Split(',')[1];

            if (!firstRule.Contains(':') || !secondRule.Contains(':'))
            {
                validationResult.Message = ValidationMessages.InvalidRule;

                return validationResult;
            }

            var firstRuleDivisor = firstRule.Split(':')[0];
            var firstRuleWord = firstRule.Split(':')[1];
            var firstRuleDivisorInt = 0;

            var secondRuleDivisor = secondRule.Split(':')[0];
            var secondRuleWord = secondRule.Split(':')[1];
            var secondRuleDivisorInt = 0;

            if (!int.TryParse(firstRuleDivisor, out firstRuleDivisorInt) ||
                string.IsNullOrWhiteSpace(firstRuleWord) ||
                !int.TryParse(secondRuleDivisor, out secondRuleDivisorInt) ||
                string.IsNullOrWhiteSpace(secondRuleWord))
            {
                validationResult.Message = ValidationMessages.InvalidRule;

                return validationResult;
            }

            #endregion

            // If all checks passed, user has specified correct Arguments
            validationResult.IsValid = true;

            return validationResult;
        }

        public Filter Parse(string[] args)
        {
            if (!args.Any())
            {
                return null;
            }

            var filter = new Filter
            {
                SequenceStart = Convert.ToInt32(args[1]),
                SequenceEnd = Convert.ToInt32(args[2])
            };

            filter.Rules.Add(new Rule
            {
                Divisor = Convert.ToInt32(args[3].Split(',')[0].Split(':')[0]),
                Word = args[3].Split(',')[0].Split(':')[1]
            });

            filter.Rules.Add(new Rule
            {
                Divisor = Convert.ToInt32(args[3].Split(',')[1].Split(':')[0]),
                Word = args[3].Split(',')[1].Split(':')[1]
            });

            return filter;
        }

        #endregion
    }
}
