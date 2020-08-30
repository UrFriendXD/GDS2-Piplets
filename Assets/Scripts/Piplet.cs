using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class Piplet : MonoBehaviour
{

    [SerializeField] private float speed = 2;
    [SerializeField] private float stoppingDistance = 3;
    public int level; 
    [SerializeField] private int steps = 0;
    [SerializeField] private int level2Threshold = 300;
    [SerializeField] private int level3Threshold = 3000;
    public GameObject player;
    private Transform target;
    private bool stepping;

    void Start()
    {
        target = player.GetComponent<Transform>();
        level = 1; 
    }


    void Update()
    {
        if (player.GroundCheck == true && player.transform.position.y == transform.position.y)
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
        else if (player.GroundCheck == true && player.transform.position.y != transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y,transform.position.z);
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
}
