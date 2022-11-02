using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using System;
using UnityEngine.U2D.Animation;

public class Player : NetworkBehaviour
{
  public static string localUsername;
  public static int localCharacterIndex;

  [SyncVar(OnChange = nameof(OnNameChanged))]
  public string username;

  private void OnNameChanged(string oldValue, string newValue, bool isServer)
  {
    Debug.Log($"Username changed from {oldValue} to {newValue}. Is server: {isServer}");
    _usernameText.text = newValue;
  }


  [SyncVar(OnChange = nameof(OnCharacterIndexChanged))]
  public int characterIndex;

  private void OnCharacterIndexChanged(int oldValue, int newValue, bool isServer)
  {
    Debug.Log($"CharacterIndex changed from {oldValue} to {newValue}. Is server: {isServer}");
    GetComponent<SpriteLibrary>().spriteLibraryAsset = _characterSpriteLibraries[characterIndex];
  }

  [SerializeField] private TMPro.TextMeshProUGUI _usernameText;
  [SerializeField] private SpriteLibraryAsset[] _characterSpriteLibraries;

  public override void OnStartClient()
  {
    base.OnStartClient();
    if (!IsOwner) return;
    //ServerSetName($"Player {DateTime.Now.ToLongTimeString()}");
    //ServerSetCharacterIndex(UnityEngine.Random.Range(0, _characterSpriteLibraries.Length));
    ServerSetName(localUsername);
    ServerSetCharacterIndex(localCharacterIndex);
  }

  [ServerRpc]
  private void ServerSetName(string name)
  {
    username = name;
  }

  [ServerRpc]
  private void ServerSetCharacterIndex(int index)
  {
    characterIndex = index;
  }

}
