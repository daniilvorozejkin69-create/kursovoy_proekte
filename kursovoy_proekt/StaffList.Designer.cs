using System.Windows.Forms;

namespace kursovoy_proekt
{
    partial class StaffList
    {
        private System.ComponentModel.IContainer components = null;

        // Основные панели
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;

        // Информация о пользователе
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelUserInfo;
        private System.Windows.Forms.Panel panelSeparator;

        // Панель фильтров
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Button buttonRefresh;

        // Панель действий
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonBackToMenu;

        // Таблица
        private System.Windows.Forms.DataGridView dataGridViewStaff;

        // Пагинация
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelPageInfo;

        // Статус и версия
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label labelVersion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffList));

            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelPageInfo = new System.Windows.Forms.Label();
            this.dataGridViewStaff = new System.Windows.Forms.DataGridView();
            this.panelActions = new System.Windows.Forms.Panel();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.labelUserInfo = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStaff)).BeginInit();
            this.panelActions.SuspendLayout();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.SuspendLayout();

            // ============================================
            // HEADER
            // ============================================
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1300, 90);
            this.panelHeader.TabIndex = 0;

            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(25, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;

            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(90, 25);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(325, 45);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Управление персоналом";

            // ============================================
            // GREEN LINE
            // ============================================
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 90);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(1300, 3);
            this.panelGreenLine.TabIndex = 1;

            // ============================================
            // CONTENT
            // ============================================
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(240, 245, 235);
            this.panelContent.Controls.Add(this.statusStrip);
            this.panelContent.Controls.Add(this.labelVersion);
            this.panelContent.Controls.Add(this.panelPagination);
            this.panelContent.Controls.Add(this.dataGridViewStaff);
            this.panelContent.Controls.Add(this.panelActions);
            this.panelContent.Controls.Add(this.panelFilters);
            this.panelContent.Controls.Add(this.panelSeparator);
            this.panelContent.Controls.Add(this.labelUserInfo);
            this.panelContent.Controls.Add(this.labelWelcome);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 93);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(1300, 657);
            this.panelContent.TabIndex = 2;

            // ============================================
            // WELCOME SECTION
            // ============================================
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelWelcome.Location = new System.Drawing.Point(30, 20);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(131, 21);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Добро пожаловать,";

            this.labelUserInfo.AutoSize = true;
            this.labelUserInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelUserInfo.ForeColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.labelUserInfo.Location = new System.Drawing.Point(161, 20);
            this.labelUserInfo.Name = "labelUserInfo";
            this.labelUserInfo.Size = new System.Drawing.Size(136, 21);
            this.labelUserInfo.TabIndex = 1;
            this.labelUserInfo.Text = "Имя пользователя";

            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.panelSeparator.Location = new System.Drawing.Point(30, 50);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(1240, 2);
            this.panelSeparator.TabIndex = 2;

            // ============================================
            // FILTERS PANEL
            // ============================================
            this.panelFilters.BackColor = System.Drawing.Color.White;
            this.panelFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilters.Controls.Add(this.buttonRefresh);
            this.panelFilters.Controls.Add(this.comboBoxStatus);
            this.panelFilters.Controls.Add(this.labelStatus);
            this.panelFilters.Controls.Add(this.comboBoxRole);
            this.panelFilters.Controls.Add(this.labelRole);
            this.panelFilters.Controls.Add(this.pictureBoxSearch);
            this.panelFilters.Controls.Add(this.textBoxSearch);
            this.panelFilters.Controls.Add(this.labelSearch);
            this.panelFilters.Location = new System.Drawing.Point(30, 70);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(1240, 80);
            this.panelFilters.TabIndex = 3;

            // labelSearch
            this.labelSearch.AutoSize = true;
            this.labelSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSearch.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelSearch.Location = new System.Drawing.Point(15, 15);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(51, 19);
            this.labelSearch.TabIndex = 0;
            this.labelSearch.Text = "Поиск:";

            // textBoxSearch
            this.textBoxSearch.BackColor = System.Drawing.Color.White;
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSearch.Location = new System.Drawing.Point(15, 40);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(300, 27);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.Text = "Поиск по ФИО, должности...";
            this.textBoxSearch.ForeColor = System.Drawing.Color.Gray;

            // pictureBoxSearch
            this.pictureBoxSearch.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch.Image")));
            this.pictureBoxSearch.Location = new System.Drawing.Point(290, 43);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSearch.TabIndex = 2;
            this.pictureBoxSearch.TabStop = false;

            // labelRole
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRole.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelRole.Location = new System.Drawing.Point(340, 15);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(38, 19);
            this.labelRole.TabIndex = 3;
            this.labelRole.Text = "Роль:";

            // comboBoxRole
            this.comboBoxRole.BackColor = System.Drawing.Color.White;
            this.comboBoxRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRole.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxRole.Items.AddRange(new object[] {
                "Все роли",
                "Администратор",
                "Сотрудник ресепшена",
                "Управляющий"});
            this.comboBoxRole.Location = new System.Drawing.Point(340, 40);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(180, 28);
            this.comboBoxRole.TabIndex = 4;

            // labelStatus
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelStatus.Location = new System.Drawing.Point(540, 15);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(55, 19);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Статус:";

            // comboBoxStatus
            this.comboBoxStatus.BackColor = System.Drawing.Color.White;
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStatus.Items.AddRange(new object[] {
                "Все",
                "Активные",
                "Неактивные"});
            this.comboBoxStatus.Location = new System.Drawing.Point(540, 40);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(150, 28);
            this.comboBoxStatus.TabIndex = 6;

            // buttonRefresh
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(720, 35);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(130, 35);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "🔄 Применить";
            this.buttonRefresh.UseVisualStyleBackColor = false;

            // ============================================
            // ACTIONS PANEL
            // ============================================
            this.panelActions.BackColor = System.Drawing.Color.White;
            this.panelActions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActions.Controls.Add(this.buttonBackToMenu);
            this.panelActions.Controls.Add(this.buttonDelete);
            this.panelActions.Controls.Add(this.buttonEdit);
            this.panelActions.Controls.Add(this.buttonAdd);
            this.panelActions.Location = new System.Drawing.Point(30, 160);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(1240, 70);
            this.panelActions.TabIndex = 4;

            // buttonAdd
            this.buttonAdd.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(15, 15);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(150, 40);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "➕  Добавить";
            this.buttonAdd.UseVisualStyleBackColor = false;

            // buttonEdit
            this.buttonEdit.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.buttonEdit.FlatAppearance.BorderSize = 0;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEdit.ForeColor = System.Drawing.Color.White;
            this.buttonEdit.Location = new System.Drawing.Point(175, 15);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(170, 40);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "✏️  Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = false;

            // buttonDelete
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(355, 15);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(140, 40);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "🗑️  Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;

            // buttonBackToMenu
            this.buttonBackToMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackToMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonBackToMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.buttonBackToMenu.FlatAppearance.BorderSize = 2;
            this.buttonBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBackToMenu.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.buttonBackToMenu.Location = new System.Drawing.Point(1085, 15);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(140, 40);
            this.buttonBackToMenu.TabIndex = 3;
            this.buttonBackToMenu.Text = "🏠  В меню";
            this.buttonBackToMenu.UseVisualStyleBackColor = false;

            // ============================================
            // DATA GRID VIEW
            // ============================================
            this.dataGridViewStaff.AllowUserToAddRows = false;
            this.dataGridViewStaff.AllowUserToDeleteRows = false;
            this.dataGridViewStaff.AllowUserToResizeRows = false;
            this.dataGridViewStaff.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStaff.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewStaff.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewStaff.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewStaff.ColumnHeadersHeight = 50;
            this.dataGridViewStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Стиль заголовков
            this.dataGridViewStaff.EnableHeadersVisualStyles = false;
            this.dataGridViewStaff.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.dataGridViewStaff.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewStaff.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.dataGridViewStaff.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewStaff.ColumnHeadersDefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);

            // Стиль ячеек
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(220, 235, 210);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.dataGridViewStaff.RowsDefaultCellStyle = dataGridViewCellStyle1;

            // Альтернативные строки
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(248, 250, 245);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(220, 235, 210);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.dataGridViewStaff.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;

            this.dataGridViewStaff.GridColor = System.Drawing.Color.FromArgb(220, 235, 210);
            this.dataGridViewStaff.Location = new System.Drawing.Point(30, 240);
            this.dataGridViewStaff.Name = "dataGridViewStaff";
            this.dataGridViewStaff.ReadOnly = true;
            this.dataGridViewStaff.RowHeadersVisible = false;
            this.dataGridViewStaff.RowTemplate.Height = 45;
            this.dataGridViewStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStaff.Size = new System.Drawing.Size(1240, 300);
            this.dataGridViewStaff.TabIndex = 5;

            // ============================================
            // КОЛОНКИ ТАБЛИЦЫ
            // ============================================

            // ID
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.HeaderText = "ID";
            colId.Name = "ID";
            colId.DataPropertyName = "ID";
            colId.Width = 50;
            colId.ReadOnly = true;
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colId.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.dataGridViewStaff.Columns.Add(colId);

            // ФИО
            DataGridViewTextBoxColumn colFIO = new DataGridViewTextBoxColumn();
            colFIO.HeaderText = "ФИО";
            colFIO.Name = "ФИО";
            colFIO.DataPropertyName = "ФИО";
            colFIO.Width = 250;
            colFIO.ReadOnly = true;
            colFIO.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            colFIO.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dataGridViewStaff.Columns.Add(colFIO);

            // Должность
            DataGridViewTextBoxColumn colPosition = new DataGridViewTextBoxColumn();
            colPosition.HeaderText = "Должность";
            colPosition.Name = "Должность";
            colPosition.DataPropertyName = "Должность";
            colPosition.Width = 180;
            colPosition.ReadOnly = true;
            this.dataGridViewStaff.Columns.Add(colPosition);

            // Роль
            DataGridViewTextBoxColumn colRole = new DataGridViewTextBoxColumn();
            colRole.HeaderText = "Роль в системе";
            colRole.Name = "Роль";
            colRole.DataPropertyName = "Роль";
            colRole.Width = 150;
            colRole.ReadOnly = true;
            colRole.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewStaff.Columns.Add(colRole);

            // Логин
            DataGridViewTextBoxColumn colLogin = new DataGridViewTextBoxColumn();
            colLogin.HeaderText = "Логин";
            colLogin.Name = "Логин";
            colLogin.DataPropertyName = "Логин";
            colLogin.Width = 120;
            colLogin.ReadOnly = true;
            colLogin.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 10F);
            colLogin.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.dataGridViewStaff.Columns.Add(colLogin);

            // Телефон
            DataGridViewTextBoxColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.HeaderText = "Телефон";
            colPhone.Name = "Телефон";
            colPhone.DataPropertyName = "Телефон";
            colPhone.Width = 150;
            colPhone.ReadOnly = true;
            colPhone.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 10F);
            colPhone.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.dataGridViewStaff.Columns.Add(colPhone);

            // Email
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.HeaderText = "Email";
            colEmail.Name = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.Width = 200;
            colEmail.ReadOnly = true;
            colEmail.DefaultCellStyle.Font = new System.Drawing.Font("Consolas", 10F);
            colEmail.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.dataGridViewStaff.Columns.Add(colEmail);

            // Дата приёма
            DataGridViewTextBoxColumn colHireDate = new DataGridViewTextBoxColumn();
            colHireDate.HeaderText = "Дата приёма";
            colHireDate.Name = "Дата приёма";
            colHireDate.DataPropertyName = "Дата приёма";
            colHireDate.Width = 120;
            colHireDate.ReadOnly = true;
            colHireDate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewStaff.Columns.Add(colHireDate);

            // Статус
            DataGridViewCheckBoxColumn colIsActive = new DataGridViewCheckBoxColumn();
            colIsActive.HeaderText = "Активен";
            colIsActive.Name = "Активен";
            colIsActive.DataPropertyName = "Активен";
            colIsActive.Width = 80;
            colIsActive.ReadOnly = true;
            colIsActive.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewStaff.Columns.Add(colIsActive);

            // ============================================
            // PAGINATION PANEL
            // ============================================
            this.panelPagination.BackColor = System.Drawing.Color.Transparent;
            this.panelPagination.Controls.Add(this.buttonPrev);
            this.panelPagination.Controls.Add(this.buttonNext);
            this.panelPagination.Controls.Add(this.labelPageInfo);
            this.panelPagination.Location = new System.Drawing.Point(30, 550);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(1240, 50);
            this.panelPagination.TabIndex = 6;

            // buttonPrev
            this.buttonPrev.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.buttonPrev.FlatAppearance.BorderSize = 0;
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrev.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPrev.ForeColor = System.Drawing.Color.White;
            this.buttonPrev.Location = new System.Drawing.Point(400, 5);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(50, 40);
            this.buttonPrev.TabIndex = 0;
            this.buttonPrev.Text = "◀";
            this.buttonPrev.UseVisualStyleBackColor = false;

            // buttonNext
            this.buttonNext.BackColor = System.Drawing.Color.FromArgb(106, 153, 85);
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNext.ForeColor = System.Drawing.Color.White;
            this.buttonNext.Location = new System.Drawing.Point(470, 5);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(50, 40);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "▶";
            this.buttonNext.UseVisualStyleBackColor = false;

            // labelPageInfo
            this.labelPageInfo.AutoSize = true;
            this.labelPageInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPageInfo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.labelPageInfo.Location = new System.Drawing.Point(0, 15);
            this.labelPageInfo.Name = "labelPageInfo";
            this.labelPageInfo.Size = new System.Drawing.Size(142, 20);
            this.labelPageInfo.TabIndex = 2;
            this.labelPageInfo.Text = "Страница 1 из 1 | 0";

            // ============================================
            // STATUS STRIP
            // ============================================
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(76, 145, 195);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(30, 600);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1240, 22);
            this.statusStrip.TabIndex = 7;

            this.toolStripStatusLabel.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(135, 17);
            this.toolStripStatusLabel.Text = "Загрузка данных...";

            // ============================================
            // VERSION
            // ============================================
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.labelVersion.Location = new System.Drawing.Point(30, 630);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(158, 13);
            this.labelVersion.TabIndex = 8;
            this.labelVersion.Text = "База отдыха v1.0 | Персонал";

            // ============================================
            // FORM
            // ============================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 750);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StaffList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление персоналом";
            this.Load += new System.EventHandler(this.StaffList_Load);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStaff)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.ResumeLayout(false);
        }
    }
}