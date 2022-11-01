using UnityEngine;
using System.Runtime.InteropServices;

namespace RFG.NEAR
{

  public class NearAPI
  {
    private static string _signedIn = "false";//Just to mimic the actual functionality
    private static string _dummytokens = "[{token_id:'1',metadata:{title:'Fred',media:'https://roguefoxguild.mypinata.cloud/ipfs/QmYMT3s9C4ckQxfMEm7ew4PUVPSrYLeo36uhdhGSctDJdB/Character_1.png'} },{token_id:'2',metadata:{title:'Alice',media:'https://roguefoxguild.mypinata.cloud/ipfs/QmYMT3s9C4ckQxfMEm7ew4PUVPSrYLeo36uhdhGSctDJdB/Character_2.png'}}]";

#if !UNITY_EDITOR

    [DllImport("__Internal")]
    public static extern void RequestSignIn(string contractId, string network = "testnet");

    [DllImport("__Internal")]
    public static extern void SignOut(string network = "testnet");

    [DllImport("__Internal")]
    public static extern void IsSignedIn(string network = "testnet");

    [DllImport("__Internal")]
    public static extern void NftTokensForOwner(string accountId, string contractId,string network = "testnet");

    [DllImport("__Internal")]
    public static extern void GetAccountId(string network = "testnet");

#else

    public static void RequestSignIn(string contractId, string network = "testnet")
    {
      Debug.Log("RequestSignIn: " + contractId + " " + network);
      _signedIn = "true";
    }

    public static void SignOut(string network = "testnet")
    {
      Debug.Log("SignOut: " + network);
      _signedIn = "false";
    }

    public static void IsSignedIn(string network = "testnet")
    {
      Debug.Log("IsSignedIn: " + network);
      NearCallbacks.Instance.IsSignedIn(_signedIn);
    }

    public static void GetAccountId(string network = "testnet")
    {
      Debug.Log("GetAccountId: " + network);
      NearCallbacks.Instance.GetAccountId("testing.near");
    }

    public static void NftTokensForOwner(string accountId, string contractId, string network = "testnet")
    {
      Debug.Log("NftTokensForOwner: " + accountId + " " + contractId + " " + network);
      NearCallbacks.Instance.NftTokensForOwner(_dummytokens);
    }

#endif

  }
}