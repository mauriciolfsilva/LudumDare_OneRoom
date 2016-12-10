using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

    [SerializeField]
    private string type;
    [SerializeField]
    private float speed;
    private Vector3 startingPoint;

    void Start()
    {
        startingPoint = transform.position;
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
        Behavior(type,"Vertical",1);
	}

    void Behavior(string myType, string axis, int direction)
    {
        if (axis.Equals("Vertical"))
        {
            switch (myType)
            {
                case "Arrow":
                    transform.position += new Vector3(0, Time.deltaTime * speed * 2f * direction, 0);
                    break;
                case "Rock":
                    transform.position += new Vector3(0, Time.deltaTime * speed * 0.7f * direction, 0);
                    break;
                case "Saw":
                    transform.position += new Vector3(0, Time.deltaTime * speed * 1f * direction, 0);
                    transform.Rotate(0, 0, Time.deltaTime * 720);
                    if(Mathf.Abs(startingPoint.y - transform.position.y) > 15)
                    {
                        speed *= -1;
                    }
                    break;
            }
        }

        else
        {
            switch (myType)
            {
                case "Arrow":
                    transform.position += new Vector3(Time.deltaTime * speed * 2f * direction, 0, 0);
                    break;
                case "Rock":
                    transform.position += new Vector3(Time.deltaTime * speed * 0.7f * direction, 0, 0);
                    break;
                case "Saw":
                    transform.position += new Vector3(Time.deltaTime * speed * 1f * direction, 0, 0);
                    transform.Rotate(0, 0, Time.deltaTime * 720);
                    if (Mathf.Abs(startingPoint.x - transform.position.x) > 15)
                    {
                        speed *= -1;
                    }
                    break;
            }
        }
    }
}