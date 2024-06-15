namespace WobblySaveManager
{
    partial class StartForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            label1 = new Label();
            txtSavePath = new TextBox();
            btnShow = new Button();
            label2 = new Label();
            lvSaves = new ListView();
            chName = new ColumnHeader();
            chDate = new ColumnHeader();
            chWorlds = new ColumnHeader();
            btnReload = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Save Path:";
            // 
            // txtSavePath
            // 
            txtSavePath.Enabled = false;
            txtSavePath.Location = new Point(12, 27);
            txtSavePath.Name = "txtSavePath";
            txtSavePath.Size = new Size(364, 23);
            txtSavePath.TabIndex = 1;
            // 
            // btnShow
            // 
            btnShow.Location = new Point(385, 27);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(75, 23);
            btnShow.TabIndex = 2;
            btnShow.Text = "Show...";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 98);
            label2.Name = "label2";
            label2.Size = new Size(76, 15);
            label2.TabIndex = 4;
            label2.Text = "Found Saves:";
            // 
            // lvSaves
            // 
            lvSaves.Columns.AddRange(new ColumnHeader[] { chName, chDate, chWorlds });
            lvSaves.FullRowSelect = true;
            lvSaves.Location = new Point(12, 116);
            lvSaves.Name = "lvSaves";
            lvSaves.Size = new Size(448, 322);
            lvSaves.TabIndex = 5;
            lvSaves.UseCompatibleStateImageBehavior = false;
            lvSaves.View = View.Details;
            lvSaves.SelectedIndexChanged += lvSaves_SelectedIndexChanged;
            lvSaves.DoubleClick += lvSaves_DoubleClick;
            // 
            // chName
            // 
            chName.Text = "Name";
            chName.Width = 160;
            // 
            // chDate
            // 
            chDate.Text = "Date";
            chDate.Width = 150;
            // 
            // chWorlds
            // 
            chWorlds.Text = "Worlds";
            chWorlds.Width = 100;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(12, 56);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(448, 23);
            btnReload.TabIndex = 6;
            btnReload.Text = "Reload Saves";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 450);
            Controls.Add(btnReload);
            Controls.Add(lvSaves);
            Controls.Add(label2);
            Controls.Add(btnShow);
            Controls.Add(txtSavePath);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StartForm";
            Text = "Wobbly Save Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSavePath;
        private Button btnShow;
        private Label label2;
        private ListView lvSaves;
        private ColumnHeader chName;
        private ColumnHeader chDate;
        private ColumnHeader chWorlds;
        private Button btnReload;
    }
}
