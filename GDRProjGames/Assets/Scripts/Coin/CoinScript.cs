using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //Animation Rotate object
    void Update()
    {
        transform.Rotate(0.6f,0.0f,0.0f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        
    }
}
