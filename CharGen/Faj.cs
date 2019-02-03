namespace CharGen
{
    internal class Faj
    {
        string név;
        public int Er, Gy, Ü, Ák, Eg, Sz, Intell, Ae, Asz;

        public Faj(string név, int er, int gy, int ü, int Ák, int Eg, int sz, int intell, int ae, int asz)
        {
            this.név = név;
            this.Er = er;
            this.Gy = gy;
            this.Ü = ü;
            this.Ák = Ák;
            this.Eg = Eg;
            this.Sz = sz;
            this.Intell = intell;
            this.Ae = ae;
            this.Asz = asz;
        }

        public override string ToString()
        {
            return név;
        }
    }
}