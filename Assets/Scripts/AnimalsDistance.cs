using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
//using UnityEditor;
#endif
using UnityEngine;

public class AnimalsDistance : MonoBehaviour
{
    public float DistanceToActivate = 20f;
    private bool _isActive = true;
    private Activator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.ObjectToActivate.Add(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (distance > DistanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < DistanceToActivate)
            {
                Activate();
            }
        }
    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }
    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _activator.ObjectToActivate.Remove(this);
    }

#if UNITY_EDITOR
    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = Color.grey;
    //    Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
    //}
#endif
}
