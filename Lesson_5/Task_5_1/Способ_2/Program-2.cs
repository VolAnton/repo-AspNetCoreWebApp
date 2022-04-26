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
                for (int j = j_Start; j < (array.GetLength(1) - numbOfCircles); j++)
                {
                    if (GetBreak(score, scoreToExit))
                    {
                        break;
                    }
                    score++;
                    array[(i_Start), j] = score;
                }

                for (int i = (i_Start + 1); i < (array.GetLength(0) - numbOfCircles); i++)
                {
                    if (GetBreak(score, scoreToExit))
                    {
                        break;
                    }
                    score++;
                    array[i, (array.GetLength(1) - 1 - numbOfCircles)] = score;
                }

                for (int j = (array.GetLength(1) - 2 - numbOfCircles); j >= j_Start; j--)
                {
                    if (GetBreak(score, scoreToExit))
                    {
                        break;
                    }
                    score++;
                    array[(array.GetLength(0) - 1 - numbOfCircles), j] = score;
                }

                for (int i = (array.GetLength(0) - 2 - numbOfCircles); i >= i_Start + 1; i--)
                {
                    if (GetBreak(score, scoreToExit))
                    {
                        break;
                    }
                    score++;
                    array[i, (j_Start)] = score;
                }

                i_Start++;
                j_Start++;
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
