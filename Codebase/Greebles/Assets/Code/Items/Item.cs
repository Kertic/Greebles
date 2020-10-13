using UnityEngine;

namespace Code.Items
{
    [CreateAssetMenu(fileName = "BaseItem", menuName = "Items/Base Item", order = 1)]
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite _itemSprite = null;

        public Sprite ItemSprite
        {
            get { return _itemSprite; }
        }
    }
}