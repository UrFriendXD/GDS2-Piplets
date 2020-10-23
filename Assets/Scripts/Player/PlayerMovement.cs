using System.Collections;
using Player;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAction control;
    public bool LadderMovement, endLadder, GroundCheck, GroundCheck2,GroundCheck3, WallCheck, isInteracting, falling, Stairs, endStairs, Out, isInside;
    [SerializeField] private float baseWalkSpeed,  fallspeed, upLadderSpeed, downLadderSpeed, maxfallspeed, fallspeedovertime, startfallspeed, upStairSpeed, downStairSpeed, stairSpeed;
    public float movementInput;
    public float ladderspeed;
    public float interactingObjectPos;
    // public GameObject UI, UI2;
    public GameObject menu;
    public bool isUIOn, isSleeping;
    public int input;

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
        isInside = true;
        isSleeping = false;
        control.player.Zero.performed += cxt => Zero();
        control.player.One.performed += cxt => One();
        control.player.Two.performed += cxt => Two();
        control.player.Three.performed += cxt => Three();
        control.player.Four.performed += cxt => Four();
        control.player.Five.performed += cxt => Five();
        control.player.Six.performed += cxt => Six();
        control.player.Seven.performed += cxt => Seven();
        control.player.Eight.performed += cxt => Eight();
        control.player.Nine.performed += cxt => Nine();
        control.player.Ten.performed += cxt => Ten();
        control.player.Eleven.performed += cxt => Eleven();
        control.player.Menu.performed += ctx => Menu();
        _playerScript = GetComponent<PlayerScript>();
    }

    public void Menu()
    {
        if (!isUIOn || menu.activeSelf)
        {
            menu.SetActive(!menu.activeSelf);
            isUIOn = !isUIOn;
        }
    }

    #region Selecting Items

    public void Zero()
    {
        _playerScript.SelectItem(0);
    } 

    public void One()
    {
        _playerScript.SelectItem(1);
    }

    public void Two()
    {
        _playerScript.SelectItem(2);
    }

    public void Three()
    {
        _playerScript.SelectItem(3);
    }
    
    private void Four()
    {
        _playerScript.SelectItem(4);
    }

    private void Five()
    {
        _playerScript.SelectItem(5);
    }
    private void Six()
    {
        _playerScript.SelectItem(6);
    }
    private void Seven()
    {
        _playerScript.SelectItem(7);
    }
    private void Eight()
    {
        _playerScript.SelectItem(8);
    }
    private void Nine()
    {
        _playerScript.SelectItem(9);
    }

    private void Ten()
    {
        _playerScript.SelectItem(10);
    }
    private void Eleven()
    {
        _playerScript.SelectItem(11);
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

    public void EndOn2()
    {
        endStairs = true;
    }

    public void OutOff()
    {
        Out = false;
    }

    public void OutOn()
    {
        Out = true;
    }

    public void EndOff2()
    {
        endStairs = false;
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

    public void GroundOn3()
    {
        GroundCheck3 = true;
    }

    public void GroundOff3()
    {
        GroundCheck3 = false;
    }

    public void StairsOff()
    {
        Stairs = false;
    }

    public void StairsOn()
    {
        Stairs = true;
    }

    public void WallOn()
    {
        WallCheck = true;
    }

    public void WallOff()
    {
        WallCheck = false;
    }

    public void ToggleMovement()
    {
        isUIOn = !isUIOn;
    }

    // public void PlayerMovementOn()
    // {
    //     if (UI.activeSelf || UI2.activeSelf)
    //     {
    //         isUIOn = false;
    //     }
    //     else
    //     {
    //         isUIOn = true;
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        //PlayerMovementOn();
        if (!isUIOn)
        {
            playerMoveRightAndLeft();
            if (LadderMovement == true)
            {
                LadderMoveUpAndDown();
            }
            if(Stairs == true)
            {
                StairMoveUpAndDown();
            }
            if (LadderMovement == false && GroundCheck == false && GroundCheck2 == false && GroundCheck3 == false && Stairs == false)
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
            if(Stairs == true && falling == true)
            {
                fall();
            }
            if (GroundCheck || LadderMovement || GroundCheck2 || GroundCheck3)
            {
                fallspeed = startfallspeed;
                falling = false;
            }
            if(GroundCheck3 == true)
            {
                this.GetComponent<SpriteRenderer>().sortingOrder = 5;
            }
            else if((GroundCheck == true || GroundCheck2 == true) && isInside == true)
            {
                this.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }else if ((GroundCheck == true || GroundCheck2 == true) && isInside == false)
            {
                this.GetComponent<SpriteRenderer>().sortingOrder = 5;
            }
        }
    }

    public void fall()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.y +=  -1 * fallspeed * Time.deltaTime;
        transform.position = currentPosition;
        _playerScript.playerAnimationController.OffLadder();

    }

    public void LadderMoveUpAndDown()
    {
        float movementInput = control.player.LadderMovement.ReadValue<float>();
        if(movementInput == 1)
        {
            ladderspeed = upLadderSpeed;
            _playerScript.playerAnimationController.ClimbingAnimation();
        }
        if(movementInput == -1)
        {
            ladderspeed = downLadderSpeed;
            _playerScript.playerAnimationController.SlidingAnimation();
        }
        if(movementInput == 1 && endLadder == true)
        {
            _playerScript.playerAnimationController.OffLadder();
            movementInput = 0;
        }
        if (movementInput == -1 && GroundCheck == true && LadderMovement == false)
        {
            _playerScript.playerAnimationController.OffLadder();
            movementInput = 0;
        }
        if(movementInput == -1 && LadderMovement == true && GroundCheck2 == true)
        {
            _playerScript.playerAnimationController.OffLadder();
            movementInput = 0;
        }
        
        if (LadderMovement)
        {
            switch (movementInput)
            {
                case -1: 
                    if (movementLadderDownAudioTimer <= 0)
                    {
                        _playerScript.playerAudio.PlayLadderDescentEvent();
                        movementLadderDownAudioTimer = movementLadderDownAudioDelay;
                    }
                    break;
                case 1:
                    if (movementLadderUpAudioTimer <= 0)
                    {
                        _playerScript.playerAudio.PlayLadderClimbEvent();
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
                movementInput = control.player.movement.ReadValue<float>();
                rotatePlayerMovement(movementInput);
                if(WallCheck == true && movementInput ==1 && transform.rotation.y == 0)
                {
                    movementInput = 0;
                }
                if (WallCheck == true && movementInput == -1 && transform.rotation.y != 0)
                {
                    movementInput = 0;
                }

                if ((movementInput == 1 || movementInput == -1) && (GroundCheck || GroundCheck2 || GroundCheck3))
                {
                    if (movementAudioTimer <= 0)
                    {
                        _playerScript.playerAudio.PlayWalkEvent();
                        movementAudioTimer = movementAudioTimerDelay;
                    }
                }

                if (movementAudioTimer > 0)
                {
                    movementAudioTimer -= Time.deltaTime;
                }
                
                _playerScript.playerAnimationController.WalkAnimation(Mathf.Abs(movementInput));

                Vector3 currentPosition = transform.position;
                currentPosition.x += movementInput * (baseWalkSpeed * _playerScript.playerStats.movespeed.Value) * Time.deltaTime;
                transform.position = currentPosition;
            }
            if (endLadder == true)
            {
                _playerScript.playerAnimationController.OffLadder();
                movementInput = control.player.movement.ReadValue<float>();
                rotatePlayerMovement(movementInput);
                Vector3 currentPosition = transform.position;
                currentPosition.x += movementInput * (baseWalkSpeed * _playerScript.playerStats.movespeed.Value) * Time.deltaTime;
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


    public void StairMoveUpAndDown()
    {
            float movementInput = control.player.LadderMovement.ReadValue<float>();
            if (movementInput == 1)
            {
                stairSpeed = upStairSpeed;
            }
            if (movementInput == -1)
            {
                stairSpeed = downStairSpeed;
            }
            if (movementInput == 1 && endStairs == true)
            {
                movementInput = 0;
            }
            if (movementInput == -1 && GroundCheck3 == true && Stairs == true)
            {
                movementInput = 0;
            }
            if(Out == true && movementInput == -1)
            {
                movementInput = 0;
            }
            Vector3 currentPosition = transform.position;
            currentPosition.y += movementInput * stairSpeed * Time.deltaTime;
            transform.position = currentPosition;
    }

}