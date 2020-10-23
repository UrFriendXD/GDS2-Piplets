using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "SO/Piplet Database")]

public class PipletsDatabase : ScriptableObject
{
    public PipletStats[] _pipletStats;
    
    	public Item GetItemReference(string itemID)
    	{
    		foreach (Item item in _pipletStats)
    		{
    			if (item.ID == itemID)
    			{
    				return item;
    			}
    		}
    		return null;
    	}
    
    	public Item GetItemCopy(string itemID)
    	{
    		Item item = GetItemReference(itemID);
    		return item != null ? item.GetCopy() : null;
    	}
    
    	#if UNITY_EDITOR
    	private void OnValidate()
    	{
    		LoadItems();
    	}
    
    	private void OnEnable()
    	{
    		EditorApplication.projectChanged -= LoadItems;
    		EditorApplication.projectChanged += LoadItems;
    	}
    
    	private void OnDisable()
    	{
    		EditorApplication.projectChanged -= LoadItems;
    	}
    
    	private void LoadItems()
    	{
	        _pipletStats = FindAssetsByType<PipletStats>("Assets/PipletStats");
    	}
    
    	// Slightly modified version of this answer: http://answers.unity.com/answers/1216386/view.html
    	public static T[] FindAssetsByType<T>(params string[] folders) where T : Object
    	{
    		string type = typeof(T).Name;
    
    		string[] guids;
    		if (folders == null || folders.Length == 0) {
    			guids = AssetDatabase.FindAssets("t:" + type);
    		} else {
    			guids = AssetDatabase.FindAssets("t:" + type, folders);
    		}
    
    		T[] assets = new T[guids.Length];
    
    		for (int i = 0; i < guids.Length; i++)
    		{
    			string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
    			assets[i] = AssetDatabase.LoadAssetAtPath<T>(assetPath);
    		}
    		return assets;
    	}
    	#endif
}
