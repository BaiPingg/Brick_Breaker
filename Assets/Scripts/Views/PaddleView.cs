using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine;

namespace Brick_Breaker.Views
{

    public class PaddleView : View
    {
        public float speed;
        public float maxPosx = 4;
        void Update()
        {
            var hori = Input.GetAxis("Horizontal");
            var target = transform.position + new Vector3(speed * hori * Time.deltaTime, 0, 0);
            var x = Mathf.Clamp(target.x, -maxPosx, maxPosx);
            transform.position = new Vector3(x, target.y, 0);
        }
    }
}