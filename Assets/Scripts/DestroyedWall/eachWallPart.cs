using UnityEngine;
using System.Collections;

public class eachWallPart : MonoBehaviour {

    // Use this for initialization
    Rigidbody rb;
    BoxCollider sp;
    MeshRenderer mc;

    PartedWall root;
    
	void Start () {
        //root = transform.parent.GetComponent<PartedWall>();
        root = transform.root.GetComponent<PartedWall>();
        mc = GetComponent<MeshRenderer>();
        mc.enabled = false;

        rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.mass = 0.1f;

        sp = gameObject.AddComponent<BoxCollider>();
        sp.size /= 2; 

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision a)
    {
        
        if (Vector3.Distance(a.rigidbody.velocity+rb.velocity,Vector3.zero)>2 || a.gameObject.name.Contains("Rock"))
        {
            mc.enabled = true;
            rb.isKinematic = false;
            Destroy(this);

            if(root != null)
            {
                root.OnDestroy();

            }
        }
    }
}
