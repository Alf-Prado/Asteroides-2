using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public string type;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0.3f, 0));
    }
}
