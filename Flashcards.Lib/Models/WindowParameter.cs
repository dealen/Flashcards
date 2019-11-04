using System;
using System.Collections.Generic;
using System.Text;

namespace Flashcards.Lib.Models
{
    public class WindowParameter
    {
        private List<Word> list;
        private bool flag;

        public WindowParameter(List<Word> list, bool flag)
        {
            this.list = list;
            this.flag = flag;
        }

        public List<Word> Words
        {
            get { return list; }
            set { list = value; }
        }
        public bool IsTranslated
        {
            get { return flag; }
            set { flag = value; }
        }
    }
}
