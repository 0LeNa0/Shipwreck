using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    
    public class Boat : MonoBehaviour
    {
        [SerializeField] private GameObject upgradeMenu;
        [SerializeField] private GameObject savedDrowning;
        //private Vector3 _posOnBoat = new Vector3(0f, 1f, 1.5f);
        
        private List<GameObject> _savedDrowningsArray;
        void OnTriggerEnter(Collider colliderObject){
            switch (colliderObject.tag)
            {
                case "Drowning":
                    TakeDrowning(colliderObject.gameObject);
                    break;
                case "Helicopter":
                    DropDrowning();
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
                obj.transform.parent = this.transform;
                //obj.transform.position = _posOnBoat+new Vector3(0f,0f,-1f);
                
            }
        }
        
        void DropDrowning()
        {
            if(Inventory.GetI().DownDrownings());
            {
            
            }

        }
        
    }
}
