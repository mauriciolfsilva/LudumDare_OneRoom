using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour {

	// Use this for initialization
    GameObject fadePanel;
	void Start () {
        fadePanel = GameObject.FindGameObjectWithTag("Fade");
	}

    IEnumerator changeScene(string name)
    {
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(name);
    }
    
    void fadeScene(string name)
    {
        StartCoroutine(changeScene(name));
        fadePanel.GetComponent<Animator>().Play("FadeOut");
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.tag.Equals("Play"))
                    fadeScene("MainGame");
                else if (hit.collider.gameObject.tag.Equals("Options"))
                    fadeScene("Options");
            }
        }
	}
}
