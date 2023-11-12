using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SkeletonAI1 : MonoBehaviour
{
    private NavMeshAgent nav;
    public GameObject player;
    public Animator animator;

    private PlayerData data;
    private bool isAttacking = false;
    private float updateTime = 0;

    public float maxDamge;
    public float minDamge;

    public Slider healthSlider;
    public float maxHealth;
    public float health;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        data = FindObjectOfType<PlayerData>();
        healthSlider.maxValue = maxHealth;
        health = maxHealth;
        healthSlider.value = health;
    }

    private void Update()
    {
        updateTime += Time.deltaTime;

        float dist = Vector3.Distance(this.transform.position, player.transform.position);

        if(dist < 4)
        {
            //atk
            if (!isAttacking)
            {
                StartCoroutine(Attack());
            }
        }
        else
        {
            //walk
            animator.SetBool("Attack", false);
            isAttacking = false;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthSlider.value = health;
        //animator.SetBool("Attacked", true);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool("Attack", true);
            yield return new WaitForSeconds(1.2f);
            data.TakeDamage(Random.Range(minDamge, maxDamge));
            isAttacking = false;
        }

    }

    private void LateUpdate()
    {
        if(updateTime > 2)
        {
            nav.destination = player.transform.position;
            updateTime = 0;
        }
    }


}
