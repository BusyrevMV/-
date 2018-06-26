namespace Паркинг
{
    partial class WinFormDataParkings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinFormDataParkings));
            this.parkingDataSet = new Паркинг.parkingDataSet();
            this.парковкиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.парковкиTableAdapter = new Паркинг.parkingDataSetTableAdapters.парковкиTableAdapter();
            this.tableAdapterManager = new Паркинг.parkingDataSetTableAdapters.TableAdapterManager();
            this.парковкиBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.парковкиBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.парковкиDataGridView = new System.Windows.Forms.DataGridView();
            this.тарифыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.тарифыTableAdapter = new Паркинг.parkingDataSetTableAdapters.тарифыTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиBindingNavigator)).BeginInit();
            this.парковкиBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.тарифыBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // parkingDataSet
            // 
            this.parkingDataSet.DataSetName = "parkingDataSet";
            this.parkingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // парковкиBindingSource
            // 
            this.парковкиBindingSource.DataMember = "парковки";
            this.парковкиBindingSource.DataSource = this.parkingDataSet;
            // 
            // парковкиTableAdapter
            // 
            this.парковкиTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Паркинг.parkingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.автоTableAdapter = null;
            this.tableAdapterManager.группыTableAdapter = null;
            this.tableAdapterManager.историяпроездовTableAdapter = null;
            this.tableAdapterManager.историятранзакцийTableAdapter = null;
            this.tableAdapterManager.клиентыTableAdapter = null;
            this.tableAdapterManager.контактыклиентовTableAdapter = null;
            this.tableAdapterManager.маркиавтоTableAdapter = null;
            this.tableAdapterManager.моделиавтоTableAdapter = null;
            this.tableAdapterManager.настройкиTableAdapter = null;
            this.tableAdapterManager.парковкиTableAdapter = this.парковкиTableAdapter;
            this.tableAdapterManager.пользователиTableAdapter = null;
            this.tableAdapterManager.тарифыTableAdapter = this.тарифыTableAdapter;
            // 
            // парковкиBindingNavigator
            // 
            this.парковкиBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.парковкиBindingNavigator.BindingSource = this.парковкиBindingSource;
            this.парковкиBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.парковкиBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.парковкиBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.парковкиBindingNavigatorSaveItem});
            this.парковкиBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.парковкиBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.парковкиBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.парковкиBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.парковкиBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.парковкиBindingNavigator.Name = "парковкиBindingNavigator";
            this.парковкиBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.парковкиBindingNavigator.Size = new System.Drawing.Size(800, 25);
            this.парковкиBindingNavigator.TabIndex = 0;
            this.парковкиBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 15);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 20);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // парковкиBindingNavigatorSaveItem
            // 
            this.парковкиBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.парковкиBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("парковкиBindingNavigatorSaveItem.Image")));
            this.парковкиBindingNavigatorSaveItem.Name = "парковкиBindingNavigatorSaveItem";
            this.парковкиBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 23);
            this.парковкиBindingNavigatorSaveItem.Text = "Сохранить данные";
            this.парковкиBindingNavigatorSaveItem.Click += new System.EventHandler(this.парковкиBindingNavigatorSaveItem_Click);
            // 
            // парковкиDataGridView
            // 
            this.парковкиDataGridView.AllowUserToAddRows = false;
            this.парковкиDataGridView.AllowUserToDeleteRows = false;
            this.парковкиDataGridView.AutoGenerateColumns = false;
            this.парковкиDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.парковкиDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.парковкиDataGridView.DataSource = this.парковкиBindingSource;
            this.парковкиDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.парковкиDataGridView.Location = new System.Drawing.Point(0, 25);
            this.парковкиDataGridView.Name = "парковкиDataGridView";
            this.парковкиDataGridView.Size = new System.Drawing.Size(800, 425);
            this.парковкиDataGridView.TabIndex = 1;
            // 
            // тарифыBindingSource
            // 
            this.тарифыBindingSource.DataMember = "тарифы";
            this.тарифыBindingSource.DataSource = this.parkingDataSet;
            // 
            // тарифыTableAdapter
            // 
            this.тарифыTableAdapter.ClearBeforeFill = true;
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
            this.dataGridViewTextBoxColumn2.DataPropertyName = "название";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "адрес";
            this.dataGridViewTextBoxColumn3.HeaderText = "Адрес";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "вместимость";
            this.dataGridViewTextBoxColumn4.HeaderText = "Вместимость";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "занято";
            this.dataGridViewTextBoxColumn5.HeaderText = "Занято";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "тариф";
            this.dataGridViewTextBoxColumn6.DataSource = this.тарифыBindingSource;
            this.dataGridViewTextBoxColumn6.DisplayMember = "название";
            this.dataGridViewTextBoxColumn6.HeaderText = "Тариф";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn6.ValueMember = "id";
            // 
            // WinFormDataParkings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.парковкиDataGridView);
            this.Controls.Add(this.парковкиBindingNavigator);
            this.Name = "WinFormDataParkings";
            this.Text = "Парковки";
            this.Load += new System.EventHandler(this.WinFormDataParkings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.parkingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиBindingNavigator)).EndInit();
            this.парковкиBindingNavigator.ResumeLayout(false);
            this.парковкиBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.парковкиDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.тарифыBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private parkingDataSet parkingDataSet;
        private System.Windows.Forms.BindingSource парковкиBindingSource;
        private parkingDataSetTableAdapters.парковкиTableAdapter парковкиTableAdapter;
        private parkingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator парковкиBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton парковкиBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView парковкиDataGridView;
        private parkingDataSetTableAdapters.тарифыTableAdapter тарифыTableAdapter;
        private System.Windows.Forms.BindingSource тарифыBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn6;
    }
}