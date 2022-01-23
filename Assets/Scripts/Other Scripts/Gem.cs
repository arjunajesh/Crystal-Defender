using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gem : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotateSpeed = 1;
    public float health = 1;

    public GameObject gem;
    public GameObject endGameUI;
    public GameObject lostText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
        if (health <= 0)
        {
            Debug.Log("YOU LOST");
            Time.timeScale = 0f;
            endGameUI.SetActive(true);
            lostText.SetActive(true);
        }
        //transform.position = new Vector3 (-0.325F, Mathf.PingPong (Time.time * bounceSpeed, bounce), 1.867F);
    }
}
