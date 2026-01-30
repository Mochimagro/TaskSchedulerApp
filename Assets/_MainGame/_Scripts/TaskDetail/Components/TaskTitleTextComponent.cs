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
		IObservable<string> OnTextEnter { get; }
    }


	public class TaskTitleTextComponent : MonoBehaviour ,ITaskTitleTextComponent
	{
		[SerializeField] TMP_InputField _titleText;

		Subject<string> _onTitleTextEnter = new Subject<string>();


        public string SetText { set => _titleText.text = value; }

        public IObservable<string> OnTextEnter => _onTitleTextEnter;

        public void Init () 
		{
			_titleText.text = default;
			_titleText.onEndEdit.AddListener(value =>
			{
				_onTitleTextEnter.OnNext(value);
			});
		}
		
	}
}