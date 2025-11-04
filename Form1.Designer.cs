using ScintillaNet.WinForms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            txtArgs = new TextBox();
            label3 = new Label();
            txtDesscription = new TextBox();
            btnRun = new Button();
            btnNew = new Button();
            btnUpdateCode = new Button();
            comboBoxPythonPaths = new ComboBox();
            panelEditor = new Panel();
            splitContainer1 = new SplitContainer();
            dataGridViewCode = new DataGridView();
            ColumnINDEX = new DataGridViewTextBoxColumn();
            ColumnFileName = new DataGridViewTextBoxColumn();
            ColumnDesc = new DataGridViewTextBoxColumn();
            ColumnPythonCode = new DataGridViewTextBoxColumn();
            ColumnArgs = new DataGridViewTextBoxColumn();
            buttonDelete = new Button();
            buttonImport = new Button();
            label4 = new Label();
            textBoxFilename = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCode).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(8, 397);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Python Path";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(8, 486);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 0;
            label2.Text = "Args";
            // 
            // txtArgs
            // 
            txtArgs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtArgs.Location = new Point(86, 482);
            txtArgs.Name = "txtArgs";
            txtArgs.Size = new Size(421, 23);
            txtArgs.TabIndex = 2;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(8, 422);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 0;
            label3.Text = "Desscription";
            // 
            // txtDesscription
            // 
            txtDesscription.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDesscription.Location = new Point(86, 419);
            txtDesscription.Multiline = true;
            txtDesscription.Name = "txtDesscription";
            txtDesscription.Size = new Size(499, 57);
            txtDesscription.TabIndex = 2;
            // 
            // btnRun
            // 
            btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRun.Location = new Point(513, 481);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(72, 24);
            btnRun.TabIndex = 3;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(74, 3);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(52, 24);
            btnNew.TabIndex = 3;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnUpdateCode
            // 
            btnUpdateCode.Location = new Point(132, 3);
            btnUpdateCode.Name = "btnUpdateCode";
            btnUpdateCode.Size = new Size(78, 24);
            btnUpdateCode.TabIndex = 3;
            btnUpdateCode.Text = "Update";
            btnUpdateCode.UseVisualStyleBackColor = true;
            btnUpdateCode.Click += btnUpdateCode_Click;
            // 
            // comboBoxPythonPaths
            // 
            comboBoxPythonPaths.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxPythonPaths.FormattingEnabled = true;
            comboBoxPythonPaths.Location = new Point(86, 394);
            comboBoxPythonPaths.Name = "comboBoxPythonPaths";
            comboBoxPythonPaths.Size = new Size(499, 23);
            comboBoxPythonPaths.TabIndex = 4;
            // 
            // panelEditor
            // 
            panelEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelEditor.Location = new Point(3, 32);
            panelEditor.Name = "panelEditor";
            panelEditor.Size = new Size(585, 356);
            panelEditor.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(11, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridViewCode);
            splitContainer1.Panel1.Controls.Add(buttonDelete);
            splitContainer1.Panel1.Controls.Add(buttonImport);
            splitContainer1.Panel1.Controls.Add(btnNew);
            splitContainer1.Panel1.Controls.Add(btnUpdateCode);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(btnRun);
            splitContainer1.Panel2.Controls.Add(txtDesscription);
            splitContainer1.Panel2.Controls.Add(comboBoxPythonPaths);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(panelEditor);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(textBoxFilename);
            splitContainer1.Panel2.Controls.Add(txtArgs);
            splitContainer1.Size = new Size(892, 509);
            splitContainer1.SplitterDistance = 297;
            splitContainer1.TabIndex = 5;
            // 
            // dataGridViewCode
            // 
            dataGridViewCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCode.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCode.Columns.AddRange(new DataGridViewColumn[] { ColumnINDEX, ColumnFileName, ColumnDesc, ColumnPythonCode, ColumnArgs });
            dataGridViewCode.Location = new Point(13, 32);
            dataGridViewCode.Name = "dataGridViewCode";
            dataGridViewCode.Size = new Size(275, 469);
            dataGridViewCode.TabIndex = 0;
            dataGridViewCode.RowEnter += dataGridViewCode_RowEnter;
            // 
            // ColumnINDEX
            // 
            ColumnINDEX.HeaderText = "ID";
            ColumnINDEX.Name = "ColumnINDEX";
            // 
            // ColumnFileName
            // 
            ColumnFileName.HeaderText = "FileName";
            ColumnFileName.Name = "ColumnFileName";
            // 
            // ColumnDesc
            // 
            ColumnDesc.HeaderText = "Desc";
            ColumnDesc.Name = "ColumnDesc";
            // 
            // ColumnPythonCode
            // 
            ColumnPythonCode.HeaderText = "PythonCode";
            ColumnPythonCode.Name = "ColumnPythonCode";
            // 
            // ColumnArgs
            // 
            ColumnArgs.HeaderText = "Args";
            ColumnArgs.Name = "ColumnArgs";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(215, 3);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(73, 24);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(13, 3);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(52, 24);
            buttonImport.TabIndex = 3;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 6);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 0;
            label4.Text = "Filename";
            // 
            // textBoxFilename
            // 
            textBoxFilename.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxFilename.Location = new Point(69, 3);
            textBoxFilename.Name = "textBoxFilename";
            textBoxFilename.Size = new Size(519, 23);
            textBoxFilename.TabIndex = 2;
            // 
            // Form1
            // 
            ClientSize = new Size(915, 533);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Python Run";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCode).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Scintilla txtCode;
        private Label label2;
        private TextBox txtArgs;
        private Label label3;
        private TextBox txtDesscription;
        private Button btnRun;
        private Button btnNew;
        private Button btnUpdateCode;
        private ComboBox comboBoxPythonPaths;
        private Panel panelEditor;
        private SplitContainer splitContainer1;
        private Label label4;
        private TextBox textBoxFilename;
        private DataGridView dataGridViewCode;
        private DataGridViewTextBoxColumn ColumnINDEX;
        private DataGridViewTextBoxColumn ColumnFileName;
        private DataGridViewTextBoxColumn ColumnDesc;
        private DataGridViewTextBoxColumn ColumnPythonCode;
        private DataGridViewTextBoxColumn ColumnArgs;
        private Button buttonDelete;
        private Button buttonImport;
    }
}
