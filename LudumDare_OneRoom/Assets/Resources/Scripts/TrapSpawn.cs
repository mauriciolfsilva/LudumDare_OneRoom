using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawn : MonoBehaviour {
    [SerializeField]
    private GameObject[] traps;
    private int trapType;

    public int TrapType
    {
        get
        {
            return trapType;
        }

        set
        {
            trapType = value;
        }
    }

    public GameObject[] Traps
    {
        get
        {
            return Traps;
        }
    }

	void Start ()
    {
        trapType = 0;
	}
	
	void Update ()
    {
		if(Input.GetMouseButton(1))
        {
            Spawn(trapType);
        }
	}

    void Spawn(int type)
    {
        Camera cam = this.gameObject.GetComponent<Camera>();
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        traps[type].transform.position = new Vector3(pos.x,pos.y,180);
        Instantiate(traps[type]);        
    }
}