using Robotlegs.Bender.Platforms.Unity.Extensions.Mediation.Impl;
using UnityEngine;
using Brick_Breaker.Events;
using System;

namespace Brick_Breaker.Views
{
    public class BallView : EventView
    {

        public float ballSpeed = 6f; 
        private Rigidbody2D rb;
        private Vector3 originPos;
        protected override void Start()
        {
            base.Start();
            originPos = transform.position;
            rb = GetComponent<Rigidbody2D>();
            
        }

        public void Fire()
        {
            rb.velocity = Vector2.up * ballSpeed;
            dispatcher.Dispatch(new RoundEvent(RoundEvent.Type.ADD_ROUND));
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("Brick"))
            {
                Vector2 reflection = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
                rb.velocity = reflection.normalized * ballSpeed;
            }

            if (collision.gameObject.CompareTag("Paddle"))
            {
                dispatcher.Dispatch(new RoundEvent(RoundEvent.Type.ADD_ROUND));
            }
        }

        public void Reset()
        {
            transform.position = originPos;
            rb.velocity = Vector3.zero;

        }
    }
}
