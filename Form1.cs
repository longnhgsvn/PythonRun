//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program. If not, see <https://www.gnu.org/licenses/>.
//https://github.com/longnhgsvn/PythonRun 

using ScintillaNet.Abstractions.Enumerations;
using ScintillaNet.WinForms;
using ScintillaNet.WinForms.Collections;
using System.Diagnostics;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System;

using System.IO;
using System.Windows.Forms;

// Add the SQLite library (the Microsoft.Data.Sqlite package is included in the project)
using Microsoft.Data.Sqlite;


namespace PythonRun
{
    public partial class Form1 : Form
    {
        private readonly string currentFile = @"script.py"; // IDE0044: Make field readonly fix applied
        private string pythonPath; // CS0236 fix: Moved initialization to constructor

        public Form1()
        {
            InitializeComponent();


            // Initialize txtCode
            // 
            // txtCode Scintilla can be error if crated in designer, so create it in code
            // 
            txtCode = new ScintillaNet.WinForms.Scintilla();
            
            txtCode.Dock = DockStyle.Fill;
            txtCode.Location = new Point(0, 0);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(585, 356);
            txtCode.TabIndex = 0;
            panelEditor.Controls.Add(txtCode);


            SetupEditor();

            // Initialize pythonPath after comboBoxPythonPaths is available
            pythonPath = comboBoxPythonPaths.Text;
        }

        private void SetupEditor()
        {
            // Set Python lexer using LexerName (newer API)
            txtCode.LexerName = "python";

            // Enable line number margin first
            txtCode.Margins[0].Type = MarginType.Number;
            txtCode.Margins[0].Width = 30;

            // Reset to default styles
            txtCode.StyleResetDefault();

            // Set font for all styles first
            txtCode.Styles[0].Font = "Consolas";
            txtCode.Styles[0].Size = 14;

            // Configure Python syntax highlighting styles
            // Python style indices according to Scintilla Python lexer:
            // 0=Default, 1=CommentLine, 2=Number, 3=String, 4=Character, 5=Keyword, 6=Triple, 7=TripleDouble, 8=ClassName, 9=DefName, 10=Operator, 11=Identifier

            // Default text style - set background color
            txtCode.Styles[0].ForeColor = System.Drawing.Color.Black;
            txtCode.Styles[0].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Comment line style (# comments)
            txtCode.Styles[1].ForeColor = System.Drawing.Color.LightGreen;
            txtCode.Styles[1].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Number style
            txtCode.Styles[2].ForeColor = System.Drawing.Color.Cyan;
            txtCode.Styles[2].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // String style (single quotes)
            txtCode.Styles[3].ForeColor = System.Drawing.Color.SandyBrown;
            txtCode.Styles[3].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Character style
            txtCode.Styles[4].ForeColor = System.Drawing.Color.SandyBrown;
            txtCode.Styles[4].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Keyword style - make it bold and blue
            txtCode.Styles[5].ForeColor = System.Drawing.Color.DeepSkyBlue;
            txtCode.Styles[5].Bold = true;
            txtCode.Styles[5].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Triple quoted strings (single and double)
            txtCode.Styles[6].ForeColor = System.Drawing.Color.SandyBrown;
            txtCode.Styles[6].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtCode.Styles[7].ForeColor = System.Drawing.Color.SandyBrown;
            txtCode.Styles[7].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Class name and function name
            txtCode.Styles[8].ForeColor = System.Drawing.Color.Cyan;  // ClassName
            txtCode.Styles[8].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtCode.Styles[9].ForeColor = System.Drawing.Color.Yellow; // DefName
            txtCode.Styles[9].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Operator
            txtCode.Styles[10].ForeColor = System.Drawing.Color.Black;
            txtCode.Styles[10].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Identifier
            txtCode.Styles[11].ForeColor = System.Drawing.Color.Black;
            txtCode.Styles[11].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);

            // Set Python keywords for syntax highlighting (keyword set 0)
            string pythonKeywords = "and as assert break class continue def del elif else except False finally for from global if import in is lambda None nonlocal not or pass raise return True try while with yield";
            txtCode.SetKeywords(0, pythonKeywords);

            // Set wrap mode
            txtCode.WrapMode = WrapMode.Word;

            // Force colorization of all text
            txtCode.Colorize(0, -1);

            // Add event handler to refresh highlighting when text changes
            txtCode.TextChanged += (s, e) =>
            {
                // Colorize from the beginning to ensure all text is highlighted
                txtCode.Colorize(0, -1);
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            File.WriteAllText(currentFile, txtCode.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Create a new row in dataGridViewCode and use the value of the Filename column in that row to open the corresponding file
            // Auto-increment ID
            // Filename from textBoxFilename
            // Description column from txtDesscription
            // PythonCode column from txtCode
            // Args column from txtArgs
            // Update the database
            // Reload dataGridViewCode from the database

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pythonCode.db");

            // Check if the database file exists
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("Database file not found!");
                return;
            }

            // Define the connection string
            string connectionString = $"Data Source={dbPath};";

            try
            {
                // Create and open the SQLite connection
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    // Insert a new row into the "Code" table
                    string insertQuery = @"
                INSERT INTO Code (Filename, Description, PythonCode, Args)
                VALUES (@Filename, @Description, @PythonCode, @Args);";

                    using (var command = new SqliteCommand(insertQuery, connection))
                    {
                        // Bind parameters to the query
                        command.Parameters.AddWithValue("@Filename", textBoxFilename.Text);
                        command.Parameters.AddWithValue("@Description", txtDesscription.Text);
                        command.Parameters.AddWithValue("@PythonCode", txtCode.Text);
                        command.Parameters.AddWithValue("@Args", txtArgs.Text);

                        // Execute the insert command
                        command.ExecuteNonQuery();
                    }

                    // Reload the data from the database into the DataGridView
                    string selectQuery = "SELECT * FROM Code;";
                    using (var command = new SqliteCommand(selectQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            // Create a DataTable to hold the data
                            var dataTable = new System.Data.DataTable();
                            dataTable.Load(reader);


                            // xóa hết dòng cột dataGridViewCode trước khi nạp dữ liệu mới
                            dataGridViewCode.DataSource = null;
                            dataGridViewCode.Rows.Clear();
                            dataGridViewCode.Columns.Clear();


                            // Bind the DataTable to the DataGridView
                            dataGridViewCode.DataSource = dataTable;
                        }
                    }
                }

                MessageBox.Show("New row added successfully and data reloaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqliteException ex)
            {
                // Handle SQLite-specific exceptions
                MessageBox.Show($"SQLite error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Get the Python path and arguments
            pythonPath = comboBoxPythonPaths.Text;

            // Get the filename from textBoxFilename
            string pythonFileName = textBoxFilename.Text;

            // Ensure the filename ends with .py
            if (!pythonFileName.EndsWith(".py", StringComparison.OrdinalIgnoreCase))
            {
                pythonFileName += ".py";
            }

            // Define the full path for the Python file
            string pythonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pythonFileName);

            try
            {
                // Save the Python code from txtCode to the file
                File.WriteAllText(pythonFilePath, txtCode.Text);

                // Define the arguments for the Python script
                string arguments = $"{pythonFilePath} {txtArgs.Text}";

                // Generate a random number between 111 and 999 for the .bat file name
                Random random = new Random();
                int randomNumber = random.Next(111, 1000);

                // Define the path for the .bat file with the random number
                string batFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"run_python_{randomNumber}.bat");

                // Create the .bat file with the Python execution command
                using (var writer = new StreamWriter(batFilePath, false))
                {
                    writer.WriteLine($"@echo off");
                    writer.WriteLine($"\"{pythonPath}\" {arguments}");
                    writer.WriteLine($"pause"); // Pause to allow the user to see the output
                    writer.WriteLine($"exit");
                }

                // Execute the .bat file
                var psi = new ProcessStartInfo
                {
                    FileName = batFilePath,
                    UseShellExecute = true, // Use ShellExecute to run the .bat file
                    CreateNoWindow = false // Show the command window
                };

                var process = Process.Start(psi);
                if (process != null)
                {
                    process.WaitForExit();

                    // Optionally, you can clean up the .bat file after execution
                    File.Delete(batFilePath);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the process
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (process != null)
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    foreach (var line in output.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (line.EndsWith(".exe", StringComparison.OrdinalIgnoreCase))
                            results.Add(line.Trim());
                    }
                }
            }
            catch
            {
                // nothing to do -> empty list
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

            txtCode.Width = this.ClientSize.Width - 20;

            ConnectToDatabase();

        }

        
        private void ConnectToDatabase()
        {
            // Define the path to the SQLite database file
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pythonCode.db");

            // Check if the database file exists
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("Database file not found!");
                return;
            }

            // Define the connection string
            string connectionString = $"Data Source={dbPath};";

            try
            {
                // Create and open the SQLite connection
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    // Define the query to fetch data from the "Code" table
                    string query = "SELECT * FROM Code";

                    // Create the command to execute the query
                    using (var command = new SqliteCommand(query, connection))
                    {
                        // Execute the query and read the results
                        using (var reader = command.ExecuteReader())
                        {
                            // Create a DataTable to hold the data
                            var dataTable = new System.Data.DataTable();
                            dataTable.Load(reader);

                            // xóa hết dòng cột dataGridViewCode trước khi nạp dữ liệu mới
                            dataGridViewCode.DataSource = null;
                            dataGridViewCode.Rows.Clear();
                            dataGridViewCode.Columns.Clear();

                            // Bind the DataTable to the DataGridView
                            dataGridViewCode.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (SqliteException ex)
            {
                // Handle SQLite-specific exceptions
                MessageBox.Show($"SQLite error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCode_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (dataGridViewCode.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the ID of the selected row
            var selectedRow = dataGridViewCode.CurrentRow;
            if (selectedRow.Cells["ID"].Value == null)
            {
                MessageBox.Show("The selected row does not have a valid ID.", "Invalid Row", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            // Validate input fields
            if (string.IsNullOrWhiteSpace(textBoxFilename.Text) ||
                string.IsNullOrWhiteSpace(txtDesscription.Text) ||
                string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define the path to the SQLite database file
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pythonCode.db");

            // Check if the database file exists
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("Database file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Define the connection string
            string connectionString = $"Data Source={dbPath};";

            try
            {
                // Create and open the SQLite connection
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    // Update the row in the "Code" table using the ID column
                    string updateQuery = @"
                UPDATE Code
                SET Filename = @Filename,
                    Description = @Description,
                    PythonCode = @PythonCode,
                    Args = @Args
                WHERE ID = @ID;";

                    using (var command = new SqliteCommand(updateQuery, connection))
                    {
                        // Bind parameters to the query
                        command.Parameters.AddWithValue("@Filename", textBoxFilename.Text);
                        command.Parameters.AddWithValue("@Description", txtDesscription.Text);
                        command.Parameters.AddWithValue("@PythonCode", txtCode.Text);
                        command.Parameters.AddWithValue("@Args", txtArgs.Text);
                        command.Parameters.AddWithValue("@ID", id);

                        // Execute the update command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Row updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows were updated. The ID may not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // Update the modified row in the DataGridView
                    selectedRow.Cells["Filename"].Value = textBoxFilename.Text;
                    selectedRow.Cells["Description"].Value = txtDesscription.Text;
                    selectedRow.Cells["PythonCode"].Value = txtCode.Text;
                    selectedRow.Cells["Args"].Value = txtArgs.Text;
                }
            }
            catch (SqliteException ex)
            {
                // Handle SQLite-specific exceptions
                MessageBox.Show($"SQLite error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewCode_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Retrieve data from the current row in dataGridViewCode to display in the controls

            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewCode.Rows.Count)
            {
                var row = dataGridViewCode.Rows[e.RowIndex];
                textBoxFilename.Text = row.Cells["Filename"].Value?.ToString() ?? "";
                txtDesscription.Text = row.Cells["Description"].Value?.ToString() ?? "";
                txtCode.Text = row.Cells["PythonCode"].Value?.ToString() ?? "";
                txtArgs.Text = row.Cells["Args"].Value?.ToString() ?? "";
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (dataGridViewCode.CurrentRow == null)
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the ID of the selected row
            var selectedRow = dataGridViewCode.CurrentRow;
            if (selectedRow.Cells["ID"].Value == null)
            {
                MessageBox.Show("The selected row does not have a valid ID.", "Invalid Row", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            // Define the path to the SQLite database file
            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pythonCode.db");

            // Check if the database file exists
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("Database file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Define the connection string
            string connectionString = $"Data Source={dbPath};";

            try
            {
                // Create and open the SQLite connection
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    // Define the DELETE query
                    string deleteQuery = "DELETE FROM Code WHERE ID = @ID;";

                    // Execute the DELETE query
                    using (var command = new SqliteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Row deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows were deleted. The ID may not exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // Refresh the DataGridView
                    string selectQuery = "SELECT * FROM Code;";
                    using (var command = new SqliteCommand(selectQuery, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            // Create a DataTable to hold the data
                            var dataTable = new System.Data.DataTable();
                            dataTable.Load(reader);

                            // Clear and reload the DataGridView
                            dataGridViewCode.DataSource = null;
                            dataGridViewCode.Rows.Clear();
                            dataGridViewCode.Columns.Clear();
                            dataGridViewCode.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (SqliteException ex)
            {
                // Handle SQLite-specific exceptions
                MessageBox.Show($"SQLite error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select multiple .py files
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Python Files (*.py)|*.py";
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select Python Files";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file paths
                    string[] selectedFiles = openFileDialog.FileNames;

                    // Define the path to the SQLite database file
                    string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pythonCode.db");

                    // Check if the database file exists
                    if (!File.Exists(dbPath))
                    {
                        MessageBox.Show("Database file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Define the connection string
                    string connectionString = $"Data Source={dbPath};";

                    try
                    {
                        // Create and open the SQLite connection
                        using (var connection = new SqliteConnection(connectionString))
                        {
                            connection.Open();

                            // Insert each selected file into the database
                            foreach (string filePath in selectedFiles)
                            {
                                string fileName = Path.GetFileName(filePath); // Get the file name
                                string fileContent = File.ReadAllText(filePath); // Read the file content

                                // Insert the file data into the "Code" table
                                string insertQuery = @"
                            INSERT INTO Code (Filename, Description, PythonCode, Args)
                            VALUES (@Filename, @Description, @PythonCode, @Args);";

                                using (var command = new SqliteCommand(insertQuery, connection))
                                {
                                    command.Parameters.AddWithValue("@Filename", fileName);
                                    command.Parameters.AddWithValue("@Description", "Imported Python File");
                                    command.Parameters.AddWithValue("@PythonCode", fileContent);
                                    command.Parameters.AddWithValue("@Args", ""); // Default empty arguments
                                    command.ExecuteNonQuery();
                                }
                            }

                            // Reload the data from the database into the DataGridView
                            string selectQuery = "SELECT * FROM Code;";
                            using (var command = new SqliteCommand(selectQuery, connection))
                            {
                                using (var reader = command.ExecuteReader())
                                {
                                    // Create a DataTable to hold the data
                                    var dataTable = new System.Data.DataTable();
                                    dataTable.Load(reader);

                                    // Clear and reload the DataGridView
                                    dataGridViewCode.DataSource = null;
                                    dataGridViewCode.Rows.Clear();
                                    dataGridViewCode.Columns.Clear();
                                    dataGridViewCode.DataSource = dataTable;
                                }
                            }
                        }

                        MessageBox.Show("Files imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqliteException ex)
                    {
                        // Handle SQLite-specific exceptions
                        MessageBox.Show($"SQLite error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        // Handle general exceptions
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

}

