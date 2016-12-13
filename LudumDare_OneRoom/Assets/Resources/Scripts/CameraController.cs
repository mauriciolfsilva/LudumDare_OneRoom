using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject[] players;
    private GameObject[] heads;
    [SerializeField]
    private GameObject cloud;
    private float timeToSpawn;


    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        heads = GameObject.FindGameObjectsWithTag("Head");
        timeToSpawn = 0;

        for(int i = 0; i < 3; i++)
        {
            if (!players[i].name.Equals(PlayerPrefs.GetString("Type")))
                players[i].SetActive(false);

            if (!heads[i].name.Equals(PlayerPrefs.GetString("Type")))
                heads[i].SetActive(false);
        }

    }

    void Update()
    {
        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn <= 0)
        {
            Vector3 target = new Vector3(950, -90, Random.Range(0,950));
            timeToSpawn = Random.Range(0,6);
            cloud.transform.position = target;
            Instantiate(cloud);
        }
    }

}
