using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private GameObject terrain;
    private Transform transformTerrain;

    void Start()
    {
        transformTerrain = terrain.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("touch " + other.name);
        if(other.tag=="Player") 
        {
                InvokeRepeating("RotChange", 0.01f,0.05f);
                //terrain.transform.rotation = new Quaternion(transformTerrain.rotation.x, transformTerrain.rotation.y-0.1f,transformTerrain.rotation.z,transformTerrain.rotation.w); 
        }
    }
    private void RotChange()
    {
        if (terrain.transform.rotation.y == 0 || terrain.transform.rotation.y > -90)
        {
        terrain.transform.rotation = new Quaternion(transformTerrain.rotation.x, transformTerrain.rotation.y - 0.1f, transformTerrain.rotation.z, transformTerrain.rotation.w);
        }
    }
}
