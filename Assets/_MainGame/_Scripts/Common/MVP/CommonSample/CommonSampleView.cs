using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UniRx;
using UnityEngine.UI;
using Zenject;

namespace MVPTemplateEditor.Game.CommonSample
{
	using Component;
	
	public interface ICommonSampleView
    {
		void Init();

	}

	[RequireComponent(typeof(ZenjectBinding))]
	public class CommonSampleView : MonoBehaviour ,ICommonSampleView
	{

		public void Init()
		{
			

		}
		
	}
}