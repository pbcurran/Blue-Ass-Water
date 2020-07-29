using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGreen : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int pointsForKill = 50;
    public int identifier = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ScoreKeeper scoreKeeper = other.gameObject.GetComponent<ScoreKeeper>();

        // tries below to see if it a red or a blue laser that hit the gem
        
        try
        {
            LaserGreen laserGreen = other.gameObject.GetComponent<LaserGreen>();
            // green laser on green gem process
            if (laserGreen.laserIdentifier == 1)
            {
                ProcessGreenHit(damageDealer);
            }
        }
        catch
        {  
        }

        try
        {
            LaserRed laserRed = other.gameObject.GetComponent<LaserRed>();
            // red laser on green gem process
            if (laserRed.laserIdentifier == 2)
            {
                FindObjectOfType<ScoreKeeper>().ResetMultiplier();
                //Debug.Log("red laser to green gem");
                Debug.Log(FindObjectOfType<ScoreKeeper>().GetMultiplier());
            }
        }
        catch
        {
        }

        try
        {
            HealthBottomShredder bottomShredder = other.gameObject.GetComponent<HealthBottomShredder>();
            // process for when the gem hits the shredder
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

    private void ProcessGreenHit(DamageDealer damageDealer)
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
