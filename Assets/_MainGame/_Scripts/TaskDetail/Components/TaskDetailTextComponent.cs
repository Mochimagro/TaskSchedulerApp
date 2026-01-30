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
        IObservable<string> OnEnterText {  get; }
    }


	public class TaskDetailTextComponent : MonoBehaviour ,ITaskDetailTextComponent
	{
		[SerializeField] TMP_InputField _taskDetailText = default;

		Subject<string> _onEnterText = new Subject<string>();
		public IObservable<string> OnEnterText => _onEnterText;

        public string SetText { set => _taskDetailText.text = value; }

        public void Init () 
		{
			_taskDetailText.text = string.Empty;
			_taskDetailText.onEndEdit.AddListener(value =>
			{
				_onEnterText.OnNext(value);
			});
		}
		
	}
}