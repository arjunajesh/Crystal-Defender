using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GemMainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotateSpeed = 1;
    public float bounce = 1;
    public float bounceSpeed = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
        transform.position = new Vector3(-0.325F, Mathf.PingPong(Time.time * bounceSpeed, bounce), -910F);
    }
}
