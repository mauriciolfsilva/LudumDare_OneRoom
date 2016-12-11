using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

    [SerializeField]
    private string type;
    [SerializeField]
    private float speed;
    private Vector3 startingPoint;
    [SerializeField]
    private string axis;
    [SerializeField]
    private int direction;

    void Start()
    {
        startingPoint = transform.position;
    }

    public int Direction
    {
        get
        {
            return direction;
        }
        set
        {
            direction = value;
        }
    }

    public string Axis
    {
        get
        {
            return axis;
        }
        set
        {
            axis = value;
        }
    }

    public string Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    void Update () {
        Behavior(type,axis,direction);
	}

    void Behavior(string myType, string _axis, int _direction)
    {
        if (_axis.Equals("Vertical"))
        {
            switch (myType)
            {
                case "Arrow":
                    transform.position += Vector3.forward * Time.deltaTime * speed * 2f * _direction;
                    break;
                case "Rock":
                    transform.position += Vector3.forward * Time.deltaTime * speed * 0.7f * _direction;
                    break;
                case "Saw":
                    transform.position += Vector3.forward * Time.deltaTime * speed * 1f * _direction;
                    transform.Rotate(0, Time.deltaTime * 720, 0);
                    if(Mathf.Abs(startingPoint.z - transform.position.z) > 15)
                    {
                        speed *= -1;
                        if (startingPoint.z > transform.position.z) transform.position += Vector3.forward * 2;
                        else transform.position -= Vector3.forward * 2;

                    }
                    break;
                case "Bomb":
                    float temp = Time.deltaTime;
                    transform.localScale += new Vector3(direction * temp, direction * temp, direction * temp);
                    if(transform.localScale.x >= 2 || transform.localScale.x <= 1)
                    {
                        direction *= -1;
                        if (transform.localScale.x >= 2f) transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
                        else transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                    }
                    break;
            }
        }

        else
        {
            switch (myType)
            {
                case "Arrow":
                    transform.position += new Vector3(Time.deltaTime * speed * 2f * _direction, 0, 0);
                    break;
                case "Rock":
                    transform.position += new Vector3(Time.deltaTime * speed * 0.7f * _direction, 0, 0);
                    break;
                case "Saw":
                    transform.position += new Vector3(Time.deltaTime * speed * 1f * _direction, 0, 0);
                    transform.Rotate(0, 0, Time.deltaTime * 720);
                    if (Mathf.Abs(startingPoint.x - transform.position.x) > 15)
                    {
                        speed *= -1;
                        if (startingPoint.x > transform.position.x) transform.position += Vector3.right*2;
                        else transform.position -= Vector3.right * 2;

                    }
                    break;
                case "Bomb":
                    float temp = Time.deltaTime;
                    transform.localScale += new Vector3(direction * temp, direction * temp, direction * temp);
                    if (transform.localScale.x >= 2 || transform.localScale.x <= 1)
                    {
                        direction *= -1;
                        if (transform.localScale.x >= 2f) transform.localScale = new Vector3(1.9f, 1.9f, 1.9f);
                        else transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                    }
                    break;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Dead");
        }
    }
}