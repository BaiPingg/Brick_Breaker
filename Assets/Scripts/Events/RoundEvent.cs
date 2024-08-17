
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
        public RoundEvent(Enum type) : base(type)
        {
        }
        public enum Type
        {
            ADD_ROUND,
            ROUND_UPDATE
        }
    }
}