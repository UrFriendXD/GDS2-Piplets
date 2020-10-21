using System;
using System.Collections;
using Player;
using UnityEngine;

public class Piplet : MonoBehaviour
{

    [SerializeField] private float speed = 2;
    [SerializeField] private float stoppingDistance = 1;
    public int level; 
    [SerializeField] private int steps = 0;
    [SerializeField] private int level2Threshold = 300;
    [SerializeField] private int level3Threshold = 3000;
    private PlayerScript playerScript;
    private Transform target;
    private bool stepping;
    private PlayerMovement _PlayerMovement;

    [SerializeField] private PipletStats pipletStats;

    void Start()
    {
        playerScript = ServiceLocator.Current.Get<PlayersManager>().GetPlayerFromID(0);
        target = playerScript.transform;
        level = 1;
        _PlayerMovement = playerScript.playerMovement;
        if (gameObject.activeSelf)
        {
            ActivatePiplet();
        }
    }

    void Update()
    {
        if (target.transform.position.x < this.transform.position.x && transform.rotation.y != 0)
        {
            this.transform.Rotate(0f, 180f, 0f);
        }
        if (target.transform.position.x > this.transform.position.x &&  transform.rotation.y == 0)
        { 
            this.transform.Rotate(0f, -180f, 0f);
        }
        if (_PlayerMovement.GroundCheck == true && target.transform.position.y == transform.position.y)
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
        else if (_PlayerMovement.GroundCheck == true && target.transform.position.y != transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.transform.position.y ,transform.position.z);
        }

        if (steps > level2Threshold)
        {
            level = 2;
        }

        if (steps > level3Threshold)
        {
            level = 3;
        }
    }

   private IEnumerator BuildTrust()
    {
        steps += 1;
        stepping = true;
        yield return new WaitForSeconds(1);
        stepping = false;
    }

   public void ActivatePiplet()
   {
       pipletStats.Equip(playerScript.playerStats);
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
