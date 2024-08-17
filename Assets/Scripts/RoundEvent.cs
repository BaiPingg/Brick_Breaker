
using System;
using Robotlegs.Bender.Extensions.EventManagement.Impl;
namespace Brick_Breaker.Events
{
    public class RoundEvent : Event
    {
        public int round;
        public RoundEvent(Enum type, int round) : base(type)
        {
            this.round = round;
        }

        public enum Type
        {
            ROUND_CHANGE,
            ROUND_UPDATE
        }
    }
}