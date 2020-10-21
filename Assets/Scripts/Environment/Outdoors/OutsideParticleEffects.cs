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
        if (particle.transform.position.y <= 4)
        {
            particle.transform.position = transform.position;
        }
        else
        {
            particle.transform.position = transform.position + new Vector3(0, 1.5f, 0);
        }
        particle.SetActive(true);
        //StartCoroutine(ParticleOff(particle));
    }

    //IEnumerator ParticleOff(GameObject particle)
    //{
        //yield return new WaitForSeconds(2.0f);
        //particle.SetActive(false);
    //}
}
