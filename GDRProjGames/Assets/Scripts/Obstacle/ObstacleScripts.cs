using UnityEngine;

public class ObstacleScripts : MonoBehaviour
{
    //player destruction
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")                   
            GameController.Instance.DestroyPlayer();
        
    }
}
