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

    Vector3 pointToSpawn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.Log("Is executing");
            return hit.point;
        }
        else
            return Vector3.zero;
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
        if (Input.GetMouseButtonDown (0))
        {
            Spawn(trapType);
        }
	}

    void Spawn(int type)
    {
        Vector3 pos = pointToSpawn();
        traps[type].transform.position = new Vector3(pos.x,20,pos.z);
        Instantiate(traps[type]);        
    }
}