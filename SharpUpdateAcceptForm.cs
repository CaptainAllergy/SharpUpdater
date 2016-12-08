using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpUpdate
{
    internal partial class SharpUpdateAcceptForm : Form
    {
        private ISharpUpdateable applicationInfo;

        private SharpUpdateXML updateInfo;

        private SharpUpdateInfoForm updateInfoForm;

        internal SharpUpdateAcceptForm(ISharpUpdateable applicationInfo, SharpUpdateXML updateInfo)
        {
            InitializeComponent();

            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;

            this.Text = this.applicationInfo.ApplicationName + " - Update Available";

            if (this.applicationInfo.ApplicationIcon != null)
            {
                this.Icon = this.applicationInfo.ApplicationIcon;
            }

            this.label1.Text = String.Format("New Version: {0}", this.updateInfo.Version.ToString());
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (this.updateInfoForm == null)
            {
                this.updateInfoForm = new SharpUpdateInfoForm(this.applicationInfo, this.updateInfo);
            }

            this.updateInfoForm.ShowDialog(this);
        }
    }
}
