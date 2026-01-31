using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemyHealth;

    void Start()
    {
        //debug
        enemyHealth = 100f;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) //this function triggers automatically by Unity, not manually
    {
        //check if the incoming object has a ProjectileBehavior component
        ProjectileBehavior projectile = other.GetComponent<ProjectileBehavior>();

        if (projectile != null)
        {
            //get the weapon damage
            WeaponController weapon = other.GetComponentInParent<WeaponController>();
            float damage = 10f; //default

            if (weapon != null)
            {
                damage = weapon.weaponDamage;
            }

            enemyHealth -= damage;

            Debug.Log($"The enemy has been hit! {enemyHealth} HP left!");

            //destroy the projectile on impact
            Destroy(other.gameObject);
        }
    }
}
