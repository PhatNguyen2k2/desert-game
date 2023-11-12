using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [Header("PlayerStats")]
    public float maxHealth;
    public float curHealth;

    [Header("UIComponents")]
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public void Start()
    {
        healthSlider.maxValue = maxHealth;
        curHealth = maxHealth;
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }

    public void TakeDamage(float damage)
    {
        curHealth -= damage;
        healthSlider.value = curHealth;
        if(curHealth <= 0)
        {
            Application.LoadLevel("Login");
        }
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    } 
    public void Heal(float health)
    {
        curHealth += health;
        if(curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        healthSlider.value = curHealth;
        healthText.text = curHealth.ToString("F0") + "/" + maxHealth.ToString("F0");
    }
}
