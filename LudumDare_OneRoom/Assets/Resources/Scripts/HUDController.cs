using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour {

    GameObject fadePanel;
    GameObject[] trapButtons;

	void Start () {

        if (GameObject.FindGameObjectWithTag("Fade") != null) fadePanel = GameObject.FindGameObjectWithTag("Fade");
        if (GameObject.FindGameObjectsWithTag("TrapButton") != null) trapButtons = GameObject.FindGameObjectsWithTag("TrapButton");
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
    
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.tag.Equals("Play"))
                    fadeScene("MainGame");
                else if (hit.collider.gameObject.tag.Equals("Options"))
                    fadeScene("Options");
                else if (hit.collider.gameObject.tag.Equals("TrapButton"))
                {
                    foreach(GameObject g in trapButtons)
                    {
                        g.GetComponent<TrapButton>().Selected = false;
                    }
                    hit.collider.gameObject.GetComponent<TrapButton>().Selected = true;
                    this.gameObject.GetComponent<TrapSpawn>().TrapType = int.Parse(hit.collider.gameObject.name);
                }
            }
        }
	}
}
