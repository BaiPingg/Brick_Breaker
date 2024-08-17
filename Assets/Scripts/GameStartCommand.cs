using UnityEngine;

using Robotlegs.Bender.Extensions.CommandCenter.API;

namespace Brick_Breaker.Commands
{
    public class GameStartCommand : ICommand
    {
        public void Execute()
        {
           var gameenv= Resources.Load<GameObject>("gameEnv");
            GameObject.Instantiate(gameenv);
        }
    }
}
