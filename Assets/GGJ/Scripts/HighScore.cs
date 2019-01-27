using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GGJ.Scripts
{
    public class HighScore
    {
        public int Value { get; private set; }
        public HighScore()
        {
            Value = 0;
        }
        public void updateScore(int newScore)
        {
            if (Value < newScore) Value = newScore;
        }
    }
}