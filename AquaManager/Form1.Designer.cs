
namespace AquaManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroTabs = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.theTime = new MetroFramework.Controls.MetroLabel();
            this.projectsTab = new MetroFramework.Controls.MetroTabPage();
            this.projectsCancelButton = new MetroFramework.Controls.MetroTile();
            this.projectsDeleteButton = new MetroFramework.Controls.MetroTile();
            this.projectsGrid = new System.Windows.Forms.DataGridView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.projectsAddButton = new MetroFramework.Controls.MetroTile();
            this.projectsUpdateButton = new MetroFramework.Controls.MetroTile();
            this.panel1 = new System.Windows.Forms.Panel();
            this.projectsFinishDatePicker = new System.Windows.Forms.DateTimePicker();
            this.projectsNameLabel = new MetroFramework.Controls.MetroLabel();
            this.projectsDeadLinePicker = new System.Windows.Forms.DateTimePicker();
            this.projectsNameText = new MetroFramework.Controls.MetroTextBox();
            this.projectsCreateDatePicker = new System.Windows.Forms.DateTimePicker();
            this.projectsTeamLabel = new MetroFramework.Controls.MetroLabel();
            this.projectsTypeLabel = new MetroFramework.Controls.MetroLabel();
            this.projectsStatusLabel = new MetroFramework.Controls.MetroLabel();
            this.projectsStatusCombo = new MetroFramework.Controls.MetroComboBox();
            this.projectsCreateDateLabel = new MetroFramework.Controls.MetroLabel();
            this.projectsTypeCombo = new MetroFramework.Controls.MetroComboBox();
            this.projectsDeadLineLabel = new MetroFramework.Controls.MetroLabel();
            this.projectsTeamCombo = new MetroFramework.Controls.MetroComboBox();
            this.projectsFinishDateLabel = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage6 = new MetroFramework.Controls.MetroTabPage();
            this.getTime = new System.Windows.Forms.Timer(this.components);
            this.autoUpdateToggle = new MetroFramework.Controls.MetroToggle();
            this.autoUpdateLabel = new MetroFramework.Controls.MetroLabel();
            this.autoUpadteTimer = new System.Windows.Forms.Timer(this.components);
            this.metroTabs.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.projectsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabs
            // 
            this.metroTabs.Controls.Add(this.metroTabPage1);
            this.metroTabs.Controls.Add(this.projectsTab);
            this.metroTabs.Controls.Add(this.metroTabPage3);
            this.metroTabs.Controls.Add(this.metroTabPage4);
            this.metroTabs.Controls.Add(this.metroTabPage5);
            this.metroTabs.Controls.Add(this.metroTabPage6);
            this.metroTabs.Location = new System.Drawing.Point(23, 63);
            this.metroTabs.Name = "metroTabs";
            this.metroTabs.SelectedIndex = 1;
            this.metroTabs.Size = new System.Drawing.Size(1091, 475);
            this.metroTabs.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTabs.TabIndex = 0;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.theTime);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1083, 436);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Главная";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // theTime
            // 
            this.theTime.AutoSize = true;
            this.theTime.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.theTime.Location = new System.Drawing.Point(905, 411);
            this.theTime.Name = "theTime";
            this.theTime.Size = new System.Drawing.Size(117, 25);
            this.theTime.Style = MetroFramework.MetroColorStyle.Purple;
            this.theTime.TabIndex = 2;
            this.theTime.Text = "Getting time...";
            // 
            // projectsTab
            // 
            this.projectsTab.Controls.Add(this.projectsCancelButton);
            this.projectsTab.Controls.Add(this.projectsDeleteButton);
            this.projectsTab.Controls.Add(this.projectsGrid);
            this.projectsTab.Controls.Add(this.metroLabel1);
            this.projectsTab.Controls.Add(this.projectsAddButton);
            this.projectsTab.Controls.Add(this.projectsUpdateButton);
            this.projectsTab.Controls.Add(this.panel1);
            this.projectsTab.HorizontalScrollbarBarColor = true;
            this.projectsTab.Location = new System.Drawing.Point(4, 35);
            this.projectsTab.Name = "projectsTab";
            this.projectsTab.Size = new System.Drawing.Size(1083, 436);
            this.projectsTab.TabIndex = 1;
            this.projectsTab.Text = "Проекты";
            this.projectsTab.VerticalScrollbarBarColor = true;
            // 
            // projectsCancelButton
            // 
            this.projectsCancelButton.Location = new System.Drawing.Point(3, 319);
            this.projectsCancelButton.Name = "projectsCancelButton";
            this.projectsCancelButton.Size = new System.Drawing.Size(97, 92);
            this.projectsCancelButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.projectsCancelButton.TabIndex = 7;
            this.projectsCancelButton.Text = "Назад";
            this.projectsCancelButton.Visible = false;
            // 
            // projectsDeleteButton
            // 
            this.projectsDeleteButton.Location = new System.Drawing.Point(3, 221);
            this.projectsDeleteButton.Name = "projectsDeleteButton";
            this.projectsDeleteButton.Size = new System.Drawing.Size(97, 92);
            this.projectsDeleteButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.projectsDeleteButton.TabIndex = 6;
            this.projectsDeleteButton.Text = "Удалить";
            this.projectsDeleteButton.Visible = false;
            // 
            // projectsGrid
            // 
            this.projectsGrid.AllowUserToAddRows = false;
            this.projectsGrid.AllowUserToDeleteRows = false;
            this.projectsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.projectsGrid.BackgroundColor = System.Drawing.Color.White;
            this.projectsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectsGrid.Location = new System.Drawing.Point(645, 3);
            this.projectsGrid.Name = "projectsGrid";
            this.projectsGrid.ReadOnly = true;
            this.projectsGrid.Size = new System.Drawing.Size(435, 430);
            this.projectsGrid.TabIndex = 2;
            this.projectsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.editProjects);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(66, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Действия";
            // 
            // projectsAddButton
            // 
            this.projectsAddButton.Location = new System.Drawing.Point(3, 25);
            this.projectsAddButton.Name = "projectsAddButton";
            this.projectsAddButton.Size = new System.Drawing.Size(97, 92);
            this.projectsAddButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.projectsAddButton.TabIndex = 3;
            this.projectsAddButton.Text = "Добавить";
            // 
            // projectsUpdateButton
            // 
            this.projectsUpdateButton.Location = new System.Drawing.Point(3, 123);
            this.projectsUpdateButton.Name = "projectsUpdateButton";
            this.projectsUpdateButton.Size = new System.Drawing.Size(97, 92);
            this.projectsUpdateButton.Style = MetroFramework.MetroColorStyle.Purple;
            this.projectsUpdateButton.TabIndex = 5;
            this.projectsUpdateButton.Text = "Обновить";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.projectsFinishDatePicker);
            this.panel1.Controls.Add(this.projectsNameLabel);
            this.panel1.Controls.Add(this.projectsDeadLinePicker);
            this.panel1.Controls.Add(this.projectsNameText);
            this.panel1.Controls.Add(this.projectsCreateDatePicker);
            this.panel1.Controls.Add(this.projectsTeamLabel);
            this.panel1.Controls.Add(this.projectsTypeLabel);
            this.panel1.Controls.Add(this.projectsStatusLabel);
            this.panel1.Controls.Add(this.projectsStatusCombo);
            this.panel1.Controls.Add(this.projectsCreateDateLabel);
            this.panel1.Controls.Add(this.projectsTypeCombo);
            this.panel1.Controls.Add(this.projectsDeadLineLabel);
            this.panel1.Controls.Add(this.projectsTeamCombo);
            this.panel1.Controls.Add(this.projectsFinishDateLabel);
            this.panel1.Location = new System.Drawing.Point(174, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 313);
            this.panel1.TabIndex = 22;
            // 
            // projectsFinishDatePicker
            // 
            this.projectsFinishDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.projectsFinishDatePicker.Location = new System.Drawing.Point(171, 280);
            this.projectsFinishDatePicker.Name = "projectsFinishDatePicker";
            this.projectsFinishDatePicker.Size = new System.Drawing.Size(237, 20);
            this.projectsFinishDatePicker.TabIndex = 21;
            // 
            // projectsNameLabel
            // 
            this.projectsNameLabel.AutoSize = true;
            this.projectsNameLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.projectsNameLabel.Location = new System.Drawing.Point(14, 26);
            this.projectsNameLabel.Name = "projectsNameLabel";
            this.projectsNameLabel.Size = new System.Drawing.Size(88, 25);
            this.projectsNameLabel.TabIndex = 8;
            this.projectsNameLabel.Text = "Название";
            // 
            // projectsDeadLinePicker
            // 
            this.projectsDeadLinePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.projectsDeadLinePicker.Location = new System.Drawing.Point(171, 239);
            this.projectsDeadLinePicker.Name = "projectsDeadLinePicker";
            this.projectsDeadLinePicker.Size = new System.Drawing.Size(237, 20);
            this.projectsDeadLinePicker.TabIndex = 20;
            // 
            // projectsNameText
            // 
            this.projectsNameText.Location = new System.Drawing.Point(171, 28);
            this.projectsNameText.Name = "projectsNameText";
            this.projectsNameText.Size = new System.Drawing.Size(237, 23);
            this.projectsNameText.TabIndex = 9;
            // 
            // projectsCreateDatePicker
            // 
            this.projectsCreateDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.projectsCreateDatePicker.Location = new System.Drawing.Point(171, 193);
            this.projectsCreateDatePicker.Name = "projectsCreateDatePicker";
            this.projectsCreateDatePicker.Size = new System.Drawing.Size(237, 20);
            this.projectsCreateDatePicker.TabIndex = 19;
            // 
            // projectsTeamLabel
            // 
            this.projectsTeamLabel.AutoSize = true;
            this.projectsTeamLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.projectsTeamLabel.Location = new System.Drawing.Point(14, 65);
            this.projectsTeamLabel.Name = "projectsTeamLabel";
            this.projectsTeamLabel.Size = new System.Drawing.Size(79, 25);
            this.projectsTeamLabel.TabIndex = 10;
            this.projectsTeamLabel.Text = "Команда";
            // 
            // projectsTypeLabel
            // 
            this.projectsTypeLabel.AutoSize = true;
            this.projectsTypeLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.projectsTypeLabel.Location = new System.Drawing.Point(14, 105);
            this.projectsTypeLabel.Name = "projectsTypeLabel";
            this.projectsTypeLabel.Size = new System.Drawing.Size(41, 25);
            this.projectsTypeLabel.TabIndex = 11;
            this.projectsTypeLabel.Text = "Тип";
            // 
            // projectsStatusLabel
            // 
            this.projectsStatusLabel.AutoSize = true;
            this.projectsStatusLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.projectsStatusLabel.Location = new System.Drawing.Point(14, 145);
            this.projectsStatusLabel.Name = "projectsStatusLabel";
            this.projectsStatusLabel.Size = new System.Drawing.Size(63, 25);
            this.projectsStatusLabel.TabIndex = 12;
            this.projectsStatusLabel.Text = "Статус";
            // 
            // projectsStatusCombo
            // 
            this.projectsStatusCombo.FormattingEnabled = true;
            this.projectsStatusCombo.ItemHeight = 23;
            this.projectsStatusCombo.Location = new System.Drawing.Point(171, 145);
            this.projectsStatusCombo.Name = "projectsStatusCombo";
            this.projectsStatusCombo.Size = new System.Drawing.Size(237, 29);
            this.projectsStatusCombo.TabIndex = 18;
            // 
            // projectsCreateDateLabel
            // 
            this.projectsCreateDateLabel.AutoSize = true;
            this.projectsCreateDateLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.projectsCreateDateLabel.Location = new System.Drawing.Point(14, 188);
            this.projectsCreateDateLabel.Name = "projectsCreateDateLabel";
            this.projectsCreateDateLabel.Size = new System.Drawing.Size(148, 25);
            this.projectsCreateDateLabel.TabIndex = 13;
            this.projectsCreateDateLabel.Text = "Дата добавления";
            // 
            // projectsTypeCombo
            // 
            this.projectsTypeCombo.FormattingEnabled = true;
            this.projectsTypeCombo.ItemHeight = 23;
            this.projectsTypeCombo.Location = new System.Drawing.Point(171, 105);
            this.projectsTypeCombo.Name = "projectsTypeCombo";
            this.projectsTypeCombo.Size = new System.Drawing.Size(237, 29);
            this.projectsTypeCombo.TabIndex = 17;
            // 
            // projectsDeadLineLabel
            // 
            this.projectsDeadLineLabel.AutoSize = true;
            this.projectsDeadLineLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.projectsDeadLineLabel.Location = new System.Drawing.Point(14, 234);
            this.projectsDeadLineLabel.Name = "projectsDeadLineLabel";
            this.projectsDeadLineLabel.Size = new System.Drawing.Size(80, 25);
            this.projectsDeadLineLabel.TabIndex = 14;
            this.projectsDeadLineLabel.Text = "Дедлайн";
            // 
            // projectsTeamCombo
            // 
            this.projectsTeamCombo.FormattingEnabled = true;
            this.projectsTeamCombo.ItemHeight = 23;
            this.projectsTeamCombo.Location = new System.Drawing.Point(171, 65);
            this.projectsTeamCombo.Name = "projectsTeamCombo";
            this.projectsTeamCombo.Size = new System.Drawing.Size(237, 29);
            this.projectsTeamCombo.TabIndex = 16;
            // 
            // projectsFinishDateLabel
            // 
            this.projectsFinishDateLabel.AutoSize = true;
            this.projectsFinishDateLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.projectsFinishDateLabel.Location = new System.Drawing.Point(14, 275);
            this.projectsFinishDateLabel.Name = "projectsFinishDateLabel";
            this.projectsFinishDateLabel.Size = new System.Drawing.Size(151, 25);
            this.projectsFinishDateLabel.TabIndex = 15;
            this.projectsFinishDateLabel.Text = "Дата завершения";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1083, 436);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Команды";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(1083, 436);
            this.metroTabPage4.TabIndex = 3;
            this.metroTabPage4.Text = "Сотрудники";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(1083, 436);
            this.metroTabPage5.TabIndex = 4;
            this.metroTabPage5.Text = "Настройки";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            // 
            // metroTabPage6
            // 
            this.metroTabPage6.HorizontalScrollbarBarColor = true;
            this.metroTabPage6.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage6.Name = "metroTabPage6";
            this.metroTabPage6.Size = new System.Drawing.Size(1083, 436);
            this.metroTabPage6.TabIndex = 5;
            this.metroTabPage6.Text = "Администрирование";
            this.metroTabPage6.VerticalScrollbarBarColor = true;
            // 
            // getTime
            // 
            this.getTime.Enabled = true;
            this.getTime.Tick += new System.EventHandler(this.getTime_Tick);
            // 
            // autoUpdateToggle
            // 
            this.autoUpdateToggle.AutoSize = true;
            this.autoUpdateToggle.Location = new System.Drawing.Point(943, 43);
            this.autoUpdateToggle.Name = "autoUpdateToggle";
            this.autoUpdateToggle.Size = new System.Drawing.Size(80, 17);
            this.autoUpdateToggle.Style = MetroFramework.MetroColorStyle.Purple;
            this.autoUpdateToggle.TabIndex = 1;
            this.autoUpdateToggle.Text = "Off";
            this.autoUpdateToggle.UseVisualStyleBackColor = true;
            this.autoUpdateToggle.CheckedChanged += new System.EventHandler(this.autoUpdateToggle_CheckedChanged);
            // 
            // autoUpdateLabel
            // 
            this.autoUpdateLabel.AutoSize = true;
            this.autoUpdateLabel.Location = new System.Drawing.Point(823, 41);
            this.autoUpdateLabel.Name = "autoUpdateLabel";
            this.autoUpdateLabel.Size = new System.Drawing.Size(114, 19);
            this.autoUpdateLabel.TabIndex = 2;
            this.autoUpdateLabel.Text = "Автообновление";
            // 
            // autoUpadteTimer
            // 
            this.autoUpadteTimer.Interval = 5000;
            this.autoUpadteTimer.Tick += new System.EventHandler(this.autoUpadteTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 561);
            this.Controls.Add(this.autoUpdateLabel);
            this.Controls.Add(this.autoUpdateToggle);
            this.Controls.Add(this.metroTabs);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "AquaManager";
            this.metroTabs.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.projectsTab.ResumeLayout(false);
            this.projectsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabs;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroLabel theTime;
        private System.Windows.Forms.Timer getTime;
        private MetroFramework.Controls.MetroTabPage projectsTab;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private MetroFramework.Controls.MetroTabPage metroTabPage6;
        private System.Windows.Forms.DataGridView projectsGrid;
        private MetroFramework.Controls.MetroToggle autoUpdateToggle;
        private MetroFramework.Controls.MetroLabel autoUpdateLabel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile projectsAddButton;
        private System.Windows.Forms.Timer autoUpadteTimer;
        private MetroFramework.Controls.MetroTile projectsUpdateButton;
        private MetroFramework.Controls.MetroLabel projectsCreateDateLabel;
        private MetroFramework.Controls.MetroLabel projectsStatusLabel;
        private MetroFramework.Controls.MetroLabel projectsTypeLabel;
        private MetroFramework.Controls.MetroLabel projectsTeamLabel;
        private MetroFramework.Controls.MetroTextBox projectsNameText;
        private MetroFramework.Controls.MetroLabel projectsNameLabel;
        private MetroFramework.Controls.MetroTile projectsCancelButton;
        private MetroFramework.Controls.MetroTile projectsDeleteButton;
        private MetroFramework.Controls.MetroLabel projectsDeadLineLabel;
        private MetroFramework.Controls.MetroLabel projectsFinishDateLabel;
        private System.Windows.Forms.DateTimePicker projectsFinishDatePicker;
        private System.Windows.Forms.DateTimePicker projectsDeadLinePicker;
        private System.Windows.Forms.DateTimePicker projectsCreateDatePicker;
        private MetroFramework.Controls.MetroComboBox projectsStatusCombo;
        private MetroFramework.Controls.MetroComboBox projectsTypeCombo;
        private MetroFramework.Controls.MetroComboBox projectsTeamCombo;
        private System.Windows.Forms.Panel panel1;
    }
}

