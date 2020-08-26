using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private PlayerAction control;
    public bool LadderMovement, endLadder, GroundCheck, canChop, chopping, canWater, watering, enoughSeed, canPlant, planting, canHarvest, harvesting;
    [SerializeField] private float walkspeed, ladderspeed;
    public float treePos, waterPos;
    public int plantSeedType;

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
        LadderMovement = false;
        endLadder = false;
        chopping = false;
        watering = false;
        control.player.ChopTree.performed += cxt => chop();
        control.player.WaterPlant.performed += cxt => water();
        control.player.Sapling.performed += cxt => sap();
        control.player.AloeSeed.performed += cxt => aloe();
        control.player.CottonSeed.performed += cxt => cotton();
        control.player.PlantSeed.performed += cxt => plant();
        control.player.Harvesting.performed += cxt => harvest();
    }

    public void sap()
    {
        plantSeedType = 1;
        this.GetComponent<PlantManagement>().switchSeedType(plantSeedType);
    }

    public void aloe()
    {
        plantSeedType = 2;
        this.GetComponent<PlantManagement>().switchSeedType(plantSeedType);
    }

    public void cotton()
    {
        plantSeedType = 3;
        this.GetComponent<PlantManagement>().switchSeedType(plantSeedType);
    }

    public void plant()
    {
        if (enoughSeed == true && canPlant == true)
        {
            rotatePlayer();
            //runs planting animation
            StartCoroutine(coolDownPlant(2f));
        }
    }

    public void harvest()
    {
        if (canHarvest == true)
        {
            rotatePlayer();
            //runs harvesting animation
            StartCoroutine(coolDownHarvest(2f));
        }
    }

    

    public void updateSeed(int value)
    {
        if(value > 0)
        {
            enoughSeed = true;
        }
        else
        {
            enoughSeed = false;
        }
    }

    public void plantOn()
    {
        canPlant = true;
    }

    public void plantOff()
    {
        canPlant = false;
    }

    public void harvestOn()
    {
        canHarvest = true;
    }

    public void harvestOff()
    {
        canHarvest = false;
    }

    public void waterOn(float value)
    {
        waterPos = value;
        canWater = true;
    }

    public void waterOff(float value)
    {
        waterPos = value;
        canWater = false;
    }

    public void chopOn(float value)
    {
        treePos = value;
        canChop = true;
    }

    public void chopOff(float value)
    {
        treePos = value;
        canChop = false;
    }

    public void chop()
    {
        if (canChop == true)
        {
            rotatePlayer();
            //runs chopping animation
            StartCoroutine(coolDownAxe(2f));
        }
    }

    public void water()
    {
        if (canWater == true)
        {
            rotatePlayer();
            //runs chopping animation
            StartCoroutine(coolDownWaterCan(2f));
        }

    }

    public void rotatePlayer()
    {
        if ((canChop == true && chopping == false) || ((watering == false && canWater == true) || (planting == false && canPlant == true)) || (harvesting == false && canHarvest == true))
        {
            if (((transform.position.x > treePos && treePos !=0)|| (transform.position.x > waterPos && waterPos != 0)) && transform.rotation.y == 0)
            {
                this.transform.Rotate(0f, -180f, 0f);
            }
            if (((transform.position.x < treePos && treePos != 0) || (transform.position.x < waterPos && waterPos != 0)) && transform.rotation.y != 0)
            {
                this.transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    IEnumerator coolDownAxe(float time)
    {
        chopping = true;
        axe Axe = gameObject.GetComponentInChildren<axe>();
        Axe.axeOn();
        yield return new WaitForSeconds(time);
        chopping = false;
        Axe.axeOff();
    }

    IEnumerator coolDownHarvest(float time)
    {
        harvesting = true;
        harvestTool HarvestTool = gameObject.GetComponentInChildren<harvestTool>();
        HarvestTool.harvestToolOn();
        yield return new WaitForSeconds(time);
        harvesting = false;
        HarvestTool.harvestToolOff();
    }

    IEnumerator coolDownPlant(float time)
    {
        planting = true;
        shovel Shovel = gameObject.GetComponentInChildren<shovel>();
        Shovel.shovelOn();
        yield return new WaitForSeconds(time);
        planting = false;
        Shovel.shovelOff();
    }

    IEnumerator coolDownWaterCan(float time)
    {
        watering = true;
        can Can = gameObject.GetComponentInChildren<can>();
        Can.canOn();
        yield return new WaitForSeconds(time);
        watering = false;
        Can.canOff();
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
