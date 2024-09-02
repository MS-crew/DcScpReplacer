namespace DcScpReplacer
{
    using System.Linq;
    using DcScpReplacer.Model;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Map;
    using Exiled.Events.EventArgs.Player;
    using PlayerRoles;
    public class EventHandlers
    {
        private readonly Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        public void OnWaitingForPlayers() => Exiled.Events.Handlers.Player.Left += OnLeft;
        public void OnLeft(LeftEventArgs ev)
        {
            if (Round.ElapsedTime.TotalSeconds > Plugin.Instance.Config.DcScpReplaceTimeout)
            {
                Exiled.Events.Handlers.Player.Left -= OnLeft;
                return;
            }

            if (!ev.Player.IsScp || ev.Player.Role == RoleTypeId.Scp0492)
                return;
            Player? newscp = null;
            foreach (RoleTypeId role in Plugin.Instance.Config.ReplaceRolesfordcscp)
            {
                newscp ??= Player.List.FirstOrDefault(x => x.Role == role);
                if (newscp != null)
                {
                  break;
                }
            }

            if (newscp == null)
                return;
            DcScp dcplayer = new(ev.Player);
            dcplayer.NewScp(newscp);
            if (Plugin.Instance.Config.ScpReplaceAnnouncement)
            {
                if (newscp.Role == RoleTypeId.Scp079)
                    Map.Broadcast(Plugin.Instance.Translation.Scp079Replaced);
                else
                {
                    string ScpReplaceMessage = Plugin.Instance.Translation.ScpReplaced.Replace("$Scprole", newscp.Role.Type.ToString());
                    Map.Broadcast(3,ScpReplaceMessage);
                }    
            }
            Exiled.Events.Handlers.Map.AnnouncingScpTermination += ScpTerminationAnnouncement;
            //newscp.Broadcast(Plugin.Instance.Translation.NowYouAreScp,true);
        }
        public void ScpTerminationAnnouncement(AnnouncingScpTerminationEventArgs ev)
        {
            ev.IsAllowed = false;
            Exiled.Events.Handlers.Map.AnnouncingScpTermination -= ScpTerminationAnnouncement;
        }
    }
}
