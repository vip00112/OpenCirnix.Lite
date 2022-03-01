
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
            this.textBox_press1 = new System.Windows.Forms.TextBox();
            this.textBox_mapping1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_press2 = new System.Windows.Forms.TextBox();
            this.textBox_mapping2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_press3 = new System.Windows.Forms.TextBox();
            this.textBox_mapping3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_press4 = new System.Windows.Forms.TextBox();
            this.textBox_mapping4 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_press5 = new System.Windows.Forms.TextBox();
            this.textBox_mapping5 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_press6 = new System.Windows.Forms.TextBox();
            this.textBox_mapping6 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_press7 = new System.Windows.Forms.TextBox();
            this.textBox_mapping7 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox_press8 = new System.Windows.Forms.TextBox();
            this.textBox_mapping8 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox_press9 = new System.Windows.Forms.TextBox();
            this.textBox_mapping9 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.textBox_press10 = new System.Windows.Forms.TextBox();
            this.textBox_mapping10 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox_mapping = new System.Windows.Forms.GroupBox();
            this.button_mappingSetting = new System.Windows.Forms.Button();
            this.button_mappingSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delay)).BeginInit();
            this.groupBox_mapping.SuspendLayout();
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
            this.button_gameDelay.Text = "게임 딜레이";
            this.button_gameDelay.UseVisualStyleBackColor = true;
            this.button_gameDelay.Click += new System.EventHandler(this.button_gameDelay_Click);
            // 
            // button_autoRG
            // 
            this.button_autoRG.Location = new System.Drawing.Point(268, 68);
            this.button_autoRG.Name = "button_autoRG";
            this.button_autoRG.Size = new System.Drawing.Size(100, 23);
            this.button_autoRG.TabIndex = 2;
            this.button_autoRG.Text = "자동 새로고침";
            this.button_autoRG.UseVisualStyleBackColor = true;
            this.button_autoRG.Click += new System.EventHandler(this.button_autoRG_Click);
            // 
            // button_memory
            // 
            this.button_memory.Location = new System.Drawing.Point(268, 126);
            this.button_memory.Name = "button_memory";
            this.button_memory.Size = new System.Drawing.Size(100, 23);
            this.button_memory.TabIndex = 4;
            this.button_memory.Text = "메모리 정리";
            this.button_memory.UseVisualStyleBackColor = true;
            this.button_memory.Click += new System.EventHandler(this.button_memory_Click);
            // 
            // button_speedStarter
            // 
            this.button_speedStarter.Location = new System.Drawing.Point(268, 97);
            this.button_speedStarter.Name = "button_speedStarter";
            this.button_speedStarter.Size = new System.Drawing.Size(100, 23);
            this.button_speedStarter.TabIndex = 3;
            this.button_speedStarter.Text = "빠른 게임시작";
            this.button_speedStarter.UseVisualStyleBackColor = true;
            this.button_speedStarter.Click += new System.EventHandler(this.button_speedStarter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(376, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "게임 딜레이";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(376, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "자동 새로고침";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(376, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "빠른 게임시작";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(376, 131);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "메모리 정리";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "= !dr 0 ~ 550";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(474, 73);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "= !rg";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(474, 102);
            this.label7.Margin = new System.Windows.Forms.Padding(5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "= !ss";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(474, 131);
            this.label8.Margin = new System.Windows.Forms.Padding(5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "= !mm";
            // 
            // textBox_press1
            // 
            this.textBox_press1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press1.Location = new System.Drawing.Point(36, 17);
            this.textBox_press1.Name = "textBox_press1";
            this.textBox_press1.ReadOnly = true;
            this.textBox_press1.Size = new System.Drawing.Size(25, 21);
            this.textBox_press1.TabIndex = 6;
            this.textBox_press1.TabStop = false;
            this.textBox_press1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping1
            // 
            this.textBox_mapping1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping1.Location = new System.Drawing.Point(90, 17);
            this.textBox_mapping1.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_mapping1.Name = "textBox_mapping1";
            this.textBox_mapping1.ReadOnly = true;
            this.textBox_mapping1.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping1.TabIndex = 6;
            this.textBox_mapping1.TabStop = false;
            this.textBox_mapping1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(65, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 21);
            this.label9.TabIndex = 7;
            this.label9.Text = "→";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(9, 17);
            this.label13.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 21);
            this.label13.TabIndex = 8;
            this.label13.Text = "01.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_press2
            // 
            this.textBox_press2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press2.Location = new System.Drawing.Point(36, 44);
            this.textBox_press2.Name = "textBox_press2";
            this.textBox_press2.ReadOnly = true;
            this.textBox_press2.Size = new System.Drawing.Size(25, 21);
            this.textBox_press2.TabIndex = 6;
            this.textBox_press2.TabStop = false;
            this.textBox_press2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping2
            // 
            this.textBox_mapping2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping2.Location = new System.Drawing.Point(90, 44);
            this.textBox_mapping2.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_mapping2.Name = "textBox_mapping2";
            this.textBox_mapping2.ReadOnly = true;
            this.textBox_mapping2.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping2.TabIndex = 6;
            this.textBox_mapping2.TabStop = false;
            this.textBox_mapping2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(65, 44);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 21);
            this.label10.TabIndex = 7;
            this.label10.Text = "→";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(9, 44);
            this.label11.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 21);
            this.label11.TabIndex = 8;
            this.label11.Text = "02.";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_press3
            // 
            this.textBox_press3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press3.Location = new System.Drawing.Point(36, 71);
            this.textBox_press3.Name = "textBox_press3";
            this.textBox_press3.ReadOnly = true;
            this.textBox_press3.Size = new System.Drawing.Size(25, 21);
            this.textBox_press3.TabIndex = 6;
            this.textBox_press3.TabStop = false;
            this.textBox_press3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping3
            // 
            this.textBox_mapping3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping3.Location = new System.Drawing.Point(90, 71);
            this.textBox_mapping3.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_mapping3.Name = "textBox_mapping3";
            this.textBox_mapping3.ReadOnly = true;
            this.textBox_mapping3.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping3.TabIndex = 6;
            this.textBox_mapping3.TabStop = false;
            this.textBox_mapping3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(65, 71);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 21);
            this.label12.TabIndex = 7;
            this.label12.Text = "→";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(9, 71);
            this.label14.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 21);
            this.label14.TabIndex = 8;
            this.label14.Text = "03.";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_press4
            // 
            this.textBox_press4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press4.Location = new System.Drawing.Point(36, 98);
            this.textBox_press4.Name = "textBox_press4";
            this.textBox_press4.ReadOnly = true;
            this.textBox_press4.Size = new System.Drawing.Size(25, 21);
            this.textBox_press4.TabIndex = 6;
            this.textBox_press4.TabStop = false;
            this.textBox_press4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping4
            // 
            this.textBox_mapping4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping4.Location = new System.Drawing.Point(90, 98);
            this.textBox_mapping4.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_mapping4.Name = "textBox_mapping4";
            this.textBox_mapping4.ReadOnly = true;
            this.textBox_mapping4.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping4.TabIndex = 6;
            this.textBox_mapping4.TabStop = false;
            this.textBox_mapping4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(65, 98);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 21);
            this.label15.TabIndex = 7;
            this.label15.Text = "→";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(9, 98);
            this.label16.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 21);
            this.label16.TabIndex = 8;
            this.label16.Text = "04.";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_press5
            // 
            this.textBox_press5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press5.Location = new System.Drawing.Point(36, 125);
            this.textBox_press5.Name = "textBox_press5";
            this.textBox_press5.ReadOnly = true;
            this.textBox_press5.Size = new System.Drawing.Size(25, 21);
            this.textBox_press5.TabIndex = 6;
            this.textBox_press5.TabStop = false;
            this.textBox_press5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping5
            // 
            this.textBox_mapping5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping5.Location = new System.Drawing.Point(90, 125);
            this.textBox_mapping5.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.textBox_mapping5.Name = "textBox_mapping5";
            this.textBox_mapping5.ReadOnly = true;
            this.textBox_mapping5.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping5.TabIndex = 6;
            this.textBox_mapping5.TabStop = false;
            this.textBox_mapping5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(65, 125);
            this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(21, 21);
            this.label17.TabIndex = 7;
            this.label17.Text = "→";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(9, 125);
            this.label18.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 21);
            this.label18.TabIndex = 8;
            this.label18.Text = "05.";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_press6
            // 
            this.textBox_press6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press6.Location = new System.Drawing.Point(159, 17);
            this.textBox_press6.Name = "textBox_press6";
            this.textBox_press6.ReadOnly = true;
            this.textBox_press6.Size = new System.Drawing.Size(25, 21);
            this.textBox_press6.TabIndex = 6;
            this.textBox_press6.TabStop = false;
            this.textBox_press6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping6
            // 
            this.textBox_mapping6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping6.Location = new System.Drawing.Point(213, 17);
            this.textBox_mapping6.Name = "textBox_mapping6";
            this.textBox_mapping6.ReadOnly = true;
            this.textBox_mapping6.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping6.TabIndex = 6;
            this.textBox_mapping6.TabStop = false;
            this.textBox_mapping6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.Location = new System.Drawing.Point(188, 17);
            this.label19.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(21, 21);
            this.label19.TabIndex = 7;
            this.label19.Text = "→";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(132, 17);
            this.label20.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 21);
            this.label20.TabIndex = 8;
            this.label20.Text = "06.";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_press7
            // 
            this.textBox_press7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press7.Location = new System.Drawing.Point(159, 44);
            this.textBox_press7.Name = "textBox_press7";
            this.textBox_press7.ReadOnly = true;
            this.textBox_press7.Size = new System.Drawing.Size(25, 21);
            this.textBox_press7.TabIndex = 6;
            this.textBox_press7.TabStop = false;
            this.textBox_press7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping7
            // 
            this.textBox_mapping7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping7.Location = new System.Drawing.Point(213, 44);
            this.textBox_mapping7.Name = "textBox_mapping7";
            this.textBox_mapping7.ReadOnly = true;
            this.textBox_mapping7.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping7.TabIndex = 6;
            this.textBox_mapping7.TabStop = false;
            this.textBox_mapping7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(188, 44);
            this.label21.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(21, 21);
            this.label21.TabIndex = 7;
            this.label21.Text = "→";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(132, 44);
            this.label22.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(21, 21);
            this.label22.TabIndex = 8;
            this.label22.Text = "07.";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_press8
            // 
            this.textBox_press8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press8.Location = new System.Drawing.Point(159, 71);
            this.textBox_press8.Name = "textBox_press8";
            this.textBox_press8.ReadOnly = true;
            this.textBox_press8.Size = new System.Drawing.Size(25, 21);
            this.textBox_press8.TabIndex = 6;
            this.textBox_press8.TabStop = false;
            this.textBox_press8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping8
            // 
            this.textBox_mapping8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping8.Location = new System.Drawing.Point(213, 71);
            this.textBox_mapping8.Name = "textBox_mapping8";
            this.textBox_mapping8.ReadOnly = true;
            this.textBox_mapping8.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping8.TabIndex = 6;
            this.textBox_mapping8.TabStop = false;
            this.textBox_mapping8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.Location = new System.Drawing.Point(188, 71);
            this.label23.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(21, 21);
            this.label23.TabIndex = 7;
            this.label23.Text = "→";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(132, 71);
            this.label24.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(21, 21);
            this.label24.TabIndex = 8;
            this.label24.Text = "08.";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_press9
            // 
            this.textBox_press9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press9.Location = new System.Drawing.Point(159, 98);
            this.textBox_press9.Name = "textBox_press9";
            this.textBox_press9.ReadOnly = true;
            this.textBox_press9.Size = new System.Drawing.Size(25, 21);
            this.textBox_press9.TabIndex = 6;
            this.textBox_press9.TabStop = false;
            this.textBox_press9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping9
            // 
            this.textBox_mapping9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping9.Location = new System.Drawing.Point(213, 98);
            this.textBox_mapping9.Name = "textBox_mapping9";
            this.textBox_mapping9.ReadOnly = true;
            this.textBox_mapping9.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping9.TabIndex = 6;
            this.textBox_mapping9.TabStop = false;
            this.textBox_mapping9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.Location = new System.Drawing.Point(188, 98);
            this.label25.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(21, 21);
            this.label25.TabIndex = 7;
            this.label25.Text = "→";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(132, 98);
            this.label26.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(21, 21);
            this.label26.TabIndex = 8;
            this.label26.Text = "09.";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_press10
            // 
            this.textBox_press10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_press10.Location = new System.Drawing.Point(159, 125);
            this.textBox_press10.Name = "textBox_press10";
            this.textBox_press10.ReadOnly = true;
            this.textBox_press10.Size = new System.Drawing.Size(25, 21);
            this.textBox_press10.TabIndex = 6;
            this.textBox_press10.TabStop = false;
            this.textBox_press10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_press10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_press_KeyDown);
            // 
            // textBox_mapping10
            // 
            this.textBox_mapping10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox_mapping10.Location = new System.Drawing.Point(213, 125);
            this.textBox_mapping10.Name = "textBox_mapping10";
            this.textBox_mapping10.ReadOnly = true;
            this.textBox_mapping10.Size = new System.Drawing.Size(25, 21);
            this.textBox_mapping10.TabIndex = 6;
            this.textBox_mapping10.TabStop = false;
            this.textBox_mapping10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_mapping10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_mapping_KeyDown);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.Location = new System.Drawing.Point(188, 125);
            this.label27.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(21, 21);
            this.label27.TabIndex = 7;
            this.label27.Text = "→";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(132, 125);
            this.label28.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(21, 21);
            this.label28.TabIndex = 8;
            this.label28.Text = "10.";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label29.Location = new System.Drawing.Point(376, 165);
            this.label29.Margin = new System.Windows.Forms.Padding(5);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(49, 12);
            this.label29.TabIndex = 4;
            this.label29.Text = "키 맵핑";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(376, 187);
            this.label30.Margin = new System.Windows.Forms.Padding(5);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(207, 124);
            this.label30.TabIndex = 4;
            this.label30.Text = "1. 키 맵핑 편집 클릭\r\n\r\n2. 좌측 네모에 입력 키 설정\r\n\r\n3. 우측 네모에 맵핑 키 설정\r\n\r\n4. 키 맵핑 적용 클릭\r\n\r\n※ ESC" +
    " 키 입력 시 설정 초기화 됨";
            // 
            // groupBox_mapping
            // 
            this.groupBox_mapping.Controls.Add(this.textBox_mapping6);
            this.groupBox_mapping.Controls.Add(this.label28);
            this.groupBox_mapping.Controls.Add(this.textBox_press1);
            this.groupBox_mapping.Controls.Add(this.label26);
            this.groupBox_mapping.Controls.Add(this.textBox_mapping1);
            this.groupBox_mapping.Controls.Add(this.label24);
            this.groupBox_mapping.Controls.Add(this.textBox_press2);
            this.groupBox_mapping.Controls.Add(this.label22);
            this.groupBox_mapping.Controls.Add(this.textBox_mapping2);
            this.groupBox_mapping.Controls.Add(this.label20);
            this.groupBox_mapping.Controls.Add(this.textBox_press3);
            this.groupBox_mapping.Controls.Add(this.label18);
            this.groupBox_mapping.Controls.Add(this.textBox_mapping3);
            this.groupBox_mapping.Controls.Add(this.label16);
            this.groupBox_mapping.Controls.Add(this.textBox_press4);
            this.groupBox_mapping.Controls.Add(this.label14);
            this.groupBox_mapping.Controls.Add(this.textBox_mapping4);
            this.groupBox_mapping.Controls.Add(this.label11);
            this.groupBox_mapping.Controls.Add(this.textBox_press5);
            this.groupBox_mapping.Controls.Add(this.label13);
            this.groupBox_mapping.Controls.Add(this.textBox_mapping5);
            this.groupBox_mapping.Controls.Add(this.label27);
            this.groupBox_mapping.Controls.Add(this.textBox_press6);
            this.groupBox_mapping.Controls.Add(this.label25);
            this.groupBox_mapping.Controls.Add(this.textBox_press7);
            this.groupBox_mapping.Controls.Add(this.label23);
            this.groupBox_mapping.Controls.Add(this.textBox_mapping7);
            this.groupBox_mapping.Controls.Add(this.label21);
            this.groupBox_mapping.Controls.Add(this.textBox_press8);
            this.groupBox_mapping.Controls.Add(this.label19);
            this.groupBox_mapping.Controls.Add(this.textBox_mapping8);
            this.groupBox_mapping.Controls.Add(this.label17);
            this.groupBox_mapping.Controls.Add(this.textBox_press9);
            this.groupBox_mapping.Controls.Add(this.label15);
            this.groupBox_mapping.Controls.Add(this.textBox_mapping9);
            this.groupBox_mapping.Controls.Add(this.label12);
            this.groupBox_mapping.Controls.Add(this.textBox_press10);
            this.groupBox_mapping.Controls.Add(this.label10);
            this.groupBox_mapping.Controls.Add(this.textBox_mapping10);
            this.groupBox_mapping.Controls.Add(this.label9);
            this.groupBox_mapping.Enabled = false;
            this.groupBox_mapping.Location = new System.Drawing.Point(12, 155);
            this.groupBox_mapping.Name = "groupBox_mapping";
            this.groupBox_mapping.Size = new System.Drawing.Size(250, 156);
            this.groupBox_mapping.TabIndex = 0;
            this.groupBox_mapping.TabStop = false;
            this.groupBox_mapping.Text = "키 맵핑";
            // 
            // button_mappingSetting
            // 
            this.button_mappingSetting.Location = new System.Drawing.Point(268, 160);
            this.button_mappingSetting.Name = "button_mappingSetting";
            this.button_mappingSetting.Size = new System.Drawing.Size(100, 23);
            this.button_mappingSetting.TabIndex = 5;
            this.button_mappingSetting.Text = "키 맵핑 편집";
            this.button_mappingSetting.UseVisualStyleBackColor = true;
            this.button_mappingSetting.Click += new System.EventHandler(this.button_mappingSetting_Click);
            // 
            // button_mappingSave
            // 
            this.button_mappingSave.Enabled = false;
            this.button_mappingSave.Location = new System.Drawing.Point(268, 189);
            this.button_mappingSave.Name = "button_mappingSave";
            this.button_mappingSave.Size = new System.Drawing.Size(100, 23);
            this.button_mappingSave.TabIndex = 6;
            this.button_mappingSave.Text = "키 맵핑 적용";
            this.button_mappingSave.UseVisualStyleBackColor = true;
            this.button_mappingSave.Click += new System.EventHandler(this.button_mappingSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 318);
            this.Controls.Add(this.groupBox_mapping);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_speedStarter);
            this.Controls.Add(this.button_mappingSave);
            this.Controls.Add(this.button_mappingSetting);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_delay)).EndInit();
            this.groupBox_mapping.ResumeLayout(false);
            this.groupBox_mapping.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox_press1;
        private System.Windows.Forms.TextBox textBox_mapping1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_press2;
        private System.Windows.Forms.TextBox textBox_mapping2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_press3;
        private System.Windows.Forms.TextBox textBox_mapping3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_press4;
        private System.Windows.Forms.TextBox textBox_mapping4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_press5;
        private System.Windows.Forms.TextBox textBox_mapping5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_press6;
        private System.Windows.Forms.TextBox textBox_mapping6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox_press7;
        private System.Windows.Forms.TextBox textBox_mapping7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox_press8;
        private System.Windows.Forms.TextBox textBox_mapping8;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox_press9;
        private System.Windows.Forms.TextBox textBox_mapping9;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBox_press10;
        private System.Windows.Forms.TextBox textBox_mapping10;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.GroupBox groupBox_mapping;
        private System.Windows.Forms.Button button_mappingSetting;
        private System.Windows.Forms.Button button_mappingSave;
    }
}

