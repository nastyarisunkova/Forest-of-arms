using Firebase.Database;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManager : MonoBehaviour
{
    public InputField Name;
    public InputField Gold;

    public Text NameText;
    public Text GoldText;

    private string userID;
    private DatabaseReference dbReference;
    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser()
    {
        User newUser = new User(Name.text, int.Parse(Gold.text));
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }

    public IEnumerator GetName(Action<string> onCallback)
    {
        var userNameData = dbReference.Child("users").Child(userID).Child("name").GetValueAsync();
        
        yield return new WaitUntil(predicate: () => userNameData.IsCanceled);
        
        if(userNameData!=null)
        {
            DataSnapshot snapshot = userNameData.Result;
        
            onCallback.Invoke(snapshot.Value.ToString());
        }
    }
    
    public IEnumerator GetGold(Action<int> onCallback)
    {
        var userGoldData = dbReference.Child("users").Child(userID).Child("gold").GetValueAsync();
        yield return new WaitUntil(predicate: () => userGoldData.IsCanceled);
        
        Debug.Log(userGoldData==null);
        if(userGoldData!=null)
        {
            DataSnapshot snapshot = userGoldData.Result;
           
            onCallback.Invoke(int.Parse(snapshot.Value.ToString()));
        }
    }

    public void GetUserInfo()
    {
        StartCoroutine(GetName((string name) => {
            NameText.text = "Name: " + name;
            Debug.Log(name);
        }));

        StartCoroutine(GetGold((int gold) =>
        {
            GoldText.text = "Gold: " + gold.ToString();
            Debug.Log(gold);
        }));
    }

    public void UpdateName()
    {
        dbReference.Child("users").Child(userID).Child("name").SetValueAsync(Name.text);
    }
    
    public void UpdateGold()
    {
        dbReference.Child("users").Child(userID).Child("gold").SetValueAsync(Gold.text);
    }
}
