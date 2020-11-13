using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneMassiv
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] mas;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(Razmer.Text);
                mas = new int[n];
                string st = "";
                Random rnd = new Random();
                for(int i=0;i<mas.Length;i++)
                {
                    mas[i] = rnd.Next(99)+1;//0..9
                    st += mas[i] + " ";
                }
                Result.Text ="Сгенерированный массив:"+Environment.NewLine+ st + Environment.NewLine;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int S = 0;
            long P = 1;
            foreach(int i in mas)
            {
                S += i;
                P *= i;
            }
            double Sr = (double)S / mas.Length;
            Result.Text += "Сумма Элементов массива:" + S.ToString() + Environment.NewLine;
            Result.Text += "Среднее арифметическое:" + String.Format("{0:F2}",Sr) + Environment.NewLine;
            Result.Text += "Произведение элемнтов массива:"+P.ToString()+Environment.NewLine;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int max, min;
            max = min = mas[0];
            for(int i=1;i<mas.Length;i++)
            {
                if (mas[i] > max) max = mas[i];
                if (mas[i] < min) min = mas[i];
            }
            Result.Text += "Максимальный элемент массива:" + max.ToString() + Environment.NewLine;
            Result.Text += "Минимальный элемент массива:" + min.ToString() + Environment.NewLine;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                int m = int.Parse(Ch.Text);
                if (Array.IndexOf(mas, m) == -1)
                {
                    Result.Text += "Числа " + m + " в массиве нет" + Environment.NewLine;
                }
                else
                {
                    if (Array.IndexOf(mas, m) != -1)
                        Result.Text += "Первое вхождение числа " + m + " в массив:" + Array.IndexOf(mas, m).ToString() + Environment.NewLine;

                    if (Array.LastIndexOf(mas, m) != -1)
                        Result.Text += "Последнее вхождение числа " + m + " в массив:" + Array.LastIndexOf(mas, m) + Environment.NewLine;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rb1_Checked(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<mas.Length-1;i++)
            {
                for(int j=i;j<mas.Length;j++)
                {
                    if (mas[i]>mas[j])
                    {
                        int temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            string st = "";
            foreach (int i in mas)
            {
                st +=i + " ";
            }
            Result.Text += "Отсортированный массив:" + st + Environment.NewLine;

        }

        private void rb2_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int j = i; j < mas.Length; j++)
                {
                    if (mas[i] < mas[j])
                    {
                        int temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            string st = "";
            foreach (int i in mas)
            {
                st += i + " ";
            }
            Result.Text += "Отсортированный массив:" + st + Environment.NewLine;
        }
    }
}
