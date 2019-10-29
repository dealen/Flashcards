using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Lib.Models
{
    public class Word
    {
        private string _expression;
        private string _translation;

        public string Expression
        {
            get { return _expression; }
            set
            {
                _expression = value.Trim();
            }
        }
        public string Translation
        {
            get { return _translation; }
            set
            {
                _translation = value.Trim();
            }
        }
    }
}
