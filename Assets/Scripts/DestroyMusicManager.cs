using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject musicManager = GameObject.FindWithTag("MusicManager");
        if(musicManager != null)
        {
            Destroy(musicManager);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
