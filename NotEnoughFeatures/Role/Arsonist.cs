using System.Collections.Generic;
using System.Linq;
using AmongUs.GameOptions;
using MiraAPI.Modifiers;
using MiraAPI.Networking;
using MiraAPI.Roles;
using UnityEngine;
using NotEnoughFeatures.CustomGameOverReasons;
using NotEnoughFeatures.Modifier;
using PhantomPlus.Patches;


namespace yanplaRoles.Roles.Neutral;

[RegisterCustomRole]
public class Arsonist : ImpostorRole, ICustomRole
{
    public string RoleName => "Arsonist";
    public string RoleDescription => "Douse everyone and ignite them";
    public string RoleLongDescription => RoleDescription;
    public Color RoleColor => new Color(1f, 0.3f, 0f);
    public ModdedRoleTeams Team => ModdedRoleTeams.Neutral;
    

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        CanUseVent = true,
        TasksCountForProgress = false,
        CanGetKilled = true,
        GhostRole = (RoleTypes)RoleId.Get<NeutralGhostRole>(),
        
    };

    public HashSet<byte> dousedPlayers = new HashSet<byte>();
    public int DousedAlive => dousedPlayers.Count(x => Utils.PlayerById(x) != null && Utils.PlayerById(x).Data != null && !Utils.PlayerById(x).Data.IsDead && !Utils.PlayerById(x).Data.Disconnected);

    public (bool Douse, bool Ignite) ResetTimer = (false, false ); // [0] = Douse, [1] = Ignite

    public override void SpawnTaskHeader(PlayerControl playerControl)
    {
        // remove existing task header.
    }

    public override bool CanUse(IUsable usable)
	{
		if (!GameManager.Instance.LogicUsables.CanUse(usable, Player))
		{
			return false;
		}
		Console console = usable.Cast<Console>();
		return !(console != null) || console.AllowImpostor;
	}

    public void HudUpdate(HudManager hudManager)
    {
        foreach (var playerId in dousedPlayers)
        {
            var player = Utils.PlayerById(playerId);
            var data = player?.Data;

            if (data == null || data.Disconnected || data.IsDead || PlayerControl.LocalPlayer.Data.IsDead) continue;

            player.myRend().material.SetColor("_VisorColor", RoleColor);
            player.cosmetics.nameText.color = Color.black;
        }

        if (MeetingHud.Instance != null){
            foreach (var state in MeetingHud.Instance.playerStates){
                var targetId = state.TargetPlayerId;
                var playerData = Utils.PlayerById(targetId)?.Data;
                if (playerData == null || playerData.Disconnected) {
                    dousedPlayers.Remove(targetId);
                    continue;
                }
                if (dousedPlayers.Contains(targetId)) state.NameText.color = Color.black;
            }
        }
    }

    public void Ignite()
    {
        foreach (var playerId in dousedPlayers)
        {
            var player = Utils.PlayerById(playerId);
            PlayerControl.LocalPlayer.RpcCustomMurder(player, teleportMurderer: false);

        }
        dousedPlayers.Clear();
    }

    public bool GameEnd(LogicGameFlowNormal __instance)
        {
            if (Player.Data.IsDead || Player.Data.Disconnected) return true;

            if (PlayerControl.AllPlayerControls.ToArray().Count(x => !x.Data.IsDead && !x.Data.Disconnected) <= 2 &&
                    PlayerControl.AllPlayerControls.ToArray().Count(x => !x.Data.IsDead && !x.Data.Disconnected &&
                    (x.Data.Role.IsImpostor || x.Data.Role is Arsonist)) == 1)
            {
                GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReasonsEnum.ArsonistWin, false);
                return false;
            }

            return false;
        }


    public override bool DidWin(GameOverReason gameOverReason)
    {
        return gameOverReason == (GameOverReason)CustomGameOverReasonsEnum.ArsonistWin;
    }
    
    

}