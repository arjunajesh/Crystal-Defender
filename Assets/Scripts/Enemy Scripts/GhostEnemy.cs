using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using EZCameraShake;
public class GhostEnemy : MonoBehaviour
{
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
    public float movementSpeed;
    bool isGrabbed = false;
    public int scoreAddition = 0;
    public float gemDamage = 0;
    int health;
    int damage = 0;
    public GameObject player;
    float gemHealth;
    Player playerScript;
    bool isInvisible = false;
    BoxCollider bc;

    private void Start()
    {
        gem = GameObject.Find("Gem");
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        gemHealth = gem.GetComponent<Gem>().health;
        damage = GetComponent<EnemyStats>().damage;
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        //transform.LookAt(gem.transform);

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
            transform.position = Vector3.MoveTowards(transform.position, gem.transform.position, movementSpeed * Time.deltaTime);
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
        if (throwVelocity == new Vector3(0, 0, 0))
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
        else if (collision.gameObject.CompareTag("Enemy") && throwVelocity != new Vector3(0, 0, 0) || isGrabbed == true)
        {
            Debug.Log("bruh");
            //collision.gameObject.GetComponent<EnemyStats>().health -= damage;
            Debug.Log(collision.gameObject.GetComponent<EnemyStats>().damage);
            GetComponent<EnemyStats>().health -= collision.gameObject.GetComponent<EnemyStats>().damage;

        }
        else if (collision.gameObject.CompareTag("Boundary"))
        {
            Debug.Log("hit the boundary");
            Destroy(gameObject);
        }
    }
    public void InvisibleHandler()
    {
        //Debug.Log("invisble handler");
        if (isInvisible == false)
        {
            bc.enabled = false;
            isInvisible = true;
            
        }
        else
        {
            bc.enabled = true;
            isInvisible = false;
            
        }
    }
}
