using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StateLibrary;
using System.Windows.Forms;



namespace EElmore_CPT206_Lab3
{
    public partial class Details : Form
    {
        public Details(StateLibrary.Class1 selectedState)
        {
            InitializeComponent();

            //Fills the labels on the page with the data from form1
            lblStateName.Text = selectedState.Name;
            lblPopulation.Text = selectedState.Population.ToString("N0");
            lblFlag.Text = selectedState.FlagDescription;
            lblFlower.Text = selectedState.Flower;
            lblBird.Text = selectedState.Bird;
            lblColors.Text = selectedState.Colors;
            lblCities.Text = $"{selectedState.LargestCity1}, {selectedState.LargestCity2}, {selectedState.LargestCity3}";
            lblCapital.Text = selectedState.Capitol;
            lblIncome.Text = selectedState.MedianIncome.ToString("C");
            lblJobs.Text = selectedState.ComputerJobs.ToString() + "%";
        }

        //Closes Form
        private void btnExit_Click(object sender, EventArgs e) 
        {
            this.Close();
        }
    }
}
