using Robotlegs.Bender.Extensions.Mediation.API;
using System;
using Brick_Breaker.Views;
using Brick_Breaker.Events;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Bundles.MVCS;

namespace Brick_Breaker.Mediators
{
  public   class BallMediator : Mediator
    {
        [Inject]
        public IEventDispatcher dispatcher;

        [Inject]
        public BallView  view;


        public override void Destroy()
        {
            base.Destroy();

            RemoveViewListener(RoundEvent.Type.ADD_ROUND, Dispatch);
            dispatcher.RemoveEventListener(BallEvent.Type.FIRE, Fire);
            dispatcher.RemoveEventListener(BallEvent.Type.RESET, Settlement);
        }
        
        public override void Initialize()
        {
            AddViewListener(RoundEvent.Type.ADD_ROUND, Dispatch);
            dispatcher.AddEventListener(BallEvent.Type.FIRE, Fire);
            dispatcher.AddEventListener(BallEvent.Type.RESET, Settlement);
        }

        private void Fire(IEvent e)
        {
            view.Fire();
        }
        private void Settlement(IEvent e)
        {
            view.Reset();
        }


    }
}
