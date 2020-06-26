using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProj
{
    public class CensoredFileInfo
    {
        public FileInfo FileInfo { get; set; }
        public int ReplacementCount { get; set; }

        public CensoredFileInfo(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
        }
    }
}
