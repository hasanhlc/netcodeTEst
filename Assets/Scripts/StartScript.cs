using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    private void Awake()
    {
        Screen.fullScreen = false; // Tam ekraný kapat
        Screen.SetResolution(1024, 800, false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false; // Tam ekraný kapat
        Screen.SetResolution(1024, 800, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
