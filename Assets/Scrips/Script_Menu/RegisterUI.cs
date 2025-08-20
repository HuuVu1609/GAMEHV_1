using UnityEngine;
using UnityEngine.UI;

public class RegisterUI : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public AccountManager accountManager;

    public void OnRegisterClick()
    {
        string user = usernameInput.text;
        string pass = passwordInput.text;

        StartCoroutine(accountManager.CreateAccount(user, pass));
    }
}
