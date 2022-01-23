using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public int health;
    public int damage;
    public float speed;
    [HideInInspector]
    public int maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
