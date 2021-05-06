using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaManager
{
    public partial class Manager : MetroFramework.Forms.MetroForm
    {
        public Manager()
        {
            InitializeComponent();
            this.Select();
            autoUpdateTimeCombo.SelectedIndex = 0;
            metroTabs.TabPages.Remove(adminTab);
        }

        private void getTime_Tick(object sender, EventArgs e)
        {
            theTime.Text = "Текущие дата и время: " + DateTime.Now.ToString();
        }

        private void autoUpadteTimer_Tick(object sender, EventArgs e)
        {
            updateAll();
        }

        private void updateAll()
        {
            getProjects();
            getWorkers();
            getTeams();
            getDashboard();
            if (Properties.Settings.Default.accessLevel == 4)
                getAdmin();
        }

        private void autoUpdateToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (autoUpdateToggle.Checked)
            {
                autoUpadteTimer.Start();
                projectsSecondButton.Enabled = false;
                teamsSecondButton.Enabled = false;
                workersSecondButton.Enabled = false;
                adminFirstButton.Enabled = false;
                Properties.Settings.Default.autoUpdater = true;
            }
            else if (!autoUpdateToggle.Checked)
            {
                autoUpadteTimer.Stop();
                projectsSecondButton.Enabled = true;
                teamsSecondButton.Enabled = true;
                workersSecondButton.Enabled = true;
                adminFirstButton.Enabled = true;
                if (autoUpdateToggle.Enabled)
                    Properties.Settings.Default.autoUpdater = false;
            }
        }

        private void autoUpdateController(bool _needOff)
        {
            if (_needOff)
            {
                autoUpdateToggle.Enabled = false;
                autoUpdateToggle.Checked = false;
                projectsSecondButton.Enabled = true;
                teamsSecondButton.Enabled = true;
                workersSecondButton.Enabled = true;
                adminFirstButton.Enabled = true;
            }
            else if (!_needOff)
            {
                if (Properties.Settings.Default.autoUpdater)
                    autoUpdateToggle.Checked = true;
                autoUpdateToggle.Enabled = true;
            }
        }

        MySqlConnection sqlAuth = new MySqlConnection(Properties.Settings.Default.connectText);
        MySqlConnection sqlDashboard = new MySqlConnection(Properties.Settings.Default.connectText);
        MySqlConnection sqlProjects = new MySqlConnection(Properties.Settings.Default.connectText);
        MySqlConnection sqlWorkers = new MySqlConnection(Properties.Settings.Default.connectText);
        MySqlConnection sqlTeams = new MySqlConnection(Properties.Settings.Default.connectText);
        MySqlConnection sqlAdmin = new MySqlConnection(Properties.Settings.Default.connectText);

        private int switchID;
        string errorMessage = "Проверьте подключение к интернету и/или обратитесь к системному администратору.";
        string appName = "AquaManager";
        string allowedchar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZабвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789 @.";
        private const string primkeyProjects = "id_Projects", requestProjects = "Select projects.id_Projects, projects.NameProjects, teams.NameTeams, type.NameType, status.NameStatus, projects.CreateDate, projects.DeadLine, projects.FinishDate " +
                    "From projects, teams, type, status " +
                    "Where projects.id_Teams = teams.id_Teams and projects.id_Type = type.id_Type and projects.id_Status = status.id_Status";

        private const string primkeyWorkers = "id_Workers", requestWorkers = "Select workers.id_Workers, workers.Surname, workers.Name, workers.MiddleName, positions.NamePositions, teams.NameTeams, workers.Email " +
            "From workers, positions, teams " +
            "Where workers.id_Positions = positions.id_Positions and workers.id_Teams = teams.id_Teams";

        private const string primkeyTeams = "id_Teams", requestTeams = "Select teams.id_Teams, teams.NameTeams, teams.Email " +
            "From teams";

        private const string primkeyAdmin = "id_Workers", requestAdmin = "Select workers.id_Workers, workers.Surname, workers.Name, workers.Username, workers.Password, workers.Email " +
            "From workers";

        private void getProjects()
        {
            try
            {
                sqlProjects.Open();
                MySqlDataAdapter adapterProjects = new MySqlDataAdapter(requestProjects, sqlProjects);
                DataTable dataProjects = new DataTable();
                adapterProjects.Fill(dataProjects);
                projectsGrid.DataSource = dataProjects;
                projectsGrid.Columns[primkeyProjects].Visible = false;
                sqlProjects.Close();

                projectsGrid.Columns[1].HeaderText = "Название";
                projectsGrid.Columns[2].HeaderText = "Команда";
                projectsGrid.Columns[3].HeaderText = "Тип";
                projectsGrid.Columns[4].HeaderText = "Статус";
                projectsGrid.Columns[5].HeaderText = "Дата добавления";
                projectsGrid.Columns[6].HeaderText = "Дедлайн";
                projectsGrid.Columns[7].HeaderText = "Дата завершения";
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadProjects()
        {
            try
            {
                sqlProjects.Open();
                MySqlDataAdapter adapterProjectsTeamsCombo = new MySqlDataAdapter
                    ("Select * From Teams", sqlProjects);
                DataTable dataProjectsTeamsCombo = new DataTable();
                adapterProjectsTeamsCombo.Fill(dataProjectsTeamsCombo);
                MySqlDataAdapter adapterProjectsTypeCombo = new MySqlDataAdapter
                    ("Select * From Type", sqlProjects);
                DataTable dataProjectsTypeCombo = new DataTable();
                adapterProjectsTypeCombo.Fill(dataProjectsTypeCombo);
                MySqlDataAdapter adapterProjectsStatusCombo = new MySqlDataAdapter
                    ("Select * From Status", sqlProjects);
                DataTable dataProjectsStatusCombo = new DataTable();
                adapterProjectsStatusCombo.Fill(dataProjectsStatusCombo);
                sqlProjects.Close();

                projectsTeamCombo.DataSource = dataProjectsTeamsCombo;
                projectsTeamCombo.DisplayMember = "NameTeams";
                projectsTeamCombo.ValueMember = "id_Teams";

                projectsTypeCombo.DataSource = dataProjectsTypeCombo;
                projectsTypeCombo.DisplayMember = "NameType";
                projectsTypeCombo.ValueMember = "id_Type";

                projectsStatusCombo.DataSource = dataProjectsStatusCombo;
                projectsStatusCombo.DisplayMember = "NameStatus";
                projectsStatusCombo.ValueMember = "id_Status";
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editProjects(object sender, DataGridViewCellEventArgs e)
        {
            if (Properties.Settings.Default.accessLevel != 1)
            {
                if (e.RowIndex != -1)
                {
                    autoUpdateController(true);
                    projectsGrid.Visible = false;
                    projectsEditPanel.Visible = true;
                    projectsCreateDatePicker.Enabled = false;
                    projectsFirstButton.Text = "Изменить";
                    projectsSecondButton.Text = "Удалить";
                    projectsThirdButton.Text = "Назад";
                    projectsThirdButton.Visible = true;
                    try
                    {
                        switchID = Convert.ToInt32(projectsGrid[primkeyProjects, projectsGrid.CurrentRow.Index].Value);

                        sqlProjects.Open();
                        MySqlDataAdapter adapterProjects = new MySqlDataAdapter
                            ("Select * from projects " +
                            "Where id_Projects=" + switchID, sqlProjects);
                        DataTable dataProjects = new DataTable();
                        adapterProjects.Fill(dataProjects);
                        MySqlDataAdapter adapterProjectsTeamsCombo = new MySqlDataAdapter
                            ("Select * From Teams", sqlProjects);
                        DataTable dataProjectsTeamsCombo = new DataTable();
                        adapterProjectsTeamsCombo.Fill(dataProjectsTeamsCombo);
                        MySqlDataAdapter adapterProjectsTypeCombo = new MySqlDataAdapter
                            ("Select * From Type", sqlProjects);
                        DataTable dataProjectsTypeCombo = new DataTable();
                        adapterProjectsTypeCombo.Fill(dataProjectsTypeCombo);
                        MySqlDataAdapter adapterProjectsStatusCombo = new MySqlDataAdapter
                            ("Select * From Status", sqlProjects);
                        DataTable dataProjectsStatusCombo = new DataTable();
                        adapterProjectsStatusCombo.Fill(dataProjectsStatusCombo);
                        sqlProjects.Close();
                        projectsNameText.Text = dataProjects.Rows[0][1].ToString();

                        projectsTeamCombo.DataSource = dataProjectsTeamsCombo;
                        projectsTeamCombo.DisplayMember = "NameTeams";
                        projectsTeamCombo.ValueMember = "id_Teams";
                        projectsTeamCombo.SelectedValue = dataProjects.Rows[0][2];

                        projectsTypeCombo.DataSource = dataProjectsTypeCombo;
                        projectsTypeCombo.DisplayMember = "NameType";
                        projectsTypeCombo.ValueMember = "id_Type";
                        projectsTypeCombo.SelectedValue = dataProjects.Rows[0][3];

                        projectsStatusCombo.DataSource = dataProjectsStatusCombo;
                        projectsStatusCombo.DisplayMember = "NameStatus";
                        projectsStatusCombo.ValueMember = "id_Status";
                        projectsStatusCombo.SelectedValue = dataProjects.Rows[0][4];

                        projectsCreateDatePicker.Value = Convert.ToDateTime(dataProjects.Rows[0][5]);
                        projectsDeadLinePicker.Value = Convert.ToDateTime(dataProjects.Rows[0][6]);
                        if (dataProjects.Rows[0][7] != DBNull.Value)
                            projectsFinishDatePicker.Value = Convert.ToDateTime(dataProjects.Rows[0][7]);
                    }
                    catch
                    {
                        MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Минимальный уровень доступа для изменения: 2", appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void projectsButtonActions(object sender, EventArgs e)
        {
            try
            {
                string selectedButton, request;
                selectedButton = (sender as MetroFramework.Controls.MetroTile).Text;

                switch (selectedButton)
                {
                    case "Записать":
                        if (projectsDeadLinePicker.Value < projectsCreateDatePicker.Value)
                            MessageBox.Show("Дедлайн не может быть раньше или равным дате добавления проекта.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(projectsNameText.Text))
                            MessageBox.Show("Имя проекта не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!projectsNameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Название проекта не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            sqlProjects.Open();
                            request =
                                "INSERT INTO projects " +
                                "(NameProjects, id_Teams, id_Type, id_Status, CreateDate, DeadLine) " +
                                "values ('" + projectsNameText.Text + "'," + projectsTeamCombo.SelectedValue + "," +
                                projectsTypeCombo.SelectedValue + "," + projectsStatusCombo.SelectedValue + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" +
                                projectsDeadLinePicker.Value.ToString("yyyy-MM-dd") + "')";
                            MySqlDataAdapter adapterProjectsAdd = new MySqlDataAdapter(request, sqlProjects);
                            DataTable dataProjectsAdd = new DataTable();
                            adapterProjectsAdd.Fill(dataProjectsAdd);
                            sqlProjects.Close();
                            projectsEndAction();
                        }
                        break;

                    case "Изменить":
                        if (projectsDeadLinePicker.Value < projectsCreateDatePicker.Value)
                            MessageBox.Show("Дедлайн не может быть раньше или равным дате добавления проекта.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (projectsFinishDatePicker.Value < projectsCreateDatePicker.Value && !projectsClearCheck.Checked)
                            MessageBox.Show("Дата завершения не может быть раньше или равным дате добавления проекта.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(projectsNameText.Text))
                            MessageBox.Show("Имя проекта не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!projectsNameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Название проекта не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (projectsClearCheck.Checked && projectsStatusCombo.SelectedValue.ToString() == "3")
                            MessageBox.Show("Проект не может быть завершён без даты.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            sqlProjects.Open();
                            if (projectsClearCheck.Checked)
                                request =
                                    "Update projects set " +
                                    "NameProjects= '" + projectsNameText.Text + "', " +
                                    "id_Teams=" + projectsTeamCombo.SelectedValue + ", " +
                                    "id_Type=" + projectsTypeCombo.SelectedValue + ", " +
                                    "id_Status=" + projectsStatusCombo.SelectedValue + ", " +
                                    "DeadLine= '" + projectsDeadLinePicker.Value.ToString("yyyy-MM-dd") + "', " +
                                    "FinishDate= " + "NULL " +
                                    "Where id_Projects=" + switchID;
                            else
                                request =
                                    "Update projects set " +
                                    "NameProjects= '" + projectsNameText.Text + "', " +
                                    "id_Teams=" + projectsTeamCombo.SelectedValue + ", " +
                                    "id_Type=" + projectsTypeCombo.SelectedValue + ", " +
                                    "id_Status=" + projectsStatusCombo.SelectedValue + ", " +
                                    "DeadLine= '" + projectsDeadLinePicker.Value.ToString("yyyy-MM-dd") + "', " +
                                    "FinishDate= '" + projectsFinishDatePicker.Value.ToString("yyyy-MM-dd") + "' " +
                                    "Where id_Projects=" + switchID;
                            MySqlDataAdapter adapterProjectsEdit = new MySqlDataAdapter(request, sqlProjects);
                            DataTable dataProjectsEdit = new DataTable();
                            adapterProjectsEdit.Fill(dataProjectsEdit);
                            sqlProjects.Close();
                            projectsEndAction();
                        }
                        break;

                    case "Удалить":
                        sqlProjects.Open();
                        request =
                            "Delete From Projects " +
                            "Where id_Projects=" + switchID;
                        MySqlDataAdapter adapterProjectsDelete = new MySqlDataAdapter(request, sqlProjects);
                        DataTable dataProjectsDelete = new DataTable();
                        adapterProjectsDelete.Fill(dataProjectsDelete);
                        sqlProjects.Close();
                        projectsEndAction();
                        break;

                    case "Добавить":
                        loadProjects();
                        projectsNameText.Text = "";
                        projectsFinishDateLabel.Visible = false;
                        projectsFinishDatePicker.Visible = false;
                        projectsClearCheck.Visible = false;
                        projectsCreateDatePicker.Value = DateTime.Now;
                        projectsStatusCombo.Enabled = false;
                        autoUpdateController(true);
                        projectsGrid.Visible = false;
                        projectsEditPanel.Visible = true;
                        projectsFirstButton.Text = "Записать";
                        projectsSecondButton.Text = "Назад";
                        break;

                    case "Обновить":
                        updateAll();
                        break;

                    case "Назад":
                        projectsEndAction();
                        break;
                }
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void projectsClearCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (projectsClearCheck.Checked)
            {
                projectsFinishDatePicker.Enabled = false;
                projectsStatusCombo.SelectedValue = 2;
                projectsStatusCombo.Enabled = true;
            }
            else if (!projectsClearCheck.Checked)
            {
                projectsFinishDatePicker.Enabled = true;
                projectsStatusCombo.SelectedValue = 3;
                projectsStatusCombo.Enabled = false;
            }
        }

        private void projectsEndAction()
        {
            projectsGrid.Visible = true;
            projectsEditPanel.Visible = false;
            projectsThirdButton.Visible = false;
            projectsFourthButton.Visible = false;
            projectsFinishDateLabel.Visible = true;
            projectsFinishDatePicker.Visible = true;
            projectsClearCheck.Visible = true;
            projectsClearCheck.Checked = true;
            projectsStatusCombo.Enabled = true;
            autoUpdateController(false);
            projectsFirstButton.Text = "Добавить";
            projectsSecondButton.Text = "Обновить";
            updateAll();
        }

        private void getWorkers()
        {
            try
            {
                sqlWorkers.Open();
                MySqlDataAdapter adapterWorkers = new MySqlDataAdapter(requestWorkers, sqlWorkers);
                DataTable dataWorkers = new DataTable();
                adapterWorkers.Fill(dataWorkers);
                workersGrid.DataSource = dataWorkers;
                workersGrid.Columns[primkeyWorkers].Visible = false;
                sqlWorkers.Close();

                // Изменение названий столбцов
                workersGrid.Columns[1].HeaderText = "Фамилия";
                workersGrid.Columns[2].HeaderText = "Имя";
                workersGrid.Columns[3].HeaderText = "Отчество";
                workersGrid.Columns[4].HeaderText = "Должность";
                workersGrid.Columns[5].HeaderText = "Команда";
                workersGrid.Columns[6].HeaderText = "Email";
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadWorkers()
        {
            try
            {
                sqlWorkers.Open();
                MySqlDataAdapter adapterWorkersPositionsCombo = new MySqlDataAdapter
                    ("Select * From Positions", sqlWorkers);
                DataTable dataWorkersPositionsCombo = new DataTable();
                adapterWorkersPositionsCombo.Fill(dataWorkersPositionsCombo);
                MySqlDataAdapter adapterWorkersTeamsCombo = new MySqlDataAdapter
                    ("Select * From Teams", sqlWorkers);
                DataTable dataWorkersTeamsCombo = new DataTable();
                adapterWorkersTeamsCombo.Fill(dataWorkersTeamsCombo);
                sqlWorkers.Close();

                workersPositionsCombo.DataSource = dataWorkersPositionsCombo;
                workersPositionsCombo.DisplayMember = "NamePositions";
                workersPositionsCombo.ValueMember = "id_Positions";

                workersTeamsCombo.DataSource = dataWorkersTeamsCombo;
                workersTeamsCombo.DisplayMember = "NameTeams";
                workersTeamsCombo.ValueMember = "id_Teams";
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editWorkers(object sender, DataGridViewCellEventArgs e)
        {
            if (Properties.Settings.Default.accessLevel != 1 && Properties.Settings.Default.accessLevel != 2)
            {
                if (e.RowIndex != -1)
                {
                    autoUpdateController(true);
                    workersGrid.Visible = false;
                    workersEditPanel.Visible = true;
                    workersFirstButton.Text = "Изменить";
                    workersSecondButton.Text = "Удалить";
                    workersThirdButton.Text = "Назад";
                    workersThirdButton.Visible = true;
                    try
                    {
                        switchID = Convert.ToInt32(workersGrid[primkeyWorkers, workersGrid.CurrentRow.Index].Value);
                        workersIDLabel.Text = "Идентификатор сотрудника: " + switchID;
                        sqlWorkers.Open();
                        MySqlDataAdapter adapterWorkers = new MySqlDataAdapter
                            ("Select * from workers " +
                            "Where id_Workers=" + switchID, sqlWorkers);
                        DataTable dataWorkers = new DataTable();
                        adapterWorkers.Fill(dataWorkers);
                        MySqlDataAdapter adapterWorkersPositionsCombo = new MySqlDataAdapter
                            ("Select * From Positions", sqlWorkers);
                        DataTable dataWorkersPositionsCombo = new DataTable();
                        adapterWorkersPositionsCombo.Fill(dataWorkersPositionsCombo);
                        MySqlDataAdapter adapterWorkersTeamsCombo = new MySqlDataAdapter
                            ("Select * From Teams", sqlWorkers);
                        DataTable dataWorkersTeamsCombo = new DataTable();
                        adapterWorkersTeamsCombo.Fill(dataWorkersTeamsCombo);
                        sqlWorkers.Close();
                        workersSurnameText.Text = dataWorkers.Rows[0][3].ToString();
                        workersNameText.Text = dataWorkers.Rows[0][4].ToString();
                        workersMiddleNameText.Text = dataWorkers.Rows[0][5].ToString();

                        workersPositionsCombo.DataSource = dataWorkersPositionsCombo;
                        workersPositionsCombo.DisplayMember = "NamePositions";
                        workersPositionsCombo.ValueMember = "id_Positions";
                        workersPositionsCombo.SelectedValue = dataWorkers.Rows[0][1];

                        workersTeamsCombo.DataSource = dataWorkersTeamsCombo;
                        workersTeamsCombo.DisplayMember = "NameTeams";
                        workersTeamsCombo.ValueMember = "id_Teams";
                        workersTeamsCombo.SelectedValue = dataWorkers.Rows[0][2];
                    }
                    catch
                    {
                        MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Минимальный уровень доступа для изменения: 3", appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void workersButtonActions(object sender, EventArgs e)
        {
            try
            {
                string selectedButton, request;
                selectedButton = (sender as MetroFramework.Controls.MetroTile).Text;

                switch (selectedButton)
                {
                    case "Записать":
                        if (!workersSurnameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Фамилия не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!workersNameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Имя не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!workersMiddleNameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Отчество не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(workersSurnameText.Text))
                            MessageBox.Show("Поле фамилии не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(workersNameText.Text))
                            MessageBox.Show("Поле имени не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            sqlWorkers.Open();
                            request =
                                "INSERT INTO workers " +
                                "(Surname, Name, MiddleName, id_Positions, id_Teams) " +
                                "values ('" + workersSurnameText.Text + "','" + workersNameText.Text + "','" + workersMiddleNameText.Text + "'," +
                                workersPositionsCombo.SelectedValue + "," + workersTeamsCombo.SelectedValue + ")";
                            MySqlDataAdapter adapterWorkersAdd = new MySqlDataAdapter(request, sqlWorkers);
                            DataTable dataWorkersAdd = new DataTable();
                            adapterWorkersAdd.Fill(dataWorkersAdd);
                            sqlWorkers.Close();
                            workersEndAction();
                        }
                        break;

                    case "Изменить":
                        if (!workersSurnameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Фамилия не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!workersNameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Имя не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!workersMiddleNameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Отчество не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(workersSurnameText.Text))
                            MessageBox.Show("Поле фамилии не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(workersNameText.Text))
                            MessageBox.Show("Поле имени не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            sqlWorkers.Open();
                            request =
                                "Update workers set " +
                                "Surname= '" + workersSurnameText.Text + "', " +
                                "Name= '" + workersNameText.Text + "', " +
                                "MiddleName= '" + workersMiddleNameText.Text + "', " +
                                "id_Positions=" + workersPositionsCombo.SelectedValue + ", " +
                                "id_Teams=" + workersTeamsCombo.SelectedValue + " " +
                                "Where id_Workers=" + switchID;
                            MySqlDataAdapter adapterWorkersEdit = new MySqlDataAdapter(request, sqlWorkers);
                            DataTable dataWorkersEdit = new DataTable();
                            adapterWorkersEdit.Fill(dataWorkersEdit);
                            sqlWorkers.Close();
                            workersEndAction();
                        }
                        break;

                    case "Удалить":
                        sqlWorkers.Open();
                        MySqlDataAdapter adapterCheckWorkers = new MySqlDataAdapter("Select id_Positions from Workers " +
                            "Where id_Workers=" + switchID, sqlWorkers);
                        DataTable dataCheckWorkers = new DataTable();
                        adapterCheckWorkers.Fill(dataCheckWorkers);
                        sqlWorkers.Close();
                        if (Convert.ToInt32(dataCheckWorkers.Rows[0][0]) == 4)
                            MessageBox.Show("Нельзя удалить администратора.", appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            sqlWorkers.Open();
                            request =
                                "Delete From Workers " +
                                "Where id_Workers=" + switchID;
                            MySqlDataAdapter adapterWorkersDelete = new MySqlDataAdapter(request, sqlWorkers);
                            DataTable dataWorkersDelete = new DataTable();
                            adapterWorkersDelete.Fill(dataWorkersDelete);
                            sqlWorkers.Close();
                            workersEndAction();
                        }
                        break;

                    case "Добавить":
                        loadWorkers();
                        workersSurnameText.Text = "";
                        workersNameText.Text = "";
                        workersMiddleNameText.Text = "";
                        autoUpdateController(true);
                        workersGrid.Visible = false;
                        workersEditPanel.Visible = true;
                        workersFirstButton.Text = "Записать";
                        workersSecondButton.Text = "Назад";
                        workersIDLabel.Visible = false;
                        break;

                    case "Обновить":
                        updateAll();
                        break;

                    case "Назад":
                        workersEndAction();
                        break;
                }
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void workersEndAction()
        {
            workersGrid.Visible = true;
            workersEditPanel.Visible = false;
            workersThirdButton.Visible = false;
            workersFourthButton.Visible = false;
            workersIDLabel.Visible = true;
            autoUpdateController(false);
            workersFirstButton.Text = "Добавить";
            workersSecondButton.Text = "Обновить";
            updateAll();
        }

        private void getTeams()
        {
            try
            {
                sqlTeams.Open();
                MySqlDataAdapter adapterTeams = new MySqlDataAdapter(requestTeams, sqlTeams);
                DataTable dataTeams = new DataTable();
                adapterTeams.Fill(dataTeams);
                teamsGrid.DataSource = dataTeams;
                teamsGrid.Columns[primkeyTeams].Visible = false;
                sqlTeams.Close();

                teamsGrid.Columns[1].HeaderText = "Название";
                teamsGrid.Columns[2].HeaderText = "Email";
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editTeams(object sender, DataGridViewCellEventArgs e)
        {
            if (Properties.Settings.Default.accessLevel != 1)
            {
                if (e.RowIndex != -1)
                {
                    autoUpdateController(true);
                    teamsGrid.Visible = false;
                    teamsEditPanel.Visible = true;
                    teamsFirstButton.Text = "Изменить";
                    teamsSecondButton.Text = "Удалить";
                    teamsThirdButton.Text = "Назад";
                    teamsThirdButton.Visible = true;
                    try
                    {
                        switchID = Convert.ToInt32(teamsGrid[primkeyTeams, teamsGrid.CurrentRow.Index].Value);

                        sqlTeams.Open();
                        MySqlDataAdapter adapterTeams = new MySqlDataAdapter
                            ("Select * from teams " +
                            "Where id_Teams=" + switchID, sqlWorkers);
                        DataTable dataTeams = new DataTable();
                        adapterTeams.Fill(dataTeams);
                        sqlTeams.Close();
                        teamsNameText.Text = dataTeams.Rows[0][1].ToString();
                        teamsEmailText.Text = dataTeams.Rows[0][2].ToString();
                    }
                    catch
                    {
                        MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Минимальный уровень доступа для изменения: 2", appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void teamsButtonActions(object sender, EventArgs e)
        {
            try
            {
                string selectedButton, request;
                selectedButton = (sender as MetroFramework.Controls.MetroTile).Text;

                switch (selectedButton)
                {
                    case "Записать":
                        if (!teamsNameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Название не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!teamsEmailText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Email не может содержать спецсимволы, кроме @.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(teamsNameText.Text))
                            MessageBox.Show("Название не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(teamsEmailText.Text))
                            MessageBox.Show("Поле email не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            sqlTeams.Open();
                            request =
                                "INSERT INTO teams " +
                                "(NameTeams, Email) " +
                                "values ('" + teamsNameText.Text + "','" + teamsEmailText.Text + "')";
                            MySqlDataAdapter adapterTeamsAdd = new MySqlDataAdapter(request, sqlTeams);
                            DataTable dataTeamsAdd = new DataTable();
                            adapterTeamsAdd.Fill(dataTeamsAdd);
                            sqlTeams.Close();
                            teamsEndAction();
                        }
                        break;

                    case "Изменить":
                        if (!teamsNameText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Название не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!teamsEmailText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Email не может содержать спецсимволы, кроме @.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(teamsNameText.Text))
                            MessageBox.Show("Название не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(teamsEmailText.Text))
                            MessageBox.Show("Поле email не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            sqlTeams.Open();
                            request =
                                "Update teams set " +
                                "NameTeams= '" + teamsNameText.Text + "', " +
                                "Email= '" + teamsEmailText.Text + "' " +
                                "Where id_Teams=" + switchID;
                            MySqlDataAdapter adapterTeamsEdit = new MySqlDataAdapter(request, sqlTeams);
                            DataTable dataTeamsEdit = new DataTable();
                            adapterTeamsEdit.Fill(dataTeamsEdit);
                            sqlTeams.Close();
                            teamsEndAction();
                        }
                        break;

                    case "Удалить":
                        sqlTeams.Open();
                        MySqlDataAdapter adapterCheckTeams = new MySqlDataAdapter("Select * from Projects " +
                            "Where id_Teams=" + switchID, sqlTeams);
                        DataTable dataCheckTeams = new DataTable();
                        adapterCheckTeams.Fill(dataCheckTeams);
                        sqlTeams.Close();
                        if (dataCheckTeams.Rows.Count > 0)
                            MessageBox.Show("Нельзя удалить команду, которая назначена на проект.", appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            sqlTeams.Open();
                            request =
                                "Delete From Teams " +
                                "Where id_Teams=" + switchID;
                            MySqlDataAdapter adapterTeamsDelete = new MySqlDataAdapter(request, sqlTeams);
                            DataTable dataTeamsDelete = new DataTable();
                            adapterTeamsDelete.Fill(dataTeamsDelete);
                            sqlTeams.Close();
                            teamsEndAction();
                        }
                        break;

                    case "Добавить":
                        teamsNameText.Text = "";
                        teamsEmailText.Text = "";
                        autoUpdateController(true);
                        teamsGrid.Visible = false;
                        teamsEditPanel.Visible = true;
                        teamsFirstButton.Text = "Записать";
                        teamsSecondButton.Text = "Назад";
                        break;

                    case "Обновить":
                        updateAll();
                        break;

                    case "Назад":
                        teamsEndAction();
                        break;
                }
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void teamsEndAction()
        {
            teamsGrid.Visible = true;
            teamsEditPanel.Visible = false;
            teamsThirdButton.Visible = false;
            teamsFourthButton.Visible = false;
            autoUpdateController(false);
            teamsFirstButton.Text = "Добавить";
            teamsSecondButton.Text = "Обновить";
            updateAll();
        }

        private void auth(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(authLoginText.Text))
                    MessageBox.Show("Логин не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (String.IsNullOrEmpty(authPasswordText.Text))
                    MessageBox.Show("Пароль не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (!authLoginText.Text.All(allowedchar.Contains))
                    MessageBox.Show("Логин не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (!authPasswordText.Text.All(allowedchar.Contains))
                    MessageBox.Show("Пароль не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    byte[] pwdHash = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(authPasswordText.Text));
                    string pwdBase = Convert.ToBase64String(pwdHash);
                    sqlAuth.Open();
                    MySqlDataAdapter adapterAuth = new MySqlDataAdapter
                        ("Select id_Positions, Surname, Name, id_Workers from Workers " +
                        "Where Username='" + authLoginText.Text + "' " +
                        "and Password='" + pwdBase + "'", sqlAuth);
                    DataTable dataAuth = new DataTable();
                    adapterAuth.Fill(dataAuth);
                    sqlAuth.Close();
                    if (dataAuth.Rows.Count > 0)
                    {
                        int accLvl = Convert.ToInt32(dataAuth.Rows[0][0]);
                        sqlAuth.Open();
                        MySqlDataAdapter adapterAuthAccess = new MySqlDataAdapter
                            ("Select AccessLevel from Positions " +
                            "Where id_Positions=" + accLvl, sqlAuth);
                        DataTable dataAuthAccess = new DataTable();
                        adapterAuthAccess.Fill(dataAuthAccess);
                        sqlAuth.Close();
                        Properties.Settings.Default.accessLevel = Convert.ToInt32(dataAuthAccess.Rows[0][0]);
                        Properties.Settings.Default.whois = Convert.ToInt32(dataAuth.Rows[0][3]);
                        helloLabel.Text = "Здравствуйте, " + dataAuth.Rows[0][1].ToString() + " " + dataAuth.Rows[0][2].ToString();
                        accessLevelLabel.Text = "Ваш уровень доступа: " + Properties.Settings.Default.accessLevel;
                        authPanel.Visible = false;
                        metroTabs.Visible = true;
                        metroTabs.SelectTab(0);
                        autoUpdateLabel.Visible = true;
                        autoUpdateToggle.Visible = true;
                        if (Properties.Settings.Default.accessLevel == 4)
                            metroTabs.TabPages.Insert(5, adminTab);
                        updateAll();
                        accessCheck();
                    }
                    else
                    {
                        MessageBox.Show("Неверные данные для авторизации.", appName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getDashboard()
        {
            try
            {
                sqlDashboard.Open();
                MySqlDataAdapter adapterDashboard = new MySqlDataAdapter("Select id_Teams from Workers " +
                        "Where id_Workers=" + Properties.Settings.Default.whois, sqlDashboard);
                DataTable dataDashboard = new DataTable();
                adapterDashboard.Fill(dataDashboard);
                dashboardGrid.DataSource = dataDashboard;
                sqlDashboard.Close();

                if (dataDashboard.Rows.Count > 0)
                {
                    int teamsid = Convert.ToInt32(dataDashboard.Rows[0][0]);
                    sqlDashboard.Open();
                    MySqlDataAdapter adapterDashboardTeams = new MySqlDataAdapter
                        ("Select projects.NameProjects, type.NameType, projects.CreateDate, projects.DeadLine " +
                        "from Projects, type " +
                        "Where id_Teams=" + teamsid + " and projects.id_Type = type.id_Type and projects.id_Status=2", sqlAuth);
                    DataTable dataDashboardTeams = new DataTable();
                    adapterDashboardTeams.Fill(dataDashboardTeams);
                    dashboardGrid.DataSource = dataDashboardTeams;
                    sqlDashboard.Close();
                    dashboardGrid.Columns[0].HeaderText = "Название";
                    dashboardGrid.Columns[1].HeaderText = "Тип";
                    dashboardGrid.Columns[2].HeaderText = "Дата добавления";
                    dashboardGrid.Columns[3].HeaderText = "Дедлайн";
                }
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getAdmin()
        {
            try
            {
                sqlAdmin.Open();
                MySqlDataAdapter adapterAdmin = new MySqlDataAdapter(requestAdmin, sqlAdmin);
                DataTable dataAdmin = new DataTable();
                adapterAdmin.Fill(dataAdmin);
                adminUsersGrid.DataSource = dataAdmin;
                adminUsersGrid.Columns[primkeyAdmin].Visible = false;
                sqlAdmin.Close();

                adminUsersGrid.Columns[1].HeaderText = "Фамилия";
                adminUsersGrid.Columns[2].HeaderText = "Имя";
                adminUsersGrid.Columns[3].HeaderText = "Логин";
                adminUsersGrid.Columns[4].HeaderText = "Пароль";
                adminUsersGrid.Columns[5].HeaderText = "Email";
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editAdmin(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                autoUpdateController(true);
                adminUsersGrid.Visible = false;
                adminEditPanel.Visible = true;
                adminPasswordText.Text = "";
                adminSecondButton.Visible = true;
                adminFirstButton.Text = "Изменить";
                try
                {
                    switchID = Convert.ToInt32(adminUsersGrid[primkeyAdmin, adminUsersGrid.CurrentRow.Index].Value);
                    adminIDLabel.Text = "Идентификатор сотрудника: " + switchID;
                    sqlAdmin.Open();
                    MySqlDataAdapter adapterAdmin = new MySqlDataAdapter
                        ("Select * from workers " +
                        "Where id_Workers=" + switchID, sqlWorkers);
                    DataTable dataAdmin = new DataTable();
                    adapterAdmin.Fill(dataAdmin);
                    sqlAdmin.Close();
                    adminSurnameText.Text = dataAdmin.Rows[0][3].ToString();
                    adminNameText.Text = dataAdmin.Rows[0][4].ToString();
                    adminLoginText.Text = dataAdmin.Rows[0][6].ToString();
                    adminEmailText.Text = dataAdmin.Rows[0][8].ToString();
                    adminSurnameText.Enabled = false;
                    adminNameText.Enabled = false;
                }
                catch
                {
                    MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void adminButtonActions(object sender, EventArgs e)
        {
            try
            {
                string selectedButton, request;
                selectedButton = (sender as MetroFramework.Controls.MetroTile).Text;

                switch (selectedButton)
                {

                    case "Изменить":
                        if (!adminLoginText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Логин не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!adminPasswordText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Пароль не может содержать спецсимволы.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (!adminEmailText.Text.All(allowedchar.Contains))
                            MessageBox.Show("Email не может содержать спецсимволы, кроме @.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(adminLoginText.Text))
                            MessageBox.Show("Поле логин не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(adminPasswordText.Text))
                            MessageBox.Show("Поле пароль не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (String.IsNullOrEmpty(adminEmailText.Text))
                            MessageBox.Show("Поле email не может быть пустым.", appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            byte[] pwdHash = new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.ASCII.GetBytes(adminPasswordText.Text));
                            string pwdBase = Convert.ToBase64String(pwdHash);
                            sqlAdmin.Open();
                            request =
                                "Update workers set " +
                                "Username= '" + adminLoginText.Text + "', " +
                                "Password= '" + pwdBase + "', " +
                                "Email= '" + adminEmailText.Text + "' " +
                                "Where id_Workers=" + switchID;
                            MySqlDataAdapter adapterAdminEdit = new MySqlDataAdapter(request, sqlAdmin);
                            DataTable dataAdminEdit = new DataTable();
                            adapterAdminEdit.Fill(dataAdminEdit);
                            sqlAdmin.Close();
                            adminEndAction();
                        }
                        break;

                    case "Обновить":
                        updateAll();
                        break;

                    case "Назад":
                        adminEndAction();
                        break;
                }
            }
            catch
            {
                MessageBox.Show(errorMessage, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminEndAction()
        {
            adminUsersGrid.Visible = true;
            adminEditPanel.Visible = false;
            autoUpdateController(false);
            adminFirstButton.Text = "Обновить";
            adminSecondButton.Visible = false;
            updateAll();
        }

        private void accessCheck()
        {
            if (Properties.Settings.Default.accessLevel == 1)
            {
                projectsFirstButton.Enabled = false;
                teamsFirstButton.Enabled = false;
                workersFirstButton.Enabled = false;
            }
            else if (Properties.Settings.Default.accessLevel == 2)
                workersFirstButton.Enabled = false;
        }

        private void autoUpdateTimeChange(object sender, EventArgs e)
        {
            if (autoUpdateTimeCombo.SelectedIndex == 0)
                autoUpadteTimer.Interval = 5000;
            else if (autoUpdateTimeCombo.SelectedIndex == 1)
                autoUpadteTimer.Interval = 6000;
            else if (autoUpdateTimeCombo.SelectedIndex == 2)
                autoUpadteTimer.Interval = 7000;
            else if (autoUpdateTimeCombo.SelectedIndex == 3)
                autoUpadteTimer.Interval = 8000;
            else if (autoUpdateTimeCombo.SelectedIndex == 4)
                autoUpadteTimer.Interval = 9000;
            else if (autoUpdateTimeCombo.SelectedIndex == 5)
                autoUpadteTimer.Interval = 10000;
        }

        private void accountLogout(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
