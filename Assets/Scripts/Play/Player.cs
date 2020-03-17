using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Play
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1f;

        private Rigidbody2D body;

        private void Awake()
        {
            this.body = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Use normal for angular bounce
            Vector2 normal = collision.contacts[0].normal;

            Vector2 vel = body.velocity;
            vel.x += collision.relativeVelocity.x * -Mathf.Abs(normal.x);
            vel.y += Physics2D.gravity.y * normal.y;

            this.body.velocity = Vector2.Reflect(vel, normal);
        }

        private void Update()
        {
            // FIXME Debug
            if (Input.GetKey(KeyCode.A))
            {
                this.body.AddForce(Vector2.left * speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.body.AddForce(Vector2.right * speed);
            }
        }
    }
}
