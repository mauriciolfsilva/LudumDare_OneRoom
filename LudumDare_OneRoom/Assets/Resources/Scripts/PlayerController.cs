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


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Trap"))
            Debug.Log("Morreu");
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
        if (Input.GetKey(KeyCode.W) && this.transform.position.y < 430) this.transform.position += Vector3.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S) && this.transform.position.y > -428) this.transform.position += Vector3.back * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A) && this.transform.position.x > -413) this.transform.position += Vector3.left * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) && this.transform.position.x < 445) this.transform.position += Vector3.right * speed * Time.deltaTime;
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
            else if (Input.GetKey(KeyCode.A)) transform.Rotate(new Vector3(0, 0, timePassed * 90));
            else if (Input.GetKey(KeyCode.D)) transform.Rotate(new Vector3(0, 0, timePassed * -90));

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

    void OnCollisionEnter(Collision collision)
    {
    }
}
