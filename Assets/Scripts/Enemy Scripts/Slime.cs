using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class Slime : MonoBehaviour
{

    public float throwStrength = 10;
    public ParticleSystem deathParticles;
    public GameObject gem;
    public float movementSpeed;
    public int scoreAddition = 0;
    public GameObject player;
    public float gemDamage = 0;
    int health;
    Player playerScript;
    public GameObject slimeBaby;
    GameObject slimeBaby1;
    GameObject slimeBaby2;
    BoxCollider bc;
    private void Start()
    {
        gem = GameObject.Find("Gem");
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        bc = GetComponent<BoxCollider>();
 
    }

    private void FixedUpdate()
    {
        health = GetComponent<EnemyStats>().health;

        transform.position = Vector3.MoveTowards(transform.position, gem.transform.position, movementSpeed * Time.deltaTime);
        
        if(health <= 0)
        {
            playerScript.score += scoreAddition;

            bc.enabled = false;
            slimeBaby1 = Instantiate(slimeBaby);
            slimeBaby1.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y + 0.3f, transform.position.z);
            slimeBaby2 = Instantiate(slimeBaby);
            slimeBaby2.transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            CameraShaker.Instance.ShakeOnce(1.2f, 3f, .1f, 1f);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            gem.GetComponent<Gem>().health -= gemDamage;
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
