namespace DcScpReplacer
{
    using DcScpReplacer.Model;
    using Exiled.API.Extensions;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Map;
    using Exiled.Events.EventArgs.Player;
    using PlayerRoles;
    using System.Linq;

    public class EventHandlers
    {
        private readonly Plugin plugin;
        private bool isPlayerLeftHandlerAdded = true;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        public void OnWaitingForPlayers()
        {
            if (!isPlayerLeftHandlerAdded)
            {
                Exiled.Events.Handlers.Player.Left += OnLeft;
                isPlayerLeftHandlerAdded = true;
            }
        }
        public void OnLeft(LeftEventArgs ev)
        {
            if (Round.ElapsedTime.TotalSeconds > Plugin.Instance.Config.DcScpReplaceTimeout)
            {
                Exiled.Events.Handlers.Player.Left -= OnLeft;
                isPlayerLeftHandlerAdded = false;
                return;
            }

            if (!ev.Player.IsScp || ev.Player.Role == RoleTypeId.Scp0492)
                return;

            if (Plugin.Instance.Config.ReplaceRolesfordcscp is null)
            {
                Log.Info($"replace_rolesfordcscp list is empty!Should be not, check your config file!!!");
                return;
            }

            Player? newscp = null;

            foreach (RoleTypeId role in Plugin.Instance.Config.ReplaceRolesfordcscp)
            {
                newscp ??= Player.List.GetRandomValue(x => x.Role == role);
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
            if (Ragdoll.GetLast(ev.Player)!=null)
            {
                Ragdoll.GetLast(ev.Player).Destroy();
            }
            Exiled.Events.Handlers.Map.AnnouncingScpTermination += ScpTerminationAnnouncement;
            newscp.Broadcast(Plugin.Instance.Translation.NowYouAreScp,true);
        }
        public void ScpTerminationAnnouncement(AnnouncingScpTerminationEventArgs ev)
        {
            ev.IsAllowed = false;
            Exiled.Events.Handlers.Map.AnnouncingScpTermination -= ScpTerminationAnnouncement;
        }
    }
}
