using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SkyrimLauncher
{
    public partial class FormMods : Form
    {
        List<string> installedMods = new List<string>();
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
            string joinline = FuncParser.stringRead(FormMain.pathLauncherINI, "Mods", "installedMods");
            if (!String.IsNullOrEmpty(joinline))
            {
                installedMods.AddRange(joinline.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries));
            }
            refreshFileList();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, true);
        }
        void langTranslateEN()
        {
            button_Install.Text = "Install";
            button_Uninstall.Text = "Uninstall";
            label2.Text = @"Files from Skyrim\Mods:";
            textDeleteMod = "Delete mod?";
            textNoFileSelect = "No file select.";
            textNoUninstalFile = "No .txt instruction file.";
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void refreshFileList()
        {
            if (Directory.Exists(FormMain.pathModsFolder))
            {
                foreach (string line in Directory.EnumerateFiles(FormMain.pathModsFolder))
                {
                    if (FormMain.archiveExt.Exists(s => s.Equals(Path.GetExtension(line), StringComparison.OrdinalIgnoreCase)))
                    {
                        string file = Path.GetFileName(line);
                        listView1.Items.Add(file);
                        if (installedMods.Exists(s => s.Equals(file, StringComparison.OrdinalIgnoreCase)))
                        {
                            listView1.Items[listView1.Items.Count - 1].BackColor = Color.PaleGreen;
                        }
                    }
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_Install_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                FuncMisc.toggleButtons(this, false);
                listView1.Enabled = false;
                FuncFiles.unpackArhive(FormMain.pathModsFolder + listView1.SelectedItems[0].Text, false, true);
                FuncMisc.toggleButtons(this, true);
                listView1.Enabled = true;
                string file = FormMain.pathModsFolder + Path.GetFileNameWithoutExtension(FormMain.pathModsFolder + listView1.SelectedItems[0].Text) + ".txt";
                if (File.Exists(file))
                {
                    if (FuncParser.keyExists(file, "INSTALL", "ADDARCHIVES"))
                    {
                        foreach (string line in FuncParser.stringRead(file, "INSTALL", "ADDARCHIVES").Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            FuncMisc.resourceArchives(line, false);
                        }
                    }
                    if (FuncParser.keyExists(file, "INSTALL", "ASPECTRATIO_" + FormMain.aspectRatio))
                    {
                        FuncFiles.unpackArhive(FormMain.pathGameFolder + FuncParser.stringRead(file, "INSTALL", "ASPECTRATIO_" + FormMain.aspectRatio), true, true);
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
                listView1.SelectedItems[0].BackColor = Color.PaleGreen;
                if (!installedMods.Exists(s => s.Equals(listView1.SelectedItems[0].Text, StringComparison.OrdinalIgnoreCase)))
                {
                    installedMods.Add(listView1.SelectedItems[0].Text);
                    FuncParser.iniWrite(FormMain.pathLauncherINI, "Mods", "installedMods", String.Join("|", installedMods));
                }
            }
            else
            {
                MessageBox.Show(textNoFileSelect);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_Uninstall_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (FuncMisc.dialogResult(textDeleteMod, FormMain.textConfirmTitle))
                {
                    string file = FormMain.pathModsFolder + Path.GetFileNameWithoutExtension(FormMain.pathModsFolder + listView1.SelectedItems[0].Text) + ".txt";
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
                            foreach (string line in FuncParser.stringRead(file, "INSTALL", "ADDARCHIVES").Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                FuncMisc.resourceArchives(line, true);
                            }
                        }
                        if (FuncParser.keyExists(file, "UNINSTALL", "UNPACK"))
                        {
                            FuncFiles.unpackArhive(FormMain.pathGameFolder + FuncParser.stringRead(file, "UNINSTALL", "UNPACK"), true, true);
                        }
                        listView1.SelectedItems[0].BackColor = SystemColors.Window;
                        installedMods.Remove(listView1.SelectedItems[0].Text);
                        FuncParser.iniWrite(FormMain.pathLauncherINI, "Mods", "installedMods", String.Join("|", installedMods));
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
        void button_Close_MouseEnter(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonCloseGlow;
        }
        void button_Close_MouseLeave(object sender, EventArgs e)
        {
            button_Close.BackgroundImage = Properties.Resources.buttonClose;
        }
    }
}