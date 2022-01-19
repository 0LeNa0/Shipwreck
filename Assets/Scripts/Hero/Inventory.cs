using UnityEngine;

namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {
        private static Inventory _i;
        
 
        [Header("Set in Inspector")]
        [SerializeField] private int _drowningCost;
        [SerializeField] private int _inventoryMax;
        
        [Header("Set Dynamically")]
        [SerializeField] private int _drownings;
        [SerializeField] private int _coins;
        
        void Awake()
        {
            if (!_i)
            {
                _i = this;
            }
        }


        public void UpDrownings(GameObject obj)
        {
            if (_drownings < _inventoryMax)
            {
                this._drownings += 1;
                Destroy(obj, 0.3f);
            }
        }
        
        public void DownDrownings()
        {
            _coins += _drownings * _drowningCost;
            this._drownings = 0;
        }
        
        public static Inventory GetI()
        {
            return _i;
        }

        public int GetDrownings()
        {
            return _drownings;
        }
        
        public int GetCoins()
        {
            return _coins;
        }
        
        public int GetInventoryMax()
        {
            return _inventoryMax;
        }

    }
}
