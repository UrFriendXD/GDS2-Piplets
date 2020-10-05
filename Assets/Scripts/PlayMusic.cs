using UnityEngine;

public class PlayMusic : MonoBehaviour
{

    public AK.Wwise.Event Event;
    void Start()
    {
        Event.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
