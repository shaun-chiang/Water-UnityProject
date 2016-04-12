using UnityEngine;
using System.Collections;

public class OnPickedUpScript : MonoBehaviour
{

    public void OnPickedUp(PickupItem item)
    {
        if (item.PickupIsMine)
        {
            Debug.Log("I picked up something. That's a score!");
           
        }
        else
        {
            Debug.Log("Someone else picked up something. Lucky!");
        }
    }
}
