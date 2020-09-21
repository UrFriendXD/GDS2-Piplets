using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class PlayerAnimationController : MonoBehaviour
{
    
    private Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Watering = Animator.StringToHash("Watering");

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
}
