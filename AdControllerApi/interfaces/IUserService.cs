using System;

public interface IUserService
{
    // Retrieves the last ad watch time for a user
    DateTime GetLastAdWatchTime(int userId);

    // Updates the last ad watch time for a user
    void UpdateLastAdWatchTime(int userId, DateTime lastAdWatchTime);

    // Other methods for user management can be added here
}
