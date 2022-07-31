using ABI_RC.Core.Networking;
using ABI_RC.Core.Player;
using DarkRift.Client.Unity;
using Dissonance.Integrations.DarkRift2.Demo;
using EXO_CVR.FishsCumCorner.Config;
using EXO_CVR.FishsCumCorner.Lab;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wrappers;

namespace EXO_CVR.FishsCumCorner.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadPlayers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ushort UserID = PlayerWrapper.GetPlayer(UserIDlb.Text).GetPlayerObject().GetComponentInChildren<DR2RemotePlayer>().ID;
            try
            {
                ServerExploits.ForceKick(uint.Parse(NetworkManager.Instance.ipAddress), UserID);
                MelonLogger.Log($"{PlayerWrapper.GetPlayer(UserIDlb.Text)} Kicked");
            }
            catch (Exception ex)
            {
                MelonLogger.Log($"[KickPlayer] ~> {ex.Message}");
            }
             
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                ModConfig.LogNetworkOnEvent = true;
            else if (checkBox1.Checked == false)
                ModConfig.LogNetworkOnEvent = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
             
             
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CVRPlayerManager.Instance.GetAllPlayers().ToList().ForEach(player =>
                {
                    if (player.Username == PlayerList.SelectedItem.ToString())
                        UserIDlb.Text = player.Uuid;
                });
            }
            catch { MelonLogger.Log("Cant Load UserID"); }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PlayerList.Items.Clear();
            try
            {
                CVRPlayerManager.Instance.GetAllPlayers().ToList().ForEach(player =>
                {
                    PlayerList.Items.Add(player.Username);
                });
            }
            catch (Exception ex)
            {

            }
        }
        public void LoadPlayers()
        {
            try
            {
                CVRPlayerManager.Instance.GetAllPlayers().ToList().ForEach(player =>
                {
                    PlayerList.Items.Add(player.Username);
                });
            }
            catch (Exception ex)
            {

            }
        }
    }
}
