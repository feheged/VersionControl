﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    { 
        BindingList<User> users = new BindingList<User>();




    
        public Form1()
        {
            InitializeComponent();
            
            lblFullName.Text = Resource1.FullName;
            btnAdd.Text = Resource1.Add;

            listBox1.DataSource = users; ///megoldasban listusers
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User u = new User();
            
            u.FullName = textBox1.Text; //txtFullName
            users.Add(u);
        }
    }
}