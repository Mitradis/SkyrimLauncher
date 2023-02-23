using System;
using System.IO;
using System.Windows.Forms;

namespace SkyrimLauncher
{
    public partial class FormMods : Form
    {
        string textDeleteMod = "Удалить мод?";
        string textNoFileSelect = "Не выбран файл.";
        string textNoUninstalFile = "Нет .txt файла инструкции.";

        public FormMods()
        {
            InitializeComponent();
            FuncMisc.setFormFont(this);
            if (FormMain.numberStyle > 1)
            {
                imageBackgroundImage();
            }
            if (FormMain.langTranslate == "EN")
            {
                langTranslateEN();
            }
            refreshFileList();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, true);
        }
        private void langTranslateEN()
        {
            button_Install.Text = "Install";
            button_Uninstall.Text = "Uninstall";
            label2.Text = @"Files from Skyrim\Mods";
            textDeleteMod = "Delete mod?";
            textNoFileSelect = "No file select.";
            textNoUninstalFile = "No .txt instruction file.";
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void refreshFileList()
        {
            if (Directory.Exists(FormMain.pathModsFolder))
            {
                foreach (string line in Directory.EnumerateFiles(FormMain.pathModsFolder))
                {
                    if (FormMain.archiveExt.Exists(s => s.Equals(Path.GetExtension(line), StringComparison.OrdinalIgnoreCase)))
                    {
                        listBox1.Items.Add(Path.GetFileName(line));
                    }
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Install_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                FuncMisc.toggleButtons(this, false);
                listBox1.Enabled = false;
                FuncFiles.unpackArhive(FormMain.pathModsFolder + listBox1.SelectedItem.ToString(), false, true);
                FuncMisc.toggleButtons(this, true);
                listBox1.Enabled = true;
                string file = FormMain.pathModsFolder + Path.GetFileNameWithoutExtension(FormMain.pathModsFolder + listBox1.SelectedItem.ToString()) + ".txt";
                if (File.Exists(file))
                {
                    if (FuncParser.keyExists(file, "INSTALL", "ADDARCHIVES"))
                    {
                        foreach (string line in FuncParser.stringRead(file, "INSTALL", "ADDARCHIVES").Split(new string[] { "|" }, StringSplitOptions.None))
                        {
                            FuncMisc.resourceArchives(line, false);
                        }
                    }
                    if (FuncParser.keyExists(file, "INSTALL", "ASPECTRATIO_" + FormMain.aspectRatio.ToString()))
                    {
                        FuncFiles.unpackArhive(FormMain.pathGameFolder + FuncParser.stringRead(file, "INSTALL", "ASPECTRATIO_" + FormMain.aspectRatio.ToString()), true, true);
                    }
                    foreach (string line in File.ReadLines(file))
                    {
                        if (String.IsNullOrEmpty(line) || line.StartsWith("["))
                        {
                            break;
                        }
                        else if (line.EndsWith(".esm") || line.EndsWith(".esp"))
                        {
                            FuncMisc.addPlugin(line);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(textNoFileSelect);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Uninstall_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (FuncMisc.dialogResult(textDeleteMod, FormMain.textConfirmTitle))
                {
                    string file = FormMain.pathModsFolder + Path.GetFileNameWithoutExtension(FormMain.pathModsFolder + listBox1.SelectedItem.ToString()) + ".txt";
                    if (File.Exists(file))
                    {
                        foreach (string line in File.ReadLines(file))
                        {
                            if (String.IsNullOrEmpty(line) || line.StartsWith("["))
                            {
                                break;
                            }
                            else if (line.EndsWith(".esm") || line.EndsWith(".esp"))
                            {
                                FuncMisc.removePlugin(line);
                            }
                            FuncFiles.deleteModFile(line);
                        }
                        if (FuncParser.keyExists(file, "INSTALL", "ADDARCHIVES"))
                        {
                            foreach (string line in FuncParser.stringRead(file, "INSTALL", "ADDARCHIVES").Split(new string[] { "|" }, StringSplitOptions.None))
                            {
                                FuncMisc.resourceArchives(line, true);
                            }
                        }
                        if (FuncParser.keyExists(file, "UNINSTALL", "UNPACK"))
                        {
                            FuncFiles.unpackArhive(FormMain.pathGameFolder + FuncParser.stringRead(file, "UNINSTALL", "UNPACK"), true, true);
                        }
                    }
                    else
                    {
                        MessageBox.Show(textNoUninstalFile);
                    }
                }
            }
            else
            {
                MessageBox.Show(textNoFileSelect);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        private void button_Close_MouseEnter(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonCloseGlow;
        }
        private void button_Close_MouseLeave(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonClose;
        }
    }
}