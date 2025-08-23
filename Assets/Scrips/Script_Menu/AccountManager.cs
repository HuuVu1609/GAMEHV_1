using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Account
{
    public string useName;
    public string password;
}
[System.Serializable]
public class LoginResponse
{
    public string message;
    public string token;
}
public class AccountManager : MonoBehaviour
{
    private string registerUrl = "http://localhost:5081/api/GameHV_1/Account/NewAcc";
    private string loginUrl = "http://localhost:5081/api/Login/Account/Login/Token";

    public static string jwtToken = "";

    public IEnumerator CreateAccount(string username, string password)
    {
        Account acc = new Account { useName = username, password = password };
        string jsonData = JsonUtility.ToJson(acc);

        UnityWebRequest req = new UnityWebRequest(registerUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        req.uploadHandler = new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Dang ki thanh cong");
        }  
        else
        {
            Debug.LogError("Loi: " + req.error);
        }
    }

    public IEnumerator Login(string username, string password)
    {
        Account acc = new Account { useName = username, password = password };
        string jsonData = JsonUtility.ToJson(acc);

        UnityWebRequest req = new UnityWebRequest(loginUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        req.uploadHandler = new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            string result = req.downloadHandler.text;
            Debug.Log("Dang nhap thanh cong!");
            // [NEW] Parse JSON từ server
            LoginResponse loginRes = JsonUtility.FromJson<LoginResponse>(result);

            // [NEW] Lưu token để dùng cho request khác
            jwtToken = loginRes.token;
            PlayerPrefs.SetString("jwt_token", loginRes.token);
            PlayerPrefs.Save();

            Debug.Log("Đăng nhập thành công! Token: " + jwtToken);
        }
        else
        {
            Debug.LogError("Sai tk hoac mk: " + req.error);
        }
    }
}
