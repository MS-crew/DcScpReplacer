<h1 align="center">Dc Scp Replacer</h1>
<div align="center">
<a href="https://github.com/MS-crew/DcScpReplacer"><img src="https://img.shields.io/github/actions/workflow/status/Exiled-Team/EXILED/main.yml?style=for-the-badge&logo=githubactions&label=build"/> href="https://github.com/MS-crew/DcScpReplacer" alt="GitHub Source Code"></a>
<a href="https://github.com/MS-crew/DcScpReplacer/releases"><img src="https://img.shields.io/badge/Build-1.1.0-brightgreen?style=for-the-badge&logo=gitbook" href="https://github.com/MS-crew/DcScpReplacer/releases" alt="GitHub Releases"></a>


This plugin for SCP: Secret Laboratory replaces exiting SCP players with new players, eliminating the need for mods or admin intervention. The plugin provides a range of customizable features to enhance your server's gameplay experience.
</div>

## Features

- **Dynamic SCP Replacement:** Automatically replace exiting SCP players with new players, ensuring continuous gameplay without manual intervention.
- **Customizable Texts:** Personalize the messages and notifications to fit your server’s style.
- **Adjustable Replacement Intervals:** Set the time period for when replacements should occur based on the appearance of SCPs.
- **Role Selection:** Choose which roles can replace exiting SCPs, allowing for flexible role management.
- **Flexible Role Management:** The plugin will first attempt to assign a player to the role listed at the top of the `replace_rolesfordcscp` list. Ensure the desired role is at the top of this list; if a player for that role is not available, the plugin will move to the next role in the list.

## Installation

1. Download the release file from the GitHub page [here](https://github.com/MS-crew/DcScpReplacer/releases).
2. Extract the contents into your `\AppData\Roaming\EXILED\Plugins` directory.
3. Configure the plugin according to your server’s needs using the provided settings.
4. Restart your server to apply the changes.

### Feedback and Issues

This is the initial release of the plugin. We welcome any feedback, bug reports, or suggestions for improvements.

- **Report Issues:** [Issues Page](https://github.com/MS-crew/DcScpReplacer/issues)
- **Contact:** [discerrahidenetim@gmail.com](mailto:discerrahidenetim@gmail.com)

Thank you for using our plugin and helping us improve it!
### Default Config
```yml
# Should the plugin be active?
s_enabled: true
# Specifies whether debugging messages will be displayed.
debug: false
# Should a broadcast message be sent when the SCP is changed?
scp_replace_announcement: true
# The time period from the start of the round during which a new SCP will be assigned if one leaves.
dc_scp_replace_timeout: 120
# Roles that can be substituted for scp.(Let the first one at the top be the role you want to assign!)
replace_rolesfordcscp:
- Spectator
- ClassD
- Scientist
- FacilityGuard
```
