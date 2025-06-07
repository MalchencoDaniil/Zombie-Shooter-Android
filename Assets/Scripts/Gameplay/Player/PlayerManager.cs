using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player _mainPlayer;

    [SerializeField]
    private List<PlayerFollower> _activeFollowers = new List<PlayerFollower>();

    [SerializeField]
    private PlayerFollower _playerFollowerPrefab;

    public void RemoveFollower(PlayerFollower playerFollower)
    {
        _activeFollowers.Remove(playerFollower);
    }
}