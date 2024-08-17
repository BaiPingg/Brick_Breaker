using Robotlegs.Bender.Extensions.Mediation.API;
using System;
using Brick_Breaker.Views;
using Brick_Breaker.Events;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Bundles.MVCS;

namespace Brick_Breaker.Mediators
{
    public class SettlementMediator : Mediator
    {
        [Inject]
        public IEventDispatcher dispatcher;

        [Inject]
        public SettlementView view;


        public override void Destroy()
        {
            RemoveViewListener(GameProcedureEvent.Type.START_GAME, Dispatch);
        }

        public override void Initialize()
        {
            AddViewListener(GameProcedureEvent.Type.START_GAME, Dispatch);
        }


    }
}
