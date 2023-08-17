using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OIT_Call_Manager
{
    public partial class Main_Form : Form
    {
        // константы для флагов состояния занятий
        const int LESSONS_STATUS_NOBEGIN  = 0x00;  // пара ещё не началась
        const int LESSONS_STATUS_BEGIN = 0xF8;  // пара идёт
        const int LESSONS_STATUS_END    = 0xFF;  // пара закончилась

        const bool LESSONS_CHECK_OFF   = false; // пара отключена
        const bool LESSONS_CHECK_ON    = true;  // пара включена


        ArrayList BeginingTimeList = new ArrayList();
        ArrayList EndTimeList = new ArrayList();
        ArrayList PanelList = new ArrayList();
        ArrayList Label_begTimeList = new ArrayList();
        ArrayList Label_endTimeList = new ArrayList();
        ArrayList Label_statusList = new ArrayList();
        ArrayList Pause_TimeBegin_List = new ArrayList();
        ArrayList Pause_TimeEnd_List = new ArrayList();
        int CurrentLessons = -1;
        bool LessGo = false; // пара не идёт/идёт
        bool FormShow_flag = true;

#region // список флагов начала, хода и конца занятий

        int[] lessons_status_flag = new int[6];
        //int[] lessons_go_flag = new int[6];
        //int[] lessons_end_flag = new int[6];
        bool[] lessons_check_flag = new bool[6];

        //-------------
        

#endregion

        public Main_Form()
        {
            InitializeComponent();
            serialPort1.PortName = "COM1";
            serialPort1.BaudRate = 1200;
            serialPort1.DataBits = 8;
            serialPort1.Open();
            serialPort1.DtrEnable = false;
            BackColor = Color.RoyalBlue;
            menuStrip1.BackColor = Color.CornflowerBlue;
            File_ToolStripMenuItem.BackColor = Color.CornflowerBlue;
            panel_lessons_show.BackColor = Color.CornflowerBlue;
            label_panel_lessons_show_header.ForeColor = Color.WhiteSmoke;
            label_panel_lessons_show_1смена.ForeColor = Color.WhiteSmoke;
            label_panel_lessons_show_2смена.ForeColor = Color.WhiteSmoke;

            LoadList();
            Load_AppKernel();
        }

//---------------------------------------------------------------------------------
#region  // загрузка Label/panel List
        public void LoadList()
        {
            PanelList.Add(panel_1пара);
            PanelList.Add(panel_2пара);
            PanelList.Add(panel_3пара);
            PanelList.Add(panel_4пара);
            PanelList.Add(panel_5пара);
            PanelList.Add(panel_6пара);

            Label_begTimeList.Add(label_1пара_время_начала);
            Label_begTimeList.Add(label_2пара_время_начала);
            Label_begTimeList.Add(label_3пара_время_начала);
            Label_begTimeList.Add(label_4пара_время_начала);
            Label_begTimeList.Add(label_5пара_время_начала);
            Label_begTimeList.Add(label_6пара_время_начала);

            Label_endTimeList.Add(label_1пара_время_конца);
            Label_endTimeList.Add(label_2пара_время_конца);
            Label_endTimeList.Add(label_3пара_время_конца);
            Label_endTimeList.Add(label_4пара_время_конца);
            Label_endTimeList.Add(label_5пара_время_конца);
            Label_endTimeList.Add(label_6пара_время_конца);

            Label_statusList.Add(label_1пара_статус);
            Label_statusList.Add(label_2пара_статус);
            Label_statusList.Add(label_3пара_статус);
            Label_statusList.Add(label_4пара_статус);
            Label_statusList.Add(label_5пара_статус);
            Label_statusList.Add(label_6пара_статус);
        }

        // очистка листов
        public bool ListClear()
        {
            BeginingTimeList.Clear();
            EndTimeList.Clear();
            PanelList.Clear();
            Label_begTimeList.Clear();
            Label_endTimeList.Clear();
            Label_statusList.Clear();
            Pause_TimeBegin_List.Clear();
            Pause_TimeEnd_List.Clear();
            /*for (int i = 0; i < lessons_check_flag.Length; i++)
            {
                lessons_status_flag[i] = 0;
                lessons_check_flag[i] = false;
            }*/
            return true;
        }
#endregion
   //---------------------------------------------------------------------------------
       public int rrr = 0;
#region  // субметоды ToolStripMenu и contextMenu


        private void SettingsOneDay_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsOneDay_Form sod_f = new SettingsOneDay_Form();
           // timer1.Start();
            sod_f.Show();
            //rrr = 1;
        }

        private void OnAllBuzzer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OnAllBuzzer_ToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                OnAllBuzzer_ToolStripMenuItem.Checked = true;
                if (OffAllBuzzer_ToolStripMenuItem.CheckState == CheckState.Checked)
                    OffAllBuzzer_ToolStripMenuItem.Checked = false;
            }
            else
                if (OnAllBuzzer_ToolStripMenuItem.CheckState == CheckState.Checked)
                    OnAllBuzzer_ToolStripMenuItem.Checked = false;
        }

        private void OffAllBuzzer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OffAllBuzzer_ToolStripMenuItem.CheckState == CheckState.Unchecked)
            {
                OffAllBuzzer_ToolStripMenuItem.Checked = true;
                if (OnAllBuzzer_ToolStripMenuItem.CheckState == CheckState.Checked)
                    OnAllBuzzer_ToolStripMenuItem.Checked = false;
            }
            else
                if (OffAllBuzzer_ToolStripMenuItem.CheckState == CheckState.Checked)
                    OffAllBuzzer_ToolStripMenuItem.Checked = false;
        }

        private void Settings_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeSettings_Form sett_form = new ChangeSettings_Form();
            sett_form.Show();
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void showHideMainForm_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(FormShow_flag)
            {
                ShowInTaskbar = false;
                Hide();
                FormShow_flag = false;
            }
            else
                if(!FormShow_flag)
                {
                    ShowInTaskbar = true;
                    Show();
                    FormShow_flag = true;
                }
        }

        private void About_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.Show();
        }

        private void contextMenuStrip_notifyIcon_Opening(object sender, CancelEventArgs e)
        {
           if(FormShow_flag) 
              showHideMainFormToolStripMenuItem.Text = "Скрыть Call Manager";
            else
             if(!FormShow_flag)
                showHideMainFormToolStripMenuItem.Text = "Показать Call Manager";
        }

#endregion
//---------------------------------------------------------------------------------

        public void Load_AppKernel()
        {
            
         /* if (Settings.Default.SettingCheckBox_TopMost)
                TopMost = true;
            else TopMost = false;
            * убрать из настроек, если не буду юзать 
          */
           
            DateTime CurrentDateTime = DateTime.Today;

            if (Settings_OneDay.Default.SettingCheckBox_useOneDay)
            {
                int date = DateTime.Compare(Settings_OneDay.Default.Setting_Date.Date, CurrentDateTime);

                if (date == 0)
                {  // если текущая дата совпадает с датой дня на 1 распис.
                    Load_OneDay_AppKernel(CurrentDateTime);
                }
                else
                    if (date < 0)
                    { // если просрочено
                        Settings_OneDay.Default.SettingCheckBox_useOneDay = false;
                        Settings_OneDay.Default.Save();
                        ListClear();
                        LoadList();
                        Load_AppKernel(); //вызываем заново
                    }
            }
            else
            {
                Load_AllDay_AppKernel(CurrentDateTime);
                // дописать!!
            }
        }

        // загрузка ядра расписания на 1 день
        private void Load_OneDay_AppKernel(DateTime CurrentDateTime)
        {
            CreateTimeLists_OneDay();

            string curr_Date = CurrentDateTime.ToLongDateString();
            DayOfWeek dw = CurrentDateTime.DayOfWeek;

            DateTime dtt = new DateTime();
            dtt = CurrentDateTime;

            string curr_Day = dtt.ToString("dddd");

            label_panel_lessons_show_header.Text = "Расписание звонков на " + curr_Date + " (" + curr_Day + ")";
            timer_OneDayShowMainForm.Start();
            timer_OneDayCore.Start();
        }

        private void Load_AllDay_AppKernel(DateTime CurrentDateTime)
        { 
            // дописать!!!!
            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Monday: { CreateTimeLists_Monday();  break; }
                case DayOfWeek.Tuesday: { CreateTimeLists_Tuesday();  break; }
                case DayOfWeek.Wednesday: { CreateTimeLists_Wednesday();  break; }
                case DayOfWeek.Thursday: { CreateTimeLists_Thursday();  break; }
                case DayOfWeek.Friday: { CreateTimeLists_Friday();  break; }
                case DayOfWeek.Saturday: { CreateTimeLists_Saturday();  break; }
               // case DayOfWeek.Sunday: { break; }
            }

            string curr_Date = CurrentDateTime.ToLongDateString();

            DateTime dtt = new DateTime();
            dtt = CurrentDateTime;

            string curr_Day = dtt.ToString("dddd");

            label_panel_lessons_show_header.Text = "Расписание звонков на: " + curr_Day;
            timer_OneDayShowMainForm.Start();
            timer_OneDayCore.Start();
        }

        #region // Функции создания списков на день недели

        private void CreateTimeLists_Monday()
        {
            #region // Понедельник
          // 1-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_понедельник_1пара)
                lessons_check_flag[0] = LESSONS_CHECK_ON;
            else lessons_check_flag[0]=LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_понедельник_1пара_начало);
            EndTimeList.Add(Settings.Default.Setting_понедельник_1пара_конец);

            // 2-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_понедельник_2пара)
                lessons_check_flag[1] = LESSONS_CHECK_ON;
            else lessons_check_flag[1] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_понедельник_2пара_начало);
            EndTimeList.Add(Settings.Default.Setting_понедельник_2пара_конец);

            // 3-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_понедельник_3пара)
                lessons_check_flag[2] = LESSONS_CHECK_ON;
            else lessons_check_flag[2] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_понедельник_3пара_начало);
            EndTimeList.Add(Settings.Default.Setting_понедельник_3пара_конец);

            // 4-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_понедельник_4пара)
                lessons_check_flag[3] = LESSONS_CHECK_ON;
            else lessons_check_flag[3] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_понедельник_4пара_начало);
            EndTimeList.Add(Settings.Default.Setting_понедельник_4пара_конец);

            // 5-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_понедельник_5пара)
                lessons_check_flag[4] = LESSONS_CHECK_ON;
            else lessons_check_flag[4] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_понедельник_5пара_начало);
            EndTimeList.Add(Settings.Default.Setting_понедельник_5пара_конец);

            // 6-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_понедельник_6пара)
                lessons_check_flag[5] = LESSONS_CHECK_ON;
            else lessons_check_flag[5] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_понедельник_6пара_начало);
            EndTimeList.Add(Settings.Default.Setting_понедельник_6пара_конец);
         // конец  ---------------------------------------------------;

            //  Перемены ------------------------------------------------------------------------;
            // 1-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_понедельник_1пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_понедельник_2пара_начало);
            // 2-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_понедельник_2пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_понедельник_3пара_начало);
            // 3-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_понедельник_3пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_понедельник_4пара_начало);
            // 4-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_понедельник_4пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_понедельник_5пара_начало);
            // 5-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_понедельник_5пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_понедельник_6пара_начало);

              #endregion
        }

        private void CreateTimeLists_Tuesday()
        {
            #region // Вторник
            // 1-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_вторник_1пара)
                lessons_check_flag[0] = LESSONS_CHECK_ON;
            else lessons_check_flag[0] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_вторник_1пара_начало);
            EndTimeList.Add(Settings.Default.Setting_вторник_1пара_конец);

            // 2-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_вторник_2пара)
                lessons_check_flag[1] = LESSONS_CHECK_ON;
            else lessons_check_flag[1] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_вторник_2пара_начало);
            EndTimeList.Add(Settings.Default.Setting_вторник_2пара_конец);

            // 3-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_вторник_3пара)
                lessons_check_flag[2] = LESSONS_CHECK_ON;
            else lessons_check_flag[2] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_вторник_3пара_начало);
            EndTimeList.Add(Settings.Default.Setting_вторник_3пара_конец);

            // 4-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_вторник_4пара)
                lessons_check_flag[3] = LESSONS_CHECK_ON;
            else lessons_check_flag[3] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_вторник_4пара_начало);
            EndTimeList.Add(Settings.Default.Setting_вторник_4пара_конец);

            // 5-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_вторник_5пара)
                lessons_check_flag[4] = LESSONS_CHECK_ON;
            else lessons_check_flag[4] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_вторник_5пара_начало);
            EndTimeList.Add(Settings.Default.Setting_вторник_5пара_конец);

            // 6-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_вторник_6пара)
                lessons_check_flag[5] = LESSONS_CHECK_ON;
            else lessons_check_flag[5] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_вторник_6пара_начало);
            EndTimeList.Add(Settings.Default.Setting_вторник_6пара_конец);
            // конец  ---------------------------------------------------;

            //  Перемены ------------------------------------------------------------------------;
            // 1-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_вторник_1пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_вторник_2пара_начало);
            // 2-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_вторник_2пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_вторник_3пара_начало);
            // 3-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_вторник_3пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_вторник_4пара_начало);
            // 4-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_вторник_4пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_вторник_5пара_начало);
            // 5-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_вторник_5пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_вторник_6пара_начало);

            #endregion
        }

        private void CreateTimeLists_Wednesday()
        {
            #region // Среда
            // 1-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_среда_1пара)
                lessons_check_flag[0] = LESSONS_CHECK_ON;
            else lessons_check_flag[0] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_среда_1пара_начало);
            EndTimeList.Add(Settings.Default.Setting_среда_1пара_конец);

            // 2-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_среда_2пара)
                lessons_check_flag[1] = LESSONS_CHECK_ON;
            else lessons_check_flag[1] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_среда_2пара_начало);
            EndTimeList.Add(Settings.Default.Setting_среда_2пара_конец);

            // 3-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_среда_3пара)
                lessons_check_flag[2] = LESSONS_CHECK_ON;
            else lessons_check_flag[2] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_среда_3пара_начало);
            EndTimeList.Add(Settings.Default.Setting_среда_3пара_конец);

            // 4-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_среда_4пара)
                lessons_check_flag[3] = LESSONS_CHECK_ON;
            else lessons_check_flag[3] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_среда_4пара_начало);
            EndTimeList.Add(Settings.Default.Setting_среда_4пара_конец);

            // 5-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_среда_5пара)
                lessons_check_flag[4] = LESSONS_CHECK_ON;
            else lessons_check_flag[4] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_среда_5пара_начало);
            EndTimeList.Add(Settings.Default.Setting_среда_5пара_конец);

            // 6-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_среда_6пара)
                lessons_check_flag[5] = LESSONS_CHECK_ON;
            else lessons_check_flag[5] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_среда_6пара_начало);
            EndTimeList.Add(Settings.Default.Setting_среда_6пара_конец);
            // конец  ---------------------------------------------------;

            //  Перемены ------------------------------------------------------------------------;
            // 1-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_среда_1пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_среда_2пара_начало);
            // 2-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_среда_2пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_среда_3пара_начало);
            // 3-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_среда_3пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_среда_4пара_начало);
            // 4-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_среда_4пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_среда_5пара_начало);
            // 5-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_среда_5пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_среда_6пара_начало);

            #endregion
        }

        private void CreateTimeLists_Thursday()
        {
            #region // Четверг
            // 1-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_четверг_1пара)
                lessons_check_flag[0] = LESSONS_CHECK_ON;
            else lessons_check_flag[0] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_четверг_1пара_начало);
            EndTimeList.Add(Settings.Default.Setting_четверг_1пара_конец);

            // 2-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_четверг_2пара)
                lessons_check_flag[1] = LESSONS_CHECK_ON;
            else lessons_check_flag[1] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_четверг_2пара_начало);
            EndTimeList.Add(Settings.Default.Setting_четверг_2пара_конец);

            // 3-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_четверг_3пара)
                lessons_check_flag[2] = LESSONS_CHECK_ON;
            else lessons_check_flag[2] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_четверг_3пара_начало);
            EndTimeList.Add(Settings.Default.Setting_четверг_3пара_конец);

            // 4-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_четверг_4пара)
                lessons_check_flag[3] = LESSONS_CHECK_ON;
            else lessons_check_flag[3] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_четверг_4пара_начало);
            EndTimeList.Add(Settings.Default.Setting_четверг_4пара_конец);

            // 5-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_четверг_5пара)
                lessons_check_flag[4] = LESSONS_CHECK_ON;
            else lessons_check_flag[4] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_четверг_5пара_начало);
            EndTimeList.Add(Settings.Default.Setting_четверг_5пара_конец);

            // 6-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_четверг_6пара)
                lessons_check_flag[5] = LESSONS_CHECK_ON;
            else lessons_check_flag[5] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_четверг_6пара_начало);
            EndTimeList.Add(Settings.Default.Setting_четверг_6пара_конец);
            // конец  ---------------------------------------------------;

            //  Перемены ------------------------------------------------------------------------;
            // 1-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_четверг_1пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_четверг_2пара_начало);
            // 2-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_четверг_2пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_четверг_3пара_начало);
            // 3-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_четверг_3пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_четверг_4пара_начало);
            // 4-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_четверг_4пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_четверг_5пара_начало);
            // 5-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_четверг_5пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_четверг_6пара_начало);

            #endregion
        }

        private void CreateTimeLists_Friday()
        {
            #region // Пятница
            // 1-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_пятница_1пара)
                lessons_check_flag[0] = LESSONS_CHECK_ON;
            else lessons_check_flag[0] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_пятница_1пара_начало);
            EndTimeList.Add(Settings.Default.Setting_пятница_1пара_конец);

            // 2-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_пятница_2пара)
                lessons_check_flag[1] = LESSONS_CHECK_ON;
            else lessons_check_flag[1] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_пятница_2пара_начало);
            EndTimeList.Add(Settings.Default.Setting_пятница_2пара_конец);

            // 3-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_пятница_3пара)
                lessons_check_flag[2] = LESSONS_CHECK_ON;
            else lessons_check_flag[2] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_пятница_3пара_начало);
            EndTimeList.Add(Settings.Default.Setting_пятница_3пара_конец);

            // 4-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_пятница_4пара)
                lessons_check_flag[3] = LESSONS_CHECK_ON;
            else lessons_check_flag[3] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_пятница_4пара_начало);
            EndTimeList.Add(Settings.Default.Setting_пятница_4пара_конец);

            // 5-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_пятница_5пара)
                lessons_check_flag[4] = LESSONS_CHECK_ON;
            else lessons_check_flag[4] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_пятница_5пара_начало);
            EndTimeList.Add(Settings.Default.Setting_пятница_5пара_конец);

            // 6-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_пятница_6пара)
                lessons_check_flag[5] = LESSONS_CHECK_ON;
            else lessons_check_flag[5] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_пятница_6пара_начало);
            EndTimeList.Add(Settings.Default.Setting_пятница_6пара_конец);
            // конец  ---------------------------------------------------;

            //  Перемены ------------------------------------------------------------------------;
            // 1-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_пятница_1пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_пятница_2пара_начало);
            // 2-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_пятница_2пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_пятница_3пара_начало);
            // 3-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_пятница_3пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_пятница_4пара_начало);
            // 4-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_пятница_4пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_пятница_5пара_начало);
            // 5-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_пятница_5пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_пятница_6пара_начало);

            #endregion
        }

        private void CreateTimeLists_Saturday()
        {
            #region // Суббота
            // 1-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_суббота_1пара)
                lessons_check_flag[0] = LESSONS_CHECK_ON;
            else lessons_check_flag[0] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_суббота_1пара_начало);
            EndTimeList.Add(Settings.Default.Setting_суббота_1пара_конец);

            // 2-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_суббота_2пара)
                lessons_check_flag[1] = LESSONS_CHECK_ON;
            else lessons_check_flag[1] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_суббота_2пара_начало);
            EndTimeList.Add(Settings.Default.Setting_суббота_2пара_конец);

            // 3-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_суббота_3пара)
                lessons_check_flag[2] = LESSONS_CHECK_ON;
            else lessons_check_flag[2] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_суббота_3пара_начало);
            EndTimeList.Add(Settings.Default.Setting_суббота_3пара_конец);

            // 4-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_суббота_4пара)
                lessons_check_flag[3] = LESSONS_CHECK_ON;
            else lessons_check_flag[3] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_суббота_4пара_начало);
            EndTimeList.Add(Settings.Default.Setting_суббота_4пара_конец);

            // 5-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_суббота_5пара)
                lessons_check_flag[4] = LESSONS_CHECK_ON;
            else lessons_check_flag[4] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_суббота_5пара_начало);
            EndTimeList.Add(Settings.Default.Setting_суббота_5пара_конец);

            // 6-я пара ---------------------------------------------------;
            if (Settings.Default.SettingCheckBox_суббота_6пара)
                lessons_check_flag[5] = LESSONS_CHECK_ON;
            else lessons_check_flag[5] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings.Default.Setting_суббота_6пара_начало);
            EndTimeList.Add(Settings.Default.Setting_суббота_6пара_конец);
            // конец  ---------------------------------------------------;

            //  Перемены ------------------------------------------------------------------------;
            // 1-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_суббота_1пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_суббота_2пара_начало);
            // 2-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_суббота_2пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_суббота_3пара_начало);
            // 3-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_суббота_3пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_суббота_4пара_начало);
            // 4-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_суббота_4пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_суббота_5пара_начало);
            // 5-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings.Default.Setting_суббота_5пара_конец);
            Pause_TimeEnd_List.Add(Settings.Default.Setting_суббота_6пара_начало);

            #endregion
        }

        #endregion


        // сождаём 2 списка времени начала/конца занятий для конкретной даты
        private void CreateTimeLists_OneDay()
        {
            #region
          // 1-я пара ---------------------------------------------------;
            if (Settings_OneDay.Default.Setting_CheckBox_1пара)
                lessons_check_flag[0] = LESSONS_CHECK_ON;
            else lessons_check_flag[0]=LESSONS_CHECK_OFF;
            BeginingTimeList.Add((string)Settings_OneDay.Default.Setting_Time_1пара_начало);
            EndTimeList.Add(Settings_OneDay.Default.Setting_Time_1пара_конец);

          // 2-я пара ---------------------------------------------------;
            if (Settings_OneDay.Default.Setting_CheckBox_2пара)
                lessons_check_flag[1] = LESSONS_CHECK_ON;
            else lessons_check_flag[1] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add(Settings_OneDay.Default.Setting_Time_2пара_начало);
            EndTimeList.Add(Settings_OneDay.Default.Setting_Time_2пара_конец);

          // 3-я пара ---------------------------------------------------;
            if (Settings_OneDay.Default.Setting_CheckBox_3пара)
                lessons_check_flag[2] = LESSONS_CHECK_ON;
            else lessons_check_flag[2] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add(Settings_OneDay.Default.Setting_Time_3пара_начало);
            EndTimeList.Add(Settings_OneDay.Default.Setting_Time_3пара_конец);

          // 4-я пара ---------------------------------------------------;
            if (Settings_OneDay.Default.Setting_CheckBox_4пара)
                lessons_check_flag[3] = LESSONS_CHECK_ON;
            else lessons_check_flag[3] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add(Settings_OneDay.Default.Setting_Time_4пара_начало);
            EndTimeList.Add(Settings_OneDay.Default.Setting_Time_4пара_конец);

          // 5-я пара ---------------------------------------------------;
            if (Settings_OneDay.Default.Setting_CheckBox_5пара)
                lessons_check_flag[4] = LESSONS_CHECK_ON;
            else lessons_check_flag[4] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add(Settings_OneDay.Default.Setting_Time_5пара_начало);
            EndTimeList.Add(Settings_OneDay.Default.Setting_Time_5пара_конец);

          // 6-я пара ---------------------------------------------------;
            if (Settings_OneDay.Default.Setting_CheckBox_6пара)
                lessons_check_flag[5] = LESSONS_CHECK_ON;
            else lessons_check_flag[5] = LESSONS_CHECK_OFF;
            BeginingTimeList.Add(Settings_OneDay.Default.Setting_Time_6пара_начало);
            EndTimeList.Add(Settings_OneDay.Default.Setting_Time_6пара_конец);
          // конец  ---------------------------------------------------;

        //  Перемены ------------------------------------------------------------------------;
            // 1-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings_OneDay.Default.Setting_Time_1пара_конец);
            Pause_TimeEnd_List.Add(Settings_OneDay.Default.Setting_Time_2пара_начало);
            // 2-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings_OneDay.Default.Setting_Time_2пара_конец);
            Pause_TimeEnd_List.Add(Settings_OneDay.Default.Setting_Time_3пара_начало);
            // 3-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings_OneDay.Default.Setting_Time_3пара_конец);
            Pause_TimeEnd_List.Add(Settings_OneDay.Default.Setting_Time_4пара_начало);
            // 4-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings_OneDay.Default.Setting_Time_4пара_конец);
            Pause_TimeEnd_List.Add(Settings_OneDay.Default.Setting_Time_5пара_начало);
            // 5-я ----------------------------------------------------;
            Pause_TimeBegin_List.Add(Settings_OneDay.Default.Setting_Time_5пара_конец);
            Pause_TimeEnd_List.Add(Settings_OneDay.Default.Setting_Time_6пара_начало);

            #endregion
        }



//===========================================================================================

#region    // таймер подачи звонка для отдельной даты

        private void timer_OneDayCore_Tick(object sender, EventArgs e)
        {
            string str_sec = ":00";
            string Current_Time = DateTime.Now.ToLongTimeString();
            if (Current_Time.IndexOf(":") == 1)
                Current_Time = "0" + Current_Time;

            


            for (int i = 0; i < BeginingTimeList.Count; i++)
            {

                if ((0 < String.Compare(Current_Time, (string)BeginingTimeList[i] + str_sec)) &&
                    (0 > String.Compare(Current_Time, (string)EndTimeList[i] + str_sec))
                    && (lessons_check_flag[i] == LESSONS_CHECK_ON))
                {
                    Searh_lessonsEnd_and_Flags(i);
                    LessGo = true;
                    label1.Text = "Сейчас идёт " + (i + 1) + "-я пара";
                    /*DateTime dt_1, dt_2, dt_3;
                    DateTime.TryParse((string)BeginingTimeList[i] + str_sec, out dt_1);
                    DateTime.TryParse((string)EndTimeList[i] + str_sec, out dt_2);
                    int sec1 = Time_GetSec(dt_1);
                    int sec2 = Time_GetSec(dt_2);

                    dt_3 = Sec_GetTime(sec2 - sec1);
                    label2.Text = "закончится через: " + dt_3.Hour.ToString() + ":" + dt_3.Minute.ToString() + ":" + dt_3.Second;
                    */
                    break;
                }
                else
                {
                    LessGo = false;


                    if (i < Pause_TimeBegin_List.Count)
                    {
                        if ((0 < String.Compare(Current_Time, (string)Pause_TimeBegin_List[i] + str_sec)) &&
                            (0 > String.Compare(Current_Time, (string)Pause_TimeEnd_List[i] + str_sec)))
                        {
                            label1.Text = "Сейчас идёт перемена";
                            break;
                        }
                    }
                }

            }
                /*
                    if ((0 < String.Compare(Current_Time, (string)EndTimeList[BeginingTimeList.Count-1] + str_sec)) &&
                        (0 > String.Compare(Current_Time, (string)BeginingTimeList[0] + str_sec)))
                    {
                        label1.Text = "Занятия закончены";
                        //MessageBox.Show("< " + i + " >");
                    }

                    if ((!LessGo) && (0 < String.Compare(Current_Time, (string)BeginingTimeList[0] + str_sec)) &&
                        (0 > String.Compare(Current_Time, (string)EndTimeList[EndTimeList.Count-1] + str_sec)))
                    {
                        label1.Text = "Идёт перемена";

                    }
                */

            for (int i = 0; i < BeginingTimeList.Count; i++)
            {
                if ( (0 == String.Compare(Current_Time, (string)BeginingTimeList[i]+str_sec)) 
                     && (lessons_check_flag[i] == LESSONS_CHECK_ON) )
                {
                    Searh_lessonsEnd_and_Flags(i);
                    if (lessons_status_flag[i] != LESSONS_STATUS_NOBEGIN)
                    {
                        lessons_status_flag[i] = LESSONS_STATUS_BEGIN;
                        if(ToGiveSignal_FromCOM_port(i))
                        {
                            //lessons_go_flag[i] = LESSONS_BEGIN;
                            CurrentLessons = i;
                            break;
                        }                       
                    }
                }
                

                if ( (0 == String.Compare(Current_Time, (string)EndTimeList[i]+str_sec))
                       && (lessons_check_flag[i] == LESSONS_CHECK_ON))
                {
                    Searh_lessonsEnd_and_Flags(i);
                    lessons_status_flag[i] = LESSONS_STATUS_END;

                    if (ToGiveSignal_FromCOM_port(i))
                    {
                       // lessons_end_flag[i] = LESSONS_STATUS_END;
                        CurrentLessons = 0;
                        break;
                    }
                }
                
            }

        }
#endregion

        //получаем количество секунд
        int Time_GetSec(DateTime time)
        {
            int hour, min, sec;
            hour = time.Hour;
            min = time.Minute;
            sec = time.Second;

            return hour * 3600 + min * 60 + sec;
        }

        // получаем структуру время из секунд
        DateTime Sec_GetTime(int sec)
        {
            DateTime curd=DateTime.Now.Date;
            int hour = sec / 3600;
            int min = (sec % 3600) / 60;
            sec = (sec % 3600) % 60;
            DateTime time = new DateTime(curd.Year, curd.Month, curd.Day, hour, min, sec);

            return time;
        }


        // определяем сколько пар уже прошло, и если проспали это - выставляем флаги
        private void Searh_lessonsEnd_and_Flags(int count) // count - номер текушей пары из листа
        {
            for(int i=0; i<count; i++)
            {
                if (lessons_check_flag[i] == LESSONS_CHECK_ON)
                {
                    lessons_status_flag[i] = LESSONS_STATUS_END;
                    //MessageBox.Show("less-stat: \n" + i);
                }
            }
            lessons_status_flag[count] = LESSONS_STATUS_BEGIN;
        }

        //---------------------------------------------------------------
        //===============================================================
        //-- функция подачи питания на ком порт
        private bool ToGiveSignal_FromCOM_port(int i)
        {
            // дописать!!!
            if (lessons_status_flag[i] == LESSONS_STATUS_BEGIN)
            {
                Signal();
                notifyIcon_call_manager.ShowBalloonTip(300, "Звонок", "Началась " + (i + 1) + "-я пара", ToolTipIcon.None);
                return true;
            }
            if (lessons_status_flag[i] == LESSONS_STATUS_END)
            {
                string next_less = null;
                int c = 0;
                if (i < 5)
                {
                    if (lessons_check_flag[i + 1] == LESSONS_CHECK_OFF)
                        c = i + 2;
                    else
                        c = i + 1;
                    next_less = "\nСледующая пара в: " + BeginingTimeList[c];
                }
                else
                    next_less = " ";
                notifyIcon_call_manager.ShowBalloonTip(300, "Звонок", "Закончилась " + (i + 1) + "-я пара"+next_less, ToolTipIcon.None);
                Signal();
                return true;
            }
            return false;               
        }

        private void Signal()
        {
            serialPort1.DtrEnable = true;
            timer_signal.Start();
        }

        private void timer_signal_Tick(object sender, EventArgs e)
        {
            serialPort1.DtrEnable = false;
            timer_signal.Stop();
        }


      //==============================================================
        string status_string_go   = "(идёт)";
        string status_string_end  = "(закончилась)";
        string status_string_off  = "(отсутствует)";
        string status_string_wait = "(ожидается)";
        Label lbt = null, let=null, lsf=null;
        Panel pnl = null;

        private void timer_OneDayShowMainForm_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < PanelList.Count; i++)
                {
                    lbt = (Label)Label_begTimeList[i];
                    lbt.Text = (string)BeginingTimeList[i];
                    let = (Label)Label_endTimeList[i];
                    let.Text = (string)EndTimeList[i];

                    lsf = (Label)Label_statusList[i];

                    pnl = (Panel)PanelList[i];

                    if ( (lessons_check_flag[i] == LESSONS_CHECK_ON) || (lessons_status_flag[i]!=LESSONS_STATUS_END) )
                    {  // если пара ожидается
                        lsf.Text = status_string_wait;
                    }
                    if (lessons_check_flag[i] == LESSONS_CHECK_OFF)
                    {  // если пара отключена
                        lsf.Text = status_string_off;
                        pnl.BackColor = Color.CornflowerBlue;
                    }

                    if ((lessons_status_flag[i] == LESSONS_STATUS_BEGIN) && (lessons_check_flag[i] == LESSONS_CHECK_ON))
                    {  // если пара включена и идёт
                        pnl.BackColor = Color.PaleGreen; 
                        lsf.Text = status_string_go;
                    }
                    
                    
                    if ((lessons_status_flag[i] == LESSONS_STATUS_END) && (lessons_check_flag[i] == LESSONS_CHECK_ON))
                    {  // если пара включена и закончилась
                        pnl.BackColor = Color.Gray;
                        lsf.Text = status_string_end;
                    }   
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show("Ошибка в методе (private void timer_OneDayShowMainForm_Tick):\n\n" + ex.Message);
                Exception_Log("косяк...", "private void timer_OneDayShowMainForm_Tick(..)", ex.Message.ToString());
            }

        }

        //===============================================================
        //---------------------------------------------------------------
        public void Exception_Log(string messange, string method_name, string ex)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string header_log = "\n//-------------------------------------------------------------------//\n";
            string end_log = "\n//------------------------------------------------------------------//\n";
            
            if (messange.Length == 0)
                messange = "no msg";
            if (method_name.Length == 0)
                method_name = "unknown_metod";
            if (ex.Length == 0)
                ex = "no_exception";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath+@"\debaglog.txt",true))
            {
                file.WriteLine(header_log+"//---------- Дата: "+dt.ToLongDateString()+"  Время: "+dt.ToLongTimeString()+" ----------------//"+"\n\n"+ messange+"\n\n"+"Ошибка в методе: "+method_name+"\n\n"+ex+"\n"+end_log);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            ListClear();
            LoadList();
            Refresh();
            Load_AppKernel(); //вызываем заново
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            notifyIcon_call_manager.Visible = false;
        }

        

        
    }

    
}


