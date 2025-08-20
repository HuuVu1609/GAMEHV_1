using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Account
{
    public string useName;
    public string password;
}

public class AccountManager : MonoBehaviour
{
    private string apiURL = "http://localhost:5081/api/GameHV_1/Account/NewAcc"; // đổi thành URL API thật

    public IEnumerator CreateAccount(string user, string pass)
    {
        Account newAcc = new Account
        {
            useName = user,
            password = pass
        };

        string jsonData = JsonUtility.ToJson(newAcc);

        UnityWebRequest req = new UnityWebRequest(apiURL, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        req.uploadHandler = new UploadHandlerRaw(bodyRaw);
        req.downloadHandler = new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("✅ Tạo tài khoản thành công!");
        }
        else
        {
            Debug.LogError("❌ Lỗi: " + req.error + "\n" + req.downloadHandler.text);
        }
    }
}
