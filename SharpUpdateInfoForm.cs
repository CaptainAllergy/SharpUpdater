using System;
using System.Windows.Forms;

namespace SharpUpdate
{
    internal partial class SharpUpdateInfoForm : Form
    {
        internal SharpUpdateInfoForm(ISharpUpdateable applicationInfo, SharpUpdateXML updateInfo)
        {
            InitializeComponent();

            if ( applicationInfo.ApplicationIcon != null)
            {
                this.Icon = applicationInfo.ApplicationIcon;
            }

            this.Text = applicationInfo.ApplicationName + " -Update Info";
            this.lblVersions.Text = String.Format("Current Version: {0}\nUpdate Version: {1}", applicationInfo.ApplicationAssembly.GetName().Version.ToString(), updateInfo.Version.ToString());
            this.txtDescription.Text = updateInfo.Description;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.Control && e.KeyCode == Keys.C))
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
