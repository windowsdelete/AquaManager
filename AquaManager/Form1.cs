using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AquaManager
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            getProjects();
            //metroTabs.TabPages.Remove(metroTabPage2);
           // metroTabs.TabPages.Insert(2, metroTabPage2);
        }

        // Таймеры обновления контента
        private void getTime_Tick(object sender, EventArgs e)
        {
            theTime.Text = DateTime.Now.ToString();
        }

        private void autoUpadteTimer_Tick(object sender, EventArgs e)
        {
            getProjects();
        }

        // Автообновление
        private void autoUpdateToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (autoUpdateToggle.Checked)
                autoUpadteTimer.Start();
            else if (!autoUpdateToggle.Checked)
                autoUpadteTimer.Stop();
        }

        // Переменные и константы
        private int switchID;
        private const string primkeyProjects = "id_Projects", requestProjects = "Select projects.id_Projects, projects.NameProjects, teams.NameTeams, type.NameType, status.NameStatus, projects.CreateDate, projects.DeadLine, projects.FinishDate " +
                    "From projects, teams, type, status " +
                    "Where projects.id_Teams = teams.id_Teams and projects.id_Type = type.id_Type and projects.id_Status = status.id_Status"; // Проекты



        private void getProjects()
        {
            try
            {
                // Получение данных из таблицы
                MySqlConnection sqlProjects = new MySqlConnection(Properties.Settings.Default.connectText);
                sqlProjects.Open();
                MySqlDataAdapter adapterProjects = new MySqlDataAdapter(requestProjects, sqlProjects);
                DataTable dataProjects = new DataTable();
                adapterProjects.Fill(dataProjects);
                projectsGrid.DataSource = dataProjects;
                projectsGrid.Columns[primkeyProjects].Visible = false;
                sqlProjects.Close();

                // Изменение названий столбцов
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
                MessageBox.Show("Peace, Death!");
            }
        }

        private void editProjects(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
            {
                autoUpdateToggle.Checked = false;
                autoUpdateToggle.Enabled = false;
                // Вынести в отдельный метод и включать после редактирования обратно
                projectsGrid.Visible = false;
                // Stops here
                try
                {
                    switchID = Convert.ToInt32(projectsGrid[primkeyProjects, projectsGrid.CurrentRow.Index].Value);

                    MySqlConnection sqlProjects = new MySqlConnection(Properties.Settings.Default.connectText);
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
                    MessageBox.Show("Peace, Death!");
                }
            }
        }
    }
}
