using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject[] players;
    private GameObject[] heads;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        heads = GameObject.FindGameObjectsWithTag("Head");

        for(int i = 0; i < 3; i++)
        {
            if (!players[i].name.Equals(PlayerPrefs.GetString("Type")))
                players[i].SetActive(false);

            if (!heads[i].name.Equals(PlayerPrefs.GetString("Type")))
                heads[i].SetActive(false);
        }

    }

}
