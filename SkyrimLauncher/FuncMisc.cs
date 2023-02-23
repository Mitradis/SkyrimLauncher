using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SkyrimLauncher
{
    public class FuncMisc
    {
        public static bool refreshButton(Button button, string file, string section, string key, bool disable = false, string value = null, bool invert = false)
        {
            if (!disable && FuncParser.keyExists(file, section, key))
            {
                button.Enabled = true;
                string readString = FuncParser.stringRead(file, section, key);
                bool toggle = false;
                toggle = readString != null && (readString == value || readString == "1" || String.Equals(readString, "true", StringComparison.OrdinalIgnoreCase));
                toggle = invert ? !toggle : toggle;
                button.BackgroundImage = toggle ? Properties.Resources.buttonToggleOn : Properties.Resources.buttonToggleOff;
                return toggle;
            }
            else
            {
                button.BackgroundImage = Properties.Resources.buttonToggleDisable;
                button.Enabled = false;
                return false;
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void refreshTrackBar(TrackBar trackbar, string file, string section, string key, Label label, int division = -1)
        {
            if (FuncParser.keyExists(file, section, key))
            {
                trackbar.Enabled = true;
                int readINT = FuncParser.intRead(file, section, key);
                if (division != -1)
                {
                    readINT = readINT / division;
                }
                if (readINT >= trackbar.Minimum && readINT <= trackbar.Maximum)
                {
                    label.Text = division != -1 ? (readINT * division).ToString() : readINT.ToString();
                    trackbar.Value = readINT;
                }
                else
                {
                    label.Text = "N/A";
                }
            }
            else
            {
                label.Text = "N/A";
                trackbar.Enabled = false;
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void refreshComboBox(ComboBox combobox, double[] list, double value, EventHandler onchange)
        {
            if (onchange != null)
            {
                combobox.SelectedIndexChanged -= onchange;
            }
            if (value != -1)
            {
                int count = list.Length;
                for (int i = 0; i < count; i++)
                {
                    if (value == list[i])
                    {
                        combobox.SelectedIndex = i;
                        break;
                    }
                    else if (i == count - 1)
                    {
                        combobox.SelectedIndex = -1;
                    }
                }
            }
            else
            {
                combobox.SelectedIndex = -1;
            }
            if (onchange != null)
            {
                combobox.SelectedIndexChanged += onchange;
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void toggleButtons(Form form, bool action)
        {
            foreach (Control line in form.Controls)
            {
                if (line is Button)
                {
                    line.Enabled = action;
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void textColor(Form form, bool black, bool button = false)
        {
            foreach (Control line in form.Controls)
            {
                if (line is Label || (button && line is Button))
                {
                    line.ForeColor = black ? SystemColors.ControlLight : SystemColors.ControlText;
                }
                else if (line is TrackBar)
                {
                    line.BackColor = black ? Color.Black : SystemColors.Control;
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void setFormFont(Form form)
        {
            if (FormMain.customFont != null)
            {
                foreach (Control line in form.Controls)
                {
                    if (line is Label || line is Button || line is ListBox || line is ListView || line is ComboBox || line is NumericUpDown)
                    {
                        line.Font = new Font(FormMain.customFont, line.Font.Size, FormMain.customFontStyle, GraphicsUnit.Point);
                    }
                }
            }
        }
        public static void supportStrikeOut(string font)
        {
            if (!testStrikeOut(font, FontStyle.Regular))
            {
                if (testStrikeOut(font, FontStyle.Bold))
                {
                    FormMain.customFontStyle = FontStyle.Bold;
                }
                else if (testStrikeOut(font, FontStyle.Italic))
                {
                    FormMain.customFontStyle = FontStyle.Italic;
                }
                else if (testStrikeOut(font, FontStyle.Strikeout))
                {
                    FormMain.customFontStyle = FontStyle.Strikeout;
                }
                else if (testStrikeOut(font, FontStyle.Underline))
                {
                    FormMain.customFontStyle = FontStyle.Underline;
                }
                else
                {
                    FormMain.customFont = null;
                }
            }
        }
        private static bool testStrikeOut(string font, FontStyle style)
        {
            try
            {
                using (Font strikeout = new Font(font, 10, style))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void setAspectRatio(int width, int height)
        {
            double[] arList = new double[] { 1.3, 1.4, 1.7, 1.8, 2.5 };
            double arRes = (double)width / height;
            int count = arList.Length;
            for (int i = 0; i < count; i++)
            {
                if (arRes <= arList[i] || (i == 4 && arRes > 2.5))
                {
                    if (FormMain.aspectRatio != i)
                    {
                        FuncFiles.unpackArhive(FormMain.pathSystemFolder + "AR(" + i.ToString() + ")", true, true);
                        FormMain.aspectRatio = i;
                    }
                    break;
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void removePlugin(string plugin)
        {
            List<string> pluginsList = new List<string>(FuncFiles.readTextFile(FormMain.pathAppData + "Plugins.txt"));
            int index = pluginsList.IndexOf(plugin);
            if (index != -1)
            {
                pluginsList.RemoveAt(index);
                FuncFiles.writeToFile(FormMain.pathAppData + "Plugins.txt", pluginsList);
            }
            pluginsList.Clear();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void addPlugin(string plugin)
        {
            List<string> pluginsList = new List<string>(FuncFiles.readTextFile(FormMain.pathAppData + "Plugins.txt"));
            if (File.Exists(FormMain.pathDataFolder + plugin) && pluginsList.IndexOf(plugin) == -1)
            {
                List<string> defaultList = new List<string>(FuncFiles.readTextFile(FormMain.pathSkyrimFolder + "Plugins.txt"));
                if (defaultList.Count < 3)
                {
                    defaultList = new List<string>(FuncSettings.pluginsTXT());
                }
                string upmod = null;
                int index1 = defaultList.IndexOf(plugin) - 1;
                int index2 = -1;
                for (int i = index1; i > 0; i--)
                {
                    upmod = defaultList[i];
                    index2 = pluginsList.IndexOf(upmod);
                    if (index2 != -1)
                    {
                        pluginsList.Insert(index2 + 1, plugin);
                        FuncFiles.writeToFile(FormMain.pathAppData + "Plugins.txt", pluginsList);
                        break;
                    }
                }
                defaultList.Clear();
            }
            pluginsList.Clear();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static void resourceArchives(string value, bool delete)
        {
            foreach (string line in new string[] { "sResourceArchiveList", "sResourceArchiveList2" })
            {
                string archives = FuncParser.stringRead(FormMain.pathSkyrimINI, "Archive", line);
                bool find = archives != null && archives.IndexOf(value, StringComparison.OrdinalIgnoreCase) != -1;
                if (find && !delete)
                {
                    break;
                }
                if ((!delete && (archives == null || (archives.Length + value.Length + 2) < 256)) || (find && delete))
                {
                    if (archives != null)
                    {
                        List<string> list = new List<string>(archives.Split(new string[] { "," }, StringSplitOptions.None));
                        int count = list.Count;
                        for (int i = 0; i < count; i++)
                        {
                            list[i] = list[i].Trim();
                        }
                        if (!delete)
                        {
                            list.Add(value);
                        }
                        else
                        {
                            list.Remove(value);
                        }
                        archives = String.Join(", ", list);
                    }
                    else if (!delete)
                    {
                        archives = value;
                    }
                    FuncParser.iniWrite(FormMain.pathSkyrimINI, "Archive", line, archives);
                    break;
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        public static bool dialogResult(string message, string title)
        {
            DialogResult dialog = MessageBox.Show(message, title, MessageBoxButtons.YesNo);
            return dialog == DialogResult.Yes;
        }
    }
}