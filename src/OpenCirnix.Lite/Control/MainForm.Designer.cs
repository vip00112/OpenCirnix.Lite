
namespace OpenCirnix.Lite
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.numericUpDown_delay = new System.Windows.Forms.NumericUpDown();
            this.button_gameDelay = new System.Windows.Forms.Button();
            this.button_autoRG = new System.Windows.Forms.Button();
            this.button_memory = new System.Windows.Forms.Button();
            this.button_speedStarter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delay)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Location = new System.Drawing.Point(12, 12);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.ReadOnly = true;
            this.richTextBox_log.Size = new System.Drawing.Size(250, 137);
            this.richTextBox_log.TabIndex = 0;
            this.richTextBox_log.TabStop = false;
            this.richTextBox_log.Text = "";
            // 
            // numericUpDown_delay
            // 
            this.numericUpDown_delay.Location = new System.Drawing.Point(268, 12);
            this.numericUpDown_delay.Maximum = new decimal(new int[] {
            550,
            0,
            0,
            0});
            this.numericUpDown_delay.Name = "numericUpDown_delay";
            this.numericUpDown_delay.Size = new System.Drawing.Size(100, 21);
            this.numericUpDown_delay.TabIndex = 0;
            this.numericUpDown_delay.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // button_gameDelay
            // 
            this.button_gameDelay.Location = new System.Drawing.Point(268, 39);
            this.button_gameDelay.Name = "button_gameDelay";
            this.button_gameDelay.Size = new System.Drawing.Size(100, 23);
            this.button_gameDelay.TabIndex = 1;
            this.button_gameDelay.Text = "GameDelay";
            this.button_gameDelay.UseVisualStyleBackColor = true;
            this.button_gameDelay.Click += new System.EventHandler(this.button_gameDelay_Click);
            // 
            // button_autoRG
            // 
            this.button_autoRG.Location = new System.Drawing.Point(268, 68);
            this.button_autoRG.Name = "button_autoRG";
            this.button_autoRG.Size = new System.Drawing.Size(100, 23);
            this.button_autoRG.TabIndex = 2;
            this.button_autoRG.Text = "AutoRG";
            this.button_autoRG.UseVisualStyleBackColor = true;
            this.button_autoRG.Click += new System.EventHandler(this.button_autoRG_Click);
            // 
            // button_memory
            // 
            this.button_memory.Location = new System.Drawing.Point(268, 126);
            this.button_memory.Name = "button_memory";
            this.button_memory.Size = new System.Drawing.Size(100, 23);
            this.button_memory.TabIndex = 4;
            this.button_memory.Text = "Memory";
            this.button_memory.UseVisualStyleBackColor = true;
            this.button_memory.Click += new System.EventHandler(this.button_memory_Click);
            // 
            // button_speedStarter
            // 
            this.button_speedStarter.Location = new System.Drawing.Point(268, 97);
            this.button_speedStarter.Name = "button_speedStarter";
            this.button_speedStarter.Size = new System.Drawing.Size(100, 23);
            this.button_speedStarter.TabIndex = 3;
            this.button_speedStarter.Text = "SpeedStarter";
            this.button_speedStarter.UseVisualStyleBackColor = true;
            this.button_speedStarter.Click += new System.EventHandler(this.button_speedStarter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "GameDelay";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(10, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "AutoRG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(10, 201);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "SpeedStarter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(10, 223);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "MemoryOptimize";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(136, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "= !dr 0 ~ 550";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 179);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "= !rg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 201);
            this.label7.Margin = new System.Windows.Forms.Padding(5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "= !ss";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 223);
            this.label8.Margin = new System.Windows.Forms.Padding(5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "= !mm";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 246);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_speedStarter);
            this.Controls.Add(this.button_memory);
            this.Controls.Add(this.button_autoRG);
            this.Controls.Add(this.button_gameDelay);
            this.Controls.Add(this.numericUpDown_delay);
            this.Controls.Add(this.richTextBox_log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenCirnix.Lite";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_log;
        private System.Windows.Forms.NumericUpDown numericUpDown_delay;
        private System.Windows.Forms.Button button_gameDelay;
        private System.Windows.Forms.Button button_autoRG;
        private System.Windows.Forms.Button button_memory;
        private System.Windows.Forms.Button button_speedStarter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

