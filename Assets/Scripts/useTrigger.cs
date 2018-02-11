using UnityEngine;
using System.Collections;

public class useTrigger : MonoBehaviour {

    Canvas onUse;
    GameObject useGO;

    void Start () {
        onUse = GameObject.Find("onUseUI").GetComponent<Canvas>();
        onUse.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            if (onUse.enabled)
            {
                useGO.GetComponent<IUse>().Use();
                onUse.enabled = false;
            }

    }
    void OnTriggerEnter(Collider a)
    {
        useGO = a.gameObject.transform.root.gameObject;

        if (useGO.tag == "iuse")
        {
            onUse.enabled = true;
        }

    }
    void OnTriggerExit(Collider a)
    {
        if (a.transform.root.gameObject.tag == "iuse")
        {
            onUse.enabled = false;
        }
    }

}
