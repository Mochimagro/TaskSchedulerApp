using System;
using System.Collections.Generic;

namespace Mochi.ChillVox.Presenter
{
	using SampleEditorWindow;
    using UnityEngine.UIElements;

    public interface ISampleEditorWindowPresenter
	{
		VisualElement VisualElement { get; }
	}

	public class SampleEditorWindowPresenter : ISampleEditorWindowPresenter
	{
		private static ISampleEditorWindowView _sampleEditorWindowView = null;
		private static ISampleEditorWindowModel _sampleEditorWindowModel = null;
        public VisualElement VisualElement => _sampleEditorWindowView.VisualElement;

		public SampleEditorWindowPresenter() 
		{
			_sampleEditorWindowView = new SampleEditorWindowView();
            _sampleEditorWindowModel = new SampleEditorWindowModel();
			
			Bind();
		}


        private static void Bind () 
		{
			

		}
	}
}