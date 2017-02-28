using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog
{
    public class Peptide
    {
        public String name { get; set; }

        public int tau { get; set; }

        public int rho { get; set; }

        public double sMol { get; set; }

        public double rmsd = 0;

        public Label[] labels { get; set; }

        public Marker[] markers { get; set; }

        public double[][] tauRhoPlot { get; set; }

        public int tauRhoPlotDimension = 180;

        public Peptide()
        {
            tauRhoPlot = new double[tauRhoPlotDimension][];
            for(int i = 0; i < tauRhoPlot.Length; i++)
            {
                tauRhoPlot[i] = new double[tauRhoPlotDimension];
            }
        }

        public override string ToString()
        {
            return name + '|' + tau + '|' + rho + '|' + sMol + '|';// + check + '|';
        }

        public void setMarker(int  length)
        {
            markers = new Marker[length];
            for (int i = 0; i < length; i++)
            {
                markers[i] = new Marker();
            }
        }

        public void setMarker(Marker[] marker)
        {
            markers = new Marker[marker.Length];
            for (int i = 0; i < marker.Length; i++)
            {
                markers[i] = new Marker();
                markers[i] = marker[i];
            }
        }

        public void setLabel(int length)
        {
            labels = new Label[length];
            for (int i = 0; i < length; i++)
            {
                labels[i] = new Label();
            }
        }

        public void setLabel(Label[] label)
        {
            labels = new Label[label.Length];
            for (int i = 0; i < label.Length; i++)
            {
                labels[i] = new Label();
                labels[i] = label[i];
            }
        }

        private int countActiveMerkers()
        {
            int counter = 0;
            //TODO: put in 'try-catch' and throw exeprion
            if (markers != null)
                foreach (Marker marker in markers)
                    if (marker.check != 1)
                        counter++;

            return counter;
        }

        public void directTask()
        {
            Peptide globalbest = new Peptide();
            Peptide bestvaluewithinsmol = new Peptide();
            Peptide counter = new Peptide();
            counter.setMarker(markers);
            counter.setLabel(labels);
            globalbest.rmsd = 100.0;
            for (counter.sMol = 0.01; counter.sMol <= 1; counter.sMol += 0.01)                       //fitting smol          
            {
                bestvaluewithinsmol.rmsd = 100;
                for (counter.tau = 0; counter.tau < tauRhoPlotDimension; counter.tau++)                           //fitting tau  
                    for (counter.rho = 0; counter.rho < tauRhoPlotDimension; counter.rho++)                        //fitting rho
                    {
                        counter.calcrmsd2();
                        if (counter.rmsd < bestvaluewithinsmol.rmsd)
                        {
                            bestvaluewithinsmol.rmsd = counter.rmsd;
                            bestvaluewithinsmol.tau = counter.tau;
                            bestvaluewithinsmol.rho = counter.rho;
                        }

                        tauRhoPlot[counter.tau][counter.rho] = counter.rmsd;
                    }
                if (globalbest.rmsd > bestvaluewithinsmol.rmsd)
                {
                    globalbest.rmsd = bestvaluewithinsmol.rmsd;
                    globalbest.tau = bestvaluewithinsmol.tau;
                    globalbest.rho = bestvaluewithinsmol.rho;
                    globalbest.sMol = counter.sMol;
                }
            }
            tau = globalbest.tau;
            rho = globalbest.rho;
            sMol = globalbest.sMol;
        }
        
        /*public void reverseTask()
        {
            Peptide globalbest = new Peptide();
            Peptide bestvaluewithinsmol = new Peptide();
            Peptide counter = new Peptide();
            counter.setLabel(this.labels.Count());
            globalbest.setLabel(this.labels.Count());
            bestvaluewithinsmol.setLabel(this.labels.Count());
            globalbest.rmsd2 = 100.0;

            for (int temp = 0; temp < counter.labels.Count(); temp++)
                for (sMol = 0.01; sMol <= 1; sMol += 0.01)      //fitting smol
                {
                    bestvaluewithinsmol.rmsd2 = 100;
                    for (counter.labels[temp].alpha = -90; counter.labels[temp].alpha <= 90; counter.labels[temp].alpha++)                   //fitting alpha
                        for (counter.labels[temp].beta = 0; counter.labels[temp].beta <= 180; counter.labels[temp].beta++)                   //fitting beta
                        {
                            calcrmsd2();
                            if (rmsd2 < bestvaluewithinsmol.rmsd2)
                            {
                                bestvaluewithinsmol.rmsd2 = rmsd2;
                                bestvaluewithinsmol.labels[temp].alpha = labels[temp].alpha;
                                bestvaluewithinsmol.labels[temp].beta = labels[temp].beta;
                            }
                        }
                    if (globalbest.rmsd2 > bestvaluewithinsmol.rmsd2)
                    {
                        globalbest.rmsd2 = bestvaluewithinsmol.rmsd2;
                        globalbest.labels[temp].alpha = bestvaluewithinsmol.labels[temp].alpha;
                        globalbest.labels[temp].beta = bestvaluewithinsmol.labels[temp].beta;
                        globalbest.sMol = sMol;
                    }
                }
            }*/

        private void calcrmsd2() // calculate mean square deviation and put it's value in rmsd2 
        {
            double PID = Math.PI / 180;
            double ks = 7.9 * sMol;
            double cost = Math.Cos(tau * PID);
            double sint = Math.Sin(tau * PID);
            double temp = 0;
            rmsd = 0;

            //TODO: put in 'try-catch' and throw exeprion
            //TODO: optimase function
            for (int g = 0; g < markers.Count(); g++)
                if (markers[g].check == 1)
                    {
                        double threecos2b = 3 * Math.Pow(Math.Cos(labels[markers[g].label].beta * PID), 2.0);
                        double tgb = Math.Tan(labels[markers[g].label].beta * PID);
                        temp = ks * (threecos2b * Math.Pow(cost + sint * Math.Sin((rho + labels[markers[g].label].alpha + (labels[markers[g].label].psi + (markers[g].position - 13.0) * 100)) * PID) * tgb, 2.0) - 1);
                        rmsd += Math.Pow(markers[g].splitting - temp, 2.0) / countActiveMerkers();
                    }
        }
    }
}
