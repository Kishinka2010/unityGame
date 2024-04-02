using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamege(1);
                other.attachedRigidbody.GetComponent<Bullet>().Die();
            }
        }
        if (DieOnAnyCollision == true)
        {
            if (other.isTrigger == false)
            {
                EnemyHealth.TakeDamege(10000);
            }
        }
    }
}
