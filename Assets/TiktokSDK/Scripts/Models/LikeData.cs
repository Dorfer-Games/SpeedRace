using System;
using System.Collections.Generic;

[Serializable]
public class LikeData
{
    public int eventId;
    public string eventType;
    public Like data;
}

[Serializable]
public class Like
{
    public int likeCount;
    public int totalLikeCount;
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
}

[Serializable]
public class FollowInfo
{
    public int followingCount;
    public int followerCount;
    public int followStatus;
    public int pushStatus;
}

[Serializable]
public class UserDetails
{
    public string createTime;
    public string bioDescription;
    public List<string> profilePictureUrls;
}