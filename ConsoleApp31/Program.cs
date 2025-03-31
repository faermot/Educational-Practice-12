using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp31
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Выберите задание (1-30): ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Задание №1");

                        new Task1().Calculate(); 

                        Thread.Sleep(3000);
                        break;
                    case "2":
                        Console.WriteLine("Задание №2");

                        new Task2().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "3":
                        Console.WriteLine("Задание №3");

                        new Task3().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "4": 
                        new Task4().Calculate(); 
                        break;
                    case "5":
                        Console.WriteLine("Задание №5");

                        new Task5().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "6":
                        Console.WriteLine("Задание №6");

                        new Task6().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "7":
                        Console.WriteLine("Задание №7");

                        new Task7().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "8":
                        Console.WriteLine("Задание №8");

                        new Task8().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "9":
                        Console.WriteLine("Задание №9");

                        new Task9().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "10":
                        Console.WriteLine("Задание №10");

                        new Task2().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "11":
                        Console.WriteLine("Задание №11");

                        new Task11().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "12":
                        Console.WriteLine("Задание №12");

                        new Task12().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "13":
                        Console.WriteLine("Задание №13");

                        new Task13().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "14":
                        Console.WriteLine("Задание №14");

                        new Task14().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "15":
                        Console.WriteLine("Задание №15");

                        new Task15().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "16":
                        Console.WriteLine("Задание №16");

                        new Task16().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "17":
                        Console.WriteLine("Задание №17");

                        new Task17().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "18":
                        Console.WriteLine("Задание №18");

                        new Task18().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "19":
                        Console.WriteLine("Задание №19");

                        new Task19().Calculate();

                        Thread.Sleep(3000);
                        break;
                    case "20":
                        Console.WriteLine("Задание №20");

                        new Task20().Calculate();

                        Thread.Sleep(3000);
                        break;
                    default: 
                        Console.WriteLine("Неверный выбор!");
                        Thread.Sleep(3000);
                        break;
                }
            }
        }
    }

    public class Task1
    {
        public void Calculate()
        {
            Point[] points = {
                new Point(1, 2), new Point(3, 4), new Point(5, 6),
                new Point(1, 2), new Point(3, 4), new Point(5, 6)
            };

            Dictionary<(Point center, double radius), int> circleCounts = new Dictionary<(Point, double), int>();

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    for (int k = j + 1; k < points.Length; k++)
                    {
                        Point p1 = points[i];
                        Point p2 = points[j];
                        Point p3 = points[k];

                        double A = p2.X - p1.X;
                        double B = p2.Y - p1.Y;
                        double C = p3.X - p1.X;
                        double D = p3.Y - p1.Y;

                        double E = A * (p1.X + p2.X) + B * (p1.Y + p2.Y);
                        double F = C * (p1.X + p3.X) + D * (p1.Y + p3.Y);

                        double G = 2 * (A * (p3.Y - p2.Y) - B * (p3.X - p2.X));

                        if (Math.Abs(G) < 0.000001) continue;

                        double centerX = (D * E - B * F) / G;
                        double centerY = (A * F - C * E) / G;
                        double radius = Math.Sqrt(Math.Pow(p1.X - centerX, 2) + Math.Pow(p1.Y - centerY, 2));

                        Point center = new Point(centerX, centerY);
                        var key = (center, radius);

                        if (!circleCounts.ContainsKey(key))
                        {
                            circleCounts[key] = 0;
                        }

                        foreach (Point p in points)
                        {
                            double distance = Math.Sqrt(Math.Pow(p.X - centerX, 2) + Math.Pow(p.Y - centerY, 2));
                            if (Math.Abs(distance - radius) < 0.000001)
                            {
                                circleCounts[key]++;
                            }
                        }
                    }
                }
            }

            var bestCircle = circleCounts.OrderByDescending(x => x.Value).FirstOrDefault();
            Console.WriteLine($"Лучшая окружность: центр ({bestCircle.Key.center.X:F2}, {bestCircle.Key.center.Y:F2}), радиус {bestCircle.Key.radius:F2}");
            Console.WriteLine($"Количество точек на окружности: {bestCircle.Value}");
        }
    }

    public class Task2
    {
        public void Calculate()
        {
            string[] names = { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов" };
            double[] results = { 12.5, 11.8, 13.2, 10.9, 12.1 };

            var topRunners = names.Zip(results, (n, r) => new { Name = n, Result = r })
                                 .OrderBy(x => x.Result)
                                 .Take(4);

            Console.WriteLine("Команда из 4 лучших бегунов:");
            foreach (var runner in topRunners)
                Console.WriteLine($"{runner.Name}: {runner.Result} сек");
        }
    }

    public class Task3
    {
        public void Calculate()
        {
            int size = 5;
            int[,] matrix = new int[size, size];
            Random rnd = new Random();

            Console.WriteLine("Исходная матрица:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rnd.Next(-10, 10);
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nПреобразованная матрица:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = -matrix[i, j] * 3;
                    Console.Write($"{matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }
    }

    public class Task4
    {
        public void Calculate()
        {
            int[,] matrix = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            List<int> elements = new List<int>();
            for (int i = 1; i < matrix.GetLength(0); i++)
                for (int j = 0; j < i; j++)
                    elements.Add(matrix[i, j]);

            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);

            Console.WriteLine("\nЭлементы ниже главной диагонали:");
            Console.WriteLine(string.Join(" ", elements));

            elements.Sort();
            Console.WriteLine("\nПосле сортировки:");
            Console.WriteLine(string.Join(" ", elements));
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],3}");
                Console.WriteLine();
            }
        }
    }

    public class Task5
    {
        public void Calculate()
        {
            int[,] array = GenerateArray(5, 5);
            Console.WriteLine("Исходный массив:");
            PrintArray(array);

            Console.WriteLine("\nСортировка пузырьком:");
            int[,] bubbleSorted = BubbleSort((int[,])array.Clone());
            PrintArray(bubbleSorted);

            Console.WriteLine("\nСортировка вставками:");
            int[,] insertionSorted = InsertionSort((int[,])array.Clone());
            PrintArray(insertionSorted);

            Console.WriteLine("\nСортировка выбором:");
            int[,] selectionSorted = SelectionSort((int[,])array.Clone());
            PrintArray(selectionSorted);
        }

        private int[,] GenerateArray(int rows, int cols)
        {
            int[,] arr = new int[rows, cols];
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    arr[i, j] = rnd.Next(1, 100);
            return arr;
        }

        private void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    Console.Write($"{arr[i, j],3}");
                Console.WriteLine();
            }
        }

        private int[,] BubbleSort(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int[] temp = new int[rows * cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    temp[i * cols + j] = arr[i, j];

            for (int i = 0; i < temp.Length - 1; i++)
                for (int j = 0; j < temp.Length - i - 1; j++)
                    if (temp[j] > temp[j + 1])
                        (temp[j], temp[j + 1]) = (temp[j + 1], temp[j]);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    arr[i, j] = temp[i * cols + j];

            return arr;
        }

        private int[,] InsertionSort(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int[] temp = new int[rows * cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    temp[i * cols + j] = arr[i, j];

            for (int i = 1; i < temp.Length; i++)
            {
                int key = temp[i];
                int j = i - 1;
                while (j >= 0 && temp[j] > key)
                {
                    temp[j + 1] = temp[j];
                    j--;
                }
                temp[j + 1] = key;
            }

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    arr[i, j] = temp[i * cols + j];

            return arr;
        }

        private int[,] SelectionSort(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            int[] temp = new int[rows * cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    temp[i * cols + j] = arr[i, j];

            for (int i = 0; i < temp.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < temp.Length; j++)
                    if (temp[j] < temp[minIndex])
                        minIndex = j;

                (temp[i], temp[minIndex]) = (temp[minIndex], temp[i]);
            }

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    arr[i, j] = temp[i * cols + j];

            return arr;
        }
    }

    public class Task6
    {
        public void Calculate()
        {
            int[,] matrix = {
                {1, 2, 3}, {2, 1, 3}, {4, 5, 6}, {1, 3, 2}
            };

            var firstRowSet = new HashSet<int>();
            for (int j = 0; j < matrix.GetLength(1); j++)
                firstRowSet.Add(matrix[0, j]);

            int similarCount = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                var rowSet = new HashSet<int>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                    rowSet.Add(matrix[i, j]);

                if (firstRowSet.SetEquals(rowSet))
                    similarCount++;
            }

            Console.WriteLine($"Количество строк, похожих на первую: {similarCount}");
        }
    }

    public class Task7
    {
        public void Calculate()
        {
            int[,] matrix = {
                {1, 2, 3}, {4, 5, 6}, {7, 8, 9}
            };
            int k = 5;

            Console.WriteLine($"Поиск элемента {k} в матрице:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                bool found = false;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == k)
                    {
                        Console.WriteLine($"Строка {i}, столбец {j}");
                        found = true;
                        break;
                    }
                }
                if (!found) Console.WriteLine($"В строке {i} элемент не найден");
            }
        }
    }

    public class Task8
    {
        public void Calculate()
        {
            int[,] matrix = {
                {5, 3, 7}, {2, 4, 6}, {9, 0, 2}
            };

            int minSum = int.MaxValue;
            int minRow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    sum += matrix[i, j];

                if (sum < minSum)
                {
                    minSum = sum;
                    minRow = i;
                }
            }

            Console.WriteLine($"Минимальная сумма в строке {minRow}: {minSum}");

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] *= minSum;

            Console.WriteLine("Результат умножения:");
            PrintMatrix(matrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],4}");
                Console.WriteLine();
            }
        }
    }

    public class Task9
    {
        public void Calculate()
        {
            int[,] matrix = {
                {3, 2, 1}, {4, 5, 6}, {9, 8, 7}
            };

            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);

            int[] lastElements = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                lastElements[i] = matrix[i, matrix.GetLength(1) - 1];

            Array.Sort(lastElements);
            Array.Reverse(lastElements);

            int[,] sortedMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < lastElements.Length; i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[j, matrix.GetLength(1) - 1] == lastElements[i])
                    {
                        for (int k = 0; k < matrix.GetLength(1); k++)
                            sortedMatrix[i, k] = matrix[j, k];
                        break;
                    }
                }
            }

            Console.WriteLine("\nМатрица после сортировки:");
            PrintMatrix(sortedMatrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],3}");
                Console.WriteLine();
            }
        }
    }

    public class Task10
    {
        public void Calculate()
        {
            int[,] matrix = {
                {5, 4, 3, 2, 1, 0},
                {6, 5, 4, 3, 2, 1},
                {7, 6, 5, 4, 3, 2},
                {8, 7, 6, 5, 4, 3}
            };

            int count = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                bool decreasing = true;
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] >= matrix[i - 1, j])
                    {
                        decreasing = false;
                        break;
                    }
                }
                if (decreasing) count++;
            }

            Console.WriteLine($"Количество монотонно убывающих столбцов: {count}");
        }
    }

    public class Task11
    {
        public void Calculate()
        {
            int[,] matrix = {
                {5, 3, 7}, {2, 4, 6}, {9, 0, 2}
            };

            int minInRow;
            int maxOfMins = int.MinValue;
            int resultRow = 0, resultCol = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                minInRow = matrix[i, 0];
                int col = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minInRow)
                    {
                        minInRow = matrix[i, j];
                        col = j;
                    }
                }

                if (minInRow > maxOfMins)
                {
                    maxOfMins = minInRow;
                    resultRow = i;
                    resultCol = col;
                }
            }

            Console.WriteLine($"Элемент с наибольшим значением среди минимальных элементов строк: {maxOfMins}");
            Console.WriteLine($"Позиция: строка {resultRow}, столбец {resultCol}");
        }
    }

    public class Task12
    {
        public void Calculate()
        {
            int[,] matrix = {
                {1, 2, 3}, {4, 5, 6}, {7, 8, 9}
            };

            int maxInOrderedColumns = 0;
            bool hasOrderedColumns = false;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                bool increasing = true;
                bool decreasing = true;

                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    if (matrix[i, j] <= matrix[i - 1, j]) increasing = false;
                    if (matrix[i, j] >= matrix[i - 1, j]) decreasing = false;
                }

                if (increasing || decreasing)
                {
                    hasOrderedColumns = true;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (matrix[i, j] > maxInOrderedColumns)
                            maxInOrderedColumns = matrix[i, j];
                    }
                }
            }

            if (hasOrderedColumns)
                Console.WriteLine($"Максимальный элемент в упорядоченных столбцах: {maxInOrderedColumns}");
            else
                Console.WriteLine("0 (нет упорядоченных столбцов)");
        }
    }

    public class Task13
    {
        public void Calculate()
        {
            int[,] matrix = {
                {1, 2, 3}, {4, 5, 6}, {7, 8, 9}
            };

            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
                {
                    int oppositeI = matrix.GetLength(0) - j - 1;
                    int oppositeJ = matrix.GetLength(1) - i - 1;
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[oppositeI, oppositeJ];
                    matrix[oppositeI, oppositeJ] = temp;
                }
            }

            Console.WriteLine("\nМатрица после отражения:");
            PrintMatrix(matrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],3}");
                Console.WriteLine();
            }
        }
    }

    public class Task14
    {
        public void Calculate()
        {
            int[,] matrix = {
                {5, 3, 7, 1},
                {2, 4, 6, 8},
                {9, 0, 2, 5},
                {7, 1, 4, 3}
            };

            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int min = matrix[i, 0];
                int minCol = 0;

                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        minCol = j;
                    }
                }

                int temp = matrix[i, 0];
                matrix[i, 0] = matrix[i, minCol];
                matrix[i, minCol] = temp;
            }

            Console.WriteLine("\nМатрица после преобразования:");
            PrintMatrix(matrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],4}");
                Console.WriteLine();
            }
        }
    }

    public class Task15
    {
        public void Calculate()
        {
            int n = 4;
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + j == n - 1) matrix[i, j] = 1;
                    else if (i + j < n - 1) matrix[i, j] = 0;
                    else matrix[i, j] = 2;
                }
            }

            Console.WriteLine("Матрица по заданному правилу:");
            PrintMatrix(matrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],3}");
                Console.WriteLine();
            }
        }
    }

    public class Task16
    {
        public void Calculate()
        {
            int[,] matrix = {
                {0, 1, 2},
                {1, 2, 3},
                {2, 3, 4}
            };

            bool symmetric = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != matrix[j, i])
                    {
                        symmetric = false;
                        break;
                    }
                }
                if (!symmetric) break;
            }

            Console.WriteLine("Матрица:");
            PrintMatrix(matrix);
            Console.WriteLine($"\nМатрица {(symmetric ? "симметрична" : "не симметрична")} относительно главной диагонали");
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],3}");
                Console.WriteLine();
            }
        }
    }

    public class Task17
    {
        public void Calculate()
        {
            int n = 4, m = 6;
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++) matrix[i, 0] = 1;
            for (int j = 0; j < m; j++) matrix[0, j] = 1;

            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
                }
            }

            Console.WriteLine("Результирующая матрица:");
            PrintMatrix(matrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],6}");
                Console.WriteLine();
            }
        }
    }

    public class Task18
    {
        public void Calculate()
        {
            int n = 4, m = 6;
            int[,] matrix = new int[n, m];
            int value = 0;

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < m; j++)
                        matrix[i, j] = value++;
                }
                else
                {
                    for (int j = m - 1; j >= 0; j--)
                        matrix[i, j] = value++;
                }
            }

            Console.WriteLine("Матрица-змейка:");
            PrintMatrix(matrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],4}");
                Console.WriteLine();
            }
        }
    }

    public class Task19
    {
        public void Calculate()
        {
            int n = 4, m = 6;
            int[,] matrix = new int[n, m];
            int value = 0;

            for (int d = 0; d < n + m - 1; d++)
            {
                int iStart = Math.Max(0, d - m + 1);
                int iEnd = Math.Min(d, n - 1);

                for (int i = iStart; i <= iEnd; i++)
                {
                    int j = d - i;
                    matrix[i, j] = value++;
                }
            }

            Console.WriteLine("Матрица с диагональным заполнением:");
            PrintMatrix(matrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],4}");
                Console.WriteLine();
            }
        }
    }

    public class Task20
    {
        public void Calculate()
        {
            int n = 2;
            int size = 2 * n + 1;
            int[,] matrix = new int[size, size];

            int x = n, y = n;
            int step = 1;
            int direction = 0;
            int stepsInDirection = 1;
            int value = 0;

            matrix[y, x] = value++;

            while (step < size)
            {
                for (int i = 0; i < stepsInDirection; i++)
                {
                    switch (direction)
                    {
                        case 0: y--; break;
                        case 1: x--; break;
                        case 2: y++; break;
                        case 3: x++; break;
                    }

                    if (x >= 0 && x < size && y >= 0 && y < size)
                        matrix[y, x] = value++;
                }

                direction = (direction + 1) % 4;
                if (direction % 2 == 0) stepsInDirection++;
                step++;
            }

            Console.WriteLine("Спиральная матрица:");
            PrintMatrix(matrix);
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],3}");
                Console.WriteLine();
            }
        }
    }

    public class Point
    {
        public double X { get; }
        public double Y { get; }
        public Point(double x, double y) { X = x; Y = y; }
    }
}