using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;




namespace KX3_CHATTERBOX
{
    public partial class KX3_CHATTERBOX : Form
    {
        string VFOA = "A";
        string VFOB = "";

        int  mtbVFOBand, tbVFOBBand;

        string FREQUENCY = "N";
        private Timer _Timer = new Timer();
        string current_mode = "LSB";
        int currentmode_number = 0;
 
        // band plan basic
        string[] bandplan = new string[] {"1800","2000","3500","4000","5300","5400","7000","7300","10000","10150","14000","143500","18068","18168","21000","21450","24890","24990","28000","29700","50000","54000"};
        int currentBand = 0;
        // modes
        string[] modes = new string[] {"LSB","USB","CW","REV","DATA","AM-S","FM T","+ -"};
 
        public KX3_CHATTERBOX()
        {
            InitializeComponent();
            //test serial code
        }

        private void KX3_CHATTERBOX_Load(object sender, EventArgs e)
        {
            _Timer.Interval = 1000;
            _Timer.Tick += new EventHandler(_Timer_Tick);
            _Timer.Start();

            // initial band set
            mtbVFO.Text = bandplan[currentBand];

            // build mode set
            lbMODES.Items.AddRange(modes);

            //set default mode
            currentmode_number = 0;
            lbMODES.SetSelected(currentmode_number, true);


            // Make a serial connection

            SerialPort mySerialPort = new SerialPort("COM4");

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

            //mySerialPort.Open();

            //mySerialPort.Close();
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
        }

    
        private void btnBandUp_Click(object sender, EventArgs e)
        {
            if (VFOA == "A")
            {
                currentBand = mtbVFOBand;
            }
            else
            {
                currentBand = tbVFOBBand;
            }
            
            if (currentBand <= 20)
            {
                currentBand += 1;
            }
            if (VFOA == "A")
            {
                mtbVFO.Text = bandplan[currentBand];
                mtbVFOBand = currentBand;
            }
            else
            {
                tbVFOB.Text = bandplan[currentBand];
                tbVFOBBand = currentBand;
            }

        }

        private void btnFreqent_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                FREQUENCY = "N";
            }
            else
            {
                FREQUENCY = "Y";
            }
        }

        private void btnXMIT_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "0";
            }
            else
            {

            }
        }

        private void btnPRE_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "1";
            }
            else
            {

            }
        }

        private void btnATTN_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "2";
            }
            else
            {

            }
        }

        private void btnAPF_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "3";
            }
            else
            {

            }
        }

        private void btnSPOT_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "4";
            }
            else
            {

            }
        }

        private void btnCMP_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "5";
            }
            else
            {

            }
        }

        private void btnDLY_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "6";
            }
            else
            {

            }
        }

        private void btnAFRFSQL_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "7";
            }
            else
            {

            }
        }

        private void btnPBTIII_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "8";
            }
            else
            {

            }
        }

        private void btnKeyerMic_Click(object sender, EventArgs e)
        {
            if (FREQUENCY == "Y")
            {
                mtbVFO.Text += "9";
            }
            else
            {

            }
        }

        private void btnBandDown_Click(object sender, EventArgs e)
        {
            if (VFOA == "A")
            {
                currentBand = mtbVFOBand;
            }
            else
            {
                currentBand = tbVFOBBand;
            }
            
            if (currentBand > 0)
            {
                currentBand -= 1;
            }

            if (VFOA == "A")
            {
                mtbVFO.Text = bandplan[currentBand];
                mtbVFOBand = currentBand;
            }
            else
            {
                tbVFOB.Text = bandplan[currentBand];
                tbVFOBBand = currentBand;
            }

        }

        void _Timer_Tick(object sender, EventArgs e)
        {
            // standard large
            this.mtbSystemTime.Text = DateTime.Now.TimeOfDay.ToString();

            // display in the small window for when VFOB is active
            this.mtbSystemTimesmall.Text = DateTime.Now.TimeOfDay.ToString();

            //this.mtbSystemTime.Text = DateTime..Now.ToString();
        }

        private void btnVFODown_Click(object sender, EventArgs e)
        {

        }

        private void btnVFOUp_Click(object sender, EventArgs e)
        {

        }

        private void btnMODE_Click(object sender, EventArgs e)
        {
            //find the currently selected mode

            currentmode_number = lbMODES.SelectedIndices[0]; // this will only work for single select!

            if (currentmode_number < 7)
            {
                lbMODES.SetSelected(currentmode_number, false);
                currentmode_number += 1;
                lbMODES.SetSelected(currentmode_number, true);

                // need to send code to rig here

            }
            else
            {
                lbMODES.SetSelected(currentmode_number, false);
                currentmode_number = 0;
                lbMODES.SetSelected(currentmode_number, true);

                // need to send code to rig here

            }

        }

        private void btnAANB_Click(object sender, EventArgs e)
        {

        }

        private void btnDATA_Click(object sender, EventArgs e)
        {

        }

        private void btnATOB_Click(object sender, EventArgs e)
        {
            if (this.tbVFOB.Visible == false)
            {
                this.tbVFOB.Text = this.mtbVFO.Text;
                this.tbVFOBBand = this.mtbVFOBand;

                // so now show the vfob box
                this.tbVFOB.Visible = true;

                // show small clock
                this.mtbSystemTimesmall.Visible = true;
            }
            else // not using VFOB anymore
            {
                // so now show the vfob box
                this.tbVFOB.Visible = false;

                // show small clock
                this.mtbSystemTimesmall.Visible = false;
            }

        }

        private void btnRIT_Click(object sender, EventArgs e)
        {

        }

        private void btnXIT_Click(object sender, EventArgs e)
        {

        }

        private void btnCLR_Click(object sender, EventArgs e)
        {

        }

        private void btnRate_Click(object sender, EventArgs e)
        {

        }

        private void btnDISP_Click(object sender, EventArgs e)
        {

        }

        private void btnMSG_Click(object sender, EventArgs e)
        {

        }

        private void btnATUTune_Click(object sender, EventArgs e)
        {

        }

        private void mtbVFO_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mtbSystemTime_MouseHover(object sender, EventArgs e)
        {
            //this.tbVFOB.Visible = true;
        }

        private void mtbSystemTime_MouseLeave(object sender, EventArgs e)
        {
            //this.tbVFOB.Visible = false;
        }

        private void tbVFOB_Click(object sender, EventArgs e)
        {
            // set the active vfo
            VFOB = "A";
            VFOA = "";
        }

        private void mtbVFO_Click(object sender, EventArgs e)
        {
            // set the active vfo
            VFOB = "";
            VFOA = "A";
        }
         
    }
}
