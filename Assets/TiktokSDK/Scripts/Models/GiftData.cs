using System;
using System.Collections.Generic;

[Serializable]
public class GiftData
{
    public int eventId;
    public string eventType;
    public Like data;
}

[Serializable]
public class Data
{
    public int giftId;
    public int repeatCount;
    public string groupId;
    public MonitorExtra monitorExtra;
    public string userId;
    public string secUid;
    public string uniqueId;
    public string nickname;
    public string profilePictureUrl;
    public int followRole;
    public List<object> userBadges;
    public UserDetails userDetails;
    public FollowInfo followInfo;
    public bool isModerator;
    public bool isNewGifter;
    public bool isSubscriber;
    public object topGifterRank;
    public string msgId;
    public string createTime;
    public string displayType;
    public string label;
    public bool repeatEnd;
    public Gift gift;
    public string describe;
    public int giftType;
    public int diamondCount;
    public string giftName;
    public string giftPictureUrl;
    public long timestamp;
    public string receiverUserId;
}

[Serializable]
public class Gift
{
    public int gift_id;
    public int repeat_count;
    public int repeat_end;
    public int gift_type;
}

[Serializable]
public class MonitorExtra
{
    public int send_profitapi_dur;
    public int profitapi_message_dur;
    public string log_id;
    public long room_id;
    public int gift_id;
    public long send_gift_send_message_success_ms;
    public long anchor_id;
    public long to_user_id;
    public long msg_id;
    public int repeat_count;
    public long from_user_id;
    public long send_gift_profit_api_start_ms;
    public long send_gift_profit_core_start_ms;
    public string from_idc;
    public int gift_type;
    public long send_gift_req_start_ms;
    public int repeat_end;
}