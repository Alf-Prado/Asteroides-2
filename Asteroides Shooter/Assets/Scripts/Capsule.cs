using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour {
    public GameObject player;
    Nave playerShip;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 3);

        player = GameObject.FindGameObjectWithTag("Player");
        playerShip = player.GetComponent<Nave>();
    }

    public void GivePoints()
    {
        playerShip.UpdateScore(10);
        playerShip.GiveHealth();
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Nave ship = collision.gameObject.GetComponent<Nave>();
        if (ship != null)
        {
            GivePoints();
        }
    }
}
