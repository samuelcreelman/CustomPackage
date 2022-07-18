using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedArithmetic : MonoBehaviour
{
    public static float Power(float value, float power)
	{
		return Mathf.Pow(value, power);
	}

	public static float Mod(float value, float mod)
	{
		return value % mod;
	}
}
