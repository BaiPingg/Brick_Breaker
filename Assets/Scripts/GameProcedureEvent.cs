
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
            START_GAME,
            EXIT_GAME,
        }
    }
}