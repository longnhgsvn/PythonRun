# PythonRun

PythonRun is a Windows Forms application that allows users to manage, edit, and execute Python scripts. It provides a user-friendly interface for working with Python code, including syntax highlighting, database integration, and script execution.

<img width="1189" height="640" alt="image" src="https://github.com/user-attachments/assets/b7a8cc85-ab29-48eb-8495-3012165865fc" />

---

## Features

- **Python Script Editor**:
  - Syntax highlighting for Python code using ScintillaNet.
  - Line numbering and keyword-based colorization.

- **Script Management**:
  - Save, update, and delete Python scripts.
  - Store scripts in an SQLite database for easy management.
  - Import multiple Python files into the database.

- **Script Execution**:
  - Execute Python scripts directly from the application.
  - Generate `.bat` files to run Python scripts with arguments.
  - Support for multiple Python installations.

- **Database Integration**:
  - SQLite database (`pythonCode.db`) to store script metadata and content.
  - Auto-incrementing IDs for script entries.

---

## Prerequisites

.NET 8 Runtime: Ensure you have the .NET 8 runtime installed. You can download it from the official .NET website
.

Python: Install Python (version 3.10 or later recommended) and ensure it is added to your system's PATH so you can run Python scripts from the command line. Verify installation by running:

python --version


or

python3 --version


SQLite: The application uses SQLite for database management. Ensure the SQLite executable is available or use the built-in SQLite support in Python via the sqlite3 module.

Optional Python Packages (if the application requires):

pip install -r requirements.txt

---

## Installation

1. **Clone the Repository**:
1. git clone https://github.com/longnhgsvn/PythonRun.git cd PythonRun
1. 
2. **Open the Project**:
- Open the solution in Visual Studio 2022 or later.

3. **Restore NuGet Packages**:
- Restore the required NuGet packages, including `Microsoft.Data.Sqlite` and `ScintillaNet.WinForms`.

4. **Build the Project**:
- Build the solution to ensure all dependencies are resolved.

5. **Run the Application**:
- Start the application from Visual Studio.

Other way download zip file
https://github.com/longnhgsvn/PythonRun/releases/download/v1.0.0/PythonRun.zip

Unzip then run  PythonRun.exe
---

## Usage

### 1. **Editing Python Scripts**
- Use the editor to write or modify Python scripts.
- Syntax highlighting and line numbering are enabled by default.

### 2. **Managing Scripts**
- **Add New Script**:
  - Enter the filename, description, and arguments.
  - Write the Python code in the editor and save it to the database.
- **Update Script**:
  - Select a script from the database, modify it, and save the changes.
- **Delete Script**:
  - Select a script and delete it from the database.

### 3. **Executing Scripts**
- Select a Python script and click "Run" to execute it.
- The application generates a `.bat` file to run the script with the selected Python interpreter.

### 4. **Importing Scripts**
- Import multiple `.py` files into the database using the "Import" button.

---

## File Structure

- **`Form1.cs`**:
- Contains the main logic for the application, including script management and execution.
- **`Form1.Designer.cs`**:
- Handles the design and layout of the Windows Forms interface.
- **`pythonCode.db`**:
- SQLite database file for storing script metadata and content.

---

## License

This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the [GNU General Public License](https://www.gnu.org/licenses/) for more details.

---

## Contributing

Contributions are welcome! Feel free to fork the repository and submit pull requests.

---

## Author

- **GitHub**: [longnhgsvn](https://github.com/longnhgsvn)

---

## Acknowledgments

- **ScintillaNet**: For providing the syntax highlighting functionality.
- **SQLite**: For lightweight database management.
---
Explanation of the README Structure:
1.	Project Overview:
•	Describes the purpose and functionality of the application.
2.	Features:
•	Highlights the key features of the application.
3.	Prerequisites:
•	Lists the dependencies required to run the application.
4.	Installation:
•	Provides step-by-step instructions to set up the project.
5.	Usage:
•	Explains how to use the application, including editing, managing, and executing scripts.
6.	File Structure:
•	Describes the key files in the project.
7.	License:
•	Includes the GNU General Public License details.
8.	Contributing:
•	Encourages contributions to the project.
9.	Acknowledgments:
•	Credits the libraries and tools used in the project.
Let me know if you need further adjustments!
