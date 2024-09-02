using System;
using System.ComponentModel;
using Exiled.API.Interfaces;
using PlayerRoles;

namespace DcScpReplacer
{
    public class Config : IConfig
    {
        [Description("Should the plugin be active?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Specifies whether debugging messages will be displayed.")]
        public bool Debug { get; set; } = false;

        [Description("Should a broadcast message be sent when the SCP is changed?")]
        public bool ScpReplaceAnnouncement { get; set; } = true;

        [Description("The time period from the start of the round during which a new SCP will be assigned if one leaves.")]
        public float DcScpReplaceTimeout { get; set; } = 120f;

        [Description("Roles that can be substituted for scp.(Let the first one at the top be the role you want to assign!)")]
        public RoleTypeId[] ReplaceRolesfordcscp { get; set; } =
        {
         RoleTypeId.Spectator,
         RoleTypeId.ClassD,
         RoleTypeId.Scientist,
         RoleTypeId.FacilityGuard,
        };

        [Description("Example roles you can add")]
        public RoleTypeId[] RolesforExp { get; set; } =
        {
         RoleTypeId.Spectator,
         RoleTypeId.Scp0492,
         RoleTypeId.ClassD,
         RoleTypeId.Scientist,
         RoleTypeId.FacilityGuard,
         RoleTypeId.NtfPrivate,
         RoleTypeId.ChaosConscript,
         RoleTypeId.NtfSergeant,
         RoleTypeId.ChaosRepressor,
         RoleTypeId.NtfCaptain,
         RoleTypeId.ChaosMarauder,
        };

    }
}
