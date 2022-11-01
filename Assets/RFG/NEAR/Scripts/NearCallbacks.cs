using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

namespace RFG.NEAR
{

  [System.Serializable]
  public class Token
  {
    public string token_id;
    public string owner_id;
    public MetaData metadata;
  }

  [System.Serializable]
  public class MetaData
  {
    public string title;
    public string description;
    public string media;
    public string media_hash;
    public string copies;
    public string issued_at;
    public string expires_at;
    public string starts_at;
    public string updated_at;
    public string extra;
    public string reference;
    public string reference_hash;
  }

  public class NearCallbacks : MonoBehaviour
  {
    public static event Action<bool> OnSignIn;
    public static event Action<string> OnGetAccountId;
    public static event Action<Token[]> OnNftTokensForOwner;

    public static NearCallbacks Instance;

    void Awake()
    {
      if (Instance == null)
      {
        Instance = this;
      }
      else
      {
        Destroy(gameObject);
      }
    }

    public void GetAccountId(string accountId)
    {
      Debug.Log("GetAccountId: " + accountId);
      OnGetAccountId?.Invoke(accountId);
    }

    public void IsSignedIn(string signedIn)
    {
      OnSignIn?.Invoke(signedIn == "true");
    }

    public void NftTokensForOwner(string tokens)
    {
      Token[] tokenArray = JsonConvert.DeserializeObject<Token[]>(tokens);
      OnNftTokensForOwner?.Invoke(tokenArray);
    }

  }

}