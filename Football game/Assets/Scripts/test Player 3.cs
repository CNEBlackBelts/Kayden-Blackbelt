using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class testPlayer3 : MonoBehaviour
{
    private TextMeshProUGUI textscore;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    private Ball2 ballAttachedToPlayer;
    private float timeShot = -1;
    public const int ANIMATION_LAYER_SHOOT = 1;
    private int myScore, otherScore;

    public Ball2 BallAttachedToPlayer { get => ballAttachedToPlayer; set => ballAttachedToPlayer = value; }

    void Start()
    {

    }


    void Update()
    {
        if (starterAssetsInputs.shoot)
        {
            starterAssetsInputs.shoot = false;
            timeShot = Time.time;
            animator.Play("Shoot", ANIMATION_LAYER_SHOOT, 0f);
            animator.SetLayerWeight(ANIMATION_LAYER_SHOOT, 1f);
        }
        if (timeShot>0)
        {
            // shoot ball
            if (ballAttachedToPlayer != null && Time.time - timeShot > 0.2)
            {
                ballAttachedToPlayer.stickToPlayer = false;

                Rigidbody rigidbody = ballAttachedToPlayer.transform.gameObject.GetComponent<Rigidbody>();
                Vector3 shootdirection = transform.forward;
                shootdirection.y += 0.5f;
                rigidbody.AddForce(shootdirection * 20f, ForceMode.Impulse);

                ballAttachedToPlayer = null;
            }

            // finish kicking animation
            if (Time.time - timeShot > 0.5)
            {
                timeShot = -1f;
            }
        }
        else
        {
            animator.SetLayerWeight(ANIMATION_LAYER_SHOOT, Mathf.Lerp(animator.GetLayerWeight(ANIMATION_LAYER_SHOOT), 0f, Time.deltaTime * 10f));
        }
    }


    public void IncreaseMyScore()
    {
        myScore++;
    }

    public void IncreaseOtherScore()
    {
        otherScore++;
    }


    //1 04 47     42 48
}
