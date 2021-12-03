using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessCap;
using DataCap;

namespace PresentationCap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Vamos a hacer instancia de los dos tipos de capa para poder manipular
        EntitieQuery queryData = new EntitieQuery();
        QueryMethodsBC methodsBC = new QueryMethodsBC();
        #region Events
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                validateFields();
                fillData();
                clearDataInTextBox(1);
                showInDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                validateFields();
                fillData();
                clearDataInTextBox(1);
                showInDgv();
                btnCreate.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                validateFields();
                deleteRegister();
                clearDataInTextBox(1);
                showInDgv();
                btnCreate.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void txtId_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                showDataInTextBox();
                btnCreate.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception)
            {
                clearDataInTextBox(0);
                btnCreate.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'queriesDataSet.Querie' table. You can move, or remove it, as needed.
            this.querieTableAdapter.Fill(this.queriesDataSet.Querie);
            for (int i = 1; i < 15; i++)
                cbNumberWeek.Items.Add(i);
            showInDgv();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.justNumbers(e);
        }
        private void txtTopic_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidateTextBox.justLetters(e);
        }
        #endregion
        #region Functions

        private void deleteRegister()
        {
            methodsBC.Delete(int.Parse(txtId.Text));
        }
        private void fillData()
        {
            queryData.id = int.Parse(txtId.Text);
            queryData.numberWeek = int.Parse(cbNumberWeek.Text);
            queryData.numberStudent = int.Parse(txtNumberStudent.Text);
            queryData.topic = txtTopic.Text;
            queryData.observations = txtObservations.Text;
            queryData.idStudent = txtIdStudent.Text;
            queryData.signStudent = txtSignStudent.Text;
            queryData.Date = DateTime.Now;
            if (btnCreate.Enabled == false)
            {
                methodsBC.Update(queryData);
            }else if(btnCreate.Enabled == true)
            {
                methodsBC.Create(queryData);
            }
        }
        private void showDataInTextBox()
        {
            // Mostramos los datos 
            Querie q = methodsBC.Read(int.Parse(txtId.Text));
            txtId.Text = Convert.ToString(q.id);
            cbNumberWeek.Text = Convert.ToString(q.numberWeek);
            txtNumberStudent.Text = Convert.ToString(q.numberStudent);
            txtTopic.Text = Convert.ToString(q.topic);
            txtObservations.Text = Convert.ToString(q.observations);
            txtIdStudent.Text = Convert.ToString(q.idStudent);
            txtSignStudent.Text = Convert.ToString(q.signStudent);
        }
        private void showInDgv()
        {
            dgvQueries.DataSource = null;
            dgvQueries.DataSource = methodsBC.ReadAll();
        }
        private void clearDataInTextBox(int type)
        {
            if (type == 1)
                txtId.Clear();
            cbNumberWeek.Text = " ";
            txtNumberStudent.Clear();
            txtTopic.Clear();
            txtObservations.Clear();
            txtIdStudent.Clear();
            txtSignStudent.Clear();
        }
        public void validateFields()
        {
            //Que Los campos no esten vacios
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtTopic.Text) || string.IsNullOrWhiteSpace(txtNumberStudent.Text)
                || string.IsNullOrWhiteSpace(txtObservations.Text) || string.IsNullOrWhiteSpace(txtIdStudent.Text) || string.IsNullOrWhiteSpace(txtSignStudent.Text))
                throw new Exception("Todos los campos son requeridos");
        }
        #endregion
    }
}
