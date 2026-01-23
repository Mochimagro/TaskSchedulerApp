using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace MVPTemplateEditor.Game.Presenter
{
	using CommonSample;

	public interface ICommonSamplePresenter
	{
		
	}

	public class CommonSamplePresenter : ICommonSamplePresenter
	{
		private ICommonSampleView _commonSampleView = null;
		private ICommonSampleModel _commonSampleModel = null;

		public CommonSamplePresenter(ICommonSampleView view,ICommonSampleModel model) 
		{
			_commonSampleView = view ?? throw new ArgumentNullException(nameof(view));
			_commonSampleModel = model ?? throw new ArgumentNullException(nameof(model));
			

			Bind();
		}
		
		private void Bind () 
		{
			

		}
	}
}