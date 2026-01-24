using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

namespace TaskSchedulerApp.Game.Component
{
	public interface ITaskDetailTextComponent
    {
		void Init();
		string SetText { set; }
    }


	public class TaskDetailTextComponent : MonoBehaviour ,ITaskDetailTextComponent
	{
		[SerializeField] TextMeshProUGUI _taskDetailText = default;

        public string SetText { set => _taskDetailText.text = value; }

        public void Init () 
		{
			_taskDetailText.text = string.Empty;

		}
		
	}
}