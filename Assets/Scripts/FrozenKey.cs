using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenKey : MonoBehaviour
{
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MeltIce()
    {
        meshRenderer.materials[1].color = new Color(0, 0, 0, 0);// sets the ice material of the key to invisible
    }
}
