
using System;
using Robotlegs.Bender.Extensions.EventManagement.Impl;
namespace Brick_Breaker.Events
{
    public class GameProcedureEvent : Event
    {
        public GameProcedureEvent(Enum type) : base(type)
        {
        }

        public enum Type
        {
            /// <summary>
            /// 开始
            /// </summary>
            START_GAME,
            /// <summary>
            /// 结算
            /// </summary>
            SETTLEMENT,
            EXIT_GAME,
        }
    }
}