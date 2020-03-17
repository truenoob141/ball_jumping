using Project.Play;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project
{
    [RequireComponent(typeof(Button))]
    public class PlayButton : MonoBehaviour
    {
        [SerializeField]
        private string planetId;

        [Inject] private GameManager gameManager;
        [Inject] private ProjectInstaller.Settings settings;

        private Button button;

        private void Awake()
        {
            this.button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            this.button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            this.button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            var planet = settings.planets.FirstOrDefault(p => p.id == this.planetId);
            if (planet == null)
                throw new ArgumentException($"Planet '{this.planetId}' not found");

            gameManager.StartGame(planet);
        }
    }
}
