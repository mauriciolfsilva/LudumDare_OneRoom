using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour {

	void Update () {
        if(Input.GetKey(KeyCode.X))
        {
            this.gameObject.GetComponent<Animator>().SetInteger("Type",2);
        }
    }
}