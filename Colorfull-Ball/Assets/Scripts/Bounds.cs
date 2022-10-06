using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform vectorback;
    public Transform vectorforward;
    public Transform vectorright;
    public Transform vectorleft;

    public void LateUpdate() 
    {
        Vector3 viewPosition = transform.position;
        viewPosition.z = Mathf.Clamp(viewPosition.z,vectorback.transform.position.z,vectorforward.transform.position.z);
        viewPosition.x = Mathf.Clamp(viewPosition.x,vectorleft.transform.position.x,vectorright.transform.position.x);
        transform.position = viewPosition;
    }
}
