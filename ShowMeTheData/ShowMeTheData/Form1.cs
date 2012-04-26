using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowMeTheData
{
    public partial class Form1 : Form
    {

        RestfulHelper restfulHelper;

        public Form1()
        {
            InitializeComponent();
            restfulHelper = new RestfulHelper();
        }

        private void cmbSports_SelectedIndexChanged(object sender, EventArgs e)
        {
            restfulHelper.SetSport(cmbSports.SelectedItem.ToString());

            switch (cmbSports.SelectedItem.ToString())
            {
                case "NBA":
                    cmbData.Items.Add("Standings");
                    cmbData.Items.Add("Team Roster");
                    break;
                case "MLB":

                    break;
                case "NFL":

                    break;
                case "NHL":
                    cmbData.Items.Add("Standings");
                    cmbData.Items.Add("Team Roster");
                    break;
            };
        }

        private void txtSeasonData_TextChanged(object sender, EventArgs e)
        {
            restfulHelper.SetSeason(txtSeasonData.Text.ToString());
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            restfulHelper.RequestData();
            string d = restfulHelper.GetData();
            txtData.Text = d;
        }

        private void cmbData_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (cmbData.SelectedItem.ToString())
            {
                case "Standings":
                    restfulHelper.SetData("standings?");
                    break;
                case "Team Roster":
                    label4.Text = "Enter in the team: ";
                    restfulHelper.SetData("roster");
                    break;
            }
        }

        private void txtExtraData_TextChanged(object sender, EventArgs e)
        {
            restfulHelper.SetTeam(txtExtraData.Text.ToString());
        }
     

        
    }
}
