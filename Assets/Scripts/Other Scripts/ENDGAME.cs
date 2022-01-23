using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDGAME : MonoBehaviour
{
    public GameObject gem;
    public GameObject endGameUI;
    public GameObject lostText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gem.transform.localScale.x <= 0.012)
        {
            Debug.Log("YOU LOST");
            Time.timeScale = 0f;
            endGameUI.SetActive(true);
            lostText.SetActive(true);
        }
    }
}
