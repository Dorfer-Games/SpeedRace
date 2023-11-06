using UnityEngine;

public class JsonParser
{
    public static object ParseJSON(string data)
    {
        if (data.Contains("eventType\":\"like"))
        {
            return JsonUtility.FromJson<LikeData>(data);
        }
        else if (data.Contains("eventType\":\"gift"))
        {
            return JsonUtility.FromJson<GiftData>(data);
        }
        return null;
    }
}
