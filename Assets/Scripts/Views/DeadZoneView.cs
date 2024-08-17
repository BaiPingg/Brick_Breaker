using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine;
using Brick_Breaker.Events;

namespace Brick_Breaker.Views
{
    public class DeadZoneView : EventView
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            dispatcher.Dispatch(new GameProcedureEvent(GameProcedureEvent.Type.SETTLEMENT));
        }
    }
}
