using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> lineL;
    [SerializeField] private List<Transform> lineM;
    [SerializeField] private List<Transform> lineR;
    [SerializeField] private int blockCount;
    private int blockAtLine;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject blockFail;
    [SerializeField] private int[] arr = {0,1,2,3,4,5,6,7,8,9,10,11,12,13 };
    [SerializeField] private List<int> arrNumbers;
    void Start()
    {
        GetRandomBlockCount();
    }
    private void GetRandomBlockCount()
    {
        blockCount = Random.Range(9, 21);
        blockAtLine = blockCount / 3;
        SpawnBlock();
        SpawnFails();
    }
    private void SpawnBlock()
    {
        for (int i = 0; i < blockAtLine / 3; i++)
        {
            arrNumbers.Add(Random.Range(0, 14));
        }
        for (int i = 0; i < arrNumbers.Count; i++)
        {
            Instantiate(block, lineL[arrNumbers[i]]);
        }
        arrNumbers.Clear();


        for (int i = 0; i < blockAtLine / 3; i++)
        {
            arrNumbers.Add(Random.Range(0, 14));
        }
        for (int i = 0; i < arrNumbers.Count; i++)
        {
            Instantiate(block, lineM[arrNumbers[i]]);
        }
        arrNumbers.Clear();


        for (int i = 0; i < blockAtLine / 3; i++)
        {
            arrNumbers.Add(Random.Range(0, 14));
        }
        for (int i = 0; i < arrNumbers.Count; i++)
        {
            Instantiate(block, lineR[arrNumbers[i]]);
        }
    }
    private void SpawnFails()
    {
        for (int i = 0; i < blockAtLine / 3; i++)
        {
            arrNumbers.Add(Random.Range(0, 14));
        }
        for (int i = 0; i < arrNumbers.Count; i++)
        {
            Instantiate(blockFail, lineL[arrNumbers[i]]);
        }
        arrNumbers.Clear();


        for (int i = 0; i < blockAtLine / 3; i++)
        {
            arrNumbers.Add(Random.Range(0, 14));
        }
        for (int i = 0; i < arrNumbers.Count; i++)
        {
            Instantiate(blockFail, lineM[arrNumbers[i]]);
        }
        arrNumbers.Clear();


        for (int i = 0; i < blockAtLine / 3; i++)
        {
            arrNumbers.Add(Random.Range(0, 14));
        }
        for (int i = 0; i < arrNumbers.Count; i++)
        {
            Instantiate(blockFail, lineR[arrNumbers[i]]);
        }
    }
}
