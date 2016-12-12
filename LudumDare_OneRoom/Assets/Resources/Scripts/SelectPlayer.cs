using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayer : MonoBehaviour {

	void Start ()
    {
        if (this.gameObject.name.Equals("Warrior")) this.gameObject.GetComponent<Animator>().SetInteger("Type", 10); 
        else if (this.gameObject.name.Equals("Mage")) this.gameObject.GetComponent<Animator>().SetInteger("Type", 20);
        else this.gameObject.GetComponent<Animator>().SetInteger("Type", 30); ;
    }
}
