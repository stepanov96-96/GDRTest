using UnityEngine;

public class CoinScript : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameController.Instance.Scoring();
            Destroy(this.gameObject);
        }
    }
}
