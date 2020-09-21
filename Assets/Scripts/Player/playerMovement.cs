using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerAction control;
    public bool LadderMovement, endLadder, GroundCheck, GroundCheck2, WallCheck, isInteracting, falling;
    [SerializeField] private float walkspeed, ladderspeed, fallspeed, upLadderSpeed, downLadderSpeed, maxfallspeed, fallspeedovertime, startfallspeed;
    public float interactingObjectPos;
    public int plantSeedType;
    public GameObject UI, UI2;
    public GameObject menu;
    public bool On;
    
    private PlayerScript _playerScript;
    private float movementAudioTimer;
    [SerializeField] private float movementAudioTimerDelay = 0.7f;
    private float movementLadderUpAudioTimer;
    [SerializeField] private float movementLadderUpAudioTimerDelay = 0.7f;    
    private float movementLadderDownAudioTimer;
    [SerializeField] private float movementLadderDownAudioDelay = 0.7f;

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
        _playerScript = GetComponent<PlayerScript>();
    }

    public void Menu()
    {
        menu.SetActive(!menu.activeSelf);
    }

    #region Selecting Items
    public void Aloe()
    {
        _playerScript.SelectItem("Aloe Seed");
    }

    public void Cotton()
    {
        _playerScript.SelectItem("Cotton Seed");
    }

    public void Sap()
    {
        _playerScript.SelectItem("Tree Seed");
    }
    
    private void SelectWateringCan()
    {
        _playerScript.SelectItem("Watering Can");
    }

    private void SelectAxe()
    {
        _playerScript.SelectItem("Axe");
    }
    #endregion

    // Stops player movement when interacting
    public void Interact()
    {
        if (!isInteracting)
        {
            StartCoroutine(PlayAnimation(1f));
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
    public void GroundOn2()
    {
        GroundCheck2 = true;
    }

    public void GroundOff2()
    {
        GroundCheck2 = false;
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
        if (UI.activeSelf || menu.activeSelf || UI2.activeSelf)
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
            if (LadderMovement == false && GroundCheck == false && GroundCheck2 == false)
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
            if (GroundCheck || LadderMovement || GroundCheck2)
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
        if(movementInput == -1 && LadderMovement == true && GroundCheck2 == true)
        {
            movementInput = 0;
        }

        if (LadderMovement)
        {
            switch (movementInput)
            {
                case -1: 
                    if (movementLadderDownAudioTimer <= 0)
                    {
                        _playerScript.PlayerAudio.PlayLadderDescentEvent();
                        movementLadderDownAudioTimer = movementLadderDownAudioDelay;
                    }
                    break;
                case 1:
                    if (movementLadderUpAudioTimer <= 0)
                    {
                        _playerScript.PlayerAudio.PlayLadderClimbEvent();
                        movementLadderUpAudioTimer = movementLadderUpAudioTimerDelay;
                    }
                    break;
            }
        }
        if (movementLadderDownAudioTimer > 0)
        {
            movementLadderDownAudioTimer -= Time.deltaTime;
        }
        if (movementLadderUpAudioTimer > 0)
        {
            movementLadderUpAudioTimer -= Time.deltaTime;
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

                if ((movementInput == 1 || movementInput == -1) && (GroundCheck || GroundCheck2))
                {
                    if (movementAudioTimer <= 0)
                    {
                        _playerScript.PlayerAudio.PlayWalkEvent();
                        movementAudioTimer = movementAudioTimerDelay;
                    }
                }

                if (movementAudioTimer > 0)
                {
                    movementAudioTimer -= Time.deltaTime;
                }
                
                _playerScript.PlayerAnimationController.WalkAnimation(Mathf.Abs(movementInput));

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