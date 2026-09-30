using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RockPaperScissorsApp
{
    public partial class MainWindow : Window
    {
        private readonly GameEngine _gameEngine = new GameEngine();
        private int _playerScore = 0;
        private int _computerScore = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnChoice_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button; // Button b = (Button)sender;

            if (button == null)
            {
                return;
            }

            GameChoice playerChoice = (GameChoice)Enum.Parse(typeof(GameChoice), button.Tag.ToString());
            GameChoice computerChoice = _gameEngine.GetComputerChoice();

            TxtPlayerVisual.Text = _gameEngine.GetEmoji(playerChoice);
            TxtComputerVisual.Text = _gameEngine.GetEmoji(computerChoice);

            GameResult result = _gameEngine.PlayRound(playerChoice, computerChoice);
            UpdateUI(result);
        }

        private void UpdateUI(GameResult result)
        {
            switch (result)
            {
                case GameResult.PlayerWins:
                    _playerScore++;
                    TxtResult.Text = "🎉 فزت في هذه الجولة!";
                    TxtResult.Foreground = new SolidColorBrush(Colors.Green);
                    break;

                case GameResult.ComputerWins:
                    _computerScore++;
                    TxtResult.Text = "💻 فاز الكمبيوتر!";
                    TxtResult.Foreground = new SolidColorBrush(Colors.Red);
                    break;

                case GameResult.Draw:
                    TxtResult.Text = "🤝 تعادل!";
                    TxtResult.Foreground = new SolidColorBrush(Colors.Gray);
                    break;
            }

            TxtPlayerScore.Text = $"أنت: {_playerScore}";
            TxtComputerScore.Text = $"الكمبيوتر: {_computerScore}";
        }
    }
}