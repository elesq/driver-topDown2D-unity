using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // cams position should be same as car positon.
    [SerializeField] GameObject MainCar;


    void LateUpdate()
    {
        // new vector 3 has an override on the z axis to keep top down view in place.
        this.transform.position = MainCar.transform.position + new Vector3(0, 0, -20);
    }
}
