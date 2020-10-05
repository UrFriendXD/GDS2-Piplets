using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Items/Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    [SerializeField] private string id;
    public string ID => id;
    public string itemName;
    public Sprite icon;
    [Range(1,99)]
    public int maximumStack = 1;
    
    protected static readonly StringBuilder sb = new StringBuilder();

    #if UNITY_EDITOR
    protected virtual void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }
    #endif

    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }
    public virtual string GetItemType()
    {
        return "";
    }

    public virtual string GetDescription()
    {
        return "";
    }
}