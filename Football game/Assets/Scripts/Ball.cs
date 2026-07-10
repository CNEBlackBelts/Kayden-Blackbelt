using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform transformPlayer;
    private bool stickToPlayer;
    private Transform playerBallPosition;
    float speed;
    Vector3 previousLocation;
    Player scriptPlayer;


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

}
