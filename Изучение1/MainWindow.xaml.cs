using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Изучение1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            // Создаем контейнер Grid
            Grid grid = new Grid
            {
                Margin = new Thickness(10)
            };

            Border border = new Border {
            Background = Brushes.DarkCyan,     // Фоновый цвет
            Padding = new Thickness(10),        // внутренний отступ
            CornerRadius = new CornerRadius(10)}; // скругление


            // Добавляем заголовок внутри блока
            TextBlock textBlock = new TextBlock
            {
                FontSize = 17,
                Foreground = Brushes.White,
                Text = wrapPanel.Children.Count + 1 + "." + descrition.Text,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            border.Child = textBlock;

            // Добавляем заголовок в контейнер Grid
            grid.Children.Add(border);
            wrapPanel.Children.Add(grid);


            BlockCount();

            grid.MouseRightButtonDown += Grid_MouseRightButtonDown; // Привязка обработчика события
            border.MouseLeftButtonDown += Border_MouseLeftButtonDown;
        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid grid)
            {
                // Удаление грида
                var parent = grid.Parent as Panel;
                parent.Children.Remove(grid);
                BlockCount();
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border)
            {
                // Пометка грида
                if (border.Background == Brushes.Green)  border.Background = Brushes.DarkCyan;
                else border.Background = Brushes.Green;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddItem_Click(sender, e);
                BlockCount();
            }
            if (e.Key == Key.Back)
            {
                if (wrapPanel.Children.Count > 0) { 
                    wrapPanel.Children.RemoveAt(wrapPanel.Children.Count - 1);
                    BlockCount();
                }
            }
        }

        void BlockCount()
        {
            blockTick.Text = "Кол-во блоков: " + wrapPanel.Children.Count;
        }
    }
}