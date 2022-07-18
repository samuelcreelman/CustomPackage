using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CustomPackage
{

    public class BasicArithmetic : MonoBehaviour
    {
        private enum Operation
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Count,
        }
        private Operation operation;

        [SerializeField]
        private TMP_InputField inputA, inputB;
        [SerializeField]
        private TMP_Dropdown dropdownOp;
        [SerializeField]
        private Button calculateButton;
        [SerializeField]
        private TextMeshProUGUI resultText;


        void Start()
        {
            dropdownOp.onValueChanged.AddListener(SetOperation);
            calculateButton.onClick.AddListener(Calculate);
        }

        private void SetOperation(int value)
        {
            operation = (Operation)(value % (int)Operation.Count);
        }

        private void Calculate()
        {
            if (float.TryParse(inputA.text, out float valueA) && float.TryParse(inputB.text, out float valueB))
            {
                var result = operation switch
                {
                    Operation.Subtraction => Subtract(valueA, valueB),
                    Operation.Multiplication => Multiply(valueA, valueB),
                    Operation.Division => Divide(valueA, valueB),
                    _ => Add(valueA, valueB),
                };
                resultText.text = result.ToString();
            }
        }

        private float Add(float valueA, float valueB)
        {
            return valueA + valueB;
        }

        private float Subtract(float valueA, float valueB)
        {
            return valueA - valueB;
        }

        private float Multiply(float valueA, float valueB)
        {
            return valueA * valueB;
        }

        private float Divide(float valueA, float valueB)
        {
            if (valueB == 0)
            {
                Debug.LogError("Divide by Zero!");
                return Mathf.Sign(valueA) > 0 ? float.PositiveInfinity : float.NegativeInfinity;
            }
            else
            {
                return valueA / valueB;
            }
        }
    }
}