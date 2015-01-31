using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CalcImpotsRevenu.Logic;
using Common;

namespace CalcImpotsRevenu
{
    public partial class Main : Form
    {
        public const string DOUBLE_FORMAT = "0.##";
        private Contexte _contexte = null;
        public Contexte Contexte
        {
            get { return _contexte; }
            set { _contexte = value; }
        }
        public Main()
        {
            InitializeComponent();
            btnCalc.Focus();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {

            Double p1E = Convertir(tbxP1E);
            Double p2E = Convertir(tbxP2E);
            Double p3E = Convertir(tbxP3E);
            Double p4E = Convertir(tbxP4E);

            Double p1P = Convertir(tbxP1P);
            Double p2P = Convertir(tbxP2P);
            Double p3P = Convertir(tbxP3P);
            Double p4P = Convertir(tbxP4P);

            Double tauxFrais = Convertir(tbxFrais);

            this.Contexte = new Contexte(tauxFrais);
            
            this.Contexte.AjouterPalier(0, p1E-1, 0, 0);
            this.Contexte.AjouterPalier(p1E, p2E-1, p1P, 1);
            this.Contexte.AjouterPalier(p2E, p3E - 1, p2P, 2);
            this.Contexte.AjouterPalier(p3E, p4E - 1, p3P, 3);
            this.Contexte.AjouterPalier(p4E, int.MaxValue, p4P, 4);

            Calcul calcul = new Calcul(this.Contexte);
            var resultCalcul = calcul.Calculer(Convert.ToInt32(tbxRevenu.Text));

            AfficherResultats(resultCalcul);
        }

        private Double Convertir(TextBox tbx)
        {
            return Convert.ToDouble(tbx.Text);
        }

        private void AfficherResultats(ImpotResult resultCalcul)
        {
            for (int i = 1; i < resultCalcul.MontantParTranches.Length; i++)
            {
                ((TextBox)this.Controls.Find(String.Format("tbxImpP{0}", i), false)[0]).Text = resultCalcul.MontantParTranches[i].ToString(DOUBLE_FORMAT);    
            }

            tbxImpotGlbl.Text = resultCalcul.MontantTotal.ToString(DOUBLE_FORMAT);
        }
    }
}