namespace PoolWizard
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.InfoUP = new System.Windows.Forms.Label();
            this.WalletLabel = new System.Windows.Forms.Label();
            this.textBoxWallet = new System.Windows.Forms.TextBox();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.UsuarioLabel = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InfoUP
            // 
            this.InfoUP.AutoSize = true;
            this.InfoUP.BackColor = System.Drawing.Color.Transparent;
            this.InfoUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoUP.Location = new System.Drawing.Point(25, 102);
            this.InfoUP.Name = "InfoUP";
            this.InfoUP.Size = new System.Drawing.Size(286, 20);
            this.InfoUP.TabIndex = 0;
            this.InfoUP.Text = "Por favor, rellene las casillas y confirme:";
            this.InfoUP.Click += new System.EventHandler(this.InfoUP_Click);
            // 
            // WalletLabel
            // 
            this.WalletLabel.AutoSize = true;
            this.WalletLabel.BackColor = System.Drawing.Color.Transparent;
            this.WalletLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WalletLabel.Location = new System.Drawing.Point(25, 162);
            this.WalletLabel.Name = "WalletLabel";
            this.WalletLabel.Size = new System.Drawing.Size(145, 20);
            this.WalletLabel.TabIndex = 1;
            this.WalletLabel.Text = "Cartera MONERO: ";
            // 
            // textBoxWallet
            // 
            this.textBoxWallet.Location = new System.Drawing.Point(189, 164);
            this.textBoxWallet.Name = "textBoxWallet";
            this.textBoxWallet.Size = new System.Drawing.Size(159, 20);
            this.textBoxWallet.TabIndex = 2;
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(189, 215);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(159, 20);
            this.textBoxUsuario.TabIndex = 4;
            // 
            // UsuarioLabel
            // 
            this.UsuarioLabel.AutoSize = true;
            this.UsuarioLabel.BackColor = System.Drawing.Color.Transparent;
            this.UsuarioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioLabel.Location = new System.Drawing.Point(25, 215);
            this.UsuarioLabel.Name = "UsuarioLabel";
            this.UsuarioLabel.Size = new System.Drawing.Size(135, 20);
            this.UsuarioLabel.TabIndex = 3;
            this.UsuarioLabel.Text = "Usuario (EMAIL): ";
            // 
            // btnInfo
            // 
            this.btnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.Location = new System.Drawing.Point(75, 290);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(100, 50);
            this.btnInfo.TabIndex = 5;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(225, 290);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 50);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "PoolWizardX";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.UsuarioLabel);
            this.Controls.Add(this.textBoxWallet);
            this.Controls.Add(this.WalletLabel);
            this.Controls.Add(this.InfoUP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Money4Free";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PoolWizardX_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label InfoUP;
        private System.Windows.Forms.Label WalletLabel;
        private System.Windows.Forms.TextBox textBoxWallet;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.Label UsuarioLabel;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
    }
}

