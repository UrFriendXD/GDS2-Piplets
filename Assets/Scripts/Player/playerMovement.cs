using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerAction control;
    public bool LadderMovement, endLadder, GroundCheck, isInteracting;
    [SerializeField] private float walkspeed, ladderspeed, fallspeed;
    public float interactingObjectPos;
    public int plantSeedType;
    
    private Player player;

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
        plantSeedType = 0;
        control.player.Sapling.performed += cxt => Sap();
        control.player.AloeSeed.performed += cxt => Aloe();
        control.player.CottonSeed.performed += cxt => Cotton();
        control.player.SelectWateringCan.performed += cxt => SelectWateringCan();
        control.player.SelectAxe.performed += cxt => SelectAxe();

        player = GetComponent<Player>();
    }

    #region Selecting Items
    public void Aloe()
    {
        player.SelectItem("Aloe Seed");
    }

    public void Cotton()
    {
        player.SelectItem("Cotton Seed");
    }

    public void Sap()
    {
        player.SelectItem("Tree Seed");
    }
    
    private void SelectWateringCan()
    {
        player.SelectItem("Watering Can");
    }

    private void SelectAxe()
    {
        player.SelectItem("Axe");
    }
    #endregion

    // Stops player movement when interacting
    public void Interact()
    {
        if (!isInteracting)
        {
            StartCoroutine(PlayAnimation(2f));
        }
    }
    
    // Sets objectPos to parameter when player touches an object
    public void TouchObject(float objectPos)
    {
        interactingObjectPos = objectPos;
    }

    private void RotatePlayer()
    {
        if (!isInteracting)
        {
            if (((transform.position.x > interactingObjectPos && interactingObjectPos !=0) && transform.rotation.y == 0))
            {
                this.transform.Rotate(0f, -180f, 0f);
            }
            if (((transform.position.x < interactingObjectPos && interactingObjectPos != 0)  && transform.rotation.y != 0))
            {
                this.transform.Rotate(0f, 180f, 0f);
            }
        }
    }
    
    // Stops player and rotates 
    private IEnumerator PlayAnimation(float time)
    {
        isInteracting = true;
        RotatePlayer();
        yield return new WaitForSeconds(time);
        isInteracting = false;
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
        if(LadderMovement == false && GroundCheck == false)
        {
            fall();
        }
    }

    public void fall()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y +=  -1 * fallspeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    public void LadderMoveUpAndDown()
    {
        float movementInput = control.player.LadderMovement.ReadValue<float>();
        if(movementInput == 1 && endLadder == true)
        {
            movementInput = 0;
        }
        if (movementInput == -1 && GroundCheck == true && LadderMovement == false)
        {
            movementInput = 0;
        }
        Vector3 currentPosition = transform.position;
        currentPosition.y += movementInput * ladderspeed * Time.deltaTime;
        transform.position = currentPosition;
    }

    public void playerMoveRightAndLeft()
    {
        if (!isInteracting)
        {
            if (endLadder == false)
            {
                float movementInput = control.player.movement.ReadValue<float>();
                rotatePlayerMovement(movementInput);
                Vector3 currentPosition = transform.position;
                currentPosition.x += movementInput * walkspeed * Time.deltaTime;
                transform.position = currentPosition;
            }
            if (endLadder == true)
            {
                float movementInput = control.player.movement.ReadValue<float>();
                rotatePlayerMovement(movementInput);
                Vector3 currentPosition = transform.position;
                currentPosition.x += movementInput * walkspeed * Time.deltaTime;
                transform.position = currentPosition;
            }
        }
    }

    public void rotatePlayerMovement(float movementInput)
    {
        if (movementInput < 0 && transform.rotation.y == 0)
        {
            this.transform.Rotate(0f, -180f, 0f);
        }
        if (movementInput > 0 && transform.rotation.y != 0)
        {
            this.transform.Rotate(0f, 180f, 0f);
        }
    }

}
