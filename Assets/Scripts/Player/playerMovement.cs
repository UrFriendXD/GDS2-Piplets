using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerAction control;
    public bool LadderMovement, endLadder, GroundCheck, WallCheck, isInteracting, falling;
    [SerializeField] private float walkspeed, ladderspeed, fallspeed, upLadderSpeed, downLadderSpeed, maxfallspeed, fallspeedovertime, startfallspeed;
    public float interactingObjectPos;
    public int plantSeedType;
    public GameObject UI;
    public GameObject menu;
    public bool On;
    
    private PlayerScript player;

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
        control.player.Menu.performed += ctx => Menu();
        player = GetComponent<PlayerScript>();
    }

    public void Menu()
    {
        menu.SetActive(!menu.activeSelf);
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

    public void WallOn()
    {
        WallCheck = true;
    }

    public void WallOff()
    {
        WallCheck = false;
    }

    public void PlayerMovementOn()
    {
        if (UI.activeSelf || menu.activeSelf)
        {
            On = false;
        }
        else
        {
            On = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementOn();
        if (On)
        {
            playerMoveRightAndLeft();
            if (LadderMovement == true)
            {
                LadderMoveUpAndDown();
            }
            if (LadderMovement == false && GroundCheck == false)
            {
                falling = true;
                if (fallspeed < maxfallspeed)
                {
                    fallspeed += fallspeedovertime * Time.deltaTime;
                }
                if (falling == true)
                {
                    fall();
                }
            }
            if (GroundCheck || LadderMovement)
            {
                fallspeed = startfallspeed;
                falling = false;
            }
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
        if(movementInput == 1)
        {
            ladderspeed = upLadderSpeed;
        }
        if(movementInput == -1)
        {
            ladderspeed = downLadderSpeed;
        }
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
                if(WallCheck == true && movementInput ==1 && transform.rotation.y == 0)
                {
                    movementInput = 0;
                }
                if (WallCheck == true && movementInput == -1 && transform.rotation.y != 0)
                {
                    movementInput = 0;
                }
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
