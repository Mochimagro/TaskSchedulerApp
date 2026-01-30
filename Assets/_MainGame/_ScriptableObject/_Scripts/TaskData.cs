using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TaskSchedulerApp.Data
{
    public interface ITaskData
    {
		public string TaskTitle {  get; set; }
        public bool TaskStatus { get; set; }
        public Priority Priority { get; set; }
        public string TaskDetail { get; set; }

    }

    [CreateAssetMenu(fileName = "TaskData", menuName = "Installers/TaskData")]
    public class TaskData :  ScriptableObjectInstaller<TaskData>,ITaskData
    {
        [SerializeField] string _taskTitle = default;
        [SerializeField] bool _isDone = false;
        [SerializeField] Priority _priority = default;
        [SerializeField][TextArea(minLines:5,maxLines:10)] string _taskDetail = default;

        public string TaskTitle { get => _taskTitle; set => _taskTitle = value; }
        public bool TaskStatus { get => _isDone; set => _isDone = value; }
        public Priority Priority { get => _priority; set => _priority = value; }
        public string TaskDetail { get => _taskDetail; set => _taskDetail = value; }

        public override void InstallBindings()
        {
            Container.Bind<ITaskData>().FromInstance(this).AsCached();
        }
    }
}