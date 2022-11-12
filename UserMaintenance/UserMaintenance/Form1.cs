﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "Vesszövel tagolt szöveg (*.csv) |*.csv";
            sfd.DefaultExt = "csv";
            sfd.AddExtension = true;


            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, true, Encoding.UTF8))
                {
                    foreach (User u in users)
                    {
                        sw.WriteLine($"{u.ID};{u.FullName}");
                    }
                }
            }
        }


        private void btnAdd3_Click(object sender, EventArgs e)
        {
            var selectID = ((Guid)listBox1.SelectedValue);
            Console.WriteLine(selectID);

            var userSelect = (from u in users
                              where selectID == u.ID
                              select u).FirstOrDefault(); 
            users.Remove(userSelect);

        }

    }
}