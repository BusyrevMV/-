namespace Паркинг
{
    partial class WinFormDataHistoryPayments
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.историятранзакцийDataGridView = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.историятранзакцийBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parkingDataSet = new Паркинг.parkingDataSet();
            this.историятранзакцийTableAdapter = new Паркинг.parkingDataSetTableAdapters.историятранзакцийTableAdapter();
            this.tableAdapterManager = new Паркинг.parkingDataSetTableAdapters.TableAdapterManager();
            this.парковкиTableAdapter = new Паркинг.parkingDataSetTableAdapters.парковкиTableAdapter();
            this.списокклиентовBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.списокклиентовTableAdapter = new Паркинг.parkingDataSetTableAdapters.списокклиентовTableAdapter();
            this.парковкиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.историятранзакцийDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.историятранзакцийBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.списокклиентовBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(121, 14);
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
            this.label1.Size = new System.Drawing.Size(254, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата операции от                                                до";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(272, 14);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(122, 20);
            this.dateTimePicker2.TabIndex = 1;
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
            this.panel1.Size = new System.Drawing.Size(868, 40);
            this.panel1.TabIndex = 1;
            // 
            // историятранзакцийDataGridView
            // 
            this.историятранзакцийDataGridView.AllowUserToAddRows = false;
            this.историятранзакцийDataGridView.AllowUserToDeleteRows = false;
            this.историятранзакцийDataGridView.AutoGenerateColumns = false;
            this.историятранзакцийDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.историятранзакцийDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.историятранзакцийDataGridView.DataSource = this.историятранзакцийBindingSource;
            this.историятранзакцийDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.историятранзакцийDataGridView.Location = new System.Drawing.Point(0, 40);
            this.историятранзакцийDataGridView.Name = "историятранзакцийDataGridView";
            this.историятранзакцийDataGridView.Size = new System.Drawing.Size(868, 462);
            this.историятранзакцийDataGridView.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(506, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Сброс";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "клиент";
            this.dataGridViewTextBoxColumn2.HeaderText = "Клиент";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "стоянка";
            this.dataGridViewTextBoxColumn3.HeaderText = "Парковка";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "операция";
            this.dataGridViewTextBoxColumn4.HeaderText = "Операция";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "номерТранзакции";
            this.dataGridViewTextBoxColumn5.HeaderText = "Номер транзакции";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "дата";
            this.dataGridViewTextBoxColumn6.HeaderText = "Дата";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "сумма";
            this.dataGridViewTextBoxColumn7.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // историятранзакцийBindingSource
            // 
            this.историятранзакцийBindingSource.DataMember = "историятранзакций";
            this.историятранзакцийBindingSource.DataSource = this.parkingDataSet;
            // 
            // parkingDataSet
            // 
            this.parkingDataSet.DataSetName = "parkingDataSet";
            this.parkingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // историятранзакцийTableAdapter
            // 
            this.историятранзакцийTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Паркинг.parkingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.автоTableAdapter = null;
            this.tableAdapterManager.группыTableAdapter = null;
            this.tableAdapterManager.историяпроездовTableAdapter = null;
            this.tableAdapterManager.историятранзакцийTableAdapter = this.историятранзакцийTableAdapter;
            this.tableAdapterManager.клиентыTableAdapter = null;
            this.tableAdapterManager.контактыклиентовTableAdapter = null;
            this.tableAdapterManager.маркиавтоTableAdapter = null;
            this.tableAdapterManager.моделиавтоTableAdapter = null;
            this.tableAdapterManager.настройкиTableAdapter = null;
            this.tableAdapterManager.парковкиTableAdapter = this.парковкиTableAdapter;
            this.tableAdapterManager.пользователиTableAdapter = null;
            this.tableAdapterManager.тарифыTableAdapter = null;
            // 
            // парковкиTableAdapter
            // 
            this.парковкиTableAdapter.ClearBeforeFill = true;
            // 
            // списокклиентовBindingSource
            // 
            this.списокклиентовBindingSource.DataMember = "списокклиентов";
            this.списокклиентовBindingSource.DataSource = this.parkingDataSet;
            // 
            // списокклиентовTableAdapter
            // 
            this.списокклиентовTableAdapter.ClearBeforeFill = true;
            // 
            // парковкиBindingSource
            // 
            this.парковкиBindingSource.DataMember = "парковки";
            this.парковкиBindingSource.DataSource = this.parkingDataSet;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(410, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // WinFormDataHistoryPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 502);
            this.Controls.Add(this.историятранзакцийDataGridView);
            this.Controls.Add(this.panel1);
            this.Name = "WinFormDataHistoryPayments";
            this.Text = "История операций по счету";
            this.Load += new System.EventHandler(this.WinFormDataHistoryPayments_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.историятранзакцийDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.историятранзакцийBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.списокклиентовBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Panel panel1;
        private parkingDataSet parkingDataSet;
        private System.Windows.Forms.BindingSource историятранзакцийBindingSource;
        private parkingDataSetTableAdapters.историятранзакцийTableAdapter историятранзакцийTableAdapter;
        private parkingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView историятранзакцийDataGridView;
        private System.Windows.Forms.BindingSource списокклиентовBindingSource;
        private parkingDataSetTableAdapters.списокклиентовTableAdapter списокклиентовTableAdapter;
        private parkingDataSetTableAdapters.парковкиTableAdapter парковкиTableAdapter;
        private System.Windows.Forms.BindingSource парковкиBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}