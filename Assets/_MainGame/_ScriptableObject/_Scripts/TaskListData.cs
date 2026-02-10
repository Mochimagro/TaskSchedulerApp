using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace TaskSchedulerApp.Data
{
    public interface ITaskListData
    {
		IReadOnlyCollection<TaskData> TaskList { get; }
        IObservable<ITaskData> OnChangeSelectedData { get; }
        IObservable<IReadOnlyCollection<TaskData>> OnChangeListData { get; }
        void SelectData(int id);
        void CreateNewData();
    }

    [CreateAssetMenu(fileName = "TaskListDataData", menuName = "Installers/TaskListDataData")]
    public class TaskListData : ScriptableObjectInstaller<TaskListData>, ITaskListData
    {
        string _taskListDataAssetFolderpath = "Assets/_MainGame/_ScriptableObject/_Data/TaskData";
        [SerializeField]List<TaskData> _taskList;
        Subject<IReadOnlyCollection<TaskData>> _onChangeListData = new Subject<IReadOnlyCollection<TaskData>>();
        ReactiveProperty<TaskData> _selectedTaskDataReactive = new ReactiveProperty<TaskData>();
        public IReadOnlyCollection<TaskData> TaskList => _taskList;


        IObservable<ITaskData> ITaskListData.OnChangeSelectedData => _selectedTaskDataReactive;

        public IObservable<IReadOnlyCollection<TaskData>> OnChangeListData => _onChangeListData;


        public override void InstallBindings()
        {
            Container.Bind<ITaskListData>().FromInstance(this).AsCached();
        }


        public void SelectData(int id)
        {
            _selectedTaskDataReactive.Value = _taskList.Where(data => data.ID == id).First();
        }

        public void CreateNewData()
        {
            TaskData newData = ScriptableObjectInstaller.CreateInstance<TaskData>();
            newData.ID = GetNextID();
            newData.TaskTitle = "New Task";

            AssetDatabase.CreateAsset(newData, $"{_taskListDataAssetFolderpath}/{newData.ID}.asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            _taskList.Add(newData);
            _onChangeListData.OnNext(_taskList);
            
        }

        private int GetNextID()
        {
            if(_taskList == null || _taskList.Count == 0) return 0;

            return _taskList.Max(data => data.ID) + 1;
        }
    }
}