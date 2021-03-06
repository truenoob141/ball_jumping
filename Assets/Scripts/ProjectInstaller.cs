﻿using Project.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Project
{
    [System.Serializable]
    public class PlanetSettings
    {
        public string id;
        public float gravity;
        public Color skyColor;
    }

    public class ProjectInstaller : MonoInstaller
    {
        [System.Serializable]
        public class Settings
        {
            public List<PlanetSettings> planets;
        }

        [Inject] private Settings settings;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<OnGameStart>();

            Container.BindInterfacesAndSelfTo<SceneManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
        }
    }
}
