﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trains
{
    public partial class TrnSearch : Form
    {
        public TrnSearch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();      
        }

        public Form PreviousForm { get; set;}

        private void byNumber_CheckedChanged(object sender, EventArgs e)
        {
            gBByNumber.Enabled  = byNumber.Checked;
            gBByParams.Enabled  = byParams.Checked;
        }

        private void byParams_CheckedChanged(object sender, EventArgs e)
        {
            gBByNumber.Enabled  = byNumber.Checked;
            gBByParams.Enabled  = byParams.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (byNumber.Checked)
            {
                TrnResultByNumber FormResultTrainByNumber   = new TrnResultByNumber();
                FormResultTrainByNumber.Owner               = this;
                this.Visible                                = false;

                Train Trn = Train.Search(Convert.ToInt32(MTBID.Text));
                FormResultTrainByNumber.ResultNumber.Text       = Trn.Number.ToString();
                FormResultTrainByNumber.ResultPlaceDepart.Text  = Trn.TimeOfDeparture;
                FormResultTrainByNumber.ResultPlaceArrive.Text  = Trn.TimeOfArrival;
                FormResultTrainByNumber.ShowDialog();

            }
        }

    }
}
