using UnityEditor.ShaderGraph;
using UnityEngine;

namespace GGJ.Scripts
{
    public class Level
    {
        public int Value { get; }

        public Level(int value)
        {
            Value = value;
        }
    }
    public class HighScore
    {
        public int Value { get; private set; }

        public HighScore(int value)
        {
            Value = value;
        }

        public void UpdateHighScore(int value) => Value = Mathf.Max(value, Value);
    }
}