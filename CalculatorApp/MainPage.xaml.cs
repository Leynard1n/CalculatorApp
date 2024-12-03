using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<string> _history;

        public MainPage()
        {
            InitializeComponent();
            _history = new ObservableCollection<string>();
            HistoryCollectionView.ItemsSource = _history;
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                var result = EvaluateExpression(InputEntry.Text);
                ResultLabel.Text = $"Результат: {result}";

                // Добавление в историю
                _history.Add($"{InputEntry.Text} = {result}");
                InputEntry.Text = string.Empty; // Очистка поля ввода
            }
            catch (Exception ex)
            {
                ResultLabel.Text = $"Ошибка: {ex.Message}";
            }
        }

        private double EvaluateExpression(string expression)
        {
            // Простой парсер для арифметических выражений
            var dataTable = new System.Data.DataTable();
            return Convert.ToDouble(dataTable.Compute(expression, string.Empty));
        }
    }
}