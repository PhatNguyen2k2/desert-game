using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public bool isField = false;

    private SkeletonAI1 skel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            isField = true;
            skel = other.GetComponent<SkeletonAI1>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "enemy")
        {
            isField = false;
            skel = null;
        }
    }

    public void Attacked(float damage)
    {
        if (isField)
        {
            skel.TakeDamage(damage);
        }
    }
}
