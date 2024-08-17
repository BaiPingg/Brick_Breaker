
using System;
using Robotlegs.Bender.Extensions.EventManagement.Impl;
namespace Brick_Breaker.Events
{
    public class GridEvent : Event
    {
        public int x;
        public int y;
        public GridEvent(Enum type, int x,int y) : base(type)
        {
            this.x = x;
            this.y = y;
        }
        
        public enum Type
        {   
            /// <summary>
            /// 销毁网格
            /// </summary>
            DestroyGridItem,
            /// <summary>
            /// 销毁砖块
            /// </summary>
            DestroyBrick,
        }
    }
}