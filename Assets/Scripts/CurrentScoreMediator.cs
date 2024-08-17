using Robotlegs.Bender.Extensions.Mediation.API;
using System;
using Brick_Breaker.Views;
using Brick_Breaker.Events;
using Robotlegs.Bender.Extensions.EventManagement.API;

namespace Brick_Breaker.Mediators
{
  public   class CurrentScoreMediator  : IMediator
    {
        [Inject]
        public IEventDispatcher dispatcher;

        [Inject]
        public CurrentScoreView  view;

        [Inject]
        public void Destroy()
        {
        }

        public void Initialize()
        {
            dispatcher.AddEventListener(CurrentScoreEvent.Type.SCORE_UPDATE, ScoreChange);
        }

        private void ScoreChange(IEvent e)
        {
            view.SetNumbe((e as CurrentScoreEvent).currentScore);
        }

     
    }
}
