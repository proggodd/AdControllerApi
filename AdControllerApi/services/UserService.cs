using MyAdsApi.Models;
using System;
using System.Collections.Generic;

public class UserService : IUserService
{
    private readonly Dictionary<int, DateTime> _lastAdWatchTimes = new Dictionary<int, DateTime>();

    public DateTime GetLastAdWatchTime(int userId)
    {
        if (_lastAdWatchTimes.ContainsKey(userId))
        {
            return _lastAdWatchTimes[userId];
        }
        else
        {
            // Default to DateTime.MinValue if user not found (no ad watched yet)
            return DateTime.MinValue;
        }
    }

    public void UpdateLastAdWatchTime(int userId, DateTime lastAdWatchTime)
    {
        _lastAdWatchTimes[userId] = lastAdWatchTime;
    }

    internal User AuthenticateUser(object email, object password)
    {
        throw new NotImplementedException();
    }

    internal void ClaimReward(int userId, RewardClaimRequest request)
    {
        throw new NotImplementedException();
    }

    internal void CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    internal List<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    internal object GetUserByEmail(string? email)
    {
        throw new NotImplementedException();
    }

    internal List<Reward> GetUserRewards(int userId)
    {
        throw new NotImplementedException();
    }
}
