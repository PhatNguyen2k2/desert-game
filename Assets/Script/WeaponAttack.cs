using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    public Animator animator;

    public bool isAttacking = false;

    private HitBox hitbox;

    //public WeaponData data;

    private void Start()
    {
        hitbox = FindObjectOfType<HitBox>();
    }

    //Input Mouse Click To Active Animation
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());   
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(Skill());
        }
    }
    //Dealing Damage
    IEnumerator Skill()
    {
        if (!isAttacking)
        {
            hitbox.Attacked(20f);
            isAttacking = true; 
            animator.SetBool("isSpin", true);
            yield return new WaitForSeconds(3f);
            animator.SetBool("isSpin", false);
            isAttacking = false;
        }
    }

    IEnumerator Attack()
    {
        if (!isAttacking)
        {
            hitbox.Attacked(9f);
            isAttacking = true;
            animator.SetBool("isAttacking",true);
            yield return new WaitForSeconds(1f);
            animator.SetBool("isAttacking", false);
            isAttacking = false;
        }
    }
}
