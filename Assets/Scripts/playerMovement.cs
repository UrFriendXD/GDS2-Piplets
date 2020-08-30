using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerAction control;
    public bool LadderMovement, endLadder, GroundCheck, chopping, watering, enoughSeed, planting, harvesting;
    [SerializeField] private float walkspeed, ladderspeed, fallspeed;
    public float treePos, plantPos;
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
        control.player.Action.performed += cxt => action();
        control.player.Sapling.performed += cxt => sap();
        control.player.AloeSeed.performed += cxt => aloe();
        control.player.CottonSeed.performed += cxt => cotton();
        control.player.Harvesting.performed += cxt => harvest();
        control.player.SelectWateringCan.performed += cxt => SelectWateringCan();
        control.player.SelectAxe.performed += cxt => SelectAxe();

        player = GetComponent<Player>();
    }

    public void aloe()
    {
        player.SelectItem("Aloe Seed");
    }

    public void cotton()
    {
        player.SelectItem("Cotton Seed");
    }

    public void sap()
    {
        player.SelectItem("Tree Seed");
    }

    public void plant()
    {
        rotatePlayer();
        //runs planting animation
        StartCoroutine(coolDownPlant(2f));
    }

    private void SelectWateringCan()
    {
        player.SelectItem("Watering Can");
    }

    private void SelectAxe()
    {
        player.SelectItem("Axe");
    }

    public void action()
    {
        player.InteractWithItem();
    }

    public void harvest()
    {
        player.InteractBare();
        rotatePlayer();
        //runs harvesting animation
        StartCoroutine(coolDownHarvest(2f));
    }

    public void plantOn(float value)
    {
        plantPos = value;
    }

    public void plantOff(float value)
    {
        plantPos = value;
    }

    public void chopOn(float value)
    {
        treePos = value;
    }

    public void chopOff(float value)
    {
        treePos = value;
    }


    public void chop() 
    { 
        rotatePlayer();
        //runs chopping animation
        StartCoroutine(coolDownAxe(2f));
    }

    public void Water()
    {
        rotatePlayer();
        //runs chopping animation
        StartCoroutine(coolDownWaterCan(2f));
    }

    public void rotatePlayer()
    {
        if ((chopping == false || watering == false ) || (planting == false  || (harvesting == false)))
        {
            if (((transform.position.x > treePos && treePos !=0)|| (transform.position.x > plantPos && plantPos != 0)) && transform.rotation.y == 0)
            {
                this.transform.Rotate(0f, -180f, 0f);
            }
            if (((transform.position.x < treePos && treePos != 0) || (transform.position.x < plantPos && plantPos != 0)) && transform.rotation.y != 0)
            {
                this.transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    IEnumerator coolDownAxe(float time)
    {
        chopping = true;
        yield return new WaitForSeconds(time);
        chopping = false;
    }

    IEnumerator coolDownHarvest(float time)
    {
        harvesting = true;
        yield return new WaitForSeconds(time);
        harvesting = false;
    }

    IEnumerator coolDownPlant(float time)
    {
        planting = true;
        yield return new WaitForSeconds(time);
        planting = false;
    }

    IEnumerator coolDownWaterCan(float time)
    {
        watering = true;
        yield return new WaitForSeconds(time);
        watering = false;
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
        if (chopping == false && watering == false && planting == false && harvesting == false)
        {
            if (GroundCheck == true && endLadder == false)
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
