using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShredder : MonoBehaviour
{
    [SerializeField] int playerHealth = 100;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
