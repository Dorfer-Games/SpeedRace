using Kuhpik;
using System.Threading.Tasks;
using UnityEngine;

public class TiktokListeningSystem : GameSystem
{
    //private const string hostname = "leaderteamsolution.com";
    private const string hostname = "tiktok.inxo.ru";
    private const int port = 9003;

    private ClientTcp tcp;

    private Task serverTask;
    private Task getDataTask;

    private TiktokSDKUI sdkUI;

    public override void OnInit()
    {
        sdkUI = FindObjectOfType<TiktokSDKUI>();
        sdkUI.OnConnectButtonClick += ConnectToStream;
        ConnectToServer();
    }

    private void ConnectToServer()
    {
        tcp = new ClientTcp(hostname, port);
        tcp.OnServerAnswered += WorkingServerResponse;

        serverTask = new Task((async () => await tcp.Observ()));
        serverTask.Start();
    }

    private void ConnectToStream(string uniqId)
    {
        if (tcp.ServerConnection)
        {
            var streamData = new StreamData("switchStream", "tiktok", uniqId);
            string streamDataJSON = JsonUtility.ToJson(streamData);
            getDataTask = new Task(async () => await tcp.SendData(streamDataJSON));
            getDataTask.Start();
            sdkUI.gameObject.SetActive(false);
            Bootstrap.Instance.ChangeGameState(GameStateID.Game);
        }
        else
        {
            Debug.Log("<color=yellow>TiktokSDK:</color><color=red>Tiktok stream connection failed! </color>");
        }
    }

    private void WorkingServerResponse(string answer)
    {
        object serverRespondedObject = JsonParser.ParseJSON(answer);
        if (serverRespondedObject is LikeData)
        {
            Debug.Log("Like");
            game.InvokeOnUserLikedEvent((LikeData)serverRespondedObject);
        }
        else if (serverRespondedObject is GiftData)
        {
            Debug.Log("Gift");
            game.InvokeOnUserGiftedEvent((GiftData)serverRespondedObject);
        }
    }

    private void OnDestroy()
    {
        tcp.OnServerAnswered -= WorkingServerResponse;
        tcp?.Dispose();
        sdkUI.OnConnectButtonClick -= ConnectToStream;
    }
}
