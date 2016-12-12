using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed;

    private bool dodging;
    private float timePassed;
    private bool dead;

    public bool Dead
    {
        get
        {
            return dead;
        }
        set
        {
            dead = value;
        }
    }

    void Start() {
        speed = 50;
        dodging = false;
        timePassed = 0;
        dead = false;
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
        this.gameObject.GetComponent<Animator>().Play("Dodge");
        this.gameObject.GetComponent<Animator>().SetInteger("Type", 1);
    }

    void Control()
    {
        #region MoveDirection
        if (Input.GetKey(KeyCode.W) && this.transform.position.y < 430)
        {
            this.transform.position += Vector3.forward * speed * Time.deltaTime;
            if(this.gameObject.GetComponent<Animator>().GetInteger("Type") == 0)
            this.gameObject.GetComponent<Animator>().SetInteger("Type", 3);
        }
        else if (Input.GetKey(KeyCode.S) && this.transform.position.y > -428)
        {
            this.transform.position += Vector3.back * speed * Time.deltaTime;
            if (this.gameObject.GetComponent<Animator>().GetInteger("Type") == 0)
                this.gameObject.GetComponent<Animator>().SetInteger("Type", 3);
        }
        if (Input.GetKey(KeyCode.A) && this.transform.position.x > -413)
        {
            this.transform.position += Vector3.left* speed * Time.deltaTime;
            if (this.gameObject.GetComponent<Animator>().GetInteger("Type") == 0)
                this.gameObject.GetComponent<Animator>().SetInteger("Type", 3);
        }
        else if (Input.GetKey(KeyCode.D) && this.transform.position.x< 445)
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
            if (this.gameObject.GetComponent<Animator>().GetInteger("Type") == 0)
                this.gameObject.GetComponent<Animator>().SetInteger("Type", 3);
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) && this.gameObject.GetComponent<Animator>().GetInteger("Type") != 2) this.gameObject.GetComponent<Animator>().Play("Walk"); ;
        if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift)) this.gameObject.GetComponent<Animator>().SetInteger("Type", 0);
        #endregion

        #region LookAtDirection
        Quaternion target;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 315, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 45, 0);
            else target = Quaternion.Euler(0,0,0);
            transform.rotation = target;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 225, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 135, 0);
            else target = Quaternion.Euler(0, 180, 0);
            transform.rotation = target;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 315, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 225, 0);
            else target = Quaternion.Euler(0, 270, 0);
            transform.rotation = target;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 45, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 135, 0);
            else target = Quaternion.Euler(0, 90, 0);
            transform.rotation = target;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 270, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 90, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 180, 0);
            else target = transform.rotation;
            transform.rotation = target;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 270, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 90, 0);
            else if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 0, 0);
            else target = transform.rotation;
            transform.rotation = target;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 0, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 180, 0);
            else if (Input.GetKey(KeyCode.D)) target = Quaternion.Euler(0, 90, 0);
            else target = Quaternion.Euler(0, 270, 0);
            transform.rotation = target;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W)) target = Quaternion.Euler(0, 0, 0);
            else if (Input.GetKey(KeyCode.S)) target = Quaternion.Euler(0, 180, 0);
            else if (Input.GetKey(KeyCode.A)) target = Quaternion.Euler(0, 270, 0);
            else target = transform.rotation;
            transform.rotation = target;
        }
        #endregion

        #region SpecialKeys
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 1.5f;
            this.gameObject.GetComponent<Animator>().Play("Running");
            this.gameObject.GetComponent<Animator>().SetInteger("Type", 2);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 1.5f;
            this.gameObject.GetComponent<Animator>().SetInteger("Type", 3);
        }

        //if (Input.GetKeyDown(KeyCode.Space) && !dodging) Dodge();
        #endregion
    }

    void Update () {
        
        if(dead)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= 1.3f)
            {
                Application.LoadLevel("Menu");
            }
        }
        else Control();
    }
}