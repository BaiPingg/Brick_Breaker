using Robotlegs.Bender.Extensions.Mediation.API;
using System;
using Brick_Breaker.Views;
using Brick_Breaker.Events;
using Robotlegs.Bender.Extensions.EventManagement.API;

namespace Brick_Breaker.Mediators
{
  public   class RoundMediator : IMediator
    {
        [Inject]
        public IEventDispatcher dispatcher;

        [Inject]
        public RoundView  view;

        
        public void Destroy()
        {

            dispatcher.RemoveEventListener(RoundEvent.Type.ROUND_UPDATE, ScoreChange);
        }

        public void Initialize()
        {
            dispatcher.AddEventListener(RoundEvent.Type.ROUND_UPDATE, ScoreChange);
        }

        private void ScoreChange(IEvent e)
        {
            view.SetNumbe((e as RoundEvent).round);
        }

     
    }
}
