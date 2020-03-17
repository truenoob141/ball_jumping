using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Project.Play
{
    public class GameManager
    {
        [Inject] private SceneManager sceneManager;

        public void StartGame(PlanetSettings planet)
        {
            Debug.Log("Start game, Planet " + planet.id);

            sceneManager.SwitchScene(Scenes.GAME);
        }
    }
}
