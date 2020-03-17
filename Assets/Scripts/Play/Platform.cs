using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Play
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Platform : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.spriteRenderer.color = Random.ColorHSV();
        }
    }
}
