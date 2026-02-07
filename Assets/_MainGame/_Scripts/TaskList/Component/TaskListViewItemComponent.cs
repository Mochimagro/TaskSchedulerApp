using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

namespace TaskSchedulerApp.Game.Component
{
	public interface ITaskListViewItemComponent
    {
		void Init();
		void Init(int id, string taskTitle);

        int SetID {  set; }
		string SetTaskTitle { set; }
		IObservable<int> OnClickButton { get; }
    }


	public class TaskListViewItemComponent : MonoBehaviour ,ITaskListViewItemComponent
	{
		int _taskID;

		[SerializeField] Button _button;
		[SerializeField] TextMeshProUGUI _taskTitle;

        public int SetID { set => _taskID = value; }
        public string SetTaskTitle { set => _taskTitle.text = value; }

		Subject<int> _onClickButton = new Subject<int>();
        public IObservable<int> OnClickButton => _onClickButton;

        public void Init()
		{
			Init(0, string.Empty);
		}

        public void Init (int id,string taskTitle) 
		{
			SetID = id;
			SetTaskTitle = taskTitle;
			_button.OnClickAsObservable().Subscribe(_ =>
			{
                _onClickButton.OnNext(_taskID);
            });
		}
		
	}
}