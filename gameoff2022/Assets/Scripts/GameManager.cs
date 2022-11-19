using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Netcode;


public class GameManager : NetworkBehaviour
{
    private static GameManager _instance;

    public GameObject playerPrefab;

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

    
    void OnClientConnectedCallback() {
        Debug.Log("Client connected");
        GameObject p = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        p.GetComponent<NetworkObject>().Spawn();
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



/**
using Unity.Netcode;
using UnityEngine;

namespace HelloWorld
{
    public class HelloWorldPlayer : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Move();
            }
        }

        public void Move()
        {
            if (NetworkManager.Singleton.IsServer)
            {
                var randomPosition = GetRandomPositionOnPlane();
                transform.position = randomPosition;
                Position.Value = randomPosition;
            }
            else
            {
                SubmitPositionRequestServerRpc();
            }
        }

        [ServerRpc]
        void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = GetRandomPositionOnPlane();
        }

        static Vector3 GetRandomPositionOnPlane()
        {
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        }

        void Update()
        {
            transform.position = Position.Value;
        }
    }
}
**/