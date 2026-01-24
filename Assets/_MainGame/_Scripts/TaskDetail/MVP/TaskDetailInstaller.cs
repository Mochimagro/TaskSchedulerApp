using UnityEngine;
using Zenject;

namespace TaskSchedulerApp.Game.Installer
{
	public class TaskDetailInstaller : MonoInstaller 
	{
		public override void InstallBindings()
		{
            Container.BindInterfacesAndSelfTo<TaskDetail.TaskDetailModel>().FromNew().AsCached();
            Container.BindInterfacesAndSelfTo<Presenter.TaskDetailPresenter>().AsCached().NonLazy();
		}
	}
}