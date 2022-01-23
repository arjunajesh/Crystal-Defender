using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //scoreText = GUI.Find("Score Text");
    }
    //
    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}
