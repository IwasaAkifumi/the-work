using UnityEngine;
using System.Collections;

public class Ctrl : MonoBehaviour
{

	
float rotateAngle;
    int rotateSpeed;

    void Start()
    {
        rotateAngle = 0.0f;
        rotateSpeed = 200;
    }

    void Update()
    {
        rotateAngle += Time.deltaTime * rotateSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rotateAngle);
    }
}
