using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OIT_Call_Manager
{
    public partial class SettingsOneDay_Form : Form
    {
        public SettingsOneDay_Form()
        {
            InitializeComponent();
            BackColor = Color.RoyalBlue;
            panel3.BackColor = Color.CornflowerBlue;
            panel4.BackColor = Color.CornflowerBlue;
            LoadSettingsOneDay();
        }

        private void button_SaveOneDaySettings_Click(object sender, EventArgs e)
        {
            Settings_OneDay.Default.SettingCheckBox_useOneDay = checkBox_useOneDay.Checked;
            Settings_OneDay.Default.Setting_Date = dateTimePicker1.Value;

            Settings_OneDay.Default.Setting_CheckBox_1пара = checkBox_OneDay_1пара.Checked;
            Settings_OneDay.Default.Setting_CheckBox_2пара = checkBox_OneDay_2пара.Checked;
            Settings_OneDay.Default.Setting_CheckBox_3пара = checkBox_OneDay_3пара.Checked;
            Settings_OneDay.Default.Setting_CheckBox_4пара = checkBox_OneDay_4пара.Checked;
            Settings_OneDay.Default.Setting_CheckBox_5пара = checkBox_OneDay_5пара.Checked;
            Settings_OneDay.Default.Setting_CheckBox_6пара = checkBox_OneDay_6пара.Checked;

            Settings_OneDay.Default.Setting_Time_1пара_начало = maskedTextBox_OneDay_1пара_начало.Text;
            Settings_OneDay.Default.Setting_Time_1пара_конец = maskedTextBox_OneDay_1пара_конец.Text;
            Settings_OneDay.Default.Setting_Time_2пара_начало = maskedTextBox_OneDay_2пара_начало.Text;
            Settings_OneDay.Default.Setting_Time_2пара_конец = maskedTextBox_OneDay_2пара_конец.Text;
            Settings_OneDay.Default.Setting_Time_3пара_начало = maskedTextBox_OneDay_3пара_начало.Text;
            Settings_OneDay.Default.Setting_Time_3пара_конец = maskedTextBox_OneDay_3пара_конец.Text;
            Settings_OneDay.Default.Setting_Time_4пара_начало = maskedTextBox_OneDay_4пара_начало.Text;
            Settings_OneDay.Default.Setting_Time_4пара_конец = maskedTextBox_OneDay_4пара_конец.Text;
            Settings_OneDay.Default.Setting_Time_5пара_начало = maskedTextBox_OneDay_5пара_начало.Text;
            Settings_OneDay.Default.Setting_Time_5пара_конец = maskedTextBox_OneDay_5пара_конец.Text;
            Settings_OneDay.Default.Setting_Time_6пара_начало = maskedTextBox_OneDay_6пара_начало.Text;
            Settings_OneDay.Default.Setting_Time_6пара_конец = maskedTextBox_OneDay_6пара_конец.Text;

            Settings_OneDay.Default.Save();
            
            Close();
        }

        void LoadSettingsOneDay()
        {
            checkBox_useOneDay.Checked = Settings_OneDay.Default.SettingCheckBox_useOneDay;
            dateTimePicker1.Value = Settings_OneDay.Default.Setting_Date;

            checkBox_OneDay_1пара.Checked = Settings_OneDay.Default.Setting_CheckBox_1пара;
            checkBox_OneDay_2пара.Checked = Settings_OneDay.Default.Setting_CheckBox_2пара;
            checkBox_OneDay_3пара.Checked = Settings_OneDay.Default.Setting_CheckBox_3пара;
            checkBox_OneDay_4пара.Checked = Settings_OneDay.Default.Setting_CheckBox_4пара;
            checkBox_OneDay_5пара.Checked = Settings_OneDay.Default.Setting_CheckBox_5пара;
            checkBox_OneDay_6пара.Checked = Settings_OneDay.Default.Setting_CheckBox_6пара;

            maskedTextBox_OneDay_1пара_начало.Text = Settings_OneDay.Default.Setting_Time_1пара_начало;
            maskedTextBox_OneDay_1пара_конец.Text = Settings_OneDay.Default.Setting_Time_1пара_конец;
            maskedTextBox_OneDay_2пара_начало.Text = Settings_OneDay.Default.Setting_Time_2пара_начало;
            maskedTextBox_OneDay_2пара_конец.Text = Settings_OneDay.Default.Setting_Time_2пара_конец;
            maskedTextBox_OneDay_3пара_начало.Text = Settings_OneDay.Default.Setting_Time_3пара_начало;
            maskedTextBox_OneDay_3пара_конец.Text = Settings_OneDay.Default.Setting_Time_3пара_конец;
            maskedTextBox_OneDay_4пара_начало.Text = Settings_OneDay.Default.Setting_Time_4пара_начало;
            maskedTextBox_OneDay_4пара_конец.Text = Settings_OneDay.Default.Setting_Time_4пара_конец;
            maskedTextBox_OneDay_5пара_начало.Text = Settings_OneDay.Default.Setting_Time_5пара_начало;
            maskedTextBox_OneDay_5пара_конец.Text = Settings_OneDay.Default.Setting_Time_5пара_конец;
            maskedTextBox_OneDay_6пара_начало.Text = Settings_OneDay.Default.Setting_Time_6пара_начало;
            maskedTextBox_OneDay_6пара_конец.Text = Settings_OneDay.Default.Setting_Time_6пара_конец;
        }

        private void SettingsOneDay_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            
           // Main_Form mf = new Main_Form();
          //  mf.Show();
            /*mf.Activate();
            mf.ListClear();
            mf.LoadList();
            mf.Refresh();
            mf.Load_AppKernel(); //вызываем заново
           */
           // mf.rt();
           // Show();
            //Close();
          //  mf.Close();
        }
    }
}
