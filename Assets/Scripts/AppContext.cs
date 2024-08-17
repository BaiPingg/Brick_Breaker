using Robotlegs.Bender.Framework.API;
using Robotlegs.Bender.Framework.Impl;
using Robotlegs.Bender.Platforms.Unity.Bundles;
using Robotlegs.Bender.Platforms.Unity.Extensions.ContextViews.Impl;
using UnityEngine;


namespace Brick_Breaker
{
    public class AppContext : MonoBehaviour
    {
        IContext context;

        private void Start()
        {
            context = new Context()
             .Install<UnitySingleContextBundle>().Configure<AppConfig>()
             .Configure(new TransformContextView(transform));
        }
    }
}