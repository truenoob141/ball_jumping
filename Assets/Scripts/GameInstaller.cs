using UnityEngine;
using Zenject;

namespace Project
{
    [CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller")]
    public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
    {
        public ProjectInstaller.Settings settings;

        public override void InstallBindings()
        {
            Container.BindInstance(this.settings);
        }
    }
}
