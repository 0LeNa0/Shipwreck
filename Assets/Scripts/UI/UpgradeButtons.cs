using Assets.Scripts.Hero;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UpgradeButtons : MonoBehaviour
    {
        [Header("Costs")] 
        [SerializeField] private int speedUpCost;
        [SerializeField] private int inventoryMaxCost;
        [Header("Upgrades power")]
        [SerializeField]private float boost;
        [SerializeField]private int size;

        public void UpgradeSpeed()
        {
            if (Inventory.GetI().GetCoins() > speedUpCost)
            {
                Inventory.GetI().Purchase(speedUpCost);
                BoatController.SpeedUp(boost);
            }
           
        }

        public void UpgradeInventoryMax()
        {
            if (Inventory.GetI().GetCoins() > inventoryMaxCost)
            {
                Inventory.GetI().Purchase(inventoryMaxCost);
                Inventory.GetI().UpInventoryMax(size);
            }
        }

        public void CloseMenu()
        {
            this.gameObject.SetActive(false);
        }
    }
}
