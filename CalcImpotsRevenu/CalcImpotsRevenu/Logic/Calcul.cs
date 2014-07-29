using System;
using System.Collections.Generic;
using System.Text;

namespace CalcImpotsRevenu.Logic
{
    public class Calcul
    {
        private Contexte _ctx;

        public Contexte Ctx
        {
            get { return _ctx; }
            set { _ctx = value; }
        }

        public Calcul(Contexte ctx)
        {
            this.Ctx = ctx;
        }

        public Double[] CalculerImpotsPaliers(String sRevenu)
        {
            Double revenu = Convert.ToDouble(sRevenu)*(1-Ctx.TauxFrais/100);
            Double[] resultat = new Double[Ctx.Paliers.Count];

            foreach (Palier p in Ctx.Paliers)
            {
                resultat[p.Ordre] = 0;
            }
            if (revenu != 0)
            {
                int palierFinal = 0;
                foreach (Palier p in Ctx.Paliers)
                {
                    if (revenu > p.LimiteInf && revenu <= p.LimiteSup)
                    {
                        palierFinal = p.Ordre;
                        break;
                    }
                }

                for (int i = 0; i <= palierFinal; i++)
                {
                    if(i<palierFinal)
                    {
                        resultat[i] = Ctx.Paliers[i].CalculImpotPalier();
                    }
                    else
                    {
                        resultat[i] = Ctx.Paliers[i].CalculImpotPalierF(revenu);
                    }
                }
            }

            return resultat;
        }

        public Double CalculerImpotRevenu(String revenu)
        {
            Double ir = 0;

            Double[] resultat = CalculerImpotsPaliers(revenu);

            for (int i = 0; i < resultat.Length; i++)
            {
                ir += resultat[i];
            }

            return ir;
        }
    }
}
