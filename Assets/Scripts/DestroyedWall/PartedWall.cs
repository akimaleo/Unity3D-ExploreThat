using UnityEngine;
using System.Collections;

public class PartedWall : MonoBehaviour {

    bool destroyed = false;
    public void OnDestroy()
    {
        if (!destroyed)
        {
            mc.enabled = false;
            for (int i = 0; i < partsOfWall; i++)
                mmc[i].enabled = true;
        }
    }
    GameObject[] partedWallGo;
    

    MeshRenderer mc;
    MeshRenderer[] mmc;

    int partsOfWall;
    void Start()
    {
        partsOfWall = transform.GetChild(1).childCount;
        mc = transform.GetChild(0).GetComponent<MeshRenderer>();

        partedWallGo = new GameObject[partsOfWall];
        mmc = new MeshRenderer[partsOfWall];
        for (int i = 0; i < partsOfWall; i++)
        {
            partedWallGo[i] = transform.GetChild(1).GetChild(i).gameObject;
            partedWallGo[i].AddComponent<eachWallPart>();
            mmc[i] = partedWallGo[i].GetComponent<MeshRenderer>();
        }
    }
	
	void Update () {
	
	}

}
