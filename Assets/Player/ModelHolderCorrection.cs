using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelHolderCorrection : MonoBehaviour
{
    public GameObject collider;
    public GameObject mesh;
    public Vector3 pos;
    // Update is called once per frame
    void Update()
    {

        pos.x = collider.transform.position.x;
        mesh.transform.position = pos;
    }
}
