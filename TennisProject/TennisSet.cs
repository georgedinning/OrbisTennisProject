using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisProject
{
    public class TennisSet
    {
        private int setNumber;
        private int player1GameCount;
        private int player2GameCount;
        public TennisSet(int setNumber)
        {
            this.setNumber = setNumber;
            player1GameCount = 0;
            player2GameCount = 0;
        }

        public void Play(IBoolPicker boolPicker, IOutputLogger outputLogger)
        {
            int setWinner;
            int gameNumber = 0;
            while ((setWinner = GetWinner()) == -1)
            {
                gameNumber++;
                TennisGame game = new TennisGame(gameNumber);
                game.Play(boolPicker, outputLogger);
                int gameWinner = game.GetWinner();
                if (gameWinner == 1)
                {
                    player1GameCount++;
                }
                else
                {
                    player2GameCount++;
                }
            }
            outputLogger.Output(String.Format("Player{0} Wins Set {1}   Player1 {2} Games - Player2 {3} Games", setWinner, this.setNumber, this.player1GameCount, this.player2GameCount));
            outputLogger.Output("");
        }
        public int GetWinner()
        {
            if (player1GameCount >= 6 && player1GameCount - player2GameCount >=2) return 1;
            if (player2GameCount >= 6 && player2GameCount - player1GameCount >= 2) return 2;
            return -1;
        }
    }
}