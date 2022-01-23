using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class Enhancer : MonoBehaviour
{
    Rigidbody rb;
    public float throwStrength = 10;
    public ParticleSystem deathParticles;
    ParticleSystem theParticles;
    public GameObject gem;
    public float movementSpeed;
    public int scoreAddition = 0;
    public float gemDamage = 0;
    int health;
    public GameObject player;
    Player playerScript;
    public float enhanceRadius = 1f;
    public LayerMask enemyLayer;
    public float enhanceRate = 5f;
    private void Start()
    {
        gem = GameObject.Find("Gem");
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        health = GetComponent<EnemyStats>().health;
        rb = GetComponent<Rigidbody>();


        InvokeRepeating("EnhanceEnemies", 0f, enhanceRate);
        
    }

    private void FixedUpdate()
    {
        health = GetComponent<EnemyStats>().health;
        transform.position = Vector3.MoveTowards(transform.position, gem.transform.position, movementSpeed * Time.deltaTime);

        if (health <= 0)
        {
            theParticles = Instantiate(deathParticles);
            theParticles.transform.position = transform.position;
            playerScript.score += scoreAddition;
            CameraShaker.Instance.ShakeOnce(1.2f, 3f, .1f, 1f);
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            gem.gameObject.transform.localScale += new Vector3(-gemDamage, -gemDamage, -gemDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
    private void EnhanceEnemies()
    {
        Debug.Log("enhance bruh");
       Collider[] colliders = Physics.OverlapSphere(transform.position, enhanceRadius,enemyLayer);
       foreach(var cube in colliders)
        {
            var enemy = cube.GetComponent<EnemyStats>();
            if(enemy.maxHealth != enemy.health)
            {
                enemy.health += 1;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, enhanceRadius);
    }
}
