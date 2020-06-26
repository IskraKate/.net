using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProj
{
    public class ReportFile
    {
        private List<CensoredFileInfo> _censoredFileInfos;
        private List<Word> _mostPopularWords;

        public ReportFile(List<CensoredFileInfo> censoredFileInfos, List<Word> mostPopularWords)
        {
            _censoredFileInfos = censoredFileInfos;
            _mostPopularWords = mostPopularWords.OrderByDescending(w => w.ReplacementCount).ToList();
        }

        private void SaveReportFileInThread(int startIndex, int endIndex, ref string saveText)
        {
            string saveLine = string.Empty;
            for (int i = startIndex; i < endIndex; i++)
            {
                saveLine += $"{_censoredFileInfos[i].FileInfo.Name};  " +
                            $"{_censoredFileInfos[i].FileInfo.FullName};  " +
                            $"{_censoredFileInfos[i].FileInfo.Length / 1024} кб;  " +
                            $"Count of replasement: {_censoredFileInfos[i].ReplacementCount}\n";
            }

            saveText += saveLine;
        }

        public void SaveReportFile(string path)
        {
            string saveText = string.Empty;
            Directory.CreateDirectory(path);

            int startIndex = 0;
            int endIndex = 2000;

            int countOfTasks = _censoredFileInfos.Count / 2000;

            Task[] tasks = new Task[countOfTasks + 1];

            for(int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() => 
                {
                    SaveReportFileInThread(startIndex, endIndex, ref saveText);
                    startIndex = endIndex;

                    if ((_censoredFileInfos.Count - endIndex) < 2000)
                    {
                        endIndex = _censoredFileInfos.Count;
                    }
                    else
                    {
                        endIndex += 2000;
                    }
                });
            }

            Task.WaitAll(tasks);


            File.WriteAllText(path + "Report.txt", saveText);
        }
        public void SaveMostPopularWord(string path)
        {
            string saveLine = string.Empty;
            Directory.CreateDirectory(path);

            int number = 1;
            int index = 0;
            foreach (Word word in _mostPopularWords)
            {
                if(index == 9)
                {
                    break;
                }

                saveLine += $"{number}. {word.CenWord} - {word.ReplacementCount}\n";
                index++;
                number++;
            }

            File.WriteAllText(path + "MostPopularWords.txt", saveLine);

        }
    }
}
