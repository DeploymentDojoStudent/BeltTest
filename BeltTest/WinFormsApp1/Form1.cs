using Microsoft.Win32;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.EditionValue.Text = (string?)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Edition", null);
            this.CustomerValue.Text = (string?)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Customer", null);
        }
    }
}