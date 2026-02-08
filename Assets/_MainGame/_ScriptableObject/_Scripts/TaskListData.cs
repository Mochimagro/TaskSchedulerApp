using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

namespace TaskSchedulerApp.Data
{
    public interface ITaskListData
    {
		IReadOnlyCollection<TaskData> TaskList { get; }
        void SelectData(int id);
        IObservable<ITaskData> OnChangeSelectedData { get; }
    }

    [CreateAssetMenu(fileName = "TaskListDataData", menuName = "Installers/TaskListDataData")]
    public class TaskListData :  ScriptableObjectInstaller<TaskListData>,ITaskListData
    {
        [SerializeField]List<TaskData> _taskList;

        public IReadOnlyCollection<TaskData> TaskList => _taskList;

        IObservable<ITaskData> ITaskListData.OnChangeSelectedData => _selectedTaskDataReactive;

        ReactiveProperty<TaskData> _selectedTaskDataReactive = new ReactiveProperty<TaskData>();


        public override void InstallBindings()
        {
            Container.Bind<ITaskListData>().FromInstance(this).AsCached();
        }

        public void SelectData(int id)
        {
            _selectedTaskDataReactive.Value = _taskList.Where(data => data.ID == id).First();
        }
    }
}