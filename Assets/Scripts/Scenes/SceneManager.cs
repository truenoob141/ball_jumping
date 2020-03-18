using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project
{
    public interface IGameScene
    {
        bool IsDefaultScene { get; }
        string SceneId { get; }

        void Activate();
        void Deactivate();
    }

    public class SceneManager
    {
        private IGameScene currentScene;
        private List<IGameScene> scenes = new List<IGameScene>();

        public void RegisterScene(IGameScene scene)
        {
            this.scenes.Add(scene);

            if (this.currentScene == null && scene.IsDefaultScene)
            {
                SwitchScene(scene);
            }
        }

        public void UnregisterScene(IGameScene scene)
        {
            this.scenes.Remove(scene);
        }

        public void SwitchScene(string sceneName)
        {
            var scene = this.scenes.FirstOrDefault(s => s.SceneId == sceneName);
            if (scene == null)
                throw new ArgumentException($"Scene '{sceneName}' not found");

            SwitchScene(scene);
        }

        private void SwitchScene(IGameScene scene)
        {
            if (scene == currentScene)
                return;

            if (currentScene != null)
            {
                currentScene.Deactivate();
                Debug.Log($"Switch scene from {currentScene.SceneId} to {scene.SceneId}");
            }
            else
            {
                Debug.Log("Switch scene to " + scene.SceneId);
            }

            currentScene = scene;
            currentScene.Activate();
        }
    }
}
