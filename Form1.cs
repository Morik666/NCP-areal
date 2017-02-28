using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Prog
{
    public partial class Form1 : Form
    {
        public Peptide peptide = new Peptide();

        public Form1(Peptide _peptide)
        {
            InitializeComponent();
            peptide = _peptide;
        }

        private void directTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream fStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //TODO: change ititial directory
            openFileDialog1.InitialDirectory = "d:\\";
            //TODO: design new container
            openFileDialog1.Filter = "prg files (*.prg)|*.prg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((fStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (fStream)
                        {
                            //TODO: fix overflow
                            byte[] fReader = new byte[1000];
                            while (fStream.Read(fReader, 0, fReader.Length) > 0)
                            {
                                string file = System.Text.Encoding.UTF8.GetString(fReader, 0, fReader.Length);
                                string[] parts = file.Split('&');
                                //TODO: design new container
                                string[] part = parts[0].Split('|');
                                string[] marks = parts[1].Split('\n');
                                string[] labes = parts[2].Split('\n');

                                peptide.name = part[0];
                                peptide.tau = int.Parse(part[1]);
                                peptide.rho = int.Parse(part[2]);
                                peptide.sMol = double.Parse(part[3]);
                                peptide.setMarker(marks.Count());
                                peptide.setLabel(labes.Count());

                                int i = 0;

                                //peptide.markers[0].position = new int();

                                foreach(string mark in marks)
                                {
                                    string[] items = mark.Split('|');
                                    peptide.markers[i].position = int.Parse(items[0]);
                                    peptide.markers[i].label = int.Parse(items[1]);
                                    peptide.markers[i].check = int.Parse(items[2]);
                                    peptide.markers[i].splitting = double.Parse(items[3]);
                                    i++;
                                }
                                i = 0;
                                foreach(string labe in labes)
                                {
                                    string[] items = labe.Split('|');
                                    peptide.labels[i].name = items[0];
                                    peptide.labels[i].alpha = double.Parse(items[1]);
                                    peptide.labels[i].beta = double.Parse(items[2]);
                                    peptide.labels[i].psi = double.Parse(items[3]);
                                    i++;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void getInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            peptide.directTask();
            //TODO: implement callback from GUI
            //peptide.rmsd = 5;
            /*int activeLabelCount = 0;
            foreach (Label label in labels)
                if (label.check == 1)
                    activeLabelCount++;

            peptide.labels = new Label[activeLabelCount];
            int i = 0;
            foreach (Label label in labels)
                if (label.check == 1)
                    peptide.markers[i++] = label;*/


            ChartValues<HeatPoint> chartValues = new ChartValues<HeatPoint>();
            for (int i = 0; i < peptide.tauRhoPlotDimension / 2; i++)
            {
                for (int j = 0; j < peptide.tauRhoPlotDimension / 2; j++)
                {
                    chartValues.Add(new HeatPoint(i, j, peptide.tauRhoPlot[i*2][j*2]));
                }
            }

            cartesianChart1.DisableAnimations = true;

            cartesianChart1.Series.Add(new HeatSeries
            {
                Values = chartValues,
                DataLabels = false,
                StrokeThickness = 0,


                GradientStopCollection = new GradientStopCollection
                    {
                        new GradientStop(System.Windows.Media.Color.FromRgb(255, 255, 255), 0),
                        new GradientStop(System.Windows.Media.Color.FromRgb(200, 0, 0), 0.6),
                        new GradientStop(System.Windows.Media.Color.FromRgb(150, 0, 0), 0.9),
                        new GradientStop(System.Windows.Media.Color.FromRgb(0, 0, 0), 1)
                    }
            });
        }

        private void editPeptideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Form2 frm = new Form2(peptide);
            frm.ShowDialog();*/
            using (Form2 form2 = new Form2(peptide))
            {
                var result = form2.ShowDialog();
                if (result == DialogResult.OK)
                {
                    peptide = form2.peptide;
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(peptide.markers[peptide.markers.Count() - 1].ToString());
        }
    }
}
