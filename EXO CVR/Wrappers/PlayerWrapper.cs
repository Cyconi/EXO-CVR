using ABI_RC.Core.Player;
using Dissonance.Integrations.DarkRift2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Wrappers
{
    public static class PlayerWrapper
    {        
        public static GameObject LocalPlayer() { return GameObject.Find("_PLAYERLOCAL"); }
        public static GameObject GetPlayerObject(this CVRPlayerEntity player) { return player.PlayerObject; }
        public static string GetAvatarID(this CVRPlayerEntity player) { return player.AvatarId; }
        public static DarkRift2Player GetDarkRiftPlayer(this CVRPlayerEntity player) { return player.DarkRift2Player; }
        public static PlayerNameplate GetNameplate(this CVRPlayerEntity player) { return player.PlayerNameplate; }
        public static string GetImageURL(this CVRPlayerEntity player) { return player.ApiProfileImageUrl; }
        public static string GetUsername(this CVRPlayerEntity player) { return player.Username; }
        public static string GetUserID(this CVRPlayerEntity player) { return player.Uuid; }
        public static PlayerMeta GetMetaData(this CVRPlayerEntity player) { return player.PlayerMetaData; }
        public static string GetRank(this CVRPlayerEntity player) { return player.ApiUserRank; }
        public static PlayerDescriptor GetPlayerDescriptor(this CVRPlayerEntity player) { return player.PlayerDescriptor; }
        public static PuppetMaster GetPuppetMaster(this CVRPlayerEntity player) { return player.PuppetMaster; }
        public static string GetStaffTag(this CVRPlayerEntity player) { return player.ApiUserStaffTag; }
        public static CVRPlayerEntity[] GetAllPlayers(this CVRPlayerManager instance) { return instance.NetworkPlayers.ToArray(); }
        public static string GetActorID(this DarkRift2Player player) { return player.PlayerId; }
        public static string GetAvatarID(this PlayerDescriptor player) { return player.avtrId; }
        public static bool IsAvatarBlocked(this PlayerDescriptor player) { return player.avatarBlocked; }
        public static bool IsVoiceMuted(this PlayerDescriptor player) { return player.voiceMuted; }
        public static string GetClanTag(this PlayerDescriptor player) { return player.userClanTag; }
        public static string GetStaffTag(this PlayerDescriptor player) { return player.userStaffTag; }
        public static string GetOwnerID(this PlayerDescriptor player) { return player.ownerId; }
        public static string GetImageURL(this PlayerDescriptor player) { return player.profileImageUrl; }
        public static string GetUsername(this PlayerDescriptor player) { return player.userName; }
        public static string GetRank(this PlayerDescriptor player) { return player.userRank; }
        public static GameObject GetAvatarObject(this PlayerSetup player) { return player._avatar; }
        public static CVRPlayerEntity GetPlayer(string UserID)
        {
            foreach (CVRPlayerEntity player in CVRPlayerManager.Instance.GetAllPlayers())
            {
                if (player.Uuid == UserID) return player;
            }
            return null;
        }
    }
}
