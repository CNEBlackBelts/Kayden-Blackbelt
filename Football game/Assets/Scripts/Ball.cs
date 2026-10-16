using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{



    //Part 2 - https://www.youtube.com/watch?v=DtBDwY9VlNo 26.10
    //Part 3 - https://www.youtube.com/watch?v=fp00FwAsmW4&list=PL_njPzrLL5Kc30i-JXHzdu2Hu3zvB5xEw&index=8
    //Part 4 https://www.youtube.com/watch?v=t3tBczQiMmY&list=PL_njPzrLL5Kc30i-JXHzdu2Hu3zvB5xEw&index=9
    //animation https://www.mixamo.com/#/?page=1&query=sitting+idle&type=Motion%2CMotionPack
    //assets https://assetstore.unity.com/packages/3d/vegetation/plants/stylized-potted-plants-290047
    //assets https://assetstore.unity.com/packages/3d/props/furniture/pbr-folding-chairs-135084
    //assets https://assetstore.unity.com/packages/3d/props/interior/low-poly-3d-lockers-239681

    [SerializeField] private Transform transformPlayer;
    private bool stickToPlayer;
    private Transform playerBallPosition;
    float speed;
    Vector3 previousLocation;
    Player scriptPlayer;

    public GameObject goal2;


    public bool StickToPlayer { get => stickToPlayer; set => stickToPlayer = value; }

    void Start()
    {
        playerBallPosition = transformPlayer.Find("Geometry").Find("BallLocation");
        scriptPlayer = transformPlayer.GetComponent<Player>();
    }

    void Update()
    {
        if (!StickToPlayer)
        {
            float distanceToPlayer = Vector2.Distance(transformPlayer.position, transform.position);
            if (distanceToPlayer < 0.5)
            {
                StickToPlayer = true;
                scriptPlayer.BallAttachedToPlayer = this;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "GoalDetector1")
        {

            scriptPlayer.IncreaseOtherScore();
            Debug.Log("You scored an own goal");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == goal2)
        {


            scriptPlayer.IncreaseMyScore();
        }
    }
}
