using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideParticleEffects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParticleOn(GameObject particle)
    {
        if (particle.activeSelf)
        {
            particle.SetActive(false);
        }
        particle.transform.position = transform.position;
        particle.SetActive(true);
        //StartCoroutine(ParticleOff(particle));
    }

    //IEnumerator ParticleOff(GameObject particle)
    //{
        //yield return new WaitForSeconds(2.0f);
        //particle.SetActive(false);
    //}
}
