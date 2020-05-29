using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

//4. Авиаразведка.Создается условная карта в виде матрицы, размерность которой определяет размер карты, содержащей
//   произвольное количество единиц(целей) в произвольных ячейках.Из произвольной точки карты стартуют несколько
//   разведчиков(процессов, потоков), курсы которых выбираются так, чтобы покрыть максимальную площадь карты.Каждый
//  разведчик фиксирует цели, чьи координаты совпадают с его координатами и по достижении границ карты сообщает количество
//  обнаруженных целей.


namespace SpiesProj
{
    enum Direction { Left, Right, Up, Down, LeftUp, LeftDown, RightUp, RightDown }

    class Plane 
    {
        private Point _point;
        public int TargetCount { get; private set; }

        public bool IsDone = false;

        private Direction _dir;

        public Plane(Point point, Direction dir)
        {
            _point = point;
            _dir = dir;

            TargetCount = 0;
            
            CreateThread();
        }

        private void CreateThread()
        {
            Thread thread = new Thread(ThreadProc);
            thread.Start();
        }

        private void ThreadProc()
        {
            while (true)
            {
                int res;
                Point oldPoint = _point;

                if (_dir == Direction.Down)
                {
                    _point.Y++;
                }
                else if (_dir == Direction.Left)
                {
                    _point.X--;
                }
                else if (_dir == Direction.LeftDown)
                {
                    _point.X--;
                    _point.Y++;
                }
                else if (_dir == Direction.LeftUp)
                {
                    _point.X--;
                    _point.Y--;
                }
                else if (_dir == Direction.Right)
                {
                    _point.X++;
                }
                else if (_dir == Direction.RightDown)
                {
                    _point.X++;
                    _point.Y++;
                }
                else if (_dir == Direction.RightUp)
                {
                    _point.X++;
                    _point.Y--;
                }
                else if (_dir == Direction.Up)
                {
                    _point.Y--;
                }

                res = Map.Move(oldPoint, _point);

                if(res == -1)
                {
                    IsDone = true;
                    break;
                }
                else
                {
                    TargetCount += res;
                }

                Thread.Sleep(400);
            }
        }
    }

    class Map
    {
        private  static Mutex _mutex = new Mutex();
        private Random _rnd;
        private Point _point;

        private static char[,] _map;
        private static int _rows { get; set; }
        private static int _columns { get; set; }

        public Map()
        {
            _rnd = new Random();

            _rows = _rnd.Next(10, 20);
            _columns = _rnd.Next(10, 20);

            _map = new char[_rows, _columns];

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    _map[i, j] = '0';
                }
            }

            Add1();
        }

        public void Add1()
        {
            int x;
            int y; 

            int count = _rnd.Next(10, 20);

            for (int i = 0; i < count; i++)
            {
                x = _rnd.Next(0, _columns);
                y = _rnd.Next(0, _rows);

                _map[y, x] = '1';
            }
        }
        public void AddStartPoint(Point point)
        {
            _map[point.Y, point.X] = 'X';
        }

        public void Display()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if(_map[i, j] == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (_map[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write($"{_map[i, j]}   ");
                }
                Console.WriteLine();
            }
        }

        public Point ChoosePlanePoint() => _point = new Point(new Random().Next(0, _columns - 1), new Random().Next(0, _rows - 1));

        public List<Direction> ChooseDirection()
        {
            List<Direction> dirs = new List<Direction>();

            if (_point.X == 0 && _point.Y == 0)
            {
                dirs.Add(Direction.Right);
                dirs.Add(Direction.RightDown);
                dirs.Add(Direction.Down);
            }
            else if (_point.X == 0 && _point.Y == _rows - 1)
            {
                dirs.Add(Direction.Up);
                dirs.Add(Direction.LeftUp);
                dirs.Add(Direction.Right);
            }
            else if (_point.Y == 0 && _point.X == _columns - 1)
            {
                dirs.Add(Direction.Left);
                dirs.Add(Direction.LeftDown);
                dirs.Add(Direction.Down);
            }
            else if (_point.X == _columns - 1 && _point.Y == _rows - 1)
            {
                dirs.Add(Direction.Left);
                dirs.Add(Direction.LeftDown);
                dirs.Add(Direction.Down);
            }
            else if (_point.X == 0)
            {
                dirs.Add(Direction.Up);
                dirs.Add(Direction.Right);
                dirs.Add(Direction.RightUp);
                dirs.Add(Direction.RightDown);
                dirs.Add(Direction.Down);
            }
            else if (_point.X == _columns - 1)
            {
                dirs.Add(Direction.Up);
                dirs.Add(Direction.Left);
                dirs.Add(Direction.LeftUp);
                dirs.Add(Direction.LeftDown);
                dirs.Add(Direction.Down);
            }
            else if (_point.Y == 0)
            {
                dirs.Add(Direction.Down);
                dirs.Add(Direction.LeftDown);
                dirs.Add(Direction.Left);
                dirs.Add(Direction.RightDown);
                dirs.Add(Direction.Right);
            }
            else if (_point.Y == _rows - 1)
            {
                dirs.Add(Direction.Up);
                dirs.Add(Direction.LeftUp);
                dirs.Add(Direction.Left);
                dirs.Add(Direction.RightUp);
                dirs.Add(Direction.Right);
            }
            else
            {
                dirs.Add(Direction.Up);
                dirs.Add(Direction.RightUp);
                dirs.Add(Direction.RightDown);
                dirs.Add(Direction.Right);
                dirs.Add(Direction.LeftUp);
                dirs.Add(Direction.LeftDown);
                dirs.Add(Direction.Left);
                dirs.Add(Direction.Down);
            }

            return dirs;
        }

        public static int Move(Point oldPoint, Point newPoint)
        {
            if (newPoint.Y >= _rows || newPoint.Y < 0 || newPoint.X >= _columns || newPoint.X < 0)
            {
                return -1;
            }

            _mutex.WaitOne();

            int data = 0;
            int.TryParse(_map[newPoint.Y, newPoint.X].ToString(), out data);

            _map[newPoint.Y, newPoint.X] = 'X';
            _map[oldPoint.Y, oldPoint.X] = '0';

            _mutex.ReleaseMutex();

            return data;
        }

    }

    class Program
    {
        static bool CheckPlanesDone(List<Plane> planes)
        {
            foreach(Plane plane in planes)
            {
                if(!plane.IsDone)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Map map = new Map();

            Point point = map.ChoosePlanePoint();

            List<Direction> dirs = map.ChooseDirection();
            List<Plane> planes = new List<Plane>(dirs.Count);

            foreach (var dir in dirs)
            {
                planes.Add(new Plane(point, dir));
            }

            for (;;)
            {
                Thread.Sleep(300);

                Console.SetCursorPosition(0, 0);
                map.Display();

                if(CheckPlanesDone(planes))
                {
                    break;
                }
            }

            for(int i = 0; i < planes.Count; i++)
            {
                Console.WriteLine($"Plane {i + 1} located {planes[i].TargetCount} targets.");
            }
        }
    }
}
