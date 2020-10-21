using UnityEngine;

public class MaterialManagement : MonoBehaviour
{
    public int woodAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMaterial(int amount)
    {
        woodAmount = woodAmount + amount;
    }
}
