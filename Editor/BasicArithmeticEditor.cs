using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#if UNITY_EDITOR

using UnityEditor;

namespace CustomPackage
{
	[CustomEditor(typeof(BasicArithmetic))]
	public class BasicArithmeticEditor : Editor
	{

		public override void OnInspectorGUI()
		{
			//base.OnInspectorGUI();
			DrawDefaultInspector();

			// Adds a calculation preview
			serializedObject.Update();

			SerializedProperty spInputA = serializedObject.FindProperty("inputA");
			SerializedProperty spInputB = serializedObject.FindProperty("inputB");
			SerializedProperty spDropdownOp = serializedObject.FindProperty("dropdownOp");

			if (spInputA.objectReferenceValue != null && spInputB.objectReferenceValue != null && spDropdownOp.objectReferenceValue != null)
			{
				TMP_InputField inputA = spInputA.objectReferenceValue as TMP_InputField;
				TMP_InputField inputB = spInputB.objectReferenceValue as TMP_InputField;

				if (inputA && inputB && float.TryParse(inputA.text, out float valueA) && float.TryParse(inputB.text, out float valueB))
				{
					float result;
					switch ((spDropdownOp.objectReferenceValue as TMP_Dropdown).value)
					{
						default:
						case 0:
							result = valueA + valueB;
							break;
						case 1:
							result = valueA - valueB;
							break;
						case 2:
							result = valueA * valueB;
							break;
						case 3:
							if (valueB == 0)
							{
								result = Mathf.Sign(valueA) > 0 ? float.PositiveInfinity : float.NegativeInfinity;
							}
							else
							{
								result = valueA / valueB;
							}
							break;
					}
					EditorGUILayout.LabelField($"Result will equal: {result}");
				}
				else
				{
					EditorGUILayout.LabelField($"Please add inputs to the fields to see the preview calculation.");
				}
			}
			else
			{
				EditorGUILayout.LabelField($"Please assign required references to see the preview calculation.");
			}

		}
	}
}

#endif