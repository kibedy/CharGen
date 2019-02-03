using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen
{
    public class Kaszt
    {
        string Név;
        public string Erő, Állóképesség, Gyorsaság, Ügyesség, Egészség, Szépség, Intelligencia, Akaraterő, Asztrál;
        int fp_a;
        int fp_sz;
        int ép_alap;
        int hm_sz;
        int hm_köt;
        int ké;
        int té;
        int vé;

        /*public Kaszt(String név, Dice Erő, Dice Állóképesség, Dice Gyorsaság, Dice Ügyesség, Dice Egészség, Dice Szépség, Dice Intelligencia, Dice Akaraterő, Dice Asztrál
            , int fp_a,int fp_sz,int ép_alap,int hm_sz,int hm_köt,int ké,int té,int vé )
        {
            this.Név = név;
            this.Erő = Erő;
            this.Állóképesség = Állóképesség;
            this.Gyorsaság = Gyorsaság;
            this.Ügyesség = Ügyesség;
            this.Egészség = Egészség;
            this.Szépség = Szépség;
            this.Intelligencia = Intelligencia;
            this.Akaraterő = Akaraterő;
            this.Asztrál = Asztrál;
            this.fp_a=fp_a;
            this.fp_sz=fp_sz;
            this.ép_alap=ép_alap;
            this.hm_sz=hm_sz;
            this.hm_köt=hm_köt;
            this.ké=ké;
            this.té=té;
            this.vé=vé;
        }
        */

        public Kaszt(string név, string Erő, string Gyorsaság, string Ügyesség, string Állóképesség, string Egészség, string Szépség, string Intelligencia, string Akaraterő, string Asztrál
         , int fp_a, int fp_sz, int ép_alap, int hm_sz, int hm_köt, int ké, int té, int vé)
        {
            this.Név = név;
            this.Erő = Erő;
            this.Állóképesség = Állóképesség;
            this.Gyorsaság = Gyorsaság;
            this.Ügyesség = Ügyesség;
            this.Egészség = Egészség;
            this.Szépség = Szépség;
            this.Intelligencia = Intelligencia;
            this.Akaraterő = Akaraterő;
            this.Asztrál = Asztrál;
            this.fp_a = fp_a;
            this.fp_sz = fp_sz;
            this.ép_alap = ép_alap;
            this.hm_sz = hm_sz;
            this.hm_köt = hm_köt;
            this.ké = ké;
            this.té = té;
            this.vé = vé;
        }

        public override string ToString()
        {
            return Név;
        }


        /*
        neve; er; ák; gy; ü; eg; sz; in; ae; asz; fp_a; fp/sz; ép_alap; hm/sz; hm_köt; ké; té; vé
        */
    }//class
}//namesp
