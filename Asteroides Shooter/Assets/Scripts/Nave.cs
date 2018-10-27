using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour {
    int shipHealth = 100;
    int shipScore = 0;
    int speedX = 27;
    int speedY = 23;
    Vector2 limiteX = new Vector2(-21.5f, 21.5f);
    float fireRate = 0.1f;
    double ShotCooldown;
    string ActualShot;

    Rigidbody rigidbodyComponent;

    public GameObject LaserShot;
    public GameObject HeavyShot;
    public GameObject ShootingPoint;

    void OnGUI()
    {
        GUILayout.Label("Health: " + shipHealth);
        GUILayout.Label("Score: " + shipScore);
    }

    // Use this for initialization
    void Start () {
        rigidbodyComponent = GetComponent<Rigidbody>();
        ActualShot = "Laser Shot";
	}
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxis("Horizontal") * speedX;
        float inputY = Input.GetAxis("Vertical") * speedY;
        

        rigidbodyComponent.velocity = new Vector2(inputX, inputY);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, limiteX.x, limiteX.y), transform.position.y, transform.position.z);

        if (ShotCooldown > 0)
        {
            ShotCooldown -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && ShotCooldown <= 0)
        {
            ShotCooldown = fireRate;
            if (ActualShot == "Laser Shot")
            {
                Instantiate(LaserShot, ShootingPoint.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(HeavyShot, ShootingPoint.transform.position, Quaternion.identity);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (ActualShot == "Laser Shot")
            {
                ActualShot = "Heavy Shot";
            }
            else
            {
                ActualShot = "Laser Shot";
            }
        }

    }

    public void ShipTakesDamage()
    {
        shipHealth = shipHealth - 5;

        if (shipHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int score)
    {
        shipScore = shipScore + score;
    }

    public void GiveHealth()
    {
        int neededHealth;
        neededHealth = 100 - shipHealth;

        if (neededHealth == 0)
        {
            return;
        }

        if (neededHealth >= 5)
        {
            shipHealth = shipHealth + 5;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        Rock rock = collision.gameObject.GetComponent<Rock>();
        if (rock != null)
        {
            ShipTakesDamage();
            Invoke("ChangeColor", 0f);
            Invoke("ResetColor", 1f);
            Destroy(rock.gameObject);
        }

        EnemyShot shot = collision.gameObject.GetComponent<EnemyShot>();
        if (shot != null)
        {
            ShipTakesDamage();
            Invoke("ChangeColor", 0f);
            Invoke("ResetColor", 1f);
            Destroy(shot.gameObject);
        }
    }

    void ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    void ResetColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
