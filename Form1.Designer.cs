namespace PythonRun
{
    partial class Form1
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
            label1 = new Label();
            txtCode = new TextBox();
            label2 = new Label();
            txtArgs = new TextBox();
            label3 = new Label();
            txtOutput = new TextBox();
            btnRun = new Button();
            btnOpen = new Button();
            btnSave = new Button();
            comboBoxPythonPaths = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 0;
            label1.Text = "Python Code";
            // 
            // txtCode
            // 
            txtCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtCode.Location = new Point(12, 34);
            txtCode.Multiline = true;
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(1004, 405);
            txtCode.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 451);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 0;
            label2.Text = "Arg";
            // 
            // txtArgs
            // 
            txtArgs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtArgs.Location = new Point(90, 448);
            txtArgs.Name = "txtArgs";
            txtArgs.Size = new Size(926, 23);
            txtArgs.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 485);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 0;
            label3.Text = "Out TXT";
            // 
            // txtOutput
            // 
            txtOutput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutput.Location = new Point(90, 481);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(926, 67);
            txtOutput.TabIndex = 2;
            // 
            // btnRun
            // 
            btnRun.Location = new Point(90, 554);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(109, 30);
            btnRun.TabIndex = 3;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(216, 554);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(109, 30);
            btnOpen.TabIndex = 3;
            btnOpen.Text = "Open";
            btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(331, 554);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(109, 30);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // comboBoxPythonPaths
            // 
            comboBoxPythonPaths.FormattingEnabled = true;
            comboBoxPythonPaths.Location = new Point(107, 5);
            comboBoxPythonPaths.Name = "comboBoxPythonPaths";
            comboBoxPythonPaths.Size = new Size(909, 23);
            comboBoxPythonPaths.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 585);
            Controls.Add(comboBoxPythonPaths);
            Controls.Add(btnSave);
            Controls.Add(btnOpen);
            Controls.Add(btnRun);
            Controls.Add(txtOutput);
            Controls.Add(txtArgs);
            Controls.Add(txtCode);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Python Run";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCode;
        private Label label2;
        private TextBox txtArgs;
        private Label label3;
        private TextBox txtOutput;
        private Button btnRun;
        private Button btnOpen;
        private Button btnSave;
        private ComboBox comboBoxPythonPaths;
    }
}
