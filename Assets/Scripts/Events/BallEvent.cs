
using System;
using Robotlegs.Bender.Extensions.EventManagement.Impl;
namespace Brick_Breaker.Events
{
    public class BallEvent : Event
    {
       
        public BallEvent(Enum type) : base(type)
        {
        }
        public enum Type
        {
            /// <summary>
            /// 发射
            /// </summary>
            FIRE,
            /// <summary>
            /// 重置位置
            /// </summary>
            RESET
        }
    }
}