namespace PoolWizard
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.cartera = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.Label();
            this.infoWorking = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // cartera
            // 
            this.cartera.AutoSize = true;
            this.cartera.BackColor = System.Drawing.Color.Transparent;
            this.cartera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartera.Location = new System.Drawing.Point(44, 111);
            this.cartera.Name = "cartera";
            this.cartera.Size = new System.Drawing.Size(44, 20);
            this.cartera.TabIndex = 0;
            this.cartera.Text = "text1";
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.BackColor = System.Drawing.Color.Transparent;
            this.usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario.Location = new System.Drawing.Point(44, 241);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(44, 20);
            this.usuario.TabIndex = 1;
            this.usuario.Text = "text2";
            // 
            // infoWorking
            // 
            this.infoWorking.AutoSize = true;
            this.infoWorking.BackColor = System.Drawing.Color.Transparent;
            this.infoWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoWorking.ForeColor = System.Drawing.Color.Red;
            this.infoWorking.Location = new System.Drawing.Point(42, 39);
            this.infoWorking.Name = "infoWorking";
            this.infoWorking.Size = new System.Drawing.Size(72, 31);
            this.infoWorking.TabIndex = 2;
            this.infoWorking.Text = "OFF";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnInfo
            // 
            this.btnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.Location = new System.Drawing.Point(75, 290);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(100, 50);
            this.btnInfo.TabIndex = 3;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(225, 290);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 50);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Cambiar datos";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Money4Free";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PoolWizard.Properties.Resources.BackgroundImage;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.infoWorking);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.cartera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Money4Free";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label cartera;
        private System.Windows.Forms.Label usuario;
        private System.Windows.Forms.Label infoWorking;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}