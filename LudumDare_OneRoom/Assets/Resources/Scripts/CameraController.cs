using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

<<<<<<< HEAD
=======
    GameObject player;
    public GameObject shadow;
    [SerializeField]
    private float speed;

>>>>>>> origin/master
    void Start()
    {
    }

    void Update ()
    {
<<<<<<< HEAD
=======
        if (this.tag.Equals("MainCamera"))
        {
            //Vector3 actualPoint = pointToSpawn();
            //shadow.transform.position = new Vector3(actualPoint.x, actualPoint.y, player.transform.position.z - 30f);
            if (Input.GetKey(KeyCode.W)) this.transform.position = new Vector3(this.transform.position.x,
                                                                                        this.transform.position.y + player.GetComponent<PlayerController>().Speed * Time.deltaTime,
                                                                                        this.transform.position.z);
            if (Input.GetKey(KeyCode.S)) this.transform.position = new Vector3(this.transform.position.x,
                                                                                        this.transform.position.y - player.GetComponent<PlayerController>().Speed * Time.deltaTime,
                                                                                        this.transform.position.z);
            if (Input.GetKey(KeyCode.A)) this.transform.position = new Vector3(this.transform.position.x - player.GetComponent<PlayerController>().Speed * Time.deltaTime,
                                                                                        this.transform.position.y,
                                                                                        this.transform.position.z);
            if (Input.GetKey(KeyCode.D)) this.transform.position = new Vector3(this.transform.position.x + player.GetComponent<PlayerController>().Speed * Time.deltaTime,
                                                                                        this.transform.position.y,
                                                                                        this.transform.position.z);
        }

        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) this.transform.position = new Vector3(this.transform.position.x,
                                                                                        this.transform.position.y + speed * Time.deltaTime,
                                                                                        this.transform.position.z);
            if (Input.GetKey(KeyCode.DownArrow)) this.transform.position = new Vector3(this.transform.position.x,
                                                                                        this.transform.position.y - speed * Time.deltaTime,
                                                                                        this.transform.position.z);
            if (Input.GetKey(KeyCode.LeftArrow)) this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime,
                                                                                        this.transform.position.y,
                                                                                        this.transform.position.z);
            if (Input.GetKey(KeyCode.RightArrow)) this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime,
                                                                                        this.transform.position.y,
                                                                                        this.transform.position.z);
            #region Camera Rotate
            /*if (Input.GetMouseButton(1) && Input.GetAxis("Mouse X") > 0)
            {
                transform.Rotate(new Vector3(0, speed*Time.deltaTime, 0));
            }

            else if (Input.GetMouseButton(1) && Input.GetAxis("Mouse X") < 0)
            {
                transform.Rotate(new Vector3(0, -speed * Time.deltaTime, 0));
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.fieldOfView > 20)
            {
                this.GetComponent<Camera>().fieldOfView -= speed * Time.deltaTime;
            }

            else if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.fieldOfView < 80)
            {
                this.GetComponent<Camera>().fieldOfView += speed * Time.deltaTime;
            }

            if (Input.GetAxis("Mouse Y") > 0 && Input.GetMouseButton(1))
            {
                transform.Rotate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }*/
            #endregion
        }
>>>>>>> origin/master
    }
}
