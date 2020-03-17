using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.Play
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class GameSky : MonoBehaviour
    {
        [Inject] private GameManager gameManager;
        [Inject] private SignalBus signalBus;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            this.signalBus.Subscribe<OnGameStart>(OnGameStart);
            OnGameStart();
        }

        private void OnDisable()
        {
            this.signalBus.Unsubscribe<OnGameStart>(OnGameStart);
        }

        private void OnGameStart()
        {
            if (!this.gameManager.IsValidGame)
                return;

            this.spriteRenderer.color = gameManager.CurrentPlanet.skyColor;
        }
    }
}
