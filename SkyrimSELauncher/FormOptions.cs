using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SkyrimSELauncher
{
    public partial class FormOptions : Form
    {
        string pathMyDocLogs = FuncFiles.pathAddSlash(FormMain.pathMyDoc + "Logs") + "Script";
        public static List<int> screenListW = new List<int>();
        public static List<int> screenListH = new List<int>();
        List<List<string>> masterFiles = new List<List<string>>();
        List<string> ignoreNames = new List<string>() { "Skyrim.esm", "Update.esm", "Dawnguard.esm", "HearthFires.esm", "Dragonborn.esm" };
        string pathToPlugins = FormMain.pathAppData + "Plugins.txt";
        string textDateChange = "Не удалось изменить дату изменения файла: ";
        string textGrassDensity = "iMinGrassSize - расстояние между кустами травы, меньше - плотнее.";
        string textRedateMods = "Массовое изменение даты изменения файлов по возрастанию.";
        string textShadowResolution = "iShadowMapResolution - \"тяжелый\" параметр теней.";
        string selectedScreen = null;
        int nextESMIndex = 0;
        bool blockRefreshList = true;
        bool borderless = false;
        bool goodAllMasters = true;
        bool hideobjects = false;
        bool lens = false;
        bool papyrus = false;
        bool precipitation = false;
        bool projecteuv = false;
        bool r64 = false;
        bool reflection = false;
        bool sao = false;
        bool startMoveItem = false;
        bool vsync = false;
        bool window = false;
        ListViewItem itemStartMove = null;
        Screen[] screens = Screen.AllScreens;
        DateTime lastWriteData = Directory.GetLastWriteTime(FormMain.pathDataFolder);

        public FormOptions()
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
            toolTip1.SetToolTip(label14TAB, textShadowResolution);
            toolTip1.SetToolTip(comboBox_ShadowTAB, textShadowResolution);
            toolTip1.SetToolTip(label25TAB, textGrassDensity);
            toolTip1.SetToolTip(label26TAB, textGrassDensity);
            toolTip1.SetToolTip(trackBar_GrassDensityTAB, textGrassDensity);
            toolTip1.SetToolTip(button_RedateMods, textRedateMods);
            refreshScreenIndex();
            refreshScreenResolution();
            refreshSettings();
            refreshModsList();
            listView1.Visible = true;
            timer2.Enabled = true;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            FuncMisc.textColor(this, true);
        }
        void timer2_Tick(object sender, EventArgs e)
        {
            if (lastWriteData != Directory.GetLastWriteTime(FormMain.pathDataFolder))
            {
                timer2.Enabled = false;
                refreshModsList();
                timer2.Enabled = true;
                lastWriteData = Directory.GetLastWriteTime(FormMain.pathDataFolder);
            }
        }
        void langTranslateEN()
        {
            button_ActivatedAll.Text = "Enable all";
            button_Common.Text = "Common";
            button_Distance.Text = "Distances";
            button_Hight.Text = "Hight";
            button_LogsFolder.Text = "Logs folder";
            button_Low.Text = "Low";
            button_Medium.Text = "Medium";
            button_RedateMods.Text = "Redate mods";
            button_Restore.Text = "Restore";
            button_Ultra.Text = "Ultra";
            comboBox_AATAB.Items.Clear();
            comboBox_AATAB.Items.AddRange(new object[] { "No", "FXAA", "TAA" });
            comboBox_DecalsTAB.Items.Clear();
            comboBox_DecalsTAB.Items.AddRange(new object[] { "No", "Medium", "Hight" });
            comboBox_LODObjectsTAB.Items.Clear();
            comboBox_LODObjectsTAB.Items.AddRange(new object[] { "Low", "Medium", "Hight", "Ultra" });
            comboBox_ShadowQualityTAB.Items.Clear();
            comboBox_ShadowQualityTAB.Items.AddRange(new object[] { "Low", "Medium", "Hight" });
            comboBox_VolumetricTAB.Items.Clear();
            comboBox_VolumetricTAB.Items.AddRange(new object[] { "No", "Low", "Medium", "Hight" });
            filesName.Text = "Files:";
            label10TAB.Text = "Display index:";
            label11TAB.Text = "Antialiasing:";
            label12TAB.Text = "Decals / Particles:";
            label13TAB.Text = "Shadow quality:";
            label14TAB.Text = "Shadow resolution:";
            label15TAB.Text = "Sun rays:";
            label16TAB.Text = "Ambient:";
            label17TAB.Text = "Precipitation:";
            label18TAB.Text = "Interference:";
            label19TAB.Text = "64-bit render:";
            label20TAB.Text = "Space:";
            label21TAB.Text = "Lens flare:";
            label2.Text = "Presets";
            label23TAB.Text = "Window:";
            label24TAB.Text = "Borderless:";
            label25TAB.Text = "Grass density:";
            label27TAB.Text = "Objects:";
            label29TAB.Text = "Characters:";
            label31TAB.Text = "Lighting:";
            label33TAB.Text = "Far objects:";
            label34TAB.Text = "Items:";
            label36TAB.Text = "Grass:";
            label38TAB.Text = "Shadow:";
            label40TAB.Text = "Objects details fade:";
            label5.Text = "Papyrus logs:";
            label6.Text = "Master files:";
            label7.Text = "Mods On/All:";
            label9TAB.Text = "Resolution:";
            textDateChange = "Could not change the date the file was modified: ";
            textGrassDensity = "iMinGrassSize - distance between the grass bushes, smaller - denser.";
            textRedateMods = "Mass change of the date of change of files in ascending order.";
            textShadowResolution = "iShadowMapResolution - \"heaviest\" shadow parameter.";
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void refreshSettings()
        {
            refresh64();
            refreshAA();
            refreshActors();
            refreshBorderless();
            refreshDecals();
            refreshGrass();
            refreshGrassDistance();
            refreshHideObjects();
            refreshItems();
            refreshLODObjects();
            refreshLens();
            refreshLights();
            refreshObjects();
            refreshPapyrus();
            refreshPrecipitation();
            refreshProjecteUV();
            refreshReflection();
            refreshSAO();
            refreshShadow();
            refreshShadowQuality();
            refreshShadowRange();
            refreshVolumetricLighting();
            refreshVsync();
            refreshWindow();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            itemStartMove = GetItemFromPoint(listView1, Cursor.Position);
            if (!blockRefreshList && itemStartMove != null && !ignoreNames.Exists(s => s.Equals(itemStartMove.Text, StringComparison.OrdinalIgnoreCase)))
            {
                startMoveItem = true;
                timer1.Enabled = true;
            }
        }
        void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startMoveItem)
            {
                startMoveItem = false;
                timer1.Enabled = false;
                listView1.Cursor = Cursors.Default;
                ListViewItem itemEndMove = GetItemFromPoint(listView1, Cursor.Position);
                if (itemEndMove != null && itemEndMove != itemStartMove && itemEndMove.Index >= ignoreNames.Count - 1)
                {
                    blockRefreshList = true;
                    masterFiles.Insert(itemEndMove.Index + 1, masterFiles[itemStartMove.Index]);
                    masterFiles.RemoveAt(itemStartMove.Index);
                    listView1.Items.Remove(itemStartMove);
                    listView1.Items.Insert(itemEndMove.Index + 1, itemStartMove);
                    listView1.Items[itemStartMove.Index].Focused = true;
                    listView1.Select();
                    scanAllMods();
                    writeMasterFile();
                    blockRefreshList = false;
                }
                itemStartMove = null;
            }
        }
        void listView1_MouseLeave(object sender, EventArgs e)
        {
            if (startMoveItem)
            {
                startMoveItem = false;
                timer1.Enabled = false;
                itemStartMove = null;
                listView1.Cursor = Cursors.Default;
            }
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            if (startMoveItem)
            {
                listView1.Cursor = itemStartMove != GetItemFromPoint(listView1, Cursor.Position) ? Cursors.NoMoveVert : Cursors.Default;
            }
        }
        private ListViewItem GetItemFromPoint(ListView listView, Point mousePosition)
        {
            Point localPoint = listView.PointToClient(mousePosition);
            return listView.GetItemAt(localPoint.X, localPoint.Y);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Index != -1)
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(masterFiles[e.Item.Index].ToArray());
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!blockRefreshList)
            {
                blockRefreshList = true;
                goodAllMasters = true;
                bool fail = false;
                if (e.Item.Checked)
                {
                    checkItem(e.Item, true);
                }
                else if (!ignoreNames.Exists(s => s.Equals(e.Item.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    uncheckItem(e.Item.Text);
                }
                else
                {
                    fail = true;
                    e.Item.Checked = !e.Item.Checked;
                }
                if (!fail && goodAllMasters)
                {
                    setFileID();
                    writeMasterFile();
                }
                blockRefreshList = false;
            }
        }
        void checkItem(ListViewItem item, bool check)
        {
            int lastIndex = -1;
            bool goodSort = false;
            bool hasMasters = false;
            bool indexError = false;
            foreach (string line in masterFiles[item.Index])
            {
                hasMasters = true;
                ListViewItem findItem = listView1.FindItemWithText(line);
                if (findItem != null && item.Index > findItem.Index)
                {
                    if (!findItem.Checked && check)
                    {
                        checkItem(findItem, true);
                    }
                    if (findItem.Index < lastIndex)
                    {
                        indexError = true;
                    }
                    lastIndex = findItem.Index;
                    goodSort = true;
                }
                else
                {
                    goodSort = false;
                    goodAllMasters = false;
                    break;
                }
            }
            if (!hasMasters)
            {
                goodSort = true;
            }
            if (!goodSort || indexError)
            {
                item.ForeColor = Color.Red;
            }
            else if (item.Text.EndsWith(".esm", StringComparison.OrdinalIgnoreCase) || FuncParser.checkESM(FormMain.pathDataFolder + item.Text))
            {
                item.ForeColor = Color.Blue;
            }
            else
            {
                item.ForeColor = Color.Black;
            }
            if (check)
            {
                item.Checked = goodAllMasters;
            }
        }
        void uncheckItem(string item)
        {
            int count = listView1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                foreach (string line in masterFiles[i])
                {
                    if (String.Equals(line, item, StringComparison.OrdinalIgnoreCase))
                    {
                        listView1.Items[i].Checked = false;
                        uncheckItem(listView1.Items[i].Text);
                    }
                }
            }
        }
        void scanAllMods()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                goodAllMasters = true;
                checkItem(item, item.Checked);
            }
            setFileID();
        }
        void setFileID()
        {
            int fileID = 0;
            int count = listView1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (listView1.Items[i].Checked)
                {
                    listView1.Items[i].SubItems[1].Text = BitConverter.ToString(BitConverter.GetBytes(fileID), 0, 1);
                    fileID++;
                }
                else
                {
                    listView1.Items[i].SubItems[1].Text = "";
                }
            }
        }
        void refreshModsList()
        {
            blockRefreshList = true;
            listView1.Items.Clear();
            listBox1.Items.Clear();
            masterFiles.Clear();
            nextESMIndex = 0;
            if (File.Exists(pathToPlugins) && Directory.Exists(FormMain.pathDataFolder))
            {
                List<string> pluginsList = new List<string>(FuncFiles.readTextFile(pathToPlugins));
                List<string> dataESFiles = new List<string>();
                foreach (string line in Directory.EnumerateFiles(FormMain.pathDataFolder, "*.esm"))
                {
                    string file = Path.GetFileName(line);
                    if (!ignoreNames.Exists(s => s.Equals(file, StringComparison.OrdinalIgnoreCase)))
                    {
                        dataESFiles.Add(file);
                    }
                }
                foreach (string line in Directory.EnumerateFiles(FormMain.pathDataFolder, "*.esl"))
                {
                    dataESFiles.Add(Path.GetFileName(line));
                }
                foreach (string line in Directory.EnumerateFiles(FormMain.pathDataFolder, "*.esp"))
                {
                    dataESFiles.Add(Path.GetFileName(line));
                }
                foreach (string line in ignoreNames)
                {
                    if (File.Exists(FormMain.pathDataFolder + line))
                    {
                        addToListView(line, true);
                    }
                }
                foreach (string line in pluginsList)
                {
                    if (dataESFiles.Exists(s => s.Equals(line.Replace("*", ""), StringComparison.OrdinalIgnoreCase)))
                    {
                        if (line.StartsWith("*"))
                        {
                            addToListView(Path.GetFileName(FormMain.pathDataFolder + line.Replace("*", "")), true);
                        }
                        else
                        {
                            addToListView(Path.GetFileName(FormMain.pathDataFolder + line), false);
                        }
                    }
                }
                foreach (string line in dataESFiles)
                {
                    if (!pluginsList.Exists(s => s.Replace("*", "").Equals(line, StringComparison.OrdinalIgnoreCase)))
                    {
                        addToListView(line, false);
                    }
                }
                pluginsList.Clear();
                dataESFiles.Clear();
                scanAllMods();
                writeMasterFile();
            }
            blockRefreshList = false;
        }
        void addToListView(string line, bool check)
        {
            ListViewItem item = new ListViewItem();
            item.Text = line;
            item.Checked = check;
            item.SubItems.Add("");
            if (!listView1.Items.Contains(item))
            {
                if (line.EndsWith(".esm", StringComparison.OrdinalIgnoreCase) || line.EndsWith(".esl", StringComparison.OrdinalIgnoreCase) || FuncParser.checkESM(FormMain.pathDataFolder + line))
                {
                    masterFiles.Insert(nextESMIndex, FuncParser.parserESPESM(FormMain.pathDataFolder + line));
                    listView1.Items.Insert(nextESMIndex, item);
                    nextESMIndex++;
                }
                else
                {
                    masterFiles.Add(FuncParser.parserESPESM(FormMain.pathDataFolder + line));
                    listView1.Items.Add(item);
                }
            }
        }
        void writeMasterFile()
        {
            List<string> writeList = new List<string>();
            foreach (ListViewItem item in listView1.Items)
            {
                if (!ignoreNames.Exists(s => s.Equals(item.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    if (item.Checked)
                    {
                        writeList.Add("*" + item.Text);
                    }
                    else
                    {
                        writeList.Add(item.Text);
                    }
                }
            }
            FuncFiles.writeToFile(pathToPlugins, writeList);
            writeList.Clear();
            label8.Text = listView1.CheckedItems.Count + " / " + listView1.Items.Count;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_ActivatedAll_Click(object sender, EventArgs e)
        {
            blockRefreshList = true;
            foreach (ListViewItem item in listView1.Items)
            {
                if (!item.Checked)
                {
                    checkItem(item, true);
                }
            }
            setFileID();
            writeMasterFile();
            blockRefreshList = false;
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_Restore_Click(object sender, EventArgs e)
        {
            FuncFiles.deleteAny(FormMain.pathAppData + "Plugins.txt");
            if (File.Exists(FormMain.pathSkyrimFolder + "Plugins.txt"))
            {
                FuncFiles.copyAny(FormMain.pathSkyrimFolder + "Plugins.txt", FormMain.pathAppData + "Plugins.txt");
            }
            else
            {
                FuncFiles.writeToFile(FormMain.pathAppData + "Plugins.txt", FuncSettings.pluginsTXT());
            }
            refreshModsList();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_RedateMods_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                DateTime dt = new DateTime(DateTime.Now.Year, 1, 1, 12, 0, 0, DateTimeKind.Local);
                foreach (string line in Directory.EnumerateFiles(FormMain.pathDataFolder, "*.bsa"))
                {
                    try
                    {
                        File.SetLastWriteTime(line, dt);
                    }
                    catch
                    {
                        MessageBox.Show(textDateChange + line);
                    }
                }
                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    try
                    {
                        File.SetLastWriteTime(FormMain.pathDataFolder + item.Text, dt);
                    }
                    catch
                    {
                        MessageBox.Show(textDateChange + FormMain.pathDataFolder + item.Text);
                    }
                    dt = dt.AddMinutes(1);
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_Low_Click(object sender, EventArgs e)
        {
            FuncSettings.setSettingsPreset(0);
            refreshSettings();
        }
        void button_Medium_Click(object sender, EventArgs e)
        {
            FuncSettings.setSettingsPreset(1);
            refreshSettings();
        }
        void button_Hight_Click(object sender, EventArgs e)
        {
            FuncSettings.setSettingsPreset(2);
            refreshSettings();
        }
        void button_Ultra_Click(object sender, EventArgs e)
        {
            FuncSettings.setSettingsPreset(3);
            refreshSettings();
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void comboBox_ResolutionTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iSize W", screenListW[comboBox_ResolutionTAB.SelectedIndex].ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iSize H", screenListH[comboBox_ResolutionTAB.SelectedIndex].ToString());
            aspectRatioFiles();
        }
        void refreshScreenResolution()
        {
            screenListW.Clear();
            screenListH.Clear();
            comboBox_ResolutionTAB.Items.Clear();
            FuncResolutions.Resolutions(selectedScreen);
            if (screenListW.Count == screenListH.Count && screenListW.Count > 0)
            {
                int count = screenListW.Count;
                for (int i = 0; i < count; i++)
                {
                    comboBox_ResolutionTAB.Items.Add(screenListW[i] + " x " + screenListH[i]);
                }
            }
            comboBox_ResolutionTAB.SelectedIndexChanged -= comboBox_ResolutionTAB_SelectedIndexChanged;
            comboBox_ResolutionTAB.SelectedIndex = comboBox_ResolutionTAB.Items.IndexOf(FuncParser.stringRead(FormMain.pathSkyrimPrefsINI, "Display", "iSize W") + " x " + FuncParser.stringRead(FormMain.pathSkyrimPrefsINI, "Display", "iSize H"));
            comboBox_ResolutionTAB.SelectedIndexChanged += comboBox_ResolutionTAB_SelectedIndexChanged;
            aspectRatioFiles();
        }
        void aspectRatioFiles()
        {
            if (comboBox_ResolutionTAB.SelectedIndex != -1)
            {
                FuncMisc.setAspectRatio(screenListW[comboBox_ResolutionTAB.SelectedIndex], screenListH[comboBox_ResolutionTAB.SelectedIndex]);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void comboBox_ScreenTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iAdapter", comboBox_ScreenTAB.SelectedIndex.ToString());
            selectedScreen = screens[comboBox_ScreenTAB.SelectedIndex].DeviceName;
            refreshScreenResolution();
        }
        void refreshScreenIndex()
        {
            comboBox_ScreenTAB.Items.Clear();
            if (screens.Length > 0)
            {
                int count = screens.Length;
                for (int i = 0; i < count; i++)
                {
                    comboBox_ScreenTAB.Items.Add(i.ToString());
                }
                int value = FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iAdapter");
                if (value >= 0 && value < comboBox_ScreenTAB.Items.Count)
                {
                    comboBox_ScreenTAB.SelectedIndexChanged -= comboBox_ScreenTAB_SelectedIndexChanged;
                    comboBox_ScreenTAB.SelectedIndex = value;
                    selectedScreen = screens[value].DeviceName;
                    comboBox_ScreenTAB.SelectedIndexChanged += comboBox_ScreenTAB_SelectedIndexChanged;
                }
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void comboBox_AATAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AATAB.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUseTAA", "0");
            }
            else if (comboBox_AATAB.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUseTAA", "0");
            }
            else if (comboBox_AATAB.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUseTAA", "1");
            }
        }
        void refreshAA()
        {
            if (FuncParser.stringRead(FormMain.pathSkyrimPrefsINI, "Display", "bFXAAEnabled") == "1")
            {
                comboBox_AATAB.SelectedIndex = 1;
            }
            else if (FuncParser.stringRead(FormMain.pathSkyrimPrefsINI, "Display", "bUseTAA") == "1")
            {
                comboBox_AATAB.SelectedIndex = 2;
            }
            else
            {
                comboBox_AATAB.SelectedIndex = 0;
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void comboBox_ShadowTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution", comboBox_ShadowTAB.SelectedItem.ToString());
        }
        void refreshShadow()
        {
            FuncMisc.refreshComboBox(comboBox_ShadowTAB, new double[] { 512, 1024, 2048, 4096 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iShadowMapResolution"), comboBox_ShadowTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void comboBox_DecalsTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DecalsTAB.SelectedIndex == 0)
            {
                setDecals("0", "0", "0", "0", "0", "0");
            }
            else if (comboBox_DecalsTAB.SelectedIndex == 1)
            {
                setDecals("1", "1", "100", "35", "10", "3");
            }
            else if (comboBox_DecalsTAB.SelectedIndex == 2)
            {
                setDecals("1", "1", "1000", "100", "100", "25");
            }
        }
        void setDecals(string bDecals, string bSkinnedDecals, string uMaxDecals, string uMaxSkinDecals, string iMaxDecalsPerFrame, string iMaxSkinDecalsPerFrame)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bDecals", bDecals);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "bSkinnedDecals", bSkinnedDecals);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxDecals", uMaxDecals);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxSkinDecals", uMaxSkinDecals);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxDecalsPerFrame", iMaxDecalsPerFrame);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Decals", "iMaxSkinDecalsPerFrame", iMaxSkinDecalsPerFrame);
        }
        void refreshDecals()
        {
            FuncMisc.refreshComboBox(comboBox_DecalsTAB, new double[] { 0, 100, 1000 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Decals", "uMaxDecals"), comboBox_DecalsTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void comboBox_ShadowQualityTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_ShadowQualityTAB.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iNumFocusShadow", "1");
            }
            else if (comboBox_ShadowQualityTAB.SelectedIndex == 1)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iNumFocusShadow", "2");
            }
            else if (comboBox_ShadowQualityTAB.SelectedIndex == 2)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iNumFocusShadow", "4");
            }
        }
        void refreshShadowQuality()
        {
            FuncMisc.refreshComboBox(comboBox_ShadowQualityTAB, new double[] { 1, 2, 4 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "Display", "iNumFocusShadow"), comboBox_ShadowQualityTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void comboBox_LODObjectsTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_LODObjectsTAB.SelectedIndex == 0)
            {
                setLODObjects("12500.0000", "100000.0000", "15000.0000", "25000.0000", "0.5000", "3500.0000", "5");
            }
            else if (comboBox_LODObjectsTAB.SelectedIndex == 1)
            {
                setLODObjects("75000.0000", "100000.0000", "20000.0000", "32000.0000", "1.1000", "4000.0000", "7");
            }
            else if (comboBox_LODObjectsTAB.SelectedIndex == 2)
            {
                setLODObjects("75000.0000", "250000.0000", "35000.0000", "70000.0000", "1.5000", "5000.0000", "9");
            }
            else if (comboBox_LODObjectsTAB.SelectedIndex == 3)
            {
                setLODObjects("75000.0000", "250000.0000", "60000.0000", "90000.0000", "1.5000", "16896.0000", "11");
            }
        }
        void setLODObjects(string fTreeLoadDistance, string fBlockMaximumDistance, string fBlockLevel0Distance, string fBlockLevel1Distance, string fSplitDistanceMult, string fTreesMidLODSwitchDist, string uLargeRefLODGridSize)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fTreeLoadDistance", fTreeLoadDistance);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockMaximumDistance", fBlockMaximumDistance);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel0Distance", fBlockLevel0Distance);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel1Distance", fBlockLevel1Distance);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fSplitDistanceMult", fSplitDistanceMult);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fTreesMidLODSwitchDist", fTreesMidLODSwitchDist);
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "General", "uLargeRefLODGridSize", uLargeRefLODGridSize);
        }
        void refreshLODObjects()
        {
            FuncMisc.refreshComboBox(comboBox_LODObjectsTAB, new double[] { 15000, 20000, 35000, 60000 }, FuncParser.intRead(FormMain.pathSkyrimPrefsINI, "TerrainManager", "fBlockLevel0Distance"), comboBox_LODObjectsTAB_SelectedIndexChanged);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void comboBox_VolumetricTAB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_VolumetricTAB.SelectedIndex == 0)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bVolumetricLightingEnable", "0");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iVolumetricLightingQuality", "0");
            }
            else
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bVolumetricLightingEnable", "1");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iVolumetricLightingQuality", (comboBox_VolumetricTAB.SelectedIndex - 1).ToString());
            }
        }
        void refreshVolumetricLighting()
        {
            if (FuncParser.stringRead(FormMain.pathSkyrimPrefsINI, "Display", "bVolumetricLightingEnable") != "0")
            {
                FuncMisc.refreshComboBox(comboBox_VolumetricTAB, new double[] { 0, 1, 2, 3 }, FuncParser.doubleRead(FormMain.pathSkyrimPrefsINI, "Display", "iVolumetricLightingQuality") + 1, comboBox_VolumetricTAB_SelectedIndexChanged);
            }
            else
            {
                FuncMisc.refreshComboBox(comboBox_VolumetricTAB, new double[] { 0 }, 0, comboBox_VolumetricTAB_SelectedIndexChanged);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_Papyrus_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Papyrus", "bEnableLogging", Convert.ToInt32(!papyrus).ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Papyrus", "bEnableTrace", Convert.ToInt32(!papyrus).ToString());
            refreshPapyrus();
        }
        void refreshPapyrus()
        {
            papyrus = FuncMisc.refreshButton(button_Papyrus, FormMain.pathSkyrimINI, "Papyrus", "bEnableLogging");
            if (papyrus)
            {
                FuncFiles.creatDirectory(pathMyDocLogs);
            }
        }
        void button_LogsFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pathMyDocLogs))
            {
                Process.Start(pathMyDocLogs);
            }
            else if (Directory.Exists(FormMain.pathMyDoc))
            {
                Process.Start(FormMain.pathMyDoc);
            }
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_SAOTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bSAOEnable", Convert.ToInt32(!sao).ToString());
            refreshSAO();
        }
        void refreshSAO()
        {
            sao = FuncMisc.refreshButton(button_SAOTAB, FormMain.pathSkyrimPrefsINI, "Display", "bSAOEnable");
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_PrecipitationTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUsePrecipitationOcclusion", Convert.ToInt32(!precipitation).ToString());
            refreshPrecipitation();
        }
        void refreshPrecipitation()
        {
            precipitation = FuncMisc.refreshButton(button_PrecipitationTAB, FormMain.pathSkyrimPrefsINI, "Display", "bUsePrecipitationOcclusion");
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_ProjecteUVTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bEnableProjecteUVDiffuseNormals", Convert.ToInt32(!projecteuv).ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bToggleSparkles", Convert.ToInt32(!projecteuv).ToString());
            refreshProjecteUV();
        }
        void refreshProjecteUV()
        {
            projecteuv = FuncMisc.refreshButton(button_ProjecteUVTAB, FormMain.pathSkyrimPrefsINI, "Display", "bEnableProjecteUVDiffuseNormals") && FuncMisc.refreshButton(button_ProjecteUVTAB, FormMain.pathSkyrimPrefsINI, "Display", "bToggleSparkles");
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_64TAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bUse64bitsHDRRenderTarget", Convert.ToInt32(!r64).ToString());
            refresh64();
        }
        void refresh64()
        {
            r64 = FuncMisc.refreshButton(button_64TAB, FormMain.pathSkyrimPrefsINI, "Display", "bUse64bitsHDRRenderTarget");
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_ReflectionTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bScreenSpaceReflectionEnabled", Convert.ToInt32(!reflection).ToString());
            refreshReflection();
        }
        void refreshReflection()
        {
            reflection = FuncMisc.refreshButton(button_ReflectionTAB, FormMain.pathSkyrimPrefsINI, "Display", "bScreenSpaceReflectionEnabled");
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_LensTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bIBLFEnable", Convert.ToInt32(!lens).ToString());
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Imagespace", "bLensFlare", Convert.ToInt32(!lens).ToString());
            refreshLens();
        }
        void refreshLens()
        {
            lens = FuncMisc.refreshButton(button_LensTAB, FormMain.pathSkyrimPrefsINI, "Display", "bIBLFEnable") && FuncMisc.refreshButton(button_LensTAB, FormMain.pathSkyrimPrefsINI, "Imagespace", "bLensFlare");
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_VsyncTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "iVSyncPresentInterval", Convert.ToInt32(!vsync).ToString());
            refreshVsync();
        }
        void refreshVsync()
        {
            vsync = FuncMisc.refreshButton(button_VsyncTAB, FormMain.pathSkyrimPrefsINI, "Display", "iVSyncPresentInterval");
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_WindowTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bFull Screen", Convert.ToInt32(window).ToString());
            refreshWindow();
        }
        void refreshWindow()
        {
            window = FuncMisc.refreshButton(button_WindowTAB, FormMain.pathSkyrimPrefsINI, "Display", "bFull Screen", false, null, true);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_BorderlessTAB_Click(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "bBorderless", Convert.ToInt32(!borderless).ToString());
            refreshBorderless();
        }
        void refreshBorderless()
        {
            borderless = FuncMisc.refreshButton(button_BorderlessTAB, FormMain.pathSkyrimPrefsINI, "Display", "bBorderless");
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_HideObjectsTAB_Click(object sender, EventArgs e)
        {
            if (hideobjects)
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", "16896.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel2FadeDist", "16896.0000");
            }
            else
            {
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", "4096.0000");
                FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel2FadeDist", "3072.0000");
            }
            refreshHideObjects();
        }
        void refreshHideObjects()
        {
            hideobjects = FuncMisc.refreshButton(button_HideObjectsTAB, FormMain.pathSkyrimPrefsINI, "Display", "fMeshLODLevel1FadeDist", false, "4096.0000");
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void trackBar_GrassDensityTAB_Scroll(object sender, EventArgs e)
        {

            FuncParser.iniWrite(FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", (trackBar_GrassDensityTAB.Value * 5).ToString());
            label26TAB.Text = (trackBar_GrassDensityTAB.Value * 5).ToString();
        }
        void refreshGrass()
        {
            FuncMisc.refreshTrackBar(trackBar_GrassDensityTAB, FormMain.pathSkyrimINI, "Grass", "iMinGrassSize", label26TAB, 5);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void trackBar_GrassDistanceTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", (trackBar_GrassDistanceTAB.Value * 1000).ToString());
            label37TAB.Text = (trackBar_GrassDistanceTAB.Value * 1000).ToString();
        }
        void refreshGrassDistance()
        {
            FuncMisc.refreshTrackBar(trackBar_GrassDistanceTAB, FormMain.pathSkyrimPrefsINI, "Grass", "fGrassStartFadeDistance", label37TAB, 1000);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void trackBar_ObjectsTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", (trackBar_ObjectsTAB.Value).ToString());
            label28TAB.Text = trackBar_ObjectsTAB.Value.ToString();
        }
        void refreshObjects()
        {
            FuncMisc.refreshTrackBar(trackBar_ObjectsTAB, FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultObjects", label28TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void trackBar_ItemsTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", (trackBar_ItemsTAB.Value).ToString());
            label35TAB.Text = trackBar_ItemsTAB.Value.ToString();
        }
        void refreshItems()
        {
            FuncMisc.refreshTrackBar(trackBar_ItemsTAB, FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultItems", label35TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void trackBar_ActorsTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", (trackBar_ActorsTAB.Value).ToString());
            label30TAB.Text = trackBar_ActorsTAB.Value.ToString();
        }
        void refreshActors()
        {
            FuncMisc.refreshTrackBar(trackBar_ActorsTAB, FormMain.pathSkyrimPrefsINI, "LOD", "fLODFadeOutMultActors", label30TAB);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void trackBar_LightsTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", (trackBar_LightsTAB.Value * 100).ToString());
            label32TAB.Text = (trackBar_LightsTAB.Value * 100).ToString();
        }
        void refreshLights()
        {
            FuncMisc.refreshTrackBar(trackBar_LightsTAB, FormMain.pathSkyrimPrefsINI, "Display", "fLightLODStartFade", label32TAB, 100);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void trackBar_ShadowTAB_Scroll(object sender, EventArgs e)
        {
            FuncParser.iniWrite(FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", (trackBar_ShadowTAB.Value * 500).ToString());
            label39TAB.Text = (trackBar_ShadowTAB.Value * 500).ToString();
        }
        void refreshShadowRange()
        {
            FuncMisc.refreshTrackBar(trackBar_ShadowTAB, FormMain.pathSkyrimPrefsINI, "Display", "fShadowDistance", label39TAB, 500);
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void buttons_ChangeTabs_Click(object sender, EventArgs e)
        {
            foreach (Control line in Controls)
            {
                if (line.Name.EndsWith("TAB"))
                {
                    line.Visible = !line.Visible;
                }
            }
            button_Common.Enabled = !button_Common.Enabled;
            button_Distance.Enabled = !button_Distance.Enabled;
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