using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace _20240918
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int number;
            List<int> primes = new List<int>();
            bool success = int.TryParse(box.Text, out number);

            if (!success) // 檢查輸入是否成功解析為整數
            {
                MessageBox.Show("請輸入整數", "輸入錯誤");
            }
            else if (number < 2) // 檢查輸入是否小於 2
            {
                MessageBox.Show($"輸入的值為 {number}，小於2，請重新輸入", "輸入錯誤");
            }
            else
            {
                for (int i = 2; i <= number; i++)
                {
                    if (IsPrime(i))
                    {
                        primes.Add(i);
                    }
                }

                string primeList = $"小於 {number} 的質數為: ";
                primeList += string.Join(", ", primes); // 用逗號連接質數列表
                myblock.Text = primeList;
            }
        }

        private static bool IsPrime(int n)
        {
            if (n < 2) return false; // 0 和 1 不是質數
            for (int i = 2; i <= Math.Sqrt(n); i++) // 只檢查到 n 的平方根
            {
                if (n % i == 0)
                {
                    return false; // 發現因子，n 不是質數
                }
            }
            return true; // n 是質數
        }
    }
}
