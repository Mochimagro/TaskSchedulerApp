using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
using UnityEngine.UI;
using Zenject;

namespace MVPTemplateEditor.Game.OutGameSample
{
	using Component;
	
	public interface IOutGameSampleView
    {
		void Init();

	}

	[RequireComponent(typeof(ZenjectBinding))]
	public class OutGameSampleView : MonoBehaviour ,IOutGameSampleView
	{

		public void Init()
		{
			

		}
		
	}
}