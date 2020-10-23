using UnityEngine;

public class PlayMusic : MonoBehaviour
{

    public AK.Wwise.Event Event;
    void Start()
    {
        if (GameManager.instance.MusicManager)
        {
            Event.Post(GameManager.instance.MusicManager);
        }
        else
        {
            Event.Post(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
