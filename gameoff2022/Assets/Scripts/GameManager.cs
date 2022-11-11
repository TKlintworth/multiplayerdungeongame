using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;


public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void PlayerSignedIn() {
        // change scene to index 1
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
