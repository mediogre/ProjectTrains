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
    public partial class FormEditRoute : Form
    {
        public FormEditRoute()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void FormEditRoute_Activated(object sender, EventArgs e)
        {
            List<Station> stns = Station.Search();

        }
    }
}
