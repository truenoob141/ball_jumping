using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Game
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Platform : MonoBehaviour, IInteractable
    {
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public bool Interact()
        {
            this.spriteRenderer.color = Random.ColorHSV();
            return true;
        }
    }
}
