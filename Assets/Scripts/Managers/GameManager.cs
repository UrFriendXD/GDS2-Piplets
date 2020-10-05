using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private TradableItemsList tradableItemsList;
    [SerializeField] private int amountOfPipletNeededToWin;
    
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
        SetupPiplets();
    }

    #region Game setup functions

    private void SetupMarket()
    {
        var marketManager = ServiceLocator.Current.Get<MarketManager>();
        marketManager.Setup(true, tradableItemsList);
    }

    private void SetupPiplets()
    {
        ServiceLocator.Current.Get<PipletManager>().Setup(amountOfPipletNeededToWin);
    }

    #endregion

}
