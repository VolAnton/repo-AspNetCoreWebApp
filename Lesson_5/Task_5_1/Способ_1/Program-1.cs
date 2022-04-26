using System;

namespace Task_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Greetings();

            int row = GetRow();
            int col = GetCol();
            int[,] array = new int[row, col];
            int i_Start = 0;
            int j_Start = 0;
            int score = 0;
            int numbOfCircles = 0;
            int scoreToExit = (array.GetLength(0) * array.GetLength(1));

            do
            {
                //Для записи значений в массив надо двигаться вправо > вниз > влево > вверх и т.д.
                //Записываем значения в массив двигаясь вправо
                (score, array) = GetRight(i_Start, j_Start, score, scoreToExit, numbOfCircles, array);

                //Записываем значения в массив двигаясь вниз
                (score, array) = GetDown(i_Start, j_Start, score, scoreToExit, numbOfCircles, array);

                //Записываем значения в массив двигаясь влево
                (score, array) = GetLeft(i_Start, j_Start, score, scoreToExit, numbOfCircles, array);

                //Записываем значения в массив двигаясь вниз
                (score, array) = GetUp(i_Start, j_Start, score, scoreToExit, numbOfCircles, array);

                //Увеличиваем начальное положения строчки массива на 1
                i_Start++;

                //Увеличиваем начальное положения столбца массива на 1
                j_Start++;

                //Увеличиваем счетчик полного оборота записи по кругу на 1
                numbOfCircles++;
            }
            while (!GetBreak(score, scoreToExit));

            GetPrintArray(array);

            Console.ReadKey();
        }

        public static void Greetings()
        {
            Console.WriteLine(@"Приветствую!
Данная программа заполнит любой массив по спирали.
Для продолжение нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
        }

        public static int GetRow()
        {
            string rowString;
            int rowInt;
            int numb;
            bool isNumb = false;
            bool isNumbMoreZero = false;

            do
            {
                Console.WriteLine("Укажите число строк массива и нажмите Enter");
                rowString = Console.ReadLine();

                if (Int32.TryParse(rowString, out numb))
                {
                    isNumb = true;

                    if (Int32.Parse(rowString) > 0)
                    {
                        isNumbMoreZero = true;
                    }

                }

            }
            while (!isNumb || !isNumbMoreZero);

            rowInt = Int32.Parse(rowString);
            return rowInt;
        }
        public static int GetCol()
        {
            string colString;
            int colInt;
            int numb;
            bool isNumb = false;
            bool isNumbMoreZero = false;

            do
            {
                Console.WriteLine("Укажите число столбцов массива и нажмите Enter");
                colString = Console.ReadLine();

                if (Int32.TryParse(colString, out numb))
                {
                    isNumb = true;

                    if (Int32.Parse(colString) > 0)
                    {
                        isNumbMoreZero = true;
                    }

                }

            }
            while (!isNumb || !isNumbMoreZero);

            colInt = Int32.Parse(colString);
            return colInt;
        }

        public static bool GetBreak(int curentScore, int breakScore)
        {
            if (curentScore == breakScore)
            {
                return true;
            }

            return false;
        }

        public static (int, int[,]) GetRight(int i_Start_Method, int j_Start_Method, int score_Method, int scoreToExit_Method, int numbOfCircles_Method, int[,] array_Method)
        {
            for (int j = j_Start_Method; j < (array_Method.GetLength(1) - numbOfCircles_Method); j++)
            {

                if (GetBreak(score_Method, scoreToExit_Method))
                {
                    break;
                }

                score_Method++;
                array_Method[(i_Start_Method), j] = score_Method;
            }

            return (score_Method, array_Method);
        }

        public static (int, int[,]) GetDown(int i_Start_Method, int j_Start_Method, int score_Method, int scoreToExit_Method, int numbOfCircles_Method, int[,] array_Method)
        {
            for (int i = (i_Start_Method + 1); i < (array_Method.GetLength(0) - numbOfCircles_Method); i++)
            {

                if (GetBreak(score_Method, scoreToExit_Method))
                {
                    break;
                }

                score_Method++;
                array_Method[i, (array_Method.GetLength(1) - 1 - numbOfCircles_Method)] = score_Method;
            }

            return (score_Method, array_Method);
        }

        public static (int, int[,]) GetLeft(int i_Start_Method, int j_Start_Method, int score_Method, int scoreToExit_Method, int numbOfCircles_Method, int[,] array_Method)
        {
            for (int j = (array_Method.GetLength(1) - 2 - numbOfCircles_Method); j >= j_Start_Method; j--)
            {

                if (GetBreak(score_Method, scoreToExit_Method))
                {
                    break;
                }

                score_Method++;
                array_Method[(array_Method.GetLength(0) - 1 - numbOfCircles_Method), j] = score_Method;
            }

            return (score_Method, array_Method);
        }

        public static (int, int[,]) GetUp(int i_Start_Method, int j_Start_Method, int score_Method, int scoreToExit_Method, int numbOfCircles_Method, int[,] array_Method)
        {
            for (int i = (array_Method.GetLength(0) - 2 - numbOfCircles_Method); i >= i_Start_Method + 1; i--)
            {

                if (GetBreak(score_Method, scoreToExit_Method))
                {
                    break;
                }

                score_Method++;
                array_Method[i, (j_Start_Method)] = score_Method;
            }

            return (score_Method, array_Method);
        }
        public static void GetPrintArray(int[,] arrayPrint)
        {
            string capacity = Convert.ToString(arrayPrint.GetLength(0) * arrayPrint.GetLength(1));
            int n = capacity.Length;

            for (int i = 0; i < arrayPrint.GetLength(0); i++)
            {

                for (int j = 0; j < arrayPrint.GetLength(1); j++)
                {

                    switch (n)
                    {
                        case 1:
                            Console.Write($"{arrayPrint[i, j],1} ");
                            break;
                        case 2:
                            Console.Write($"{arrayPrint[i, j],2} ");
                            break;
                        case 3:
                            Console.Write($"{arrayPrint[i, j],3} ");
                            break;
                        case 4:
                            Console.Write($"{arrayPrint[i, j],4} ");
                            break;
                        case 5:
                            Console.Write($"{arrayPrint[i, j],5} ");
                            break;
                        default:
                            Console.Write($"{arrayPrint[i, j],6} ");
                            break;
                    }

                }

                Console.WriteLine();
            }
        }
    }
}
