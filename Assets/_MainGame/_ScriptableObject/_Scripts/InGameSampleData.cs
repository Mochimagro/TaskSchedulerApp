using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MVPTemplateEditor.Data
{

    public interface IInGameSampleData
    {
        int DefaultValue { get; }
    }

    [CreateAssetMenu(fileName = "InGameSampleData", menuName = "Installers/InGameSampleData")]
    public class InGameSampleData :  ScriptableObjectInstaller<InGameSampleData>,IInGameSampleData
    {
        [SerializeField] int _defaultValue = default;

        public int DefaultValue { get => _defaultValue; }

        public override void InstallBindings()
        {
            Container.Bind<IInGameSampleData>().FromInstance(this).AsCached();
        }
    }
}