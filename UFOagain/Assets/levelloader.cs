using UnityEngine;
using System.Collections;

public class levelloader : MonoBehaviour {
    
    IEnumerator Start()
    {
        Debug.Log("started preload");
        AsyncOperation async = Application.LoadLevelAsync(PlayerPrefs.GetString("NextScene"));
        yield return async;
        Debug.Log("Loading complete");
    }
}
