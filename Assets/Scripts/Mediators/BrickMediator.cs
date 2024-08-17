using Brick_Breaker.Views;
using Brick_Breaker.Events;
using Robotlegs.Bender.Extensions.EventManagement.API;
using Robotlegs.Bender.Bundles.MVCS;

namespace Brick_Breaker.Mediators
{
  public   class BrickMediator : Mediator
    {
        [Inject]
        public IEventDispatcher dispatcher;

        [Inject]
        public BrickView  view;


        public override void Destroy()
        {
            base.PostDestroy();
            RemoveViewListener(GridEvent.Type.DestroyGridItem, Dispatch);
            dispatcher.RemoveEventListener(GridEvent.Type.DestroyBrick, Fire);
        }

        public override void Initialize()
        {
            base.Initialize();
            AddViewListener(GridEvent.Type.DestroyGridItem, Dispatch);
            dispatcher.AddEventListener(GridEvent.Type.DestroyBrick, Fire);
        }

        private void Fire(IEvent e)
        {
            if (e is GridEvent ee)
            {
                if (view.x ==ee.x&& view.y == ee.y)
                {
                    view.DestroyObj();
                }
            }
            
        }


    }
}
