using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    public Transform Aim;
    public float offset;
    void Update()
    {
        Vector3 Eye = new Vector3(0, 45, 0);
        if (Aim.position.x > transform.position.x)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(-Eye), Time.deltaTime * offset);
        }
        else
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(Eye), Time.deltaTime * offset);
        }
    }
}
 