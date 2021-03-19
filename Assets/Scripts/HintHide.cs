using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintHide : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private Image imagePanel;
    void Start()
    {
        imagePanel = panel.GetComponent<Image>();   
    }
    void Update()
    {
        imagePanel.color = new Color(imagePanel.color.r, imagePanel.color.g, imagePanel.color.b, imagePanel.color.a-0.005f);
        if (imagePanel.color.a <= 0.1) 
            panel.SetActive(false);
    }
}
