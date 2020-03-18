using UnityEngine;
using Zenject;

namespace Project
{
    public class GameScene : MonoBehaviour, IGameScene
    {
        [SerializeField]
        private bool isDefault;

        public bool IsDefaultScene => this.isDefault;
        public string SceneId => this.name;

        [Inject] private SceneManager sceneManager;

        private void Awake()
        {
            Deactivate();

            sceneManager.RegisterScene(this);
        }

        private void OnDestroy()
        {
            sceneManager.UnregisterScene(this);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}
