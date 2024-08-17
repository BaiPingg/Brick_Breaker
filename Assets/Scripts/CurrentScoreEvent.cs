
using System;
using Robotlegs.Bender.Extensions.EventManagement.Impl;
namespace Brick_Breaker.Events
{
    public class CurrentScoreEvent : Event
    {
        public int currentScore;
        public CurrentScoreEvent(Enum type,int currentScore) : base(type)
        {
            this.currentScore = currentScore;
        }

        public enum Type
        {
            SCORE_CHANGE,
            SCORE_UPDATE
        }
    }
}