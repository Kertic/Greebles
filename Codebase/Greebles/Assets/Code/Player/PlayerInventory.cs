using System.Runtime.InteropServices;
using Code.Items;
using Code.Management;
using Code.Management.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Player
{
    [System.Serializable]
    public class InventorySlot
    {
        private Item _item = null;

        Sprite ItemSprite
        {
            get { return _item.ItemSprite; }
        }
    }

    public class PlayerInventory : BaseService
    {
        [SerializeField] private int _edgeOffset = 5;
        [SerializeField] private int _rowCount = 6, _columnCount = 10;
        [SerializeField] private Image _inventoryMenuBackground;
        [SerializeField] private Image _inventoryTemplate;

        private InventorySlot[,] _items;
        private InputManager _inputManager;

        protected override void ResolveServices()
        {
            _inputManager = ServiceManager.Instance.Resolve<InputManager>();
        }

        public override void AddToServiceManager()
        {
        }

        // Start is called before the first frame update
        private new void Start()
        {
            base.Start();
            _items = new InventorySlot[_rowCount, _columnCount];
            SetupSprites();
        }

        private void SetupSprites()
        {
            Rect rect = _inventoryMenuBackground.rectTransform.rect;
            Vector2 adjustedSize = new Vector2(
                rect.width - _edgeOffset * 2,
                rect.height - _edgeOffset * 2);

            Image templateCopy = Instantiate(_inventoryTemplate, _inventoryMenuBackground.gameObject.transform);
            templateCopy.name = "InventorySlot-1-1";

            RectTransform imageRect = templateCopy.rectTransform;
            imageRect.sizeDelta = new Vector2(adjustedSize.x / _columnCount, adjustedSize.y / _rowCount);
            imageRect.anchoredPosition = new Vector2(_edgeOffset, 0 - _edgeOffset);
            for (int row = 0; row < _rowCount; row++)
            {
                for (int column = 0; column < _columnCount; column++)
                {
                    Image currentSlot = Instantiate(templateCopy, _inventoryMenuBackground.gameObject.transform);
                    currentSlot.name = "InventorySlot_" + column + "_" + row;
                    currentSlot.rectTransform.anchoredPosition = new Vector2(
                        _edgeOffset + imageRect.sizeDelta.x * column,
                        0 - (_edgeOffset + imageRect.sizeDelta.y * row)
                    );
                }
            }

            DestroyImmediate(templateCopy.gameObject);
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            if (_inputManager.GetButton(InputManager.InputTypes.INVENTORY_TAP))
            {
                _inventoryMenuBackground.gameObject.SetActive(!_inventoryMenuBackground.gameObject.activeSelf);
            }
        }
    }
}