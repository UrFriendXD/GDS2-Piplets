using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipletAnimationController : MonoBehaviour
{
    
    private Animator animator;
    private static readonly int Moving = Animator.StringToHash("Moving");


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void MovingAnimation()
    {
        animator.SetBool(Moving, true);
    }
    
    public void IdleAnimation()
    {
        animator.SetBool(Moving, false);
    }
}
