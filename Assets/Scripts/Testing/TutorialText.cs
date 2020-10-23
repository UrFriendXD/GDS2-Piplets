using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour

{
    public Image tutorialText;
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
            StartCoroutine(close());
        }
    }
    
    private IEnumerator close()
    {
        yield return new WaitForSeconds(25);
        gameObject.GetComponentInParent<TutText>().DisableImage();
    }
}
