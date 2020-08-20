using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerAction control;
    public bool LadderMovement;
    [SerializeField] private float walkspeed, ladderspeed;

    void awake()
    {
        control = new PlayerAction();
    }

    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        LadderMovement = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerMoveRightAndLeft();
        if(LadderMovement == true)
        {
            LadderMoveUpAndDown();
        }
    }

    public void LadderMoveUpAndDown()
    {
        float movementInput = control.player.LadderMovement.ReadValue<float>();
        Vector3 currentPosition = transform.position;
        currentPosition.y += movementInput * ladderspeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    public void playerMoveRightAndLeft()
    {
        float movementInput = control.player.movement.ReadValue<float>();
        /**
        if (movementInput > 0)
        {
            if (transform.rotation.y != 0)
            {
                transform.Rotate(0f,0f,0f);
            }
        }
        if (movementInput < 0)
        {
            if (transform.rotation.y != 180)
            {
                transform.Rotate(0f,180f,0f);
            }
        }
        **/
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * walkspeed * Time.deltaTime;
        transform.position = currentPosition;
    }

}
