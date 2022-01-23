using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using EZCameraShake;
//using UnityEditor.Experimental.GraphView;

public class Enemy : MonoBehaviour {
    Rigidbody rb;
    Vector3 mousePosition;
    Vector3 objPosition;
    public float dragSpeed;
    Vector3 lastPosition;
    Vector3 throwVelocity;
    public float throwStrength = 10;
    bool move = false;
    public ParticleSystem deathParticles;
    ParticleSystem theParticles;
    public GameObject gem;
    EnemyStats enemyStats;
    bool isGrabbed = false;
    public int scoreAddition = 0;
    public float gemDamage = 0;
    int health;
    int damage = 0;
    float gemHealth;
    public GameObject player;
    Player playerScript;


    private void Start()
    {
        gem = GameObject.Find("Gem");
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        damage = GetComponent<EnemyStats>().damage;
        enemyStats = GetComponent<EnemyStats>();
        rb = GetComponent<Rigidbody>();
        
    }
    private void OnMouseDown()
    {
        move = true;
        isGrabbed = true;
    }
    private void FixedUpdate()
    {
        health = GetComponent<EnemyStats>().health;

        if (move)
        {
            objPosition = transform.position;
            throwVelocity = objPosition - lastPosition;
            lastPosition = transform.position;

            mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
            objPosition = transform.position;

            transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(mousePosition), dragSpeed);
        }
        if (isGrabbed == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, gem.transform.position, enemyStats.speed * Time.deltaTime);
        }
        if (health <= 0)
        {
            theParticles = Instantiate(deathParticles);
            theParticles.transform.position = transform.position;
            playerScript.score += scoreAddition;
            CameraShaker.Instance.ShakeOnce(1.2f, 3f, .1f, 1f);
            Destroy(gameObject);
        }
    }
    private void OnMouseUp()
    {
        move = false;
        rb.isKinematic = false;
        rb.velocity = new Vector3(throwVelocity.x * throwStrength, throwVelocity.y * throwStrength, 0);
        if(throwVelocity == new Vector3(0, 0, 0))
        {
            isGrabbed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            gem.GetComponent<Gem>().health -= gemDamage;
            //gem.gameObject.transform.localScale += new Vector3(-gemDamage, -gemDamage, -gemDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy") && (throwVelocity != new Vector3(0, 0, 0) || isGrabbed == true))
        {

            collision.gameObject.GetComponent<EnemyStats>().health -= damage;

            GetComponent<EnemyStats>().health -= collision.gameObject.GetComponent<EnemyStats>().damage;

        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
