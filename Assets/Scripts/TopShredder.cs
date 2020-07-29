using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopShredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other);
    }
}
