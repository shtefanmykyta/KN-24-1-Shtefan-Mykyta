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

namespace ЛБ6_СМООП_
{
    public partial class MainWindow : Window
    {
      
    public partial class Game2048Window : Window
    {
        private int[,] _grid = new int[4, 4];
        private Random _random = new Random();
        private int _score = 0;

        public Game2048Window()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            Array.Clear(_grid, 0, _grid.Length);
            _score = 0;
            UpdateScore();
            AddRandomTile();
            AddRandomTile();
            UpdateGrid();
        }

        private void AddRandomTile()
        {
            var emptyCells = new System.Collections.Generic.List<(int, int)>();
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (_grid[row, col] == 0)
                        emptyCells.Add((row, col));
                }
            }

            if (emptyCells.Count > 0)
            {
                var cell = emptyCells[_random.Next(emptyCells.Count)];
                _grid[cell.Item1, cell.Item2] = _random.NextDouble() < 0.9 ? 2 : 4;
            }
        }

        private void UpdateGrid()
        {
            GameGrid.Children.Clear();
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    var textBlock = new TextBlock
                    {
                        Text = _grid[row, col] == 0 ? "" : _grid[row, col].ToString(),
                        FontSize = 24,
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(5),
                        Background = GetTileColor(_grid[row, col])
                    };
                    GameGrid.Children.Add(textBlock);
                }
            }
        }

        private Brush GetTileColor(int value)
        {
            return value switch
            {
                0 => new SolidColorBrush(Color.FromRgb(205, 193, 180)),
                2 => new SolidColorBrush(Color.FromRgb(238, 228, 218)),
                4 => new SolidColorBrush(Color.FromRgb(237, 224, 200)),
                8 => new SolidColorBrush(Color.FromRgb(242, 177, 121)),
                16 => new SolidColorBrush(Color.FromRgb(245, 149, 99)),
                32 => new SolidColorBrush(Color.FromRgb(246, 124, 95)),
                64 => new SolidColorBrush(Color.FromRgb(246, 94, 59)),
                128 => new SolidColorBrush(Color.FromRgb(237, 207, 114)),
                256 => new SolidColorBrush(Color.FromRgb(237, 204, 97)),
                512 => new SolidColorBrush(Color.FromRgb(237, 200, 80)),
                1024 => new SolidColorBrush(Color.FromRgb(237, 197, 63)),
                2048 => new SolidColorBrush(Color.FromRgb(237, 194, 46)),
                _ => Brushes.Gold
            };
        }

        private void MoveLeft()
        {
            bool moved = false;
            for (int row = 0; row < 4; row++)
            {
                var line = CompressLine(GetRow(row));
                if (!line.SequenceEqual(GetRow(row)))
                    moved = true;
                SetRow(row, line);
            }
            if (moved)
            {
                AddRandomTile();
                UpdateScore();
            }
            UpdateGrid();
        }

        private int[] GetRow(int row)
        {
            return new[] { _grid[row, 0], _grid[row, 1], _grid[row, 2], _grid[row, 3] };
        }

        private void SetRow(int row, int[] values)
        {
            for (int col = 0; col < 4; col++)
                _grid[row, col] = values[col];
        }

        private int[] CompressLine(int[] line)
        {
            // Удаляем нули
            var compressed = line.Where(x => x != 0).ToArray();
            for (int i = 0; i < compressed.Length - 1; i++)
            {
                if (compressed[i] == compressed[i + 1])
                {
                    compressed[i] *= 2;
                    _score += compressed[i];
                    for (int j = i + 1; j < compressed.Length - 1; j++)
                        compressed[j] = compressed[j + 1];
                    compressed[^1] = 0;
                }
            }
            return compressed.Concat(new int[4 - compressed.Length]).ToArray();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: MoveLeft(); break;
                case Key.Right: /* MoveRight() */ break;
                case Key.Up: /* MoveUp() */ break;
                case Key.Down: /* MoveDown() */ break;
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void UpdateScore()
        {
            ScoreTextBlock.Text = $"Рахунок: {_score}";
        }
    }

}
}
