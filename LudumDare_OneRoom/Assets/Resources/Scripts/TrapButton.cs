using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapButton : MonoBehaviour {

    private bool selected;
    [SerializeField]
    private int direction;

    public bool Selected
    {
        get
        {
            return selected;
        }

        set
        {
            selected = value;
        }
    }

	void Update () {
		if(selected)
        {
            if (this.gameObject.name.Equals("2"))
            {
                float temp = Time.deltaTime;
                transform.localScale += new Vector3(direction * temp/2, direction * temp/2, direction * temp/2);
                if (transform.localScale.x >= 1.5f || transform.localScale.x <= 1)
                {
                    direction *= -1;

                    if (transform.localScale.x >= 1.5f) transform.localScale = new Vector3(1.45f, 1.45f, 1.45f);
                    else transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
                }
                    
            }

            else
            transform.Rotate(new Vector3(Time.deltaTime * 40, 0,0));
        }

        else
        {
            if (!this.name.Equals("2"))
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            }
            else transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
            transform.localScale = new Vector3(1,1,1);
        }
	}
}