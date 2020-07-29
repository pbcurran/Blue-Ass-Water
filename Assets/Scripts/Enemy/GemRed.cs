using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemRed : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int pointsForKill = 50;
    
    public int identifier = 2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ScoreKeeper scoreKeeper = other.gameObject.GetComponent<ScoreKeeper>();
        try
        {
            LaserGreen laserGreen = other.gameObject.GetComponent<LaserGreen>();
            // process for when green laser hits red
            if (laserGreen.laserIdentifier == 1)
            {
                FindObjectOfType<ScoreKeeper>().ResetMultiplier();
                //Debug.Log("green laser to red gem");
                Debug.Log(FindObjectOfType<ScoreKeeper>().GetMultiplier());
            }
        }
        catch
        {
        }

        try
        {
            LaserRed laserRed = other.gameObject.GetComponent<LaserRed>();
            if (laserRed.laserIdentifier == 2)
            {
                ProcessRedHit(damageDealer);
            }
        }
        catch
        {
        }

        try
        {
            HealthBottomShredder bottomShredder = other.gameObject.GetComponent<HealthBottomShredder>();

            if (bottomShredder.shredderidentifier == 3)
            {
                FindObjectOfType<ScoreKeeper>().ResetMultiplier();
                Destroy(gameObject);
                Debug.Log(FindObjectOfType<ScoreKeeper>().GetMultiplier());
            }
        }
        catch
        {
        }
    }

    private void ProcessRedHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<ScoreKeeper>().SetMultiplier();
        FindObjectOfType<ScoreKeeper>().AddScore(pointsForKill);
        Destroy(gameObject);
        Debug.Log(FindObjectOfType<ScoreKeeper>().GetMultiplier());
    }
}
