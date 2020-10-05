using System.Collections;
using System.Collections.Generic;
using Environment.Indoors;
using UnityEngine;
using Player;

public class PlayerAnimationController : MonoBehaviour
{
    
    private Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Watering = Animator.StringToHash("Watering");
    private static readonly int Climbing = Animator.StringToHash("Climbing");
    private static readonly int Sliding = Animator.StringToHash("Sliding");
    private static readonly int Chopping = Animator.StringToHash("Chopping");
    private static readonly int Planting = Animator.StringToHash("Planting");


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void WalkAnimation(float value)
    {
        animator.SetFloat(Speed, value);
    }

    public void WateringAnimation()
    {
        animator.SetTrigger(Watering);
    }
    
    public void ChoppingAnimation()
    {
        animator.SetTrigger(Chopping);
    }
    public void PlantingAnimation()
    {
        animator.SetTrigger(Planting);
    }  
    
    public void ClimbingAnimation()
    {
        animator.SetBool(Climbing, true);
        animator.SetBool(Sliding, false);
    }
    
    public void SlidingAnimation()
    {
        animator.SetBool(Climbing, false);
        animator.SetBool(Sliding, true);
    }

    public void OffLadder()
    {
        animator.SetBool(Climbing, false);
        animator.SetBool(Sliding, false);
    }
}
