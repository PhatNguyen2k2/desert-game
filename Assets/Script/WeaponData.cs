using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Object/Type")]
public class WeaponData : MonoBehaviour
{
    public Sprite sprite;
    public GameObject weaponPrefab;
    public float AttackSpeed;
    public float AttackDamage;
}
