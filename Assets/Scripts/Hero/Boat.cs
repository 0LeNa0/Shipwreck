using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts
{
    
    public class Boat : MonoBehaviour
    {
        [SerializeField] private GameObject upgradeMenu;
        [SerializeField] private GameObject savedDrowning;
        [SerializeField] private GameObject helicopter;
        [SerializeField] private List<GameObject> _savedDrowningsArray;
       
       private Vector3 _posOnBoat = new Vector3(0f, 1f, 1.5f);
        void OnTriggerEnter(Collider colliderObject){
            switch (colliderObject.tag)
            {
                case "Drowning":
                    TakeDrowning(colliderObject.gameObject);
                    break;
                case "Helicopter":
                    DropDrowning(colliderObject.gameObject);
                    break;
                case "Island":
                    UpdateBoat();
                    break;
            }
        }
        
        void OnTriggerExit(Collider colliderObject){
            switch (colliderObject.tag)
            {
                case "Island":
                    upgradeMenu.SetActive(false);
                    break;
            }
        }

        void UpdateBoat()
        {   
            upgradeMenu.SetActive(true);
        }
        
        void TakeDrowning(GameObject obj)
        {
            if (Inventory.GetI().UpDrownings(obj))
            {
                obj.transform.position = this.transform.position;
                obj.transform.SetParent(this.transform);
                obj.transform.localPosition = _posOnBoat;
                _posOnBoat+=new Vector3(0f,0f,-1f);
                _savedDrowningsArray.Add(obj);
            }
        }
        
        void DropDrowning(GameObject obj)
        {
            if(Inventory.GetI().DownDrownings())
            {
                for (int i = 0; i < _savedDrowningsArray.Count; i++)
                {
                    _savedDrowningsArray[i].gameObject.transform.DOMove(helicopter.transform.position, 1f);
                    Destroy(_savedDrowningsArray[i].gameObject,1.1f);
                }
                
            }
            _savedDrowningsArray.Clear();
            _posOnBoat = new Vector3(0f, 1f, 1.5f);

        }
        
    }
}
