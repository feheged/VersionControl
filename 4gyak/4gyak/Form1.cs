using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace _4gyak
{
    public partial class Form1 : Form
    {

        List<Flat> flats;
        RealEstateEntities re = new RealEstateEntities();

        Excel.Application xlApp; // A Microsoft Excel alkalmazás
        Excel.Workbook xlWB; // A létrehozott munkafüzet
        Excel.Worksheet xlSheet; // Munkalap a munkafüzeten belül


        void LoadData()
        {
            flats = re.Flat.ToList();
        }


        void CreateExcel()
        {
            try
            {
                xlApp = new Excel().Application();
                xlWB = xlApp.workbooks.Add();
                xlSheet = xlWB.ActiveSheet;


                CreateTable();


                xlApp.Visible = true;
                xlApp.UserControl = true;
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Source + '\n' + ex.Message);
                xlWB.Close(false);
                xlApp.Quite();
                xlApp = null;
                xlWB = null;
            }

        }

        private void CreateTable()
        {
            ///throw new NotImplementedException();
        }

        public Form1()
        {
            InitializeComponent();
            LoadData();

        }
    }
}
