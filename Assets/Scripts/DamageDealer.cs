using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 100;
    
    // need to change the damage of this on each of the objects that you put it on the inspector.
    // the damage of the player bullets stays high so that it one shots the gems and the gems will have the 
    // amount of damage that you want th player to lose when they miss them.
    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
