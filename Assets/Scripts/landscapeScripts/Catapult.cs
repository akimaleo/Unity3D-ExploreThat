using UnityEngine;
using System.Collections;

public class Catapult : MonoBehaviour,IUse
{
    Animator cat;
    public bool isAnim;
    Transform theSun;
    void Start()
    {

        cat = GetComponent<Animator>();
        cat.enabled = false;
        isAnim = true;
        theSun = GameObject.Find("Directional Light").transform;

    }
    void Update()
    {
        theSun.Rotate(new Vector3(0.5f, 0, 0));
        if (!isAnim)
        {
            cat.enabled = false;
        }
    }

    public void Use()
    {
        cat.enabled = true;
        tag = "Untagged";
        Destroy(this, 5);
    }
}