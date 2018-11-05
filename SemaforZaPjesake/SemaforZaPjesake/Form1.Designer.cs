namespace SemaforZaPjesake
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
            this.components = new System.ComponentModel.Container();
            this.pb_Scene = new System.Windows.Forms.PictureBox();
            this.btnStartScene = new System.Windows.Forms.Button();
            this.timerForAll = new System.Windows.Forms.Timer(this.components);
            this.btn_TurnONPedGreen = new System.Windows.Forms.Button();
            this.lb_PedWait = new System.Windows.Forms.Label();
            this.timerStopage = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Scene)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Scene
            // 
            this.pb_Scene.BackColor = System.Drawing.Color.White;
            this.pb_Scene.Location = new System.Drawing.Point(67, 24);
            this.pb_Scene.Name = "pb_Scene";
            this.pb_Scene.Size = new System.Drawing.Size(1044, 537);
            this.pb_Scene.TabIndex = 0;
            this.pb_Scene.TabStop = false;
            // 
            // btnStartScene
            // 
            this.btnStartScene.Location = new System.Drawing.Point(1140, 24);
            this.btnStartScene.Name = "btnStartScene";
            this.btnStartScene.Size = new System.Drawing.Size(128, 59);
            this.btnStartScene.TabIndex = 1;
            this.btnStartScene.Text = "Turn ON traffic lights";
            this.btnStartScene.UseVisualStyleBackColor = true;
            this.btnStartScene.Click += new System.EventHandler(this.btnStartScene_Click);
            // 
            // timerForAll
            // 
            this.timerForAll.Interval = 1000;
            this.timerForAll.Tick += new System.EventHandler(this.timerForAll_Tick);
            // 
            // btn_TurnONPedGreen
            // 
            this.btn_TurnONPedGreen.Location = new System.Drawing.Point(1140, 89);
            this.btn_TurnONPedGreen.Name = "btn_TurnONPedGreen";
            this.btn_TurnONPedGreen.Size = new System.Drawing.Size(128, 70);
            this.btn_TurnONPedGreen.TabIndex = 2;
            this.btn_TurnONPedGreen.Text = "Turn ON pedestrian green light";
            this.btn_TurnONPedGreen.UseVisualStyleBackColor = true;
            this.btn_TurnONPedGreen.Click += new System.EventHandler(this.btn_TurnONPedGreen_Click);
            // 
            // lb_PedWait
            // 
            this.lb_PedWait.AutoSize = true;
            this.lb_PedWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_PedWait.ForeColor = System.Drawing.Color.Red;
            this.lb_PedWait.Location = new System.Drawing.Point(1202, 183);
            this.lb_PedWait.Name = "lb_PedWait";
            this.lb_PedWait.Size = new System.Drawing.Size(0, 25);
            this.lb_PedWait.TabIndex = 3;
            // 
            // timerStopage
            // 
            this.timerStopage.Interval = 1000;
            this.timerStopage.Tick += new System.EventHandler(this.timerStopage_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 593);
            this.Controls.Add(this.lb_PedWait);
            this.Controls.Add(this.btn_TurnONPedGreen);
            this.Controls.Add(this.btnStartScene);
            this.Controls.Add(this.pb_Scene);
            this.Name = "Form1";
            this.Text = "Semafor za pješake";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Scene)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Scene;
        private System.Windows.Forms.Button btnStartScene;
        private System.Windows.Forms.Timer timerForAll;
        private System.Windows.Forms.Button btn_TurnONPedGreen;
        private System.Windows.Forms.Label lb_PedWait;
        private System.Windows.Forms.Timer timerStopage;
    }
}

