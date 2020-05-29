using System;
using System.Threading;

//1. Винни-Пух и пчелы.Заданное количество пчел добывают мед равными порциями, задерживаясь в пути на случайное время.
//   Винни-Пух потребляет мед порциями заданной величины за заданное время и столько же времени может прожить без питания.
//   Работа каждой пчелы реализуется в порожденном процессе (потоке).

namespace WinnieThePoohProj
{ 
    class SharedResources
    { 
        public static Mutex Mutex { get; } = new Mutex();

        public static int Honey { get; set; } = 0;

        public static bool IsDead { get; set; } = false;
    }

    class WinnieThePooh
    {
        private static Thread _thread;

        private static int _portion;
        private static int _timeToEat;
        private static int _liveWithoutEating;

        private WinnieThePooh() { }

        private static WinnieThePooh _winnie;

        private static readonly object _lock = new object();

        public static void GetInstance(int portion, int timeToEat)
        {
            _portion = portion;
            _timeToEat = timeToEat;
            _liveWithoutEating = timeToEat;

            if (_winnie == null)
            {
                lock (_lock)
                {
                    if (_winnie == null)
                    {
                        _winnie = new WinnieThePooh();
                    }
                }
            }

            EatHoney();
        }

        public static void EatHoney()
        {
            _thread = new Thread(ThreadProc);
            _thread.Start();
        }

        public static void ThreadProc()
        {
             
            while (!SharedResources.IsDead)
            {
                if (SharedResources.Honey >= _portion && !SharedResources.IsDead)
                {
                    SharedResources.Honey -= _portion;
                    Console.WriteLine($"Winnie ate {_portion}");
                    Console.WriteLine($"Honey {SharedResources.Honey}");
                    Thread.Sleep(_timeToEat);
                }
                else
                {
                    Thread.Sleep(_liveWithoutEating);

                    if (SharedResources.Honey >= _portion && !SharedResources.IsDead)
                    {
                        SharedResources.Honey -= _portion;

                        Console.WriteLine($"Winnie ate {_portion}");
                        Console.WriteLine($"Honey {SharedResources.Honey}");
                        Thread.Sleep(_timeToEat);
                    }
                    else
                    {
                        SharedResources.IsDead = true;
                        SharedResources.Honey -= _portion;

                        Console.WriteLine($"Winnie ate {_portion}");
                        Console.WriteLine($"Honey {SharedResources.Honey}");
                        Console.WriteLine("Winnie is dead :c");
                    }
                }
            }
        }
    }

    class Bee
    {
        private Thread _thread;
        private Random _rnd = new Random();

        private int _portion;
        private int _delayTime;
        private int _thisNum;

        public Bee(int portion, int thisNum)
        {
            _portion = portion;
            _thisNum = thisNum;
            _delayTime = _rnd.Next(500, 1000);
            GetHoney();
        }

        public void GetHoney()
        {
            _thread = new Thread(ThreadProc);
            _thread.Start();
        }

        private void ThreadProc()
        { 
               
            while (!SharedResources.IsDead)
            {
                SharedResources.Mutex.WaitOne();

                if (!(SharedResources.Honey  < 0))
                {

                    SharedResources.Honey += _portion;
                    Console.WriteLine($"Bee {_thisNum } got {_portion } honey. Delay time {_delayTime }");
                    Console.WriteLine($"Honey {SharedResources.Honey}");

                    Thread.Sleep(_delayTime);
                }

                SharedResources.Mutex.ReleaseMutex();
            }
              
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bee bee1 = new Bee(1, 1);
            Bee bee2 = new Bee(3, 2);

            WinnieThePooh.GetInstance(9, 2500);

        }
    }
}
