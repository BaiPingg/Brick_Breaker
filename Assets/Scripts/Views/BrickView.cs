using Brick_Breaker.Events;
using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;


namespace Brick_Breaker.Views
{

    public class BrickView : EventView
    {
        public int x, y;

        private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
        {
            dispatcher.Dispatch(new GridEvent(GridEvent.Type.DestroyGridItem, x, y));
        }
        public void DestroyObj()
        {
            Destroy(gameObject);
        }
    }
}
