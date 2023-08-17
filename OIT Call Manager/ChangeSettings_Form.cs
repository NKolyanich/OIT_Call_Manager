using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OIT_Call_Manager
{
    public partial class ChangeSettings_Form : Form
    {
        public ChangeSettings_Form()
        {
            InitializeComponent();
            BackColor = Color.RoyalBlue;
            panel13.BackColor = Color.CornflowerBlue;
            textBox_infobutton.BackColor = Color.CornflowerBlue;
            button_ShowOneDay.BackColor = Color.CornflowerBlue;
            LoadSettings();
        }

        void LoadSettings()
        {
            checkBox_general_autostart.Checked = Settings.Default.Setting_general_autostart;
            checkBox_general_showTrayMessange.Checked = Settings.Default.Setting_general_showintray;
            checkBox_general_minimizeTrayOnStart.Checked = Settings.Default.Setting_minimizeTrayOnStart;
            checkBox_general_TopMost.Checked = Settings.Default.SettingCheckBox_TopMost;

          //-- понедельник -----------------------------------------------------------------------------
            maskedTextBox_понедельник_1пара_начало.Text = Settings.Default.Setting_понедельник_1пара_начало;
            maskedTextBox_понедельник_1пара_конец.Text = Settings.Default.Setting_понедельник_1пара_конец;
            maskedTextBox_понедельник_2пара_начало.Text = Settings.Default.Setting_понедельник_2пара_начало;
            maskedTextBox_понедельник_2пара_конец.Text = Settings.Default.Setting_понедельник_2пара_конец;
            maskedTextBox_понедельник_3пара_начало.Text = Settings.Default.Setting_понедельник_3пара_начало;
            maskedTextBox_понедельник_3пара_конец.Text = Settings.Default.Setting_понедельник_3пара_конец;
            maskedTextBox_понедельник_4пара_начало.Text = Settings.Default.Setting_понедельник_4пара_начало;
            maskedTextBox_понедельник_4пара_конец.Text = Settings.Default.Setting_понедельник_4пара_конец;
            maskedTextBox_понедельник_5пара_начало.Text = Settings.Default.Setting_понедельник_5пара_начало;
            maskedTextBox_понедельник_5пара_конец.Text = Settings.Default.Setting_понедельник_5пара_конец;
            maskedTextBox_понедельник_6пара_начало.Text = Settings.Default.Setting_понедельник_6пара_начало;
            maskedTextBox_понедельник_6пара_конец.Text = Settings.Default.Setting_понедельник_6пара_конец;
          //--------------------------------------------------------------------------------------------
          //-- вторник ---------------------------------------------------------------------------------
            maskedTextBox_вторник_1пара_начало.Text = Settings.Default.Setting_вторник_1пара_начало;
            maskedTextBox_вторник_1пара_конец.Text = Settings.Default.Setting_вторник_1пара_конец;
            maskedTextBox_вторник_2пара_начало.Text = Settings.Default.Setting_вторник_2пара_начало;
            maskedTextBox_вторник_2пара_конец.Text = Settings.Default.Setting_вторник_2пара_конец;
            maskedTextBox_вторник_3пара_начало.Text = Settings.Default.Setting_вторник_3пара_начало;
            maskedTextBox_вторник_3пара_конец.Text = Settings.Default.Setting_вторник_3пара_конец;
            maskedTextBox_вторник_4пара_начало.Text = Settings.Default.Setting_вторник_4пара_начало;
            maskedTextBox_вторник_4пара_конец.Text = Settings.Default.Setting_вторник_4пара_конец;
            maskedTextBox_вторник_5пара_начало.Text = Settings.Default.Setting_вторник_5пара_начало;
            maskedTextBox_вторник_5пара_конец.Text = Settings.Default.Setting_вторник_5пара_конец;
            maskedTextBox_вторник_6пара_начало.Text = Settings.Default.Setting_вторник_6пара_начало;
            maskedTextBox_вторник_6пара_конец.Text = Settings.Default.Setting_вторник_6пара_конец;
          //--------------------------------------------------------------------------------------------
          //-- среда -----------------------------------------------------------------------------------
            maskedTextBox_среда_1пара_начало.Text = Settings.Default.Setting_среда_1пара_начало;
            maskedTextBox_среда_1пара_конец.Text = Settings.Default.Setting_среда_1пара_конец;
            maskedTextBox_среда_2пара_начало.Text = Settings.Default.Setting_среда_2пара_начало;
            maskedTextBox_среда_2пара_конец.Text = Settings.Default.Setting_среда_2пара_конец;
            maskedTextBox_среда_3пара_начало.Text = Settings.Default.Setting_среда_3пара_начало;
            maskedTextBox_среда_3пара_конец.Text = Settings.Default.Setting_среда_3пара_конец;
            maskedTextBox_среда_4пара_начало.Text = Settings.Default.Setting_среда_4пара_начало;
            maskedTextBox_среда_4пара_конец.Text = Settings.Default.Setting_среда_4пара_конец;
            maskedTextBox_среда_5пара_начало.Text = Settings.Default.Setting_среда_5пара_начало;
            maskedTextBox_среда_5пара_конец.Text = Settings.Default.Setting_среда_5пара_конец;
            maskedTextBox_среда_6пара_начало.Text = Settings.Default.Setting_среда_6пара_начало;
            maskedTextBox_среда_6пара_конец.Text = Settings.Default.Setting_среда_6пара_конец;
          //--------------------------------------------------------------------------------------------
          //-- четверг ---------------------------------------------------------------------------------
            maskedTextBox_четверг_1пара_начало.Text = Settings.Default.Setting_четверг_1пара_начало;
            maskedTextBox_четверг_1пара_конец.Text = Settings.Default.Setting_четверг_1пара_конец;
            maskedTextBox_четверг_2пара_начало.Text = Settings.Default.Setting_четверг_2пара_начало;
            maskedTextBox_четверг_2пара_конец.Text = Settings.Default.Setting_четверг_2пара_конец;
            maskedTextBox_четверг_3пара_начало.Text = Settings.Default.Setting_четверг_3пара_начало;
            maskedTextBox_четверг_3пара_конец.Text = Settings.Default.Setting_четверг_3пара_конец;
            maskedTextBox_четверг_4пара_начало.Text = Settings.Default.Setting_четверг_4пара_начало;
            maskedTextBox_четверг_4пара_конец.Text = Settings.Default.Setting_четверг_4пара_конец;
            maskedTextBox_четверг_5пара_начало.Text = Settings.Default.Setting_четверг_5пара_начало;
            maskedTextBox_четверг_5пара_конец.Text = Settings.Default.Setting_четверг_5пара_конец;
            maskedTextBox_четверг_6пара_начало.Text = Settings.Default.Setting_четверг_6пара_начало;
            maskedTextBox_четверг_6пара_конец.Text = Settings.Default.Setting_четверг_6пара_конец;
          //--------------------------------------------------------------------------------------------
          //-- пятница ---------------------------------------------------------------------------------
            maskedTextBox_пятница_1пара_начало.Text = Settings.Default.Setting_пятница_1пара_начало;
            maskedTextBox_пятница_1пара_конец.Text = Settings.Default.Setting_пятница_1пара_конец;
            maskedTextBox_пятница_2пара_начало.Text = Settings.Default.Setting_пятница_2пара_начало;
            maskedTextBox_пятница_2пара_конец.Text = Settings.Default.Setting_пятница_2пара_конец;
            maskedTextBox_пятница_3пара_начало.Text = Settings.Default.Setting_пятница_3пара_начало;
            maskedTextBox_пятница_3пара_конец.Text = Settings.Default.Setting_пятница_3пара_конец;
            maskedTextBox_пятница_4пара_начало.Text = Settings.Default.Setting_пятница_4пара_начало;
            maskedTextBox_пятница_4пара_конец.Text = Settings.Default.Setting_пятница_4пара_конец;
            maskedTextBox_пятница_5пара_начало.Text = Settings.Default.Setting_пятница_5пара_начало;
            maskedTextBox_пятница_5пара_конец.Text = Settings.Default.Setting_пятница_5пара_конец;
            maskedTextBox_пятница_6пара_начало.Text = Settings.Default.Setting_пятница_6пара_начало;
            maskedTextBox_пятница_6пара_конец.Text = Settings.Default.Setting_пятница_6пара_конец;
          //--------------------------------------------------------------------------------------------
          //-- суббота ---------------------------------------------------------------------------------
            maskedTextBox_суббота_1пара_начало.Text = Settings.Default.Setting_суббота_1пара_начало;
            maskedTextBox_суббота_1пара_конец.Text = Settings.Default.Setting_суббота_1пара_конец;
            maskedTextBox_суббота_2пара_начало.Text = Settings.Default.Setting_суббота_2пара_начало;
            maskedTextBox_суббота_2пара_конец.Text = Settings.Default.Setting_суббота_2пара_конец;
            maskedTextBox_суббота_3пара_начало.Text = Settings.Default.Setting_суббота_3пара_начало;
            maskedTextBox_суббота_3пара_конец.Text = Settings.Default.Setting_суббота_3пара_конец;
            maskedTextBox_суббота_4пара_начало.Text = Settings.Default.Setting_суббота_4пара_начало;
            maskedTextBox_суббота_4пара_конец.Text = Settings.Default.Setting_суббота_4пара_конец;
            maskedTextBox_суббота_5пара_начало.Text = Settings.Default.Setting_суббота_5пара_начало;
            maskedTextBox_суббота_5пара_конец.Text = Settings.Default.Setting_суббота_5пара_конец;
            maskedTextBox_суббота_6пара_начало.Text = Settings.Default.Setting_суббота_6пара_начало;
            maskedTextBox_суббота_6пара_конец.Text = Settings.Default.Setting_суббота_6пара_конец;

        // чекбоксы --------------------------------------------------------------------------------;
          // понедельник ---------------------------------------------------------------------------;
            checkBox_понедельник_1пара.Checked = Settings.Default.SettingCheckBox_понедельник_1пара;
            checkBox_понедельник_2пара.Checked = Settings.Default.SettingCheckBox_понедельник_2пара;
            checkBox_понедельник_3пара.Checked = Settings.Default.SettingCheckBox_понедельник_3пара;
            checkBox_понедельник_4пара.Checked = Settings.Default.SettingCheckBox_понедельник_4пара;
            checkBox_понедельник_5пара.Checked = Settings.Default.SettingCheckBox_понедельник_5пара;
            checkBox_понедельник_6пара.Checked = Settings.Default.SettingCheckBox_понедельник_6пара;
          // вторник ------------------------------------------------------------------------;
            checkBox_вторник_1пара.Checked = Settings.Default.SettingCheckBox_вторник_1пара;
            checkBox_вторник_2пара.Checked = Settings.Default.SettingCheckBox_вторник_2пара;
            checkBox_вторник_3пара.Checked = Settings.Default.SettingCheckBox_вторник_3пара;
            checkBox_вторник_4пара.Checked = Settings.Default.SettingCheckBox_вторник_4пара;
            checkBox_вторник_5пара.Checked = Settings.Default.SettingCheckBox_вторник_5пара;
            checkBox_вторник_6пара.Checked = Settings.Default.SettingCheckBox_вторник_6пара;
          // среда ---------------------------------------------------------------------------;
            checkBox_среда_1пара.Checked = Settings.Default.SettingCheckBox_среда_1пара;
            checkBox_среда_2пара.Checked = Settings.Default.SettingCheckBox_среда_2пара;
            checkBox_среда_3пара.Checked = Settings.Default.SettingCheckBox_среда_3пара;
            checkBox_среда_4пара.Checked = Settings.Default.SettingCheckBox_среда_4пара;
            checkBox_среда_5пара.Checked = Settings.Default.SettingCheckBox_среда_5пара;
            checkBox_среда_6пара.Checked = Settings.Default.SettingCheckBox_среда_6пара;
          // четверг -------------------------------------------------------------------------;
            checkBox_четверг_1пара.Checked = Settings.Default.SettingCheckBox_четверг_1пара;
            checkBox_четверг_2пара.Checked = Settings.Default.SettingCheckBox_четверг_2пара;
            checkBox_четверг_3пара.Checked = Settings.Default.SettingCheckBox_четверг_3пара;
            checkBox_четверг_4пара.Checked = Settings.Default.SettingCheckBox_четверг_4пара;
            checkBox_четверг_5пара.Checked = Settings.Default.SettingCheckBox_четверг_5пара;
            checkBox_четверг_6пара.Checked = Settings.Default.SettingCheckBox_четверг_6пара;
          // пятница -------------------------------------------------------------------------;
            checkBox_пятница_1пара.Checked = Settings.Default.SettingCheckBox_пятница_1пара;
            checkBox_пятница_2пара.Checked = Settings.Default.SettingCheckBox_пятница_2пара;
            checkBox_пятница_3пара.Checked = Settings.Default.SettingCheckBox_пятница_3пара;
            checkBox_пятница_4пара.Checked = Settings.Default.SettingCheckBox_пятница_4пара;
            checkBox_пятница_5пара.Checked = Settings.Default.SettingCheckBox_пятница_5пара;
            checkBox_пятница_6пара.Checked = Settings.Default.SettingCheckBox_пятница_6пара;
          // суббота -------------------------------------------------------------------------;
            checkBox_суббота_1пара.Checked = Settings.Default.SettingCheckBox_суббота_1пара;
            checkBox_суббота_2пара.Checked = Settings.Default.SettingCheckBox_суббота_2пара;
            checkBox_суббота_3пара.Checked = Settings.Default.SettingCheckBox_суббота_3пара;
            checkBox_суббота_4пара.Checked = Settings.Default.SettingCheckBox_суббота_4пара;
            checkBox_суббота_5пара.Checked = Settings.Default.SettingCheckBox_суббота_5пара;
            checkBox_суббота_6пара.Checked = Settings.Default.SettingCheckBox_суббота_6пара;

        }

        private void button_SaveSettings_Click(object sender, EventArgs e)
        {
            Settings.Default.Setting_general_autostart = checkBox_general_autostart.Checked;
            Settings.Default.Setting_general_showintray = checkBox_general_showTrayMessange.Checked;
            Settings.Default.Setting_minimizeTrayOnStart = checkBox_general_minimizeTrayOnStart.Checked;
            Settings.Default.SettingCheckBox_TopMost = checkBox_general_TopMost.Checked;

            SaveSettings();
            Settings.Default.Save();
           // Main_Form mf = new Main_Form();
           // mf.Load_AppKernel();
            Close();
        }

        private void SaveSettings()
        {
            // понедельник ---------------------------------------------------------------------------;
            Settings.Default.Setting_понедельник_1пара_начало = maskedTextBox_понедельник_1пара_начало.Text;
            Settings.Default.Setting_понедельник_1пара_конец = maskedTextBox_понедельник_1пара_конец.Text;
            Settings.Default.Setting_понедельник_2пара_начало = maskedTextBox_понедельник_2пара_начало.Text;
            Settings.Default.Setting_понедельник_2пара_конец = maskedTextBox_понедельник_2пара_конец.Text;
            Settings.Default.Setting_понедельник_3пара_начало = maskedTextBox_понедельник_3пара_начало.Text;
            Settings.Default.Setting_понедельник_3пара_конец = maskedTextBox_понедельник_3пара_конец.Text;
            Settings.Default.Setting_понедельник_4пара_начало = maskedTextBox_понедельник_4пара_начало.Text;
            Settings.Default.Setting_понедельник_4пара_конец = maskedTextBox_понедельник_4пара_конец.Text;
            Settings.Default.Setting_понедельник_5пара_начало = maskedTextBox_понедельник_5пара_начало.Text;
            Settings.Default.Setting_понедельник_5пара_конец = maskedTextBox_понедельник_5пара_конец.Text;
            Settings.Default.Setting_понедельник_6пара_начало = maskedTextBox_понедельник_6пара_начало.Text;
            Settings.Default.Setting_понедельник_6пара_конец = maskedTextBox_понедельник_6пара_конец.Text;
            // вторник ------------------------------------------------------------------------;
            Settings.Default.Setting_вторник_1пара_начало = maskedTextBox_вторник_1пара_начало.Text;
            Settings.Default.Setting_вторник_1пара_конец = maskedTextBox_вторник_1пара_конец.Text;
            Settings.Default.Setting_вторник_2пара_начало = maskedTextBox_вторник_2пара_начало.Text;
            Settings.Default.Setting_вторник_2пара_конец = maskedTextBox_вторник_2пара_конец.Text;
            Settings.Default.Setting_вторник_3пара_начало = maskedTextBox_вторник_3пара_начало.Text;
            Settings.Default.Setting_вторник_3пара_конец = maskedTextBox_вторник_3пара_конец.Text;
            Settings.Default.Setting_вторник_4пара_начало = maskedTextBox_вторник_4пара_начало.Text;
            Settings.Default.Setting_вторник_4пара_конец = maskedTextBox_вторник_4пара_конец.Text;
            Settings.Default.Setting_вторник_5пара_начало = maskedTextBox_вторник_5пара_начало.Text;
            Settings.Default.Setting_вторник_5пара_конец = maskedTextBox_вторник_5пара_конец.Text;
            Settings.Default.Setting_вторник_6пара_начало = maskedTextBox_вторник_6пара_начало.Text;
            Settings.Default.Setting_вторник_6пара_конец = maskedTextBox_вторник_6пара_конец.Text;
            // среда ---------------------------------------------------------------------------;
            Settings.Default.Setting_среда_1пара_начало = maskedTextBox_среда_1пара_начало.Text;
            Settings.Default.Setting_среда_1пара_конец = maskedTextBox_среда_1пара_конец.Text;
            Settings.Default.Setting_среда_2пара_начало = maskedTextBox_среда_2пара_начало.Text;
            Settings.Default.Setting_среда_2пара_конец = maskedTextBox_среда_2пара_конец.Text;
            Settings.Default.Setting_среда_3пара_начало = maskedTextBox_среда_3пара_начало.Text;
            Settings.Default.Setting_среда_3пара_конец = maskedTextBox_среда_3пара_конец.Text;
            Settings.Default.Setting_среда_4пара_начало = maskedTextBox_среда_4пара_начало.Text;
            Settings.Default.Setting_среда_4пара_конец = maskedTextBox_среда_4пара_конец.Text;
            Settings.Default.Setting_среда_5пара_начало = maskedTextBox_среда_5пара_начало.Text;
            Settings.Default.Setting_среда_5пара_конец = maskedTextBox_среда_5пара_конец.Text;
            Settings.Default.Setting_среда_6пара_начало = maskedTextBox_среда_6пара_начало.Text;
            Settings.Default.Setting_среда_6пара_конец = maskedTextBox_среда_6пара_конец.Text;
            // четверг -------------------------------------------------------------------------;
            Settings.Default.Setting_четверг_1пара_начало = maskedTextBox_четверг_1пара_начало.Text;
            Settings.Default.Setting_четверг_1пара_конец = maskedTextBox_четверг_1пара_конец.Text;
            Settings.Default.Setting_четверг_2пара_начало = maskedTextBox_четверг_2пара_начало.Text;
            Settings.Default.Setting_четверг_2пара_конец = maskedTextBox_четверг_2пара_конец.Text;
            Settings.Default.Setting_четверг_3пара_начало = maskedTextBox_четверг_3пара_начало.Text;
            Settings.Default.Setting_четверг_3пара_конец = maskedTextBox_четверг_3пара_конец.Text;
            Settings.Default.Setting_четверг_4пара_начало = maskedTextBox_четверг_4пара_начало.Text;
            Settings.Default.Setting_четверг_4пара_конец = maskedTextBox_четверг_4пара_конец.Text;
            Settings.Default.Setting_четверг_5пара_начало = maskedTextBox_четверг_5пара_начало.Text;
            Settings.Default.Setting_четверг_5пара_конец = maskedTextBox_четверг_5пара_конец.Text;
            Settings.Default.Setting_четверг_6пара_начало = maskedTextBox_четверг_6пара_начало.Text;
            Settings.Default.Setting_четверг_6пара_конец = maskedTextBox_четверг_6пара_конец.Text;
            // пятница -------------------------------------------------------------------------;
            Settings.Default.Setting_пятница_1пара_начало = maskedTextBox_пятница_1пара_начало.Text;
            Settings.Default.Setting_пятница_1пара_конец = maskedTextBox_пятница_1пара_конец.Text;
            Settings.Default.Setting_пятница_2пара_начало = maskedTextBox_пятница_2пара_начало.Text;
            Settings.Default.Setting_пятница_2пара_конец = maskedTextBox_пятница_2пара_конец.Text;
            Settings.Default.Setting_пятница_3пара_начало = maskedTextBox_пятница_3пара_начало.Text;
            Settings.Default.Setting_пятница_3пара_конец = maskedTextBox_пятница_3пара_конец.Text;
            Settings.Default.Setting_пятница_4пара_начало = maskedTextBox_пятница_4пара_начало.Text;
            Settings.Default.Setting_пятница_4пара_конец = maskedTextBox_пятница_4пара_конец.Text;
            Settings.Default.Setting_пятница_5пара_начало = maskedTextBox_пятница_5пара_начало.Text;
            Settings.Default.Setting_пятница_5пара_конец = maskedTextBox_пятница_5пара_конец.Text;
            Settings.Default.Setting_пятница_6пара_начало = maskedTextBox_пятница_6пара_начало.Text;
            Settings.Default.Setting_пятница_6пара_конец = maskedTextBox_пятница_6пара_конец.Text;
            // суббота -------------------------------------------------------------------------;
            Settings.Default.Setting_суббота_1пара_начало = maskedTextBox_суббота_1пара_начало.Text;
            Settings.Default.Setting_суббота_1пара_конец = maskedTextBox_суббота_1пара_конец.Text;
            Settings.Default.Setting_суббота_2пара_начало = maskedTextBox_суббота_2пара_начало.Text;
            Settings.Default.Setting_суббота_2пара_конец = maskedTextBox_суббота_2пара_конец.Text;
            Settings.Default.Setting_суббота_3пара_начало = maskedTextBox_суббота_3пара_начало.Text;
            Settings.Default.Setting_суббота_3пара_конец = maskedTextBox_суббота_3пара_конец.Text;
            Settings.Default.Setting_суббота_4пара_начало = maskedTextBox_суббота_4пара_начало.Text;
            Settings.Default.Setting_суббота_4пара_конец = maskedTextBox_суббота_4пара_конец.Text;
            Settings.Default.Setting_суббота_5пара_начало = maskedTextBox_суббота_5пара_начало.Text;
            Settings.Default.Setting_суббота_5пара_конец = maskedTextBox_суббота_5пара_конец.Text;
            Settings.Default.Setting_суббота_6пара_начало = maskedTextBox_суббота_6пара_начало.Text;
            Settings.Default.Setting_суббота_6пара_конец = maskedTextBox_суббота_6пара_конец.Text;

        // чекбоксы --------------------------------------------------------------------------------;
          // понедельник ---------------------------------------------------------------------------;
            Settings.Default.SettingCheckBox_понедельник_1пара = checkBox_понедельник_1пара.Checked;
            Settings.Default.SettingCheckBox_понедельник_2пара = checkBox_понедельник_2пара.Checked;
            Settings.Default.SettingCheckBox_понедельник_3пара = checkBox_понедельник_3пара.Checked;
            Settings.Default.SettingCheckBox_понедельник_4пара = checkBox_понедельник_4пара.Checked;
            Settings.Default.SettingCheckBox_понедельник_5пара = checkBox_понедельник_5пара.Checked;
            Settings.Default.SettingCheckBox_понедельник_6пара = checkBox_понедельник_6пара.Checked;
          // вторник ------------------------------------------------------------------------;
            Settings.Default.SettingCheckBox_вторник_1пара = checkBox_вторник_1пара.Checked;
            Settings.Default.SettingCheckBox_вторник_2пара = checkBox_вторник_2пара.Checked;
            Settings.Default.SettingCheckBox_вторник_3пара = checkBox_вторник_3пара.Checked;
            Settings.Default.SettingCheckBox_вторник_4пара = checkBox_вторник_4пара.Checked;
            Settings.Default.SettingCheckBox_вторник_5пара = checkBox_вторник_5пара.Checked;
            Settings.Default.SettingCheckBox_вторник_6пара = checkBox_вторник_6пара.Checked;
          // среда ---------------------------------------------------------------------------;
            Settings.Default.SettingCheckBox_среда_1пара = checkBox_среда_1пара.Checked;
            Settings.Default.SettingCheckBox_среда_2пара = checkBox_среда_2пара.Checked;
            Settings.Default.SettingCheckBox_среда_3пара = checkBox_среда_3пара.Checked;
            Settings.Default.SettingCheckBox_среда_4пара = checkBox_среда_4пара.Checked;
            Settings.Default.SettingCheckBox_среда_5пара = checkBox_среда_5пара.Checked;
            Settings.Default.SettingCheckBox_среда_6пара = checkBox_среда_6пара.Checked;
          // четверг -------------------------------------------------------------------------;
            Settings.Default.SettingCheckBox_четверг_1пара = checkBox_четверг_1пара.Checked;
            Settings.Default.SettingCheckBox_четверг_2пара = checkBox_четверг_2пара.Checked;
            Settings.Default.SettingCheckBox_четверг_3пара = checkBox_четверг_3пара.Checked;
            Settings.Default.SettingCheckBox_четверг_4пара = checkBox_четверг_4пара.Checked;
            Settings.Default.SettingCheckBox_четверг_5пара = checkBox_четверг_5пара.Checked;
            Settings.Default.SettingCheckBox_четверг_6пара = checkBox_четверг_6пара.Checked;
          // пятница -------------------------------------------------------------------------;
            Settings.Default.SettingCheckBox_пятница_1пара = checkBox_пятница_1пара.Checked;
            Settings.Default.SettingCheckBox_пятница_2пара = checkBox_пятница_2пара.Checked;
            Settings.Default.SettingCheckBox_пятница_3пара = checkBox_пятница_3пара.Checked;
            Settings.Default.SettingCheckBox_пятница_4пара = checkBox_пятница_4пара.Checked;
            Settings.Default.SettingCheckBox_пятница_5пара = checkBox_пятница_5пара.Checked;
            Settings.Default.SettingCheckBox_пятница_6пара = checkBox_пятница_6пара.Checked;
          // суббота -------------------------------------------------------------------------;
            Settings.Default.SettingCheckBox_суббота_1пара = checkBox_суббота_1пара.Checked;
            Settings.Default.SettingCheckBox_суббота_2пара = checkBox_суббота_2пара.Checked;
            Settings.Default.SettingCheckBox_суббота_3пара = checkBox_суббота_3пара.Checked;
            Settings.Default.SettingCheckBox_суббота_4пара = checkBox_суббота_4пара.Checked;
            Settings.Default.SettingCheckBox_суббота_5пара = checkBox_суббота_5пара.Checked;
            Settings.Default.SettingCheckBox_суббота_6пара = checkBox_суббота_6пара.Checked;
        }

        private void button_ShowOneDay_Click(object sender, EventArgs e)
        {
            SettingsOneDay_Form sod_f = new SettingsOneDay_Form();
            sod_f.Show();
        }
    }
}
