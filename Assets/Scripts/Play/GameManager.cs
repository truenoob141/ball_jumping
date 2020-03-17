using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Project.Play
{
    public class OnGameStart { }

    public class GameManager
    {
        public bool IsValidGame { get; private set; }
        public PlanetSettings CurrentPlanet { get; private set; }

        public int Score
        {
            get
            {
                return PlayerPrefs.GetInt("score");
            }
            private set
            {
                PlayerPrefs.SetInt("score", value);
            }
        }

        [Inject] private SceneManager sceneManager;

        private SignalBus signalBus;

        public GameManager(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void StartGame(PlanetSettings planet)
        {
            Debug.Log("Start game, Planet " + planet.id);

            Physics2D.gravity = Vector2.down * planet.gravity;

            this.CurrentPlanet = planet;
            this.IsValidGame = true;

            sceneManager.SwitchScene(Scenes.GAME);

            this.signalBus.Fire(new OnGameStart());
        }
    
        public void AddScore()
        {
            ++this.Score;
        }
    }
}
