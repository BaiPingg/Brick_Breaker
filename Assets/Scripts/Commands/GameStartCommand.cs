using UnityEngine;
using Brick_Breaker.Models;
using Robotlegs.Bender.Extensions.CommandCenter.API;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Brick_Breaker.Events;
using Cysharp.Threading.Tasks;

namespace Brick_Breaker.Commands
{
    public class GameStartCommand : ICommand
    {
        [Inject] public ScoreModel scoreModel;
        [Inject] public RoundModel roundModel;
        [Inject] public GridModel GridModel;

        [Inject] public IEventDispatcher dispatcher;
        public async void Execute()
        {
            var gameenv = Resources.Load<GameObject>("GameEnv");
            GameObject.Instantiate(gameenv);
            scoreModel.maxScore = PlayerPrefs.GetInt(AppConst.MAX_SCORE, 0);
            scoreModel.currentScore = 0;
            dispatcher.Dispatch(new CurrentScoreEvent(CurrentScoreEvent.Type.SCORE_UPDATE, scoreModel.currentScore));
            dispatcher.Dispatch(new MaxScoreEvent(MaxScoreEvent.Type.MAX_SCORE_UPDATE, scoreModel.maxScore));

            roundModel.currentRound = 0;
            dispatcher.Dispatch(new RoundEvent(RoundEvent.Type.ROUND_UPDATE, roundModel.currentRound));

            GridModel.GenerateBricks(5, Random.Range(5, 7), 1, GameObject.FindGameObjectWithTag("BrickRoot"));
            await GridModel.GenerateItems();
            await UniTask.WaitForSeconds(1);
            dispatcher.Dispatch(new BallEvent(BallEvent.Type.RESET));
            dispatcher.Dispatch(new BallEvent(BallEvent.Type.FIRE));

        }
    }
}
