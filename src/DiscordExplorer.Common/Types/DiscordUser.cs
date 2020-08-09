namespace DiscordExplorer.Common.Types
{
    public class DiscordUser
    {
        public long UserID { get; private set; }

        public DiscordUser(long id)
        {
            UserID = id;
        }
    }
}
