using UnityEngine;
using Zenject;

namespace MVPTemplateEditor.Game.Installer
{
	public class OutGameSampleInstaller : MonoInstaller 
	{
		public override void InstallBindings()
		{
            Container.BindInterfacesAndSelfTo<OutGameSample.OutGameSampleModel>().FromNew().AsCached();
            Container.BindInterfacesAndSelfTo<Presenter.OutGameSamplePresenter>().AsCached().NonLazy();
		}
	}
}