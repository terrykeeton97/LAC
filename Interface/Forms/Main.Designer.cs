using System.Drawing;
using System.Windows.Forms;

namespace LAC.Interface.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.usernameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summonerNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadClickMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editClickMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteClickMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.clickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMenuItem,
            this.loadMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(640, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // addMenuItem
            // 
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(66, 20);
            this.addMenuItem.Text = "Add new";
            this.addMenuItem.Click += new System.EventHandler(this.AddMenuItem_Click);
            // 
            // loadMenuItem
            // 
            this.loadMenuItem.Name = "loadMenuItem";
            this.loadMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadMenuItem.Text = "Load";
            this.loadMenuItem.Click += new System.EventHandler(this.LoadMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usernameColumn,
            this.summonerNameColumn,
            this.serverColumn});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 24);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(640, 284);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView_MouseClick);
            this.dataGridView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView_MouseDoubleClick);
            // 
            // usernameColumn
            // 
            this.usernameColumn.FillWeight = 134.2576F;
            this.usernameColumn.HeaderText = "Username";
            this.usernameColumn.Name = "usernameColumn";
            this.usernameColumn.ReadOnly = true;
            // 
            // summonerNameColumn
            // 
            this.summonerNameColumn.FillWeight = 135.2851F;
            this.summonerNameColumn.HeaderText = "Summoner Name";
            this.summonerNameColumn.Name = "summonerNameColumn";
            this.summonerNameColumn.ReadOnly = true;
            // 
            // serverColumn
            // 
            this.serverColumn.FillWeight = 30.4568F;
            this.serverColumn.HeaderText = "Server";
            this.serverColumn.Name = "serverColumn";
            this.serverColumn.ReadOnly = true;
            // 
            // clickMenu
            // 
            this.clickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadClickMenu,
            this.editClickMenu,
            this.deleteClickMenu});
            this.clickMenu.Name = "contextMenuStrip1";
            this.clickMenu.Size = new System.Drawing.Size(108, 70);
            // 
            // loadClickMenu
            // 
            this.loadClickMenu.Name = "loadClickMenu";
            this.loadClickMenu.Size = new System.Drawing.Size(180, 22);
            this.loadClickMenu.Text = "Load";
            this.loadClickMenu.Click += new System.EventHandler(this.LoadClickMenu_Click);
            // 
            // editClickMenu
            // 
            this.editClickMenu.Name = "editClickMenu";
            this.editClickMenu.Size = new System.Drawing.Size(180, 22);
            this.editClickMenu.Text = "Edit";
            this.editClickMenu.Click += new System.EventHandler(this.EditClickMenu_Click);
            // 
            // deleteClickMenu
            // 
            this.deleteClickMenu.Name = "deleteClickMenu";
            this.deleteClickMenu.Size = new System.Drawing.Size(180, 22);
            this.deleteClickMenu.Text = "Delete";
            this.deleteClickMenu.Click += new System.EventHandler(this.DeleteClickMenu_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 308);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAC";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.clickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private DataGridViewTextBoxColumn usernameColumn;
        private DataGridViewTextBoxColumn summonerNameColumn;
        private DataGridViewTextBoxColumn serverColumn;
        private ContextMenuStrip clickMenu;
        private ToolStripMenuItem loadClickMenu;
        private ToolStripMenuItem editClickMenu;
        private ToolStripMenuItem deleteClickMenu;
    }
}