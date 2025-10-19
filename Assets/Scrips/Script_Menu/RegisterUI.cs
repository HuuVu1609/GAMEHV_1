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
    public void OnLoginClick()
    {
        string user = usernameInput.text;
        string pass = passwordInput.text;

        if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
        {
            Debug.Log("⚠️ Vui lòng nhập Username & Password");
            return;
        }

        StartCoroutine(accountManager.Login(user, pass));
    }
}
