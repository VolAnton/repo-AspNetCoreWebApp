using System;

namespace Task_6_2
{
    class Program
    {

        static int size_X = 5;
        static int size_Y = 5;

        static int sizeToWin = 4; //Условие победы, количество заполненных подряд полей

        static char[,] playField = new char[size_Y, size_X];

        static char playerDot = 'X';
        static char computerDot = 'O';
        static char emptyDot = '.';

        static Random rnd = new Random();

        private static void InitPlayField()
        {
            for (int i = 0; i < size_Y; i++)
            {

                for (int j = 0; j < size_X; j++)
                {
                    playField[i, j] = emptyDot;
                }

            }
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("  1 2 3 4 5");
            Console.WriteLine("------------");

            for (int i = 0; i < size_Y; i++)
            {

                Console.Write($"{i + 1}|");

                for (int j = 0; j < size_X; j++)
                {
                    Console.Write(playField[i, j] + "|");
                }

                Console.WriteLine();
            }

            Console.WriteLine("------------");
        }

        private static void SetSym(int y, int x, char sym)
        {
            playField[y, x] = sym;
        }

        private static bool IsCellValid(int y, int x)
        {
            if (y < 0 || x < 0 || y > size_Y - 1 || x > size_X - 1)
            {
                return false;
            }

            return playField[y, x] == emptyDot;
        }

        private static bool IsPlayFieldFull()
        {
            for (int i = 0; i < size_Y; i++)
            {

                for (int j = 0; j < size_X; j++)
                {

                    if (playField[i, j] == emptyDot)
                    {
                        return false;
                    }

                }

            }

            return true;
        }

        //Ход игрока
        private static void PlayerMove()
        {
            int y, x;
            int numb;
            string str_Y;
            string str_X;

            do
            {
                bool isNumb_Y = false;
                bool isNumb_X = false;
                Console.WriteLine("Введите координаты Вашего хода в диапазоне от 1 до " + size_Y);

                do
                {
                    Console.WriteLine("Координата по вертикали (строке) ");
                    str_Y = Console.ReadLine();

                    if (Int32.TryParse(str_Y, out numb))
                    {
                        isNumb_Y = true;
                    }

                }
                while (!isNumb_Y);

                y = Int32.Parse(str_Y) - 1;

                do
                {
                    Console.WriteLine("Координата по горизонтале (столбцу) "); ;
                    str_X = Console.ReadLine();

                    if (Int32.TryParse(str_X, out numb))
                    {
                        isNumb_X = true;
                    }

                }
                while (!isNumb_X);

                x = Int32.Parse(str_X) - 1;
            }
            while (!IsCellValid(y, x));

            SetSym(y, x, playerDot);
        }

        /*
        Ход компьютера. Логика такая:
        1) сначало компьютер проверяет сможет ли он победить поставив 1 последнюю клетку и ходит для победы;
        2) затем комптютер проверяет и блокирует ход игрока, когда осталась 1 клетка до победы игрока;
        3) затем комптютер проверяет и блокирует ход игрока, когда осталась 2 клетки до победы игрока;
        4) если выше перечисленные условия не выполняются, то компьютер просто ходит произвольно.
         */

        private static void ComputerMove()
        {
            int y, x;
            //Ход компьютера для победы
            for (int v = 0; v < size_Y; v++)
            {

                for (int h = 0; h < size_X; h++)
                {

                    //Ищем поле для проверки
                    if (h + sizeToWin <= size_X)
                    {

                        //По горизонтале
                        if (CheckHorizontLine(v, h, computerDot) == sizeToWin - 1)
                        {

                            if (MoveComputerHorizontLine(v, h, computerDot))
                            {
                                return;
                            }

                        }

                        //По диагонали вверх
                        if (v - sizeToWin > -2)
                        {

                            if (CheckDiagLineUp(v, h, computerDot) == sizeToWin - 1)
                            {

                                if (MoveComputerDiagLineUp(v, h, computerDot))
                                {
                                    return;
                                }
                            }

                        }

                        //По диагонали вниз
                        if (v + sizeToWin <= size_Y)
                        {
                            if (CheckDiagLineDown(v, h, computerDot) == sizeToWin - 1)
                            {
                                if (MoveComputerDiagLineDown(v, h, computerDot))
                                {
                                    return;
                                }
                            }
                        }
                    }

                    //По вертикали
                    if (v + sizeToWin <= size_Y)
                    {

                        if (CheckVerticalLine(v, h, computerDot) == sizeToWin - 1)
                        {

                            if (MoveComputerVerticalLine(v, h, computerDot))
                            {
                                return;
                            }
                        }

                    }


                }
            }

            //Блокировка хода игрока при условии, что осталась 1 клетка до победы игрока
            for (int v = 0; v < size_Y; v++)
            {

                for (int h = 0; h < size_X; h++)
                {

                    //Ищем поле для проверки
                    if (h + sizeToWin <= size_X)
                    {

                        //По горизонтале
                        if (CheckHorizontLine(v, h, playerDot) == sizeToWin - 1)
                        {

                            if (MoveComputerHorizontLine(v, h, computerDot))
                            {
                                return;
                            }
                        }

                        //По диагонали вверх
                        if (v - sizeToWin > -2)
                        {

                            if (CheckDiagLineUp(v, h, playerDot) == sizeToWin - 1)
                            {

                                if (MoveComputerDiagLineUp(v, h, computerDot))
                                {
                                    return;
                                }
                            }

                        }

                        //По диагонали вниз
                        if (v + sizeToWin <= size_Y)
                        {

                            if (CheckDiagLineDown(v, h, playerDot) == sizeToWin - 1)
                            {

                                if (MoveComputerDiagLineDown(v, h, computerDot))
                                {
                                    return;
                                }
                            }

                        }


                    }

                    //По вертикали
                    if (v + sizeToWin <= size_Y)
                    {

                        if (CheckVerticalLine(v, h, playerDot) == sizeToWin - 1)
                        {

                            if (MoveComputerVerticalLine(v, h, computerDot))
                            {
                                return;
                            }
                        }

                    }

                }

            }

            //Блокировка хода игрока при условии, что осталось 2 клетки до победы игрока
            for (int v = 0; v < size_Y; v++)
            {

                for (int h = 0; h < size_X; h++)
                {

                    //Ищем поле для проверки
                    if (h + sizeToWin <= size_X)
                    {

                        //По горизонтале
                        if (CheckHorizontLine(v, h, playerDot) == sizeToWin - 2)
                        {

                            if (MoveComputerHorizontLine(v, h, computerDot))
                            {
                                return;
                            }

                        }

                        //По диагонали вверх
                        if (v - sizeToWin > -2)
                        {

                            if (CheckDiagLineUp(v, h, playerDot) == sizeToWin - 2)
                            {

                                if (MoveComputerDiagLineUp(v, h, computerDot))
                                {
                                    return;
                                }
                            }

                        }

                        //По диагонали вниз
                        if (v + sizeToWin <= size_Y)
                        {

                            if (CheckDiagLineDown(v, h, playerDot) == sizeToWin - 2)
                            {

                                if (MoveComputerDiagLineDown(v, h, computerDot))
                                {
                                    return;
                                }
                            }

                        }

                    }

                    //По вертикали
                    if (v + sizeToWin <= size_Y)
                    {

                        if (CheckVerticalLine(v, h, playerDot) == sizeToWin - 2)
                        {

                            if (MoveComputerVerticalLine(v, h, computerDot))
                            {
                                return;
                            }
                        }

                    }


                }

            }

            //Случайный ход комптюьера
            do
            {
                y = rnd.Next(0, size_Y);
                x = rnd.Next(0, size_X);
            }
            while (!IsCellValid(y, x));

            SetSym(y, x, computerDot);
        }

        //Проверка и ход комптютера по горизонтале
        private static bool MoveComputerHorizontLine(int v, int h, char dot)
        {
            for (int j = h; j < sizeToWin; j++)
            {

                if (playField[v, j] == emptyDot)
                {
                    playField[v, j] = dot;
                    return true;
                }

            }

            return false;
        }

        //Проверка и ход комптютера по вертикали
        private static bool MoveComputerVerticalLine(int v, int h, char dot)
        {
            for (int i = v; i < sizeToWin; i++)
            {

                if (playField[i, h] == emptyDot)
                {
                    playField[i, h] = dot;
                    return true;
                }

            }

            return false;
        }

        //Проверка и ход комптютера по диагонали вверх
        private static bool MoveComputerDiagLineUp(int v, int h, char dot)
        {
            for (int i = 0, j = 0; j < sizeToWin; i--, j++)
            {

                if (playField[v + i, h + j] == emptyDot)
                {
                    playField[v + i, h + j] = dot;
                    return true;
                }

            }

            return false;
        }

        //Проверка и ход комптютера по диагонали вниз
        private static bool MoveComputerDiagLineDown(int v, int h, char dot)
        {
            for (int i = 0; i < sizeToWin; i++)
            {

                if (playField[v + i, h + i] == emptyDot)
                {
                    playField[v + i, h + i] = dot;
                    return true;
                }

            }

            return false;
        }

        //Проверка заполнены ли все линии по горизонтале
        private static int CheckHorizontLine(int v, int h, char dot)
        {
            int count = 0;
            for (int j = h; j < sizeToWin + h; j++)
            {

                if (playField[v, j] == dot)
                {
                    count++;
                }

            }

            return count;
        }

        //Проверка заполнены ли все линии по вертикале
        private static int CheckVerticalLine(int v, int h, char dot)
        {
            int count = 0;

            for (int i = v; i < sizeToWin + v; i++)
            {

                if (playField[i, h] == dot)
                {
                    count++;
                }

            }

            return count;
        }

        //Проверка заполнены ли все линии по диагонали вверх
        private static int CheckDiagLineUp(int v, int h, char dot)
        {
            int count = 0;

            for (int i = 0, j = 0; j < sizeToWin; i--, j++)
            {

                if (playField[v + i, h + j] == dot)
                {
                    count++;
                }

            }

            return count;
        }

        //Проверка заполнены ли все линии по диагонали вниз
        private static int CheckDiagLineDown(int v, int h, char dot)
        {
            int count = 0;

            for (int i = 0; i < sizeToWin; i++)
            {

                if (playField[v + i, h + i] == dot)
                {
                    count++;
                }

            }

            return count;
        }

        //Проверка условия победы
        private static bool CheckWin(char dot)
        {
            for (int v = 0; v < size_Y; v++)
            {

                for (int h = 0; h < size_X; h++)
                {

                    //Ищем поле для проверки
                    if (h + sizeToWin <= size_X)
                    {

                        // По горизонтале
                        if (CheckHorizontLine(v, h, dot) >= sizeToWin)
                        {
                            return true;
                        }

                        // По диагонале вверх
                        if (v - sizeToWin > -2)
                        {

                            if (CheckDiagLineUp(v, h, dot) >= sizeToWin)
                            {
                                return true;
                            }

                        }

                        // По диагонале вниз
                        if (v + sizeToWin <= size_Y)
                        {

                            if (CheckDiagLineDown(v, h, dot) >= sizeToWin)
                            {
                                return true;
                            }

                        }

                    }

                    // По вертикале
                    if (v + sizeToWin <= size_Y)
                    {

                        if (CheckVerticalLine(v, h, dot) >= sizeToWin)
                        {
                            return true;
                        }

                    }

                }

            }

            return false;
        }

        static void Main(string[] args)
        {
            InitPlayField();
            PrintField();

            do
            {
                PlayerMove();
                Console.WriteLine("Ваш ход");
                PrintField();

                if (CheckWin(playerDot))
                {
                    Console.WriteLine("Вы победили");
                    break;
                }
                else if (IsPlayFieldFull())
                {
                    break;
                }

                ComputerMove();
                Console.WriteLine("Ход компьютера");
                PrintField();

                if (CheckWin(computerDot))
                {
                    Console.WriteLine("Победил компьютер");
                    break;
                }
                else if (IsPlayFieldFull())
                {
                    break;
                }

            }
            while (true);

            Console.WriteLine("!!!Игра окончена!!!");
            Console.ReadKey();
        }
    }
}
