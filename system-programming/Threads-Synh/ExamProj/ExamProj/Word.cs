using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProj
{
    public class Word
    {
        public string CenWord { get; set; } = string.Empty;
        public int ReplacementCount { get; set; }

        public Word(string cenWord)
        {
            CenWord = cenWord;
        }
    }
}
