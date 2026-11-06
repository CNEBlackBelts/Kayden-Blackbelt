using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] private Player scriptPlayer;

    public GameObject GoalDetector;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            if (name.Equals("GoalDetector1"))
            {
                Game.Instance.ScoreGoal(1);
            }
            else
            {
                Game.Instance.ScoreGoal(0);
            }
        }
    }
}

    






