using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TotalPhase;

namespace CameraTest
{
    public partial class CameraTestForm : Form
    {
        public CameraTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ushort[] ports = new ushort[16];
            uint[] uniqueIds = new uint[16];
            int numElem = 16;
            byte[] Sreg = new byte[4];
            byte[] Cmd = new byte[4];

            // Find all the attached devices
            int count = AardvarkApi.aa_find_devices_ext(numElem, 
                                                        ports,
                                                        numElem, 
                                                        uniqueIds);
        }
    }
}
