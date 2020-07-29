using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierDisplay : MonoBehaviour
{
    Text multiplierText;
    ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        multiplierText = GetComponent<Text>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        multiplierText.text = "X" + scoreKeeper.GetMultiplier().ToString();
    }
}
