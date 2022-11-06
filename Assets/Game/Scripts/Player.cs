using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine.U2D.Animation;

public class Player : NetworkBehaviour
{
  public static string localUsername;
  public static int localCharacterIndex;
  [SyncVar(OnChange = nameof(OnUsernameChanged))]
  public string username;

  private void OnUsernameChanged(string oldValue, string newValue, bool isServer)
  {
    _usernameText.text = newValue;
  }

  [SyncVar(OnChange = nameof(OnCharacterIndexChanged))]
  public int characterIndex;
  private void OnCharacterIndexChanged(int oldValue, int newValue, bool isServer)
  {
    GetComponent<SpriteLibrary>().spriteLibraryAsset = _characterSpriteLibraries[newValue];
  }

  [SerializeField] private TMPro.TextMeshProUGUI _usernameText;
  [SerializeField] private SpriteLibraryAsset[] _characterSpriteLibraries;

  public override void OnStartClient()
  {
    base.OnStartClient();
    if (!IsOwner) return;
    ServerSetCharacterIndex(localCharacterIndex);
    ServerSetName(localUsername);
    Camera.main.GetComponent<CameraFollow>().target = transform;
    Camera.main.orthographicSize = 3.0f;
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
