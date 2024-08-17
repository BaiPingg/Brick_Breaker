using Robotlegs.Bender.Extensions.Mediation.API;
using System;
using Brick_Breaker.Views;
using Brick_Breaker.Events;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Brick_Breaker.Models;

namespace Brick_Breaker.Mediators
{
    public class CurrentScoreMediator : IMediator
    {
        [Inject]
        public IEventDispatcher dispatcher;

        [Inject]
        public CurrentScoreView view;
        [Inject]
        public ScoreModel scoreModel;
        public void Destroy()
        {
            dispatcher.RemoveEventListener(CurrentScoreEvent.Type.SCORE_UPDATE, ScoreChange);
        }

        public void Initialize()
        {
            dispatcher.AddEventListener(CurrentScoreEvent.Type.SCORE_UPDATE, ScoreChange);
            view.SetNumbe(scoreModel.currentScore);
        }

        private void ScoreChange(IEvent e)
        {
            view.SetNumbe((e as CurrentScoreEvent).currentScore);
        }
    }
}
