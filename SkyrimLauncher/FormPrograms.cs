using System;
using System.Windows.Forms;

namespace SkyrimLauncher
{
    public partial class FormPrograms : Form
    {
        public FormPrograms()
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
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void imageBackgroundImage()
        {
            BackgroundImage = Properties.Resources.FormBackground;
            label2.ForeColor = System.Drawing.SystemColors.ControlLight;
        }
        void langTranslateEN()
        {
            label2.Text = "Unpack programs into" + Environment.NewLine + "the game directory:";
        }
        // ------------------------------------------------ BORDER OF FUNCTION ------------------------------------------------ //
        void button_CreationKit_Click(object sender, EventArgs e)
        {
            programsUnpack("CreationKit");
        }
        void button_TES5Edit_Click(object sender, EventArgs e)
        {
            programsUnpack("TES5Edit");
        }
        void button_TES5LODGen_Click(object sender, EventArgs e)
        {
            programsUnpack("TES5LODGen");
        }
        void programsUnpack(string FileName)
        {
            FuncMisc.toggleButtons(this, false);
            FuncFiles.unpackArhive(FormMain.pathProgramsFolder + FileName, true);
            FuncMisc.toggleButtons(this, true);
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