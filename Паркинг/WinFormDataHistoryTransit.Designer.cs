namespace Паркинг
{
    partial class WinFormDataHistoryTransit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.parkingDataSet = new Паркинг.parkingDataSet();
            this.историяпроездовBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.историяпроездовTableAdapter = new Паркинг.parkingDataSetTableAdapters.историяпроездовTableAdapter();
            this.tableAdapterManager = new Паркинг.parkingDataSetTableAdapters.TableAdapterManager();
            this.автоTableAdapter = new Паркинг.parkingDataSetTableAdapters.автоTableAdapter();
            this.парковкиTableAdapter = new Паркинг.parkingDataSetTableAdapters.парковкиTableAdapter();
            this.историяпроездовDataGridView = new System.Windows.Forms.DataGridView();
            this.парковкиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.автоBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.историяпроездовBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.историяпроездовDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.автоBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 40);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(526, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Сброс";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2010, 6, 2, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата проезда от                                                до";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(266, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(122, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // parkingDataSet
            // 
            this.parkingDataSet.DataSetName = "parkingDataSet";
            this.parkingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // историяпроездовBindingSource
            // 
            this.историяпроездовBindingSource.DataMember = "историяпроездов";
            this.историяпроездовBindingSource.DataSource = this.parkingDataSet;
            // 
            // историяпроездовTableAdapter
            // 
            this.историяпроездовTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Паркинг.parkingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.автоTableAdapter = this.автоTableAdapter;
            this.tableAdapterManager.группыTableAdapter = null;
            this.tableAdapterManager.историяпроездовTableAdapter = this.историяпроездовTableAdapter;
            this.tableAdapterManager.историятранзакцийTableAdapter = null;
            this.tableAdapterManager.клиентыTableAdapter = null;
            this.tableAdapterManager.контактыклиентовTableAdapter = null;
            this.tableAdapterManager.маркиавтоTableAdapter = null;
            this.tableAdapterManager.моделиавтоTableAdapter = null;
            this.tableAdapterManager.настройкиTableAdapter = null;
            this.tableAdapterManager.парковкиTableAdapter = this.парковкиTableAdapter;
            this.tableAdapterManager.пользователиTableAdapter = null;
            this.tableAdapterManager.тарифыTableAdapter = null;
            // 
            // автоTableAdapter
            // 
            this.автоTableAdapter.ClearBeforeFill = true;
            // 
            // парковкиTableAdapter
            // 
            this.парковкиTableAdapter.ClearBeforeFill = true;
            // 
            // историяпроездовDataGridView
            // 
            this.историяпроездовDataGridView.AllowUserToAddRows = false;
            this.историяпроездовDataGridView.AllowUserToDeleteRows = false;
            this.историяпроездовDataGridView.AutoGenerateColumns = false;
            this.историяпроездовDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.историяпроездовDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn6});
            this.историяпроездовDataGridView.DataSource = this.историяпроездовBindingSource;
            this.историяпроездовDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.историяпроездовDataGridView.Location = new System.Drawing.Point(0, 40);
            this.историяпроездовDataGridView.Name = "историяпроездовDataGridView";
            this.историяпроездовDataGridView.ReadOnly = true;
            this.историяпроездовDataGridView.Size = new System.Drawing.Size(864, 410);
            this.историяпроездовDataGridView.TabIndex = 2;
            this.историяпроездовDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.историяпроездовDataGridView_CellDoubleClick);
            // 
            // парковкиBindingSource
            // 
            this.парковкиBindingSource.DataMember = "парковки";
            this.парковкиBindingSource.DataSource = this.parkingDataSet;
            // 
            // автоBindingSource
            // 
            this.автоBindingSource.DataMember = "авто";
            this.автоBindingSource.DataSource = this.parkingDataSet;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "парковка";
            this.dataGridViewTextBoxColumn2.DataSource = this.парковкиBindingSource;
            this.dataGridViewTextBoxColumn2.DisplayMember = "название";
            this.dataGridViewTextBoxColumn2.HeaderText = "Парковка";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn2.ValueMember = "id";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "авто";
            this.dataGridViewTextBoxColumn3.DataSource = this.автоBindingSource;
            this.dataGridViewTextBoxColumn3.DisplayMember = "госНомер";
            this.dataGridViewTextBoxColumn3.HeaderText = "Авто";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn3.ValueMember = "id";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "въехалДата";
            this.dataGridViewTextBoxColumn4.HeaderText = "Дата въезда";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "въехалФото";
            this.dataGridViewImageColumn1.HeaderText = "Фото въезда";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Text = "Фото";
            this.dataGridViewImageColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "выехалДата";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата выезда";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "выехалФото";
            this.dataGridViewImageColumn2.HeaderText = "Фото выезда";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewImageColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "стоимость";
            this.dataGridViewTextBoxColumn6.HeaderText = "Стоимость";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // WinFormDataHistoryTransit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.историяпроездовDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "WinFormDataHistoryTransit";
            this.Text = "История парковки";
            this.Load += new System.EventHandler(this.WinFormHistoryTransit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.историяпроездовBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.историяпроездовDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.автоBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private parkingDataSet parkingDataSet;
        private System.Windows.Forms.BindingSource историяпроездовBindingSource;
        private parkingDataSetTableAdapters.историяпроездовTableAdapter историяпроездовTableAdapter;
        private parkingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private parkingDataSetTableAdapters.автоTableAdapter автоTableAdapter;
        private System.Windows.Forms.DataGridView историяпроездовDataGridView;
        private System.Windows.Forms.BindingSource автоBindingSource;
        private parkingDataSetTableAdapters.парковкиTableAdapter парковкиTableAdapter;
        private System.Windows.Forms.BindingSource парковкиBindingSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}