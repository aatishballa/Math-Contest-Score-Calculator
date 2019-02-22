namespace Geo
{
    partial class Form1
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
            this.Btn_display_tbl = new System.Windows.Forms.Button();
            this.Btn_ex_individual = new System.Windows.Forms.Button();
            this.Btn_exp_group = new System.Windows.Forms.Button();
            this.Btn_import = new System.Windows.Forms.Button();
            this.txt_school_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_exp_all_team = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_display_tbl
            // 
            this.Btn_display_tbl.Location = new System.Drawing.Point(68, 391);
            this.Btn_display_tbl.Name = "Btn_display_tbl";
            this.Btn_display_tbl.Size = new System.Drawing.Size(110, 34);
            this.Btn_display_tbl.TabIndex = 1;
            this.Btn_display_tbl.Text = "Display results";
            this.Btn_display_tbl.UseVisualStyleBackColor = true;
            this.Btn_display_tbl.Click += new System.EventHandler(this.Btn_display_tbl_Click);
            // 
            // Btn_ex_individual
            // 
            this.Btn_ex_individual.Location = new System.Drawing.Point(203, 415);
            this.Btn_ex_individual.Name = "Btn_ex_individual";
            this.Btn_ex_individual.Size = new System.Drawing.Size(98, 50);
            this.Btn_ex_individual.TabIndex = 2;
            this.Btn_ex_individual.Text = "Export ALL individual report";
            this.Btn_ex_individual.UseVisualStyleBackColor = true;
            this.Btn_ex_individual.Click += new System.EventHandler(this.Btn_ex_individual_Click);
            // 
            // Btn_exp_group
            // 
            this.Btn_exp_group.Location = new System.Drawing.Point(27, 58);
            this.Btn_exp_group.Name = "Btn_exp_group";
            this.Btn_exp_group.Size = new System.Drawing.Size(85, 43);
            this.Btn_exp_group.TabIndex = 3;
            this.Btn_exp_group.Text = "Export group report ";
            this.Btn_exp_group.UseVisualStyleBackColor = true;
            this.Btn_exp_group.Click += new System.EventHandler(this.Btn_exp_group_Click);
            // 
            // Btn_import
            // 
            this.Btn_import.Location = new System.Drawing.Point(68, 351);
            this.Btn_import.Name = "Btn_import";
            this.Btn_import.Size = new System.Drawing.Size(110, 34);
            this.Btn_import.TabIndex = 4;
            this.Btn_import.Text = "Calculate Scores";
            this.Btn_import.UseVisualStyleBackColor = true;
            this.Btn_import.Click += new System.EventHandler(this.Btn_import_Click);
            // 
            // txt_school_id
            // 
            this.txt_school_id.Location = new System.Drawing.Point(12, 32);
            this.txt_school_id.Name = "txt_school_id";
            this.txt_school_id.Size = new System.Drawing.Size(112, 20);
            this.txt_school_id.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter School ID : ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Btn_exp_group);
            this.panel1.Controls.Add(this.txt_school_id);
            this.panel1.Location = new System.Drawing.Point(321, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 114);
            this.panel1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(456, 302);
            this.dataGridView1.TabIndex = 8;
            // 
            // btn_exp_all_team
            // 
            this.btn_exp_all_team.Location = new System.Drawing.Point(203, 352);
            this.btn_exp_all_team.Name = "btn_exp_all_team";
            this.btn_exp_all_team.Size = new System.Drawing.Size(98, 52);
            this.btn_exp_all_team.TabIndex = 9;
            this.btn_exp_all_team.Text = "Export ALL team report";
            this.btn_exp_all_team.UseVisualStyleBackColor = true;
            this.btn_exp_all_team.Click += new System.EventHandler(this.btn_exp_all_team_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 493);
            this.Controls.Add(this.btn_exp_all_team);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Btn_import);
            this.Controls.Add(this.Btn_ex_individual);
            this.Controls.Add(this.Btn_display_tbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_display_tbl;
        private System.Windows.Forms.Button Btn_ex_individual;
        private System.Windows.Forms.Button Btn_exp_group;
        private System.Windows.Forms.Button Btn_import;
        private System.Windows.Forms.TextBox txt_school_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_exp_all_team;
    }
}

