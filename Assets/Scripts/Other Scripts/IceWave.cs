using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWave : MonoBehaviour
{
    SphereCollider sc;
    public float increaseRate = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(sc.radius < 3)
        {
            sc.radius += increaseRate;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

    }
}
