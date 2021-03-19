using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    [SerializeField] private BlockTaker blockTaker;
    [SerializeField] private bool isFail;

    private void Start()
    {
        GameObject temp = GameObject.Find("GameManager");
        blockTaker = temp.gameObject.GetComponent<BlockTaker>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag =="Player")
        {
            blockTaker.GetBlock(this.gameObject, isFail);
        }
    }
}
