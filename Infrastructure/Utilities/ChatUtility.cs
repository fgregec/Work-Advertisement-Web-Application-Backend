namespace Infrastructure.Utilities
{
    public static class ChatUtility
    {
        public static string CreateUniqueRoomId(Guid user1, Guid user2)
        {
            var sortedUserIds = new[] { user1, user2 }.OrderBy(id => id).ToArray();
            return $"{sortedUserIds[0]}_{sortedUserIds[1]}";
        }

    }
}
