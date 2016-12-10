using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed;

    private bool dodging;
    private float timePassed;

	void Start () {
        speed = 20;
        dodging = false;
        timePassed = 0;
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

    void Dodge()
    {
        speed = 120;
        dodging = true;
    }

    void Control()
    {
        #region MoveDirection
        if (Input.GetKey(KeyCode.W)) this.transform.position = new Vector3(this.transform.position.x,
                                                                           this.transform.position.y + speed * Time.deltaTime,
                                                                           this.transform.position.z);
        if (Input.GetKey(KeyCode.S)) this.transform.position = new Vector3(this.transform.position.x,
                                                                           this.transform.position.y - speed * Time.deltaTime,
                                                                           this.transform.position.z);
        if (Input.GetKey(KeyCode.A)) this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime,
                                                                           this.transform.position.y,
                                                                           this.transform.position.z);
        if (Input.GetKey(KeyCode.D)) this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime,
                                                                           this.transform.position.y,
                                                                           this.transform.position.z);
        #endregion

        #region LookAtDirection // Not Working Yet
        Quaternion target;
        if (Input.GetKeyDown(KeyCode.W))
        {
            target = Quaternion.Euler(0,0,0);
            transform.rotation = target;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            target = Quaternion.Euler(0, 0, 180);
            transform.rotation = target;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            target = Quaternion.Euler(0, 0, 90);
            transform.rotation = target;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            target = Quaternion.Euler(0, 0, 270);
            transform.rotation = target;
        }
        #endregion

        #region SpecialKeys
        if (Input.GetKeyDown(KeyCode.LeftShift)) speed *= 1.5f;

        if (Input.GetKeyUp(KeyCode.LeftShift)) speed /= 1.5f;

        if (Input.GetKeyDown(KeyCode.Space) && !dodging) Dodge();
        #endregion
    }

    void Update () {
        Control();
        if(dodging)
        {
            timePassed += Time.deltaTime/2;
            speed = Mathf.Lerp(speed, 20,timePassed);
            if (Input.GetKey(KeyCode.W)) transform.Rotate(new Vector3(timePassed * 90, 0, 0));
            else if (Input.GetKey(KeyCode.S)) transform.Rotate(new Vector3(timePassed * -90, 0, 0));
            else if (Input.GetKey(KeyCode.A)) transform.Rotate(new Vector3(0, timePassed * 90, 0));
            else if (Input.GetKey(KeyCode.D)) transform.Rotate(new Vector3(0, timePassed * -90, 0));

        }

        if(speed <= 21)
        {
            speed = 20;
            dodging = false;
            timePassed = 0;
            Quaternion target = Quaternion.Euler(0, 0, 0);
            transform.rotation = target;
        }
    }
}
