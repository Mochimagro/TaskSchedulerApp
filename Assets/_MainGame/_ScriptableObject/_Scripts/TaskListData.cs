using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TaskSchedulerApp.Data
{
    public interface ITaskListData
    {
		IReadOnlyCollection<TaskData> Datas { get; }

    }

    [CreateAssetMenu(fileName = "TaskListDataData", menuName = "Installers/TaskListDataData")]
    public class TaskListData :  ScriptableObjectInstaller<TaskListData>,ITaskListData
    {
        [SerializeField]List<TaskData> _taskList;

        public IReadOnlyCollection<TaskData> Datas => _taskList;

        public override void InstallBindings()
        {
            Container.Bind<ITaskListData>().FromInstance(this).AsCached();
        }
    }
}