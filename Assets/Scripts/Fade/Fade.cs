using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fade : MonoBehaviour
{
    public Image fade;
    public TextMeshProUGUI date;
    public TextMeshProUGUI year;
    public TextMeshProUGUI dateCrn;
    public TextMeshProUGUI yearCrn;
    public float Time;
    public int dateNum;
    public int yearNum;
    public GameObject outsideOfBed;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        fade.canvasRenderer.SetAlpha(1.0f);
        date.canvasRenderer.SetAlpha(0.0f);
        year.canvasRenderer.SetAlpha(0.0f);
        dateCrn.canvasRenderer.SetAlpha(0.0f);
        yearCrn.canvasRenderer.SetAlpha(0.0f);
        FadeEffect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeEffect()
    {
        incrementDate();
        updateDate();
        useEffect();
    }

    public void useEffect()
    {
        StartCoroutine(FadeProcess(Time));
    }

    public void updateDate()
    {
        date.text = "Day: " + dateNum;
        year.text = "Year: " + yearNum;
        dateCrn.text = "Day: " + dateNum;
        yearCrn.text = "Year: " + yearNum;
    }

    public void incrementDate()
    {
        dateNum = GameManager.instance.DayManager.days;
        yearNum = GameManager.instance.DayManager.years;

    }

    private IEnumerator FadeProcess (float time)
    {
        fade.CrossFadeAlpha(1, 2, false);
        date.CrossFadeAlpha(1, 2, false);
        year.CrossFadeAlpha(1, 2, false);
        dateCrn.CrossFadeAlpha(0, 2, false);
        yearCrn.CrossFadeAlpha(0, 2, false);
        yield return new WaitForSeconds(time);
        fade.CrossFadeAlpha(0, 2, false);
        date.CrossFadeAlpha(0, 2, false);
        year.CrossFadeAlpha(0, 2, false);
        dateCrn.CrossFadeAlpha(1, 2, false);
        yearCrn.CrossFadeAlpha(1, 2, false);
        player.transform.position = outsideOfBed.transform.position;
        player.gameObject.GetComponent<PlayerMovement>().isUIOn = false;
        player.gameObject.GetComponent<PlayerMovement>().isSleeping = false;
    }
}
