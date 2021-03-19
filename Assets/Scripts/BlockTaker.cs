using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockTaker : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int countBlocksUnderPlayer;
    [SerializeField] private GameObject block;
    [SerializeField] private Transform transformBlock;
    [SerializeField] private Text textCount;
    [SerializeField] private List<GameObject> blocks;
    [SerializeField] private bool isFail;
    [SerializeField] private GameObject textLose;
    [SerializeField] private Button buttonLose;
    [SerializeField] private GameObject cameraSec;
    private void TakeBlock()
    {
        if(!isFail)
        {
            transformBlock = block.transform;
            transformBlock.parent = player;
            blocks.Add(block);


            player.position = new Vector3(player.position.x, player.position.y + 0.5f, player.position.z);
            transformBlock.localPosition = new Vector3(0f, -1.52f - (1f * countBlocksUnderPlayer), 0f);
            countBlocksUnderPlayer++;
        }
        if(isFail)
        {
            if (countBlocksUnderPlayer == 0)
            {
                textLose.SetActive(true);
                cameraSec.SetActive(true);
                player.gameObject.SetActive(false);
                buttonLose.gameObject.SetActive(true);
                
            }
            player.position = new Vector3(player.position.x, player.position.y - 0.5f, player.position.z);
            var temp = blocks[blocks.Count - 1];
            blocks.Remove(temp);
            temp.SetActive(false);
            countBlocksUnderPlayer--;
            
        }
        textCount.text = countBlocksUnderPlayer.ToString();
    }
    public void GetBlock(GameObject blockTaken, bool fail)
    {
        isFail = fail;
        block = blockTaken;
        TakeBlock();
    }
    public void ReloadLevel()
    {
        SceneManager.LoadSceneAsync("Game");
    }
}
