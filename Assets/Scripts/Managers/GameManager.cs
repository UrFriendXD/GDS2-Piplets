using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private TradableItemsList tradableItemsList;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SetupMarket();
    }

    #region Game setup functions

    private void SetupMarket()
    {
        var marketManager = ServiceLocator.Current.Get<MarketManager>();
        marketManager.Setup(true, tradableItemsList);
    }

    #endregion
    
}
