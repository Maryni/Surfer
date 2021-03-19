using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject cam;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            text.SetActive(true);
            button.SetActive(true);
            cam.SetActive(true);
        }
    }
}
