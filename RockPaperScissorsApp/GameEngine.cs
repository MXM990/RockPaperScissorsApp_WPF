using System;

namespace RockPaperScissorsApp
{
    public class GameEngine
    {
        private readonly Random _random = new Random();

        public GameChoice GetComputerChoice()
        {
            Array values = Enum.GetValues(typeof(GameChoice));
            return (GameChoice)values.GetValue(_random.Next(values.Length));
        }

        public GameResult PlayRound(GameChoice playerChoice, GameChoice computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return GameResult.Draw;
            }
            if ((playerChoice == GameChoice.Rock && computerChoice == GameChoice.Scissors) ||
                (playerChoice == GameChoice.Paper && computerChoice == GameChoice.Rock) ||
                (playerChoice == GameChoice.Scissors && computerChoice == GameChoice.Paper))
            {
                return GameResult.PlayerWins;
            }

            return GameResult.ComputerWins;
        }

        public string GetEmoji(GameChoice choice)
        {
            switch (choice)
            {
                case GameChoice.Rock: 
                    return "🌑";
                case GameChoice.Paper:
                    return "📄";
                case GameChoice.Scissors: 
                    return "✂️";
                default: return "";
            }
        }
    }
}