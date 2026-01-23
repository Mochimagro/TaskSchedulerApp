using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace Mochi.ChillVox.SampleEditorWindow
{
	
	public interface ISampleEditorWindowView
    {
		VisualElement VisualElement { get; }
	}

	public class SampleEditorWindowView : VisualElement ,ISampleEditorWindowView
	{
		VisualElement _visualTree;
        private VisualTreeAsset _visualTreeAsset;
		private string _visualTreeAssetFilePath = "Assets/Editor/EditorWindow/SampleEditorWindow/SampleEditorWindow.uxml";

		public SampleEditorWindowView()
		{
			_visualTreeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(_visualTreeAssetFilePath);

			_visualTree = _visualTreeAsset.CloneTree();

			this.Add(_visualTree);
		}

        public VisualElement VisualElement => this;
    }
}