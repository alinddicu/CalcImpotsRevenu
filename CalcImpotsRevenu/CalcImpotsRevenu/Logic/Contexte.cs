using System;
using System.Collections.Generic;
using System.Text;

namespace CalcImpotsRevenu.Logic
{
    public class Contexte
    {
        private List<Palier> _paliers = null;
        public List<Palier> Paliers
        {
            get { return _paliers; }
            set { _paliers = value; }
        }

        private Double _tauxFrais;
        public Double TauxFrais
        {
            get { return _tauxFrais; }
            set { _tauxFrais = value; }
        }

        public Contexte(Double tauxFrais)
        {
            Paliers = new List<Palier>();
            this.TauxFrais = tauxFrais;
        }

        public void AjouterPalier(string limiteSup, string taux, int ordre)
        {
            Palier p = new Palier();
            p.Ordre = ordre;
            p.Taux = Convert.ToDouble(taux);
            p.LimiteSup = Convert.ToDouble(limiteSup);
            if (ordre == 0)
            {
                p.LimiteInf = 0;
            }
            else
            {
                p.LimiteInf = this.Paliers[Paliers.Count - 1].LimiteSup - 1;
            }
            this.Paliers.Add(p);
        }

        public void AjouterPalier(Double limiteInf, Double limiteSup, Double taux, int ordre)
        {
            Palier p = new Palier();
            p.Ordre = ordre;
            p.Taux = taux;
            p.LimiteInf = limiteInf;
            p.LimiteSup = limiteSup;

            this.Paliers.Add(p);
        }
    }
}
