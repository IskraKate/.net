using System;
using System.Threading;

//3. Противостояние нескольких команд.Каждая команда увеличивается на случайное количество бойцов и убивает случайное
//количество бойцов участника.Борьба каждой команды реализуется в отдельном процессе(потоке).

namespace FightProj
{
    class SharedResources
    {
        public static Mutex Mutex { get; } = new Mutex();
    }

    class FirstTeam
    {
        private Random _rnd = new Random();

        public static int FirstTeamPlayers { get; set; } = 100;

        public FirstTeam()
        {
        }

        public void FirstTeamFight()
        {
            Thread thread = new Thread(ThreadProc);
            thread.Start();
        }

        public void ThreadProc()
        {
            while(FirstTeamPlayers > 0 && SecondTeam.SecondTeamPlayers > 0)
            {
                SharedResources.Mutex.WaitOne();

                FirstTeamPlayers += _rnd.Next(1,60);
                SecondTeam.SecondTeamPlayers -= _rnd.Next(1, 60);

                Console.WriteLine($"First Team Players: { FirstTeamPlayers } \nSecond Team Players : { SecondTeam.SecondTeamPlayers} ");

                if (FirstTeamPlayers < 0)
                {
                    Console.WriteLine("Second team won");
                }
                else if(SecondTeam.SecondTeamPlayers < 0)
                {
                    Console.WriteLine("First team won");
                }

                SharedResources.Mutex.ReleaseMutex();
                Thread.Sleep(400);
            }

        }
    }

    class SecondTeam
    {
        private Random _rnd = new Random();

        public static int SecondTeamPlayers { get; set; } = 100;

        public SecondTeam()
        {
          
        }

        public void SecondTeamFight()
        {
            Thread thread = new Thread(ThreadProc);
            thread.Start();
        }

        public void ThreadProc()
        {
            while (FirstTeam.FirstTeamPlayers > 0 && SecondTeamPlayers > 0)
            {
                SharedResources.Mutex.WaitOne();

                FirstTeam.FirstTeamPlayers -= _rnd.Next(1, 60);
                SecondTeamPlayers += _rnd.Next(1, 60);

                Console.WriteLine($"First Team Players: { FirstTeam.FirstTeamPlayers } \nSecond Team Players : {SecondTeamPlayers} ");

                if (FirstTeam.FirstTeamPlayers < 0)
                {
                    Console.WriteLine("Second team won");
                }
                else if (SecondTeamPlayers < 0)
                {
                    Console.WriteLine("First team won");
                }

                SharedResources.Mutex.ReleaseMutex();

                Thread.Sleep(400);
            }

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            FirstTeam ft = new FirstTeam();
            SecondTeam st = new SecondTeam();

            ft.FirstTeamFight();
            st.SecondTeamFight();
        }
    }
}
