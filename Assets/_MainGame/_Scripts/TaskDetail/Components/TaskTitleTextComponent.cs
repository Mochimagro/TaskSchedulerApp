using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;

namespace TaskSchedulerApp.Game.Component
{
	public interface ITaskTitleTextComponent
    {
		void Init();
		string SetText { set; }
    }


	public class TaskTitleTextComponent : MonoBehaviour ,ITaskTitleTextComponent
	{
		[SerializeField] TMP_InputField _titleText;

        public string SetText { set => _titleText.text = value; }

        public void Init () 
		{
			_titleText.text = default;

		}
		
	}
}