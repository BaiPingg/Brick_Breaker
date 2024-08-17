using UnityEngine;
using Brick_Breaker.Models;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Brick_Breaker.Events;
using Cysharp.Threading.Tasks;

namespace Brick_Breaker.Commands
{   
    /// <summary>
    /// 开始结算指令
    /// </summary>
    public class GameSettlementCommand : ICommand
    {
        [Inject] public ScoreModel scoreModel;
        [Inject] public RoundModel roundModel;
        [Inject] public GridModel GridModel;

        [Inject] public IEventDispatcher dispatcher;
        public void Execute()
        {
            if (scoreModel.currentScore > scoreModel.maxScore)
            {
                scoreModel.maxScore = scoreModel.currentScore;
                PlayerPrefs.SetInt(AppConst.MAX_SCORE, scoreModel.maxScore);
                dispatcher.Dispatch(new MaxScoreEvent(MaxScoreEvent.Type.MAX_SCORE_UPDATE, scoreModel.maxScore));
            }
            dispatcher.Dispatch(new BallEvent(BallEvent.Type.RESET));
            GameObject.Destroy(GameObject.Find("GameEnv(Clone)"));

            var gameenv = Resources.Load<GameObject>("Settlement");
            GameObject.Instantiate(gameenv, GameObject.Find("Canvas").transform);

        }
    }
}
