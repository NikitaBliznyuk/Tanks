using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TanksServer.Api;
using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField]
    private string ipAddress;

    [SerializeField]
    private int portNumber;

    [SerializeField]
    private Transform tank;
    
    private Socket thisSocket;

    private void Awake()
    {
        thisSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    private void Start()
    {
        thisSocket.Connect(IPAddress.Parse(ipAddress), portNumber);
        StartCoroutine(DataCycle(0.1f));
    }

    private void OnDestroy()
    {
        thisSocket.Disconnect(true);
    }

    private IEnumerator DataCycle(float delay)
    {
        while (true)
        {
            TanksServer.Api.TankStats tankStatsMessage = new TanksServer.Api.TankStats
            {
                X = tank.transform.position.x,
                Y = tank.transform.position.y,
                Z = tank.transform.position.z
            };

            string info = JsonUtility.ToJson(tankStatsMessage);
            SendData(info, typeof(TanksServer.Api.TankStats));
            
            if(!thisSocket.Connected)
                yield break;
            
            yield return new WaitForSeconds(delay);
        }
    }

    private void SendData(string data, Type type)
    {
        Message message = new Message {Info = data, Type = type.ToString()};
        string json = JsonUtility.ToJson(message);
        thisSocket.Send(Encoding.ASCII.GetBytes(json));
    }
}
