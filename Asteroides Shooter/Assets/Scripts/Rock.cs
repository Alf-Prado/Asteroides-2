using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
    public GameObject Particles;
    int RockHealth = 5;
    public GameObject player;
    public GameObject Points;
    Nave playerShip;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3);

        player = GameObject.FindGameObjectWithTag("Player");
        playerShip = player.GetComponent<Nave>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void RockTakesDamage(int damage)
    {
        RockHealth = RockHealth - damage;

        if (RockHealth <= 0)
        {
            playerShip.UpdateScore(100);
            Destroy(gameObject);
            Instantiate(Particles, transform.position, Quaternion.identity);
            if (Random.Range(0f, 20f) <= 5)
            {
                Instantiate(Points, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Shot laserShot = collision.gameObject.GetComponent<Shot>();
        if (laserShot != null)
        {
            if (laserShot.type == "Laser")
            {
                RockTakesDamage(1);
            }
            else
            {
                RockTakesDamage(2);
            }
            
            Invoke("ChangeColor", 0f);
            Invoke("ResetColor", 0.5f);
            Destroy(laserShot.gameObject);
        }
    }

    void ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
    }

    void ResetColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
