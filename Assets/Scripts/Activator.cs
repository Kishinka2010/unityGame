using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<AnimalsDistance> ObjectToActivate = new List<AnimalsDistance>();
    public Transform PlayerTransform;
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ObjectToActivate.Count; i++)
        {
            ObjectToActivate[i].CheckDistance(PlayerTransform.position);
        }
    }
}
