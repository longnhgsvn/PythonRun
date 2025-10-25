using ScintillaNet.Abstractions.Enumerations;
using ScintillaNet.WinForms.Collections;
using System.Diagnostics;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System;

using System.IO;
using System.Windows.Forms;


namespace PythonRun
{
    public partial class Form1 : Form
    {
        private readonly string currentFile = @"script.py"; // IDE0044: Make field readonly fix applied
        private string pythonPath; // CS0236 fix: Moved initialization to constructor

        public Form1()
        {
            InitializeComponent();

            SetupEditor();

            // Initialize pythonPath after comboBoxPythonPaths is available
            pythonPath = comboBoxPythonPaths.Text;
        }

        private void SetupEditor()
        {
            /*   
            txtCode.Lexer = Lexer.Python;
                txtCode.StyleResetDefault();
                txtCode.Styles[Style.Python.Default].ForeColor = System.Drawing.Color.White;
                txtCode.Styles[Style.Python.CommentLine].ForeColor = System.Drawing.Color.LightGreen;
                txtCode.Styles[Style.Python.Number].ForeColor = System.Drawing.Color.Cyan;
                txtCode.Styles[Style.Python.String].ForeColor = System.Drawing.Color.SandyBrown;
                txtCode.Styles[Style.Python.Keyword].ForeColor = System.Drawing.Color.DeepSkyBlue;
                txtCode.StyleClearAll();
                txtCode.WrapMode = WrapMode.Word;
                txtCode.Margins[0].Width = 30;
            */
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(currentFile, txtCode.Text);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentFile))
                txtCode.Text = File.ReadAllText(currentFile);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e); // Lưu trước khi chạy
            pythonPath = comboBoxPythonPaths.Text;
            var psi = new ProcessStartInfo();
            psi.FileName = pythonPath;
            psi.Arguments = $"{currentFile} {txtArgs.Text}";
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;

            var process = Process.Start(psi);
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            txtOutput.Text = output + Environment.NewLine + error;
        }

        // tim duong dan python

        public static List<string> GetPythonPaths()
        {
            var results = new List<string>();

            try
            {
                var psi = new ProcessStartInfo()
                {
                    FileName = "where.exe",
                    Arguments = "python",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(psi);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                foreach (var line in output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                        results.Add(line.Trim());
                }
            }
            catch
            {
                // Không làm gì -> trả về list rỗng
            }

            return results;
        }

        List<string> pythonPaths = GetPythonPaths();

        private void Form1_Load(object sender, EventArgs e)
        {
            var pythonPaths = GetPythonPaths();
            comboBoxPythonPaths.Items.AddRange(pythonPaths.ToArray());

            if (pythonPaths.Count > 0)
            {
                comboBoxPythonPaths.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Không tìm thấy Python trong hệ thống!");
            }


        }
    }


}

