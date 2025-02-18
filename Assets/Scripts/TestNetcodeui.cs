using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class TestNetcodeui : MonoBehaviour
{
    public Button client;
    public Button host;

    private void Awake()
    {
        host.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();

        });

        client.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();

        });
    }

}
