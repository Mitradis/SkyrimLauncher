namespace SkyrimLauncher
{
    partial class FormMods
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Install;
        private System.Windows.Forms.Button button_Uninstall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

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
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Install = new System.Windows.Forms.Button();
            this.button_Uninstall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button_Close
            // 
            this.button_Close.BackgroundImage = global::SkyrimLauncher.Properties.Resources.buttonClose;
            this.button_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_Close.FlatAppearance.BorderSize = 0;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Location = new System.Drawing.Point(223, 8);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(25, 25);
            this.button_Close.TabIndex = 1;
            this.button_Close.MouseEnter += new System.EventHandler(this.button_Close_MouseEnter);
            this.button_Close.MouseLeave += new System.EventHandler(this.button_Close_MouseLeave);
            // 
            // button_Install
            // 
            this.button_Install.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Install.Location = new System.Drawing.Point(7, 229);
            this.button_Install.Name = "button_Install";
            this.button_Install.Size = new System.Drawing.Size(117, 30);
            this.button_Install.TabIndex = 3;
            this.button_Install.Text = "Установить";
            this.button_Install.Click += new System.EventHandler(this.button_Install_Click);
            // 
            // button_Uninstall
            // 
            this.button_Uninstall.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Uninstall.Location = new System.Drawing.Point(132, 229);
            this.button_Uninstall.Name = "button_Uninstall";
            this.button_Uninstall.Size = new System.Drawing.Size(117, 30);
            this.button_Uninstall.TabIndex = 4;
            this.button_Uninstall.Text = "Удалить";
            this.button_Uninstall.Click += new System.EventHandler(this.button_Uninstall_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 266);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Файлы из Skyrim\\Mods:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(8, 34);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(240, 191);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 212;
            // 
            // FormMods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SkyrimLauncher.Properties.Resources.FormBackgroundNone;
            this.CancelButton = this.button_Close;
            this.ClientSize = new System.Drawing.Size(256, 266);
            this.ControlBox = false;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Install);
            this.Controls.Add(this.button_Uninstall);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMods";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }
    }
}