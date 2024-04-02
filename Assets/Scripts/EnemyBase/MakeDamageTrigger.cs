using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageTrigger : MonoBehaviour
{
    public int DamageValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<PlayerHealth>())
            {
                other.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(DamageValue);
            }
        }
    }

}
