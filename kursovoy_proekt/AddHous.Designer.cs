using System.Windows.Forms;

namespace kursovoy_proekt
{
    public partial class AddHous : Form
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Panel panelGreenLine;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxHouseClass;
        private System.Windows.Forms.Label labelHouseClass;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxCapacity;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.TextBox textBoxAddressNumber;
        private System.Windows.Forms.Label labelAddressNumber;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ToolTip toolTip;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddHous));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.panelGreenLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxHouseClass = new System.Windows.Forms.ComboBox();
            this.labelHouseClass = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxCapacity = new System.Windows.Forms.TextBox();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.textBoxAddressNumber = new System.Windows.Forms.TextBox();
            this.labelAddressNumber = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(145)))), ((int)(((byte)(195)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(600, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(30, 20);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(282, 37);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "ДОБАВЛЕНИЕ НОВОГО ДОМА";
            // 
            // panelGreenLine
            // 
            this.panelGreenLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.panelGreenLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGreenLine.Location = new System.Drawing.Point(0, 80);
            this.panelGreenLine.Name = "panelGreenLine";
            this.panelGreenLine.Size = new System.Drawing.Size(600, 3);
            this.panelGreenLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.panelContent.Controls.Add(this.buttonMenu);
            this.panelContent.Controls.Add(this.buttonDelete);
            this.panelContent.Controls.Add(this.buttonSave);
            this.panelContent.Controls.Add(this.comboBoxHouseClass);
            this.panelContent.Controls.Add(this.labelHouseClass);
            this.panelContent.Controls.Add(this.textBoxDescription);
            this.panelContent.Controls.Add(this.labelDescription);
            this.panelContent.Controls.Add(this.textBoxCapacity);
            this.panelContent.Controls.Add(this.labelCapacity);
            this.panelContent.Controls.Add(this.textBoxAddressNumber);
            this.panelContent.Controls.Add(this.labelAddressNumber);
            this.panelContent.Controls.Add(this.textBoxName);
            this.panelContent.Controls.Add(this.labelName);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 83);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(30);
            this.panelContent.Size = new System.Drawing.Size(600, 567);
            this.panelContent.TabIndex = 2;
            // 
            // buttonMenu
            // 
            this.buttonMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMenu.BackColor = System.Drawing.Color.Transparent;
            this.buttonMenu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonMenu.FlatAppearance.BorderSize = 2;
            this.buttonMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.buttonMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.buttonMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonMenu.Location = new System.Drawing.Point(320, 460);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(230, 50);
            this.buttonMenu.TabIndex = 8;
            this.buttonMenu.Text = "🏠 ВЕРНУТЬСЯ В МЕНЮ";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.buttonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.Location = new System.Drawing.Point(50, 460);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(230, 50);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "🗑️ УДАЛИТЬ ДОМ";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(130)))), ((int)(((byte)(65)))));
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(100)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(50, 400);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(500, 50);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "➕ ДОБАВИТЬ ДОМ";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxHouseClass
            // 
            this.comboBoxHouseClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxHouseClass.BackColor = System.Drawing.Color.White;
            this.comboBoxHouseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHouseClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxHouseClass.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxHouseClass.FormattingEnabled = true;
            this.comboBoxHouseClass.Location = new System.Drawing.Point(50, 280);
            this.comboBoxHouseClass.Name = "comboBoxHouseClass";
            this.comboBoxHouseClass.Size = new System.Drawing.Size(500, 28);
            this.comboBoxHouseClass.TabIndex = 4;
            this.toolTip.SetToolTip(this.comboBoxHouseClass, "Выберите класс дома из списка");
            this.comboBoxHouseClass.Enter += new System.EventHandler(this.Control_Enter);
            this.comboBoxHouseClass.Leave += new System.EventHandler(this.Control_Leave);
            // 
            // labelHouseClass
            // 
            this.labelHouseClass.AutoSize = true;
            this.labelHouseClass.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHouseClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelHouseClass.Location = new System.Drawing.Point(50, 255);
            this.labelHouseClass.Name = "labelHouseClass";
            this.labelHouseClass.Size = new System.Drawing.Size(89, 19);
            this.labelHouseClass.TabIndex = 0;
            this.labelHouseClass.Text = "Класс дома:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.BackColor = System.Drawing.Color.White;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDescription.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxDescription.Location = new System.Drawing.Point(50, 340);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(500, 50);
            this.textBoxDescription.TabIndex = 5;
            this.toolTip.SetToolTip(this.textBoxDescription, "Описание дома (не более 500 символов)");
            this.textBoxDescription.Enter += new System.EventHandler(this.Control_Enter);
            this.textBoxDescription.Leave += new System.EventHandler(this.Control_Leave);
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDescription.Location = new System.Drawing.Point(50, 315);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(177, 19);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Описание (необязательно):";
            // 
            // textBoxCapacity
            // 
            this.textBoxCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCapacity.BackColor = System.Drawing.Color.White;
            this.textBoxCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCapacity.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxCapacity.Location = new System.Drawing.Point(50, 220);
            this.textBoxCapacity.MaxLength = 3;
            this.textBoxCapacity.Name = "textBoxCapacity";
            this.textBoxCapacity.Size = new System.Drawing.Size(200, 27);
            this.textBoxCapacity.TabIndex = 3;
            this.toolTip.SetToolTip(this.textBoxCapacity, "Вместимость в чел. (1-999)");
            this.textBoxCapacity.Enter += new System.EventHandler(this.Control_Enter);
            this.textBoxCapacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCapacity_KeyPress);
            this.textBoxCapacity.Leave += new System.EventHandler(this.Control_Leave);
            this.textBoxCapacity.TextChanged += new System.EventHandler(this.textBoxCapacity_TextChanged);
            this.textBoxCapacity.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCapacity_Validating);
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCapacity.Location = new System.Drawing.Point(50, 195);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(88, 19);
            this.labelCapacity.TabIndex = 0;
            this.labelCapacity.Text = "Вместимость:";
            // 
            // textBoxAddressNumber
            // 
            this.textBoxAddressNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddressNumber.BackColor = System.Drawing.Color.White;
            this.textBoxAddressNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAddressNumber.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAddressNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxAddressNumber.Location = new System.Drawing.Point(50, 160);
            this.textBoxAddressNumber.MaxLength = 10;
            this.textBoxAddressNumber.Name = "textBoxAddressNumber";
            this.textBoxAddressNumber.Size = new System.Drawing.Size(200, 27);
            this.textBoxAddressNumber.TabIndex = 2;
            this.toolTip.SetToolTip(this.textBoxAddressNumber, "Номер дома (не более 10 символов)");
            this.textBoxAddressNumber.Enter += new System.EventHandler(this.Control_Enter);
            this.textBoxAddressNumber.Leave += new System.EventHandler(this.Control_Leave);
            this.textBoxAddressNumber.TextChanged += new System.EventHandler(this.textBoxAddressNumber_TextChanged);
            // 
            // labelAddressNumber
            // 
            this.labelAddressNumber.AutoSize = true;
            this.labelAddressNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelAddressNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAddressNumber.Location = new System.Drawing.Point(50, 135);
            this.labelAddressNumber.Name = "labelAddressNumber";
            this.labelAddressNumber.Size = new System.Drawing.Size(86, 19);
            this.labelAddressNumber.TabIndex = 0;
            this.labelAddressNumber.Text = "Номер дома:";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.BackColor = System.Drawing.Color.White;
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxName.Location = new System.Drawing.Point(50, 100);
            this.textBoxName.MaxLength = 100;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(500, 27);
            this.textBoxName.TabIndex = 1;
            this.toolTip.SetToolTip(this.textBoxName, "Название дома (не более 100 символов)");
            this.textBoxName.Enter += new System.EventHandler(this.Control_Enter);
            this.textBoxName.Leave += new System.EventHandler(this.Control_Leave);
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelName.Location = new System.Drawing.Point(50, 75);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(108, 19);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название дома:";
            // 
            // AddHous
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelGreenLine);
            this.Controls.Add(this.panelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(616, 689);
            this.Name = "AddHous";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление домами - База отдыха";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}