using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog
{
    public partial class Form2 : Form
    {
        public Peptide peptide = new Peptide();

        public Form2(Peptide _peptide)
        {
            InitializeComponent();
            peptide = _peptide;
        }

        private void setMarkerGrid()
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            for (int i = 0; i < peptide.markers.Count(); i++)
            {
                dgvr = new DataGridViewRow();
                dgvr.CreateCells(dataGridView1, peptide.markers[i].position, peptide.markers[i].label, Convert.ToString(Convert.ToBoolean(peptide.markers[i].check)), peptide.markers[i].splitting);
                dataGridView1.Rows.Add(dgvr);
            }
        }

        private void setLabelGrid()
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            for (int i = 0; i < peptide.labels.Count(); i++)
            {
                dgvr = new DataGridViewRow();
                dgvr.CreateCells(dataGridView2, peptide.labels[i].name, peptide.labels[i].alpha, peptide.labels[i].beta, peptide.labels[i].psi);
                dataGridView2.Rows.Add(dgvr);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = true;
            try
            {
                peptide.name = textBox1.Text;
                peptide.tau = int.Parse(textBox2.Text);
                peptide.rho = int.Parse(textBox3.Text);
                peptide.sMol = double.Parse(textBox4.Text);

                peptide.setMarker(dataGridView1.RowCount - 1);
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    peptide.markers[i].position = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    peptide.markers[i].label = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString() == "True") peptide.markers[i].check = 1;
                    else peptide.markers[i].check = 0;
                    peptide.markers[i].splitting = Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }

                peptide.setLabel(dataGridView2.RowCount - 1);
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    peptide.labels[i].name = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    peptide.labels[i].alpha = Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value.ToString());
                    peptide.labels[i].beta = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value.ToString());
                    peptide.labels[i].psi = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong input!" + ex.Message);
                ok = false;
            }
            finally
            {
                if (ok)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (peptide != null)
            {
                textBox1.Text = peptide.name;
                textBox2.Text = peptide.tau + "";
                textBox3.Text = peptide.rho + "";
                textBox4.Text = peptide.sMol + "";
                
                setMarkerGrid();
                setLabelGrid();
            }
        }
    }
}
