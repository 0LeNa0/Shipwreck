using UnityEngine;

namespace Assets.Scripts
{
    
    public class Boat : MonoBehaviour
    {

        void OnTriggerEnter(Collider colliderObject){
            if (colliderObject.gameObject.tag == "Drowning")
            {
                TakeDrowning(colliderObject.gameObject);
            } else if(colliderObject.gameObject.tag == "Island")
            {
                DropDrowning();
            }
        }
        
        void TakeDrowning(GameObject obj)
        {
            Inventory.GetI().UpDrownings(obj);
            
        }
        
        void DropDrowning()
        {
            Inventory.GetI().DownDrownings();
        }
        
    }
}
