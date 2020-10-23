using System;
using System.Collections;
using Player;
using UnityEngine;

public class Piplet : MonoBehaviour
{

    [SerializeField] private float speed = 2;
    [SerializeField] private float stoppingDistance = 1;
    public int level; 
    //[SerializeField] private int steps = 0;
    [SerializeField] private int level2Threshold = 300;
    [SerializeField] private int level3Threshold = 3000;
    private PlayerScript playerScript;
    private Transform target;
    private bool stepping;
    private PlayerMovement _PlayerMovement;
    public GameObject player;
    public int layer;

    public PipletStats pipletStats;

    public void Setup()
    {
        playerScript = ServiceLocator.Current.Get<PlayersManager>().GetPlayerFromID(0);
        if (playerScript)
        {
            target = playerScript.gameObject.transform;
        }
        else
        {
            Debug.Log("Player not found");
        }
        _PlayerMovement = playerScript.playerMovement;

        //Debug.Log(target.name);

        if (pipletStats.isUnlocked)
        {
            //ServiceLocator.Current.Get<PipletManager>().ActivePiplets.Add(this);
            //Debug.Log(ServiceLocator.Current.Get<PipletManager>().ActivePiplets.Count);
            ActivatePiplet();
            //Debug.Log(pipletStats.isUnlocked);
        }
        
        // var pipletList = ServiceLocator.Current.Get<PipletManager>().ActivePiplets;
        // if (pipletStats.pipletType == PipletType.Piplet1)
        // {
        //     target = playerScript.transform;
        // }
        // else
        // {
        //     target = pipletList[pipletList.Count-1].transform;
        // }
    }

    void Update()
    {
        layer = player.GetComponent<SpriteRenderer>().sortingOrder;
        if(this.GetComponent<SpriteRenderer>().sortingOrder != layer)
        {
            this.GetComponent<SpriteRenderer>().sortingOrder = layer;
        }
        if (target.transform.position.x < this.transform.position.x && transform.rotation.y != 0)
        {
            this.transform.Rotate(0f, 180f, 0f);
        }
        if (target.transform.position.x > this.transform.position.x && transform.rotation.y == 0)
        {
            this.transform.Rotate(0f, -180f, 0f);
        }
        if (!_PlayerMovement.isSleeping)
        {
            if ((_PlayerMovement.GroundCheck == true || _PlayerMovement.GroundCheck2 == true || _PlayerMovement.GroundCheck3 == true) && target.transform.position.y == transform.position.y)
            {
                if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    if (!stepping)
                    {
                        StartCoroutine(BuildTrust());
                    }
                }

            }
            else if ((_PlayerMovement.GroundCheck == true || _PlayerMovement.GroundCheck2 == true || _PlayerMovement.GroundCheck3 == true) && target.transform.position.y != transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
            }
        }

        if (pipletStats.steps > level2Threshold)
        {
            pipletStats.level = 2;
        }

        if (pipletStats.steps > level3Threshold)
        {
            pipletStats.level = 3;
        }
    }

   private IEnumerator BuildTrust()
    {
        pipletStats.steps += 1;
        stepping = true;
        yield return new WaitForSeconds(1);
        stepping = false;
    }

   public void ActivatePiplet()
   {
       pipletStats.Equip(playerScript.playerStats);
       if (gameObject.activeSelf) return;
       transform.position = _PlayerMovement.transform.position;
       target = playerScript.transform;
       gameObject.SetActive(true);
       //Debug.Log("Pip");
       //Debug.Log(playerScript.playerStats.movespeed.Value);
       //Debug.Log(playerScript.playerStats.harvestingDoublerModifier.Value);
       //Debug.Log(playerScript.playerStats.harvestingSeedModifier.Value);
   }

   public void DeactivatePiplet()
   {
       pipletStats.Unequip(playerScript.playerStats);
   }

   // private void OnEnable()
   // {
   //     ActivatePiplet();
   // }

   private void OnDisable()
   {
       DeactivatePiplet();
   }
}
