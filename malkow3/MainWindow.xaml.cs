using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace malkow3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // кнопка генерировать
        // во время генерации лучше не начинать новую генерацию
        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            // очистка списка
            NumbersListBox.Items.Clear();
            ProgressBar.Value = 0;

            if (int.TryParse(StartTextBox.Text, out int start) && int.TryParse(EndTextBox.Text, out int end) && start <= end)
            {
                // тотал количество полоска брр
                int totalNumbers = end - start + 1;
                ProgressBar.Maximum = totalNumbers;

                // тк нзв "ленивая генерация
                var numbers = GenerateNumbers(start, end);
                int count = 0;

                foreach (var number in numbers)
                {
                    // отобр числа
                    NumbersListBox.Items.Add(number);
                    count++;
                    ProgressBar.Value = count;

                    // задер_жка
                    await Task.Delay(200);
                }

                MessageBox.Show("поздравляем, генерация завершена!", "информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("пожалуйста, введи конкретный диапазон чисел", "ой, ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private IEnumerable<int> GenerateNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return i; // возврат чисел конечно
            }
        }
    }

}