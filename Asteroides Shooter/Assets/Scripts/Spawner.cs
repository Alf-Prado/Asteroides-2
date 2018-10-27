using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Rock;
    float delay = 1.3f;
    double cooldown;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = delay;
            Instantiate(Rock, transform.position, Quaternion.identity);

            float positionX;
            positionX = Random.Range(-20f, 20f);
            Vector3 newPosition = new Vector3(positionX, 13, 10);
            transform.position = newPosition;
        }
        
    }
}
