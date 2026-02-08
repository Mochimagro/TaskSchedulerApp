using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using TaskSchedulerApp.Data;

namespace TaskSchedulerApp.Game.TaskList
{
	public interface ITaskListModel
    {
		List<TaskNameItem> GetTaskList { get; }
		void SetSelectTask(int id);
    }


	public class TaskListModel : ITaskListModel
	{
		ITaskListData _taskListData = null;

		public TaskListModel(ITaskListData taskListData)
		{
			_taskListData = taskListData;

		}

		public List<TaskNameItem> GetTaskList => _taskListData.TaskList.Select((data) => new TaskNameItem(data.TaskTitle, data.ID)).ToList();

        public void SetSelectTask(int id) => _taskListData.SelectData(id);
    }
}