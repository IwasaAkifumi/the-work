using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{

    void Start()
    {
        Handheld.Vibrate();
        if (SystemInfo.supportsVibration) print("振動対応");
        else
        {
            print("振動非対応");
        }
    }

    void ExampleHandler()
    {
        Handheld.Vibrate();
    }



}