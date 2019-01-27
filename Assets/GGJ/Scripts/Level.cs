
using UnityEngine;
using UnityEngine.UI;
using Zenject;

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
}