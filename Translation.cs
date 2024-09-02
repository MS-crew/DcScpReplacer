namespace DcScpReplacer
{
    using System.ComponentModel;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;
    public class Translation : ITranslation
    {
        [Description("Broadcast message that will appear to the player replacing an SCP that has left.")]
        public Broadcast NowYouAreScp { get; set; } = new Broadcast("<i> An SCP has left the game, and you've been chosen one! Lucky you :) </i>", 3);

        [Description("A message that will appear when an SCP is replaced.")]
        public string ScpReplaced { get; set; } = ("<color=red>🎭 $Scprole has undergone a spiritual transformation!</color>");

        [Description("Message that will appear when SCP-079 is replaced.")]
        public Broadcast Scp079Replaced { get; set; } = new Broadcast("<color=red>👥 Unauthorized access to SCP-079's storage has been detected!</color>", 3);
    }
}
