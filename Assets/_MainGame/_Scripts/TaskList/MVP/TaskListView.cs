using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
using UnityEngine.UI;
using Zenject;
using TaskSchedulerApp.Game.Component;

namespace TaskSchedulerApp.Game.TaskList
{

	public struct TaskNameItem
	{
		public string title;
		public int id;
		public TaskNameItem(string title, int id)
		{
			this.title = title;
			this.id = id;
		}
	}
	
	public interface ITaskListView
    {
		void Init();
		void CreateTaskItems(IReadOnlyList<TaskNameItem> items);
		IObservable<int> OnSelectTask { get; }
	}

	[RequireComponent(typeof(ZenjectBinding))]
	public class TaskListView : MonoBehaviour ,ITaskListView
	{
		[SerializeField] TaskListViewItemComponent _listItem;
		List<TaskListViewItemComponent> _listViewItems = new List<TaskListViewItemComponent>();
		[SerializeField]Transform _parentListContext;
		Subject<int>_onSelectTask = new Subject<int>();

		public IObservable<int> OnSelectTask => _onSelectTask;

        public void CreateTaskItems(IReadOnlyList<TaskNameItem> items)
        {
			foreach (var item in items) 
			{
				var listViewitem = GameObject.Instantiate(_listItem,_parentListContext);
				listViewitem.Init(item.id, item.title);
				listViewitem.OnClickButton.Subscribe(id =>
				{
					_onSelectTask.OnNext(id);
				});
				listViewitem.gameObject.SetActive(true);
				_listViewItems.Add(listViewitem);
			}
        }

        public void Init()
		{
			

		}
		
	}
}