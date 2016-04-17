using UnityEngine;
using System.Collections;

public class OnPickup : MonoBehaviour {

    public void OnPickedUp(PickupItem item)
    {
        if (item.PickupIsMine)
        {
            Debug.Log(PhotonNetwork.player.name+" score :" +PhotonNetwork.player.GetScore());
            PhotonNetwork.player.AddScore(10);
        }
        else
        {
            Debug.Log("Someone else picked up something. Lucky!");
        }
    }
}
