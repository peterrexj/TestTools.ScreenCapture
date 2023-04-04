using Pj.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTools.ScreenCapture
{
    public partial class frmHelp : Form
    {
        public frmHelp(string typeOfForm)
        {
            InitializeComponent();

            using (Stream strm = AssemblyEx.GetEmbeddedResourceAsStream(PjUtility.Runtime.GetAssembly("TestTools.ScreenCapture"),
                    $"TestTools.ScreenCapture.Resources.{(typeOfForm == "Help" ? "HelpContent.rtf" : "About.rtf")}"))
            {
                richTextbox.LoadFile(strm, RichTextBoxStreamType.RichText);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
