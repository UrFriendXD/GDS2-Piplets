using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutText : MonoBehaviour
{
    private PlayerAction control;
    public Image tutText;
    public GameObject Object;
    // Start is called before the first frame update

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

    void Start()
    {
        Object = null;
        tutText = null;
        control.player.Space.performed += cxt => Space();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Space()
    {
        DisableImage();
    }

    public void DisableImage()
    {
        if (Object != null)
        {
            Object.SetActive(false);
            tutText.gameObject.SetActive(false);
            Object = null;
            tutText = null;
        }
    }

}
