using System;
using System.Collections.Generic;
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


        public bool UpDrownings(GameObject obj)
        {
            if (_drownings < _inventoryMax)
            {
                this._drownings += 1;
                return true;
            }

            return false;
        }
        
        public bool DownDrownings()
        {
            if (_drownings != 0)
            {
                _coins += _drownings * _drowningCost;
                this._drownings = 0;
                return true;
            }
            return false;
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

        public void Purchase(int cost)
        {
            _coins -= +cost;
        }
        
        public int GetInventoryMax()
        {
            return _inventoryMax;
        }
        public void UpInventoryMax(int size)
        {
            _inventoryMax+=size;
        }

    }
}
