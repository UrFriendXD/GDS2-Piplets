using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour

{
    public Image tutorialText; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorialText.gameObject.SetActive(true);
            StartCoroutine(DisableImage());
        }
    }

    private IEnumerator DisableImage()
    {
        yield return new WaitForSeconds(45);
        tutorialText.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
