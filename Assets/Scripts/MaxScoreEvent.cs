
using System;
using Robotlegs.Bender.Extensions.EventManagement.Impl;
namespace Brick_Breaker.Events
{
    public class MaxScoreEvent : Event
    {
        public int maxScore;
        public MaxScoreEvent(Enum type, int maxScore) : base(type)
        {
            this.maxScore = maxScore;
        }

        public enum Type
        {
            MAX_SCORE_CHANGE,
            MAX_SCORE_UPDATE
        }
    }
}