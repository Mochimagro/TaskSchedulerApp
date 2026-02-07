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

    }


	public class TaskListModel : ITaskListModel
	{
		ITaskListData _taskListData = null;

		public TaskListModel(ITaskListData taskListData)
		{
			_taskListData = taskListData;

		}

		public List<TaskNameItem> GetTaskList => _taskListData.Data.Select((data) => new TaskNameItem(data.TaskTitle, data.ID)).ToList();
    }
}