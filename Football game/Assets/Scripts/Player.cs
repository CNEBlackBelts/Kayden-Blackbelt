using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //private StarterAssetsInputs starterAssetsInputs;
    //private Animator shootAnim;
    [SerializeField] TextMeshProUGUI mytextScore;
    [SerializeField] TextMeshProUGUI OpptextScore;
    [SerializeField] private int myscore = 0;
    [SerializeField] private int oppscore = 0;
    private Ball ballAttachedToPlayer;
    private float timeShot = -1f;
    public const int ANIMATION_LAYER_SHOOT = 1;
    private StarterAssetsInputs starterAssetsInputs;
    public GameObject PlayerArmature;
    public Animator shootAnim;
  


    public Ball BallAttachedToPlayer { get => ballAttachedToPlayer; set => ballAttachedToPlayer = value; }

    void Start()
    {

        shootAnim = GetComponent<Animator>();
        mytextScore.text = "" + myscore;
        OpptextScore.text = "" + oppscore;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timeShot = Time.time;
            // PlayerArmature.GetComponent<Animator>().Play("Shoot");
            shootAnim.Play("Shoot");
        }
        if (timeShot > 0)
        {
            // shoot ball
            if (ballAttachedToPlayer != null && Time.time - timeShot > 0.2)
            {
                ballAttachedToPlayer.StickToPlayer = false;

                Rigidbody rigidbody = ballAttachedToPlayer.transform.gameObject.GetComponent<Rigidbody>();
                Vector3 shootdirection = transform.forward;
                shootdirection.y += 0.3f;
                rigidbody.AddForce(shootdirection * 20f, ForceMode.Impulse);

                ballAttachedToPlayer = null;
            }

            //finish kicking animation
            if (Time.time - timeShot > 0.5)
            {
                timeShot = -1f;
            }

        }
        else
        {
            shootAnim.SetLayerWeight(ANIMATION_LAYER_SHOOT, Mathf.Lerp(shootAnim.GetLayerWeight(ANIMATION_LAYER_SHOOT), 0f, Time.deltaTime * 10f));

        }
    }



    public void IncreaseMyScore()
    {
        myscore++;
        mytextScore.text = "" +myscore;


    }

    public void IncreaseOtherScore()
    {
        oppscore++;
        OpptextScore.text = "" + oppscore;
    }

}
