using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EElmore_CPT206_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'allStatesDBDataSet.AllStates' table. You can move, or remove it, as needed.
            this.allStatesTableAdapter.Fill(this.allStatesDBDataSet.AllStates);

        }

        //Adds a new blank row to the database
        private void btnAdd_Click(object sender, EventArgs e) 
        {
            try
            {
                allStatesBindingSource.AddNew();
            }
            catch
            {
                MessageBox.Show("Error, Please Try Again");
            }
        }
        
        //Deletes the currently selected row to the database
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (allStatesBindingSource.Current != null)
                    allStatesBindingSource.RemoveCurrent();
            }
            catch
            {
                MessageBox.Show("Error, Please Try Again");
            }
        }

        //Saves any changes or new rows back to the database
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.allStatesBindingSource.EndEdit();
                this.allStatesTableAdapter.Update(this.allStatesDBDataSet.AllStates);
                MessageBox.Show("Database Updated Successfully!");
            }
            catch
            {
                MessageBox.Show("Error, Please Try Again");
            }
        }


        //Searches the database using the filter and text box
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    allStatesBindingSource.RemoveFilter();
                    return;
                }

                string column = cmbFilter.Text;

                allStatesBindingSource.Filter = "Convert(" + column + ", 'System.String') LIKE '" + txtSearch.Text + "%'";

            }
            catch
            {
                MessageBox.Show("Error, Please Try Again");
            }

        }

        //Filters the database
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                allStatesBindingSource.Filter = "Name = '" + cmbFilter.Text + "'";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, Please Try Again");
            }
        }

        //Takes the database info and prints it on form2
        private void btnDetails_Click(object sender, EventArgs e)
        {

            try
            {
                
                DataGridViewRow row = dataGridView1.CurrentRow;
                StateLibrary.Class1 selected = new StateLibrary.Class1
                {
                  
                    Name = row.Cells[1].Value.ToString(),
                    Population = int.Parse(row.Cells[2].Value.ToString()),
                    FlagDescription = row.Cells[3].Value.ToString(),
                    Flower = row.Cells[4].Value.ToString(),
                    Bird = row.Cells[5].Value.ToString(),
                    Colors = row.Cells[6].Value.ToString(),
                    LargestCity1 = row.Cells[7].Value.ToString(),
                    LargestCity2 = row.Cells[8].Value.ToString(),
                    LargestCity3 = row.Cells[9].Value.ToString(),
                    Capitol = row.Cells[10].Value.ToString(),
                    MedianIncome = decimal.Parse(row.Cells[11].Value.ToString()),
                    ComputerJobs = double.Parse(row.Cells[12].Value.ToString())
                };

      
                Details detailsPage = new Details(selected);
                detailsPage.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error,Please try again.");
            }
        }

        //Closes the Form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Clears the form
        private void btnClear_Click(object sender, EventArgs e)
        {
            allStatesBindingSource.RemoveFilter();
            txtSearch.Clear();
            
        }
    }
    }



