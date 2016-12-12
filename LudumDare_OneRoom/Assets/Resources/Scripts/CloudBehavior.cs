using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour {

    private float speed;

	void Start () {
        speed = 30f;
	}
	
	void Update () {
        this.transform.position += Vector3.left * Time.deltaTime * speed;

        if (this.transform.position.x <= -950) Destroy(this.gameObject);
	}
}
