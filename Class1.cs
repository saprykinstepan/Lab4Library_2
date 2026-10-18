using System;
using System.Text;

namespace Lab4Library
{
    public static class Class1
    {
        // Подзадание 1: Генерация массивов по правилу
        public static void SubTask1_Calculate(int n, int rows, int cols, out double[] arr1D, out double[,] arr2D)
        {
            arr1D = new double[n];
            arr2D = new double[rows, cols];
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                int k = rand.Next(1, 4);
                arr1D[i] = (Math.Pow(2, k) * Math.Sqrt(n)) / Math.Pow(n, k);
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int k = rand.Next(1, 4);
                    arr2D[i, j] = (Math.Pow(2, k) * Math.Sqrt(rows)) / Math.Pow(rows, k);
                }
            }
        }

        // Подзадание 2: Поиск минимума и прибавление его ко всем элементам
        public static double SubTask2_ProcessArray(double[] arr)
        {
            double min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += min;
            }

            return min; // Возвращаем найденный минимум
        }

        // Подзадание 3: Вычисление суммы элементов выше побочной диагонали
        public static int SubTask3_SumAboveAntiDiagonal(int[,] matrix, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + j < n - 1)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            return sum;
        }

        // Подзадание 4: Сортировка методом прямого включения
        public static void SubTask4_Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
    }
    public class DataManager
    {
        private string[][] dataArray;

        public DataManager()
        {
            dataArray = new string[3][];
            dataArray[0] = new string[3]; // Человек
            dataArray[1] = new string[4]; // Автомобиль
            dataArray[2] = new string[5]; // Здание
        }

        private bool IsValidText(string text)
        {
            // Проверка на пустоту
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            // Проверка на наличие цифр
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return false;
                }
            }

            return true; 
        }


        // --- МЕТОДЫ С ПРОВЕРКОЙ ---

        public bool SetPerson(string fio, string age, string gender)
        {
            // Проверяем ФИО и Пол
            if (IsValidText(fio) == false)
            {
                return false;
            }

            if (IsValidText(gender) == false)
            {
                return false;
            }

            // Проверка возраста
            int ageNumber;
            if (!int.TryParse(age, out ageNumber) || ageNumber <= 0 || ageNumber > 100)
            {
                return false;
            }

            dataArray[0][0] = fio;
            dataArray[0][1] = age;
            dataArray[0][2] = gender;
            return true;
        }

        public bool SetCar(string brand, string model, string year, string color)
        {
            // Проверяем Марку, Модель и Цвет
            if (IsValidText(brand) == false)
            {
                return false;
            }

            if (IsValidText(model) == false)
            {
                return false;
            }

            if (IsValidText(color) == false)
            {
                return false;
            }

            // Проверка года
            int yearNumber;
            if (!int.TryParse(year, out yearNumber) || yearNumber < 1885 || yearNumber > 2026)
            {
                return false;
            }

            dataArray[1][0] = brand;
            dataArray[1][1] = model;
            dataArray[1][2] = year;
            dataArray[1][3] = color;
            return true;
        }

        public bool SetBuilding(string address, string floors, string area, string yearBuilt, string purpose)
        {
            // Проверяем Адрес и Назначение
            if (IsValidText(address) == false)
            {
                return false;
            }

            if (IsValidText(purpose) == false)
            {
                return false;
            }

            // Проверка этажей
            int floorsNumber;
            if (!int.TryParse(floors, out floorsNumber) || floorsNumber <= 0)
            {
                return false;
            }

            // Проверка площади
            double areaNumber;
            if (!double.TryParse(area, out areaNumber) || areaNumber <= 0)
            {
                return false;
            }

            dataArray[2][0] = address;
            dataArray[2][1] = floors;
            dataArray[2][2] = area;
            dataArray[2][3] = yearBuilt;
            dataArray[2][4] = purpose;
            return true;
        }

        // --- Вывод данных ---
        public string GetPersonInfo()
        {
            return "ФИО: " + dataArray[0][0] + ", Возраст: " + dataArray[0][1] + ", Пол: " + dataArray[0][2];
        }

        public string GetCarInfo()
        {
            return "Марка: " + dataArray[1][0] + ", Модель: " + dataArray[1][1] + ", Год: " + dataArray[1][2] + ", Цвет: " + dataArray[1][3];
        }

        public string GetBuildingInfo()
        {
            return "Адрес: " + dataArray[2][0] + ", Этажей: " + dataArray[2][1] + ", Площадь: " + dataArray[2][2] + ", Год: " + dataArray[2][3] + ", Назначение: " + dataArray[2][4];
        }

        public string GetAllDataAsString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--- ЧЕЛОВЕК ---");
            sb.AppendLine(GetPersonInfo());
            sb.AppendLine();
            sb.AppendLine("--- ЛЕГКОВОЙ АВТОМОБИЛЬ ---");
            sb.AppendLine(GetCarInfo());
            sb.AppendLine();
            sb.AppendLine("--- АДМИНИСТРАТИВНОЕ ЗДАНИЕ ---");
            sb.AppendLine(GetBuildingInfo());
            return sb.ToString();
        }
    }
}