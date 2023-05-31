namespace SerialPort_ReadAddress
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_PortName = new System.Windows.Forms.ComboBox();
            this.Text_StopBits = new System.Windows.Forms.ComboBox();
            this.Text_DataBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Text_Parity = new System.Windows.Forms.ComboBox();
            this.Text_BaudRate = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Text_ReadAddress = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox2.Location = new System.Drawing.Point(323, 34);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(465, 307);
            this.textBox2.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "COM口：";
            // 
            // Text_PortName
            // 
            this.Text_PortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Text_PortName.FormattingEnabled = true;
            this.Text_PortName.Location = new System.Drawing.Point(137, 34);
            this.Text_PortName.Name = "Text_PortName";
            this.Text_PortName.Size = new System.Drawing.Size(121, 20);
            this.Text_PortName.TabIndex = 38;
            // 
            // Text_StopBits
            // 
            this.Text_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Text_StopBits.FormattingEnabled = true;
            this.Text_StopBits.Location = new System.Drawing.Point(137, 155);
            this.Text_StopBits.Name = "Text_StopBits";
            this.Text_StopBits.Size = new System.Drawing.Size(121, 20);
            this.Text_StopBits.TabIndex = 36;
            // 
            // Text_DataBits
            // 
            this.Text_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Text_DataBits.FormattingEnabled = true;
            this.Text_DataBits.Location = new System.Drawing.Point(137, 125);
            this.Text_DataBits.Name = "Text_DataBits";
            this.Text_DataBits.Size = new System.Drawing.Size(121, 20);
            this.Text_DataBits.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "数据位：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "校验位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "波特率：";
            // 
            // Text_Parity
            // 
            this.Text_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Text_Parity.FormattingEnabled = true;
            this.Text_Parity.Location = new System.Drawing.Point(137, 94);
            this.Text_Parity.Name = "Text_Parity";
            this.Text_Parity.Size = new System.Drawing.Size(121, 20);
            this.Text_Parity.TabIndex = 31;
            // 
            // Text_BaudRate
            // 
            this.Text_BaudRate.Location = new System.Drawing.Point(137, 64);
            this.Text_BaudRate.Name = "Text_BaudRate";
            this.Text_BaudRate.Size = new System.Drawing.Size(121, 21);
            this.Text_BaudRate.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 45);
            this.button1.TabIndex = 42;
            this.button1.Text = "读取地址";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "读地址：";
            // 
            // Text_ReadAddress
            // 
            this.Text_ReadAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Text_ReadAddress.FormattingEnabled = true;
            this.Text_ReadAddress.Location = new System.Drawing.Point(137, 183);
            this.Text_ReadAddress.Name = "Text_ReadAddress";
            this.Text_ReadAddress.Size = new System.Drawing.Size(121, 20);
            this.Text_ReadAddress.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 45;
            this.label7.Text = "任务数量：0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 47;
            this.label5.Text = "停止位：";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "当前任务列表";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "完成任务列表";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 371);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Text_ReadAddress);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Text_PortName);
            this.Controls.Add(this.Text_StopBits);
            this.Controls.Add(this.Text_DataBits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Text_Parity);
            this.Controls.Add(this.Text_BaudRate);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Text_PortName;
        private System.Windows.Forms.ComboBox Text_StopBits;
        private System.Windows.Forms.ComboBox Text_DataBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Text_Parity;
        private System.Windows.Forms.TextBox Text_BaudRate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Text_ReadAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

