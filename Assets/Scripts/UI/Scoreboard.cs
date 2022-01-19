using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class Scoreboard : MonoBehaviour
    {
        [Header("Set in Inspector")] [SerializeField]
        private GameObject coinsTextGO;
        [SerializeField] GameObject drowningsTextGO;


        private Text _coinsText;
        private Text _drowningsText;
        
        void Awake()
        {
            _coinsText = coinsTextGO.GetComponent<Text>();
            _drowningsText = drowningsTextGO.GetComponent<Text>();
        }

        void FixedUpdate()
        {
            _coinsText.text = ""+Inventory.GetI().GetCoins();
            _drowningsText.text = ""+Inventory.GetI().GetDrownings()+"/"+Inventory.GetI().GetInventoryMax();
        }
    }
}
