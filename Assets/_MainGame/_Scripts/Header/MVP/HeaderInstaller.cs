using UnityEngine;
using Zenject;

namespace TaskSchedulerApp.Game.Installer
{
	public class HeaderInstaller : MonoInstaller 
	{
		public override void InstallBindings()
		{
            Container.BindInterfacesAndSelfTo<Header.HeaderModel>().FromNew().AsCached();
            Container.BindInterfacesAndSelfTo<Presenter.HeaderPresenter>().AsCached().NonLazy();
		}
	}
}