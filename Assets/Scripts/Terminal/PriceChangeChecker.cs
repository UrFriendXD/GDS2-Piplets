using System;
using UnityEngine;
using UnityEngine.UI;

namespace Terminal
{
    public class PriceChangeChecker : MonoBehaviour
    {
        [SerializeField] private Sprite[] icons;
        public TradableItem _item;
        private Image _image;

        private int _previousPrice;
        // Start is called before the first frame update
        private void Start()
        {
            ServiceLocator.Current.Get<MarketManager>().PriceChanged += UpdateImage;
            _previousPrice = _item.currentSellingPrice;
            if (_previousPrice == _item.currentSellingPrice)
            {
                _image.enabled = false;
            }
        }

        private void OnValidate()
        {
            _image = GetComponent<Image>();
        }

        private void UpdateImage()
        {
            if (_item.currentSellingPrice > _previousPrice)
            {
                _image.sprite = icons[0];
                if (!_image.gameObject.activeSelf)
                {
                    _image.gameObject.SetActive(true);
                }
            }
            else if (_item.currentSellingPrice < _previousPrice)
            {
                _image.sprite = icons[1];
                if (!_image.gameObject.activeSelf)
                {
                    _image.gameObject.SetActive(true);
                }
            }
            else
            {
                _image.gameObject.SetActive(false);   
            }
        }
    }
}