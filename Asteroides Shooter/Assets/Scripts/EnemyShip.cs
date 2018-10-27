using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {
    float speed = 15f;
    private Vector2 movement;
    private float range;
    GameObject player;
    Vector3 target;
    Vector3 lastPosition;
    float fireRate = 3f;
    double ShotCooldown;

    private Rigidbody rigidbodyComponent;
    public GameObject ShootingPoint;
    public GameObject EnemyShot;

    // Use this for initialization
    void Start () {
        if (rigidbodyComponent == null)
            rigidbodyComponent = GetComponent<Rigidbody>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update () {

        if (ShotCooldown > 0)
        {
            ShotCooldown -= Time.deltaTime;
        }

        if (ShotCooldown <= 0)
        {
            ShotCooldown = fireRate;
            Instantiate(EnemyShot, ShootingPoint.transform.position, ShootingPoint.transform.rotation);
        }
        


        target = player.transform.position;

        range = Vector3.Distance(transform.position, target);

        if (range > 15.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        if (range < 14.8f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, -speed * Time.deltaTime);
        }

        if (range <= 15.2f && range >= 14.8f)
        {
            transform.position = transform.position;
        }
        
    }

    public void Shoot()
    {
        
    }
}
