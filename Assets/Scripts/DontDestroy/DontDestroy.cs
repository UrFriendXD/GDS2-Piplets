using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy dont;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        if (dont == null)
        {
            dont = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }
}
