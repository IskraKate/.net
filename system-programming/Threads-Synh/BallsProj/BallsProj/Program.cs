using System;
using System.Threading;

//2. Шарики.Координаты заданного количества шариков изменяются на случайную величину по вертикали и горизонтали.При
//  выпадении шарика за нижнюю границу допустимой области шарик исчезает.Изменение координат каждого шарика в отдельном
//  процессе (потоке).

namespace BallsProj
{
    class Ball
    {
        private Random _rnd = new Random();

        private int _x;
        private int _y;
        private int _incX;
        private int _incY;

        public Ball()
        {
            Console.CursorVisible = false;
            _x = _rnd.Next(0, Console.WindowWidth);
            _y = 0;

            _incX = _rnd.Next(1, 5);
            _incY = _rnd.Next(1, 5);
        }

        public void Update(Object locker)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(ThreadProc));
            thread.Start(locker);
        }

        private void ThreadProc(Object locker)
        {
            while (_y < Console.BufferHeight - _incY && _x < Console.BufferWidth - _incX)
            {
                lock (locker)
                {
                    Console.SetCursorPosition(_x, _y);
                    Console.Write(' ');

                    _x = _x + _incX;
                    _y = _y + _incY;

                    Console.SetCursorPosition(_x, _y);
                    Console.Write('o');
                    
                }
                    Thread.Sleep(200);
            }

            lock (locker)
            {
                Console.SetCursorPosition(_x, _y);
                Console.Write(' ');
            }
        }
    }

    class Program
    {
        static Object locker = new Object();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Ball ball = new Ball();
                ball.Update(locker);
            }
        }
    }
}
