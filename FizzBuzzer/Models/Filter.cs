
using System.Collections.Generic;

namespace FizzBuzzer.Models
{
    public class Filter
    {
        #region Constructor

        public Filter()
        {
            this.Rules = new List<Rule>();
        }

        #endregion

        #region Public Members

        public int SequenceStart { get; set; }

        public int SequenceEnd { get; set; }

        public IList<Rule> Rules { get; set; }

        #endregion
    }
}
