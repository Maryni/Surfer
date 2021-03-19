using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerParent;
    private static bool needRotate = false;
    [SerializeField] private bool isLeft;
    [SerializeField] private bool isMiddle;
    [SerializeField] private bool isRight;
    [SerializeField] private float modReverse;
    [SerializeField] private float modX;
    [SerializeField] private float modZ;
    private float timer = 10f;
    private void Start()
    {
        needRotate = false;
    }
    private void FixedUpdate()
    {
        if (timer > 0f) timer -= 0.1f;
        if(timer <0)
        {
            PositionChanger();
            if (player.position.z >= 0 && player.position.z < 22.95)//22.2 = -0.55
            {
            player.position = new Vector3(player.position.x, player.position.y, player.position.z + 0.1f);
            }
            else if (player.position.z >= 22.95 && player.position.x < 19.75)
            {
            if (player.rotation.y == 0) { player.Rotate(0f, 90f, 0f); ResetToMiddle(); modZ = modX;modX = 0;}
            player.position = new Vector3(player.position.x + 0.1f, player.position.y, player.position.z);
            }
            if (player.position.x >= 19.7)
            {
            if (!needRotate) { player.Rotate(0f, 90f, 0f); needRotate = true; modX = modZ;modZ = 0;}
            modReverse = -1f;
            
            player.position = new Vector3(player.position.x, player.position.y, player.position.z - 0.2f);
            }
        }
    }
    private void PositionChanger()
    {
            //if ((Input.mousePosition).x > Screen.width / 2) { isRight = true; isLeft = false; } //To Right
            //if ((Input.mousePosition).x < Screen.width / 2) { isRight = false; isLeft = true; } //To Left

        if(Input.GetMouseButtonUp(0))
        {
            if (isLeft)
            {
                if (Input.GetKeyDown(KeyCode.D) || (Input.mousePosition).x > Screen.width / 2)
                {
                    player.position = new Vector3(player.position.x + modX * modReverse, player.position.y, player.position.z - modZ);
                    isLeft = false;
                    isMiddle = true;
                }
            }
            if (isMiddle)
            {
                if (Input.GetKeyDown(KeyCode.D) || (Input.mousePosition).x > Screen.width / 2)
                {
                    player.position = new Vector3(player.position.x + modX * modReverse, player.position.y, player.position.z - modZ);
                    isMiddle = false;
                    isRight = true;
                }
                if (Input.GetKeyDown(KeyCode.A) || (Input.mousePosition).x < Screen.width / 2)
                {
                    player.position = new Vector3(player.position.x - modX * modReverse, player.position.y, player.position.z + modZ);
                    isMiddle = false;
                    isLeft = true;
                }
            }
            if (isRight)
            {
                if (Input.GetKeyDown(KeyCode.A) || (Input.mousePosition).x < Screen.width / 2)
                {
                    player.position = new Vector3(player.position.x - modX * modReverse, player.position.y, player.position.z + modZ);
                    isRight = false;
                    isMiddle = true;
                }
            }
        }
        
    }
    private void ResetToMiddle()
    {
        isLeft = false;
        isRight = false;
        isMiddle = true;
    }
}
