using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.Play
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [Inject] private GameManager gameManager;

        private Rigidbody2D body;

        private void Awake()
        {
            this.body = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Interact
            var interact = collision.collider.GetComponent<IInteractable>();
            if (interact != null && interact.Interact())
            {
                gameManager.AddScore();
            }

            // Bounce
            // Use normal for angular bounce
            Vector2 normal = collision.contacts[0].normal;

            Vector2 vel = body.velocity;
            vel.x += collision.relativeVelocity.x * -Mathf.Abs(normal.x);
            vel.y += Physics2D.gravity.y * normal.y;

            this.body.velocity = Vector2.Reflect(vel, normal);
        }

        private void Update()
        {
            // Simple old input
            // FIXME Replace to new input system
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                var worldPos = Camera.main.ScreenToWorldPoint(touch.position);
#endif

                float dir = Mathf.Sign(worldPos.x - transform.position.x);
                this.body.AddForce(Vector2.right * dir);
            }
        }
    }
}
