using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputChecker : MonoBehaviour
{
    public delegate void PlantUseEvent(GameObject player);
    public event PlantUseEvent ToolButtonPressed;
    // Start is called before the first frame update
    private void OnToolUse()
    {
        ToolButtonPressed?.Invoke(gameObject);
    }
}
