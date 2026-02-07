using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TaskSchedulerApp.Data
{
    public interface ITaskListData
    {
		IReadOnlyCollection<TaskData> Data { get; }

    }

    [CreateAssetMenu(fileName = "TaskListDataData", menuName = "Installers/TaskListDataData")]
    public class TaskListData :  ScriptableObjectInstaller<TaskListData>,ITaskListData
    {
        [SerializeField]List<TaskData> _taskList;

        public IReadOnlyCollection<TaskData> Data => _taskList;

        public override void InstallBindings()
        {
            Container.Bind<ITaskListData>().FromInstance(this).AsCached();
        }
    }
}