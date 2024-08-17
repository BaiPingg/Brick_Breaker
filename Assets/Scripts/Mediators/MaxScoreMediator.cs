using Robotlegs.Bender.Extensions.Mediation.API;
using System;
using Brick_Breaker.Views;
using Brick_Breaker.Events;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Brick_Breaker.Models;

namespace Brick_Breaker.Mediators
{
    public class MaxScoreMediator : IMediator
    {
        [Inject]
        public IEventDispatcher dispatcher;

        [Inject]
        public MaxScoreView view;
        [Inject]
        public ScoreModel scoreModel;

        public void Destroy()
        {
            dispatcher.RemoveEventListener(MaxScoreEvent.Type.MAX_SCORE_UPDATE, ScoreChange);
        }


        public void Initialize()
        {
            dispatcher.AddEventListener(MaxScoreEvent.Type.MAX_SCORE_UPDATE, ScoreChange);
            view.SetNumbe(scoreModel.maxScore);
        }

        private void ScoreChange(IEvent e)
        {
            view.SetNumbe((e as MaxScoreEvent).maxScore);
        }


    }
}
