using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public SpawnPoint spawnPoint;

    public static SceneManagement Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene(Player player)
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gandi'sPlayerMovementScene"))
        {
            SceneManager.LoadScene("TestScene");
        }
        //player.transform.position = spawnPoint.transform.position;
    }
}
