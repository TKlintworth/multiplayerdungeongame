using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;
using System.Threading.Tasks;


public class LoginScreen : MonoBehaviour
{
    
    public GameObject loginform;
    public GameObject loadingscreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void SetupEvents() {
        AuthenticationService.Instance.SignedIn += () => {
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");

        };

        AuthenticationService.Instance.SignInFailed += (err) => {
            Debug.LogError(err);
        };

        AuthenticationService.Instance.SignedOut += () => {
            Debug.Log("Player signed out.");
        };
        
        AuthenticationService.Instance.Expired += () =>
            {
                Debug.Log("Player session could not be refreshed and expired.");
            };
    }

    public void HitPlay() {
        Debug.Log("Hit Play");
        // show ui elements tagged "login" and hide play button
        loginform.SetActive(true);
        gameObject.SetActive(false);
    }
    
    
    public async void HitLogin() {
        Debug.Log("Hit Login");
        loginform.SetActive(false);
        loadingscreen.SetActive(true);
        // show ui elements tagged "login" and hide play button
        await AuthSingleton.Instance.SignInAnonymouslyAsync();
    }
    
}
