﻿using DevExpressLookUpEditWinforms.modelado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpressLookUpEditWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getData();
        }

        private async void getData()
        {
            using (AdventureWorksDW2017Entities entities = new AdventureWorksDW2017Entities())
            {
                lookUpEdit1.Properties.DataSource = await entities.DimPromotion.ToListAsync();
                lookUpEdit1.Properties.DisplayMember = "EnglishPromotionName";
                lookUpEdit1.Properties.ValueMember = "PromotionKey";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //it checks if any item on the lookupedit control has been selected or not
            MessageBox.Show(lookUpEdit1.EditValue != null ? lookUpEdit1.EditValue.ToString() : "Please select a promotion", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
