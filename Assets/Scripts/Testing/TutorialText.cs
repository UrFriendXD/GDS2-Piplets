using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour

{
    public Image tutorialText;
    public bool coroutineOn;
    private IEnumerator co;

    private void Start()
    {
        co = close();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(gameObject.GetComponentInParent<TutText>().Object != this)
            {
                gameObject.GetComponentInParent<TutText>().DisableImage();
            }
            gameObject.GetComponentInParent<TutText>().tutText = tutorialText;
            gameObject.GetComponentInParent<TutText>().Object = this.gameObject;
            tutorialText.gameObject.SetActive(true);
            StartCoroutine(co);
        }
    }
    
    public void stop()
    {
        if(coroutineOn == true)
        {
            StopCoroutine(co);
        }
    } 

    private IEnumerator close()
    {
        coroutineOn = true;
        yield return new WaitForSeconds(25);
        gameObject.GetComponentInParent<TutText>().DisableImage();
        coroutineOn = false;
    }
}
