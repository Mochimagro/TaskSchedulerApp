using UnityEngine;
using Zenject;

namespace TaskSchedulerApp.Game.Installer
{
	public class TaskListInstaller : MonoInstaller 
	{
		public override void InstallBindings()
		{
            Container.BindInterfacesAndSelfTo<TaskList.TaskListModel>().FromNew().AsCached();
            Container.BindInterfacesAndSelfTo<Presenter.TaskListPresenter>().AsCached().NonLazy();
		}
	}
}