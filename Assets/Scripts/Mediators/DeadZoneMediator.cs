using Robotlegs.Bender.Extensions.Mediation.API;
using System;
using Brick_Breaker.Views;
using Brick_Breaker.Events;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Bundles.MVCS;

namespace Brick_Breaker.Mediators
{
  public   class DeadZoneMediator : Mediator
    {
        [Inject]
        public IEventDispatcher dispatcher;

        [Inject]
        public DeadZoneView  view;

        public override void Destroy()
        {
            base.Destroy();

            RemoveViewListener(GameProcedureEvent.Type.SETTLEMENT, Dispatch);
        }
        
        public override void Initialize()
        {
            AddViewListener(GameProcedureEvent.Type.SETTLEMENT, Dispatch);
        }
       
    }
}
