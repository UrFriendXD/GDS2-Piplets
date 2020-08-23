using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerAction control;
    public bool LadderMovement, endLadder, GroundCheck, canChop, chopping;
    [SerializeField] private float walkspeed, ladderspeed;
    public float treePos;

    void Awake()
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
        endLadder = false;
        chopping = false;
        control.player.ChopTree.performed += cxt => chop();
    }

    public void chopOn(float value)
    {
        treePos = value;
        canChop = true;
    }

    public void chopOff()
    {
        canChop = false;
    }

    public void chop()
    {
        if (canChop == true && chopping == false)
        {
            if(transform.position.x > treePos && transform.rotation.y == 0)
            {
               this.transform.Rotate(0f, -180f, 0f);
            }
            if(transform.position.x < treePos && transform.rotation.y != 0)
            {
               this.transform.Rotate(0f, 180f, 0f);
            }
            //runs chopping animation
            StartCoroutine(coolDown(2f));
        }
    }

    IEnumerator coolDown(float time)
    {
        chopping = true;
        axe Axe = gameObject.GetComponentInChildren<axe>();
        Axe.axeOn();
        yield return new WaitForSeconds(time);
        chopping = false;
        Axe.axeOff();
    }

    public void LadderOn()
    {
        LadderMovement = true;
    }

    public void EndOn()
    {
        endLadder = true;
    }

    public void EndOff()
    {
        endLadder = false;
    }

    public void LadderOff()
    {
        LadderMovement = false;
    }

    public void GroundOn()
    {
        GroundCheck = true;
    }

    public void GroundOff()
    {
        GroundCheck = false;
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
        if(movementInput == 1 && endLadder == true)
        {
            movementInput = 0;
        }
        if (movementInput == -1 && GroundCheck == true)
        {
            movementInput = 0;
        }
        Vector3 currentPosition = transform.position;
        currentPosition.y += movementInput * ladderspeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    public void playerMoveRightAndLeft()
    {
        if (chopping == false)
        {
            if (GroundCheck == true && endLadder == false)
            {
                float movementInput = control.player.movement.ReadValue<float>();
                if(movementInput < 0 && transform.rotation.y == 0)
                {
                    this.transform.Rotate(0f, -180f, 0f);
                }
                if (movementInput > 0 && transform.rotation.y != 0)
                {
                    this.transform.Rotate(0f, 180f, 0f);
                }
                Vector3 currentPosition = transform.position;
                currentPosition.x += movementInput * walkspeed * Time.deltaTime;
                transform.position = currentPosition;
            }
            if (endLadder == true)
            {
                float movementInput = control.player.movement.ReadValue<float>();
                if (movementInput < 0 && transform.rotation.y == 0)
                {
                    this.transform.Rotate(0f, -180f, 0f);
                }
                if (movementInput > 0 && transform.rotation.y != 0)
                {
                    this.transform.Rotate(0f, 180f, 0f);
                }
                Vector3 currentPosition = transform.position;
                currentPosition.x += movementInput * walkspeed * Time.deltaTime;
                transform.position = currentPosition;
            }
        }
    }

}
