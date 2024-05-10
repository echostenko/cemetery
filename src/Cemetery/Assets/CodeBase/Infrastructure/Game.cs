using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public readonly StateMachine StateMachine;
        public static IInputService InputService;

        public Game()
        {
            StateMachine = new StateMachine();
        }
    }
}