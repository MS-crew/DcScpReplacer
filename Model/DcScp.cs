namespace DcScpReplacer.Model
{
    using Exiled.API.Features;
    using Exiled.API.Features.Roles;
    using PlayerRoles;
    using UnityEngine;
    public class DcScp
    {
        private readonly RoleTypeId role;
        private readonly Vector3 position;
        private readonly float health;
        private readonly int level;
        private readonly int exp;
        public DcScp(Player player)
        {
            role = player.Role;
            position = player.Position;
            health = player.Health;
            if (player.Role.Is(out Scp079Role scp079Role))
            {
                level = scp079Role.Level;
                exp = scp079Role.Experience;
            }
        }

        public void NewScp(Player player)
        {
            player.Role.Set(role);
            player.Position = position;
            player.Health = health;
            if (player.Role.Is(out Scp079Role scp079Role))
            {
                scp079Role.Level = level;
                scp079Role.Experience = exp;
            }
        }
    }
}
