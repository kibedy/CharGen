using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharGen
{
    public partial class Form1 : Form
    {
        List<Kaszt> kasztok;
        List<Faj> fajok;
        int sorszám;
        Karakter karakter;
        public Form1()
        {
            InitializeComponent();
            kasztok = new List<Kaszt>();
            fajok = new List<Faj>();
            Load_All_Class();
            Load_All_Races();
            ;
        }

        private void Load_All_Races()
        {
            StreamReader sr = new StreamReader("fajok másolata.csv", Encoding.GetEncoding("Windows-1250"), true);
            sorszám = 0;
            try
            {
                Faj faj = new Faj("ember", 0, 0, 0, 0, 0, 0, 0, 0, 0);
                fajok.Add(faj);
                comboBox2.Items.Add(faj);
                while (!sr.EndOfStream)
                {
                    sorszám++;
                    string sor = sr.ReadLine();
                    if (!sor[0].Equals('*') && !sor.Equals(""))
                    {
                        string[] sorelem = sor.Split(';');

                        faj = new Faj(
                        sorelem[0],
                        int.Parse(sorelem[1]),//Er
                        int.Parse(sorelem[2]),//Gy
                        int.Parse(sorelem[3]),//Ü
                        int.Parse(sorelem[4]),//Ák
                        int.Parse(sorelem[5]),//Eg
                        int.Parse(sorelem[6]),//Sz
                        int.Parse(sorelem[7]),//int
                        int.Parse(sorelem[8]),//Ae
                        int.Parse(sorelem[9]) //Asz
                            );
                        fajok.Add(faj);
                        comboBox2.Items.Add(faj);                        
                    }
                    else { }
                    comboBox2.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {
                string output = sorszám.ToString();
                output = String.Format("Hibás a fajok.txt a {0}. sorban!", output);
                MessageBox.Show(output);
            }

            sr.Close();

        }

        private void Load_All_Class()
        {
            StreamReader sr = new StreamReader("stats másolata.csv", Encoding.GetEncoding("Windows-1250"), true);
            sorszám = 0;
            Dice[] dice = new Dice[9];
            try
            {
                while (!sr.EndOfStream)
                {
                    sorszám++;
                    string sor = sr.ReadLine();
                    if (!sor[0].Equals('*') && !sor.Equals(""))
                    {
                        string[] sorelem = sor.Split(';');

                        Kaszt kaszt = new Kaszt(
                           sorelem[0].Replace(" ", "").ToLower(),
                           sorelem[1].Replace(" ", "").ToLower(), 
                           sorelem[2].Replace(" ", "").ToLower(),
                           sorelem[3].Replace(" ", "").ToLower(),
                           sorelem[4].Replace(" ", "").ToLower(),
                           sorelem[5].Replace(" ", "").ToLower(),
                           sorelem[6].Replace(" ", "").ToLower(),
                           sorelem[7].Replace(" ", "").ToLower(),
                           sorelem[8].Replace(" ", "").ToLower(),
                           sorelem[9].Replace(" ", "").ToLower(),
                           int.Parse(sorelem[10]),//this.fp_a = fp_a;
                           int.Parse(sorelem[11]), //this.fp_sz = fp_sz;                                                                                               
                           int.Parse(sorelem[12]),//this.ép_alap = ép_alap;
                           int.Parse(sorelem[13]),//this.hm_sz = hm_sz;
                           int.Parse(sorelem[14]),//this.hm_köt = hm_köt;
                           int.Parse(sorelem[15]),//this.ké = ké;
                           int.Parse(sorelem[16]),//this.té = té;
                           int.Parse(sorelem[17])//this.vé = vé;
                               );
                        kasztok.Add(kaszt);
                        comboBox1.Items.Add(kaszt);

                        

                    }
                    else { }
                }
            }
            catch (Exception)
            {
                string output = sorszám.ToString();
                output = String.Format("Hibás a kasztok.txt a {0}. sorban!", output);
                MessageBox.Show(output);
            }

            sr.Close();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            er_kf_button.Enabled = false;
            ák_kf_button.Enabled = false;
            gy_kf_button.Enabled = false;
            ü_kf_button.Enabled = false;
            eg_kf_button.Enabled = false;
            sz_kf_button.Enabled = false;
            Int_kf_button.Enabled = false;
            ae_kf_button.Enabled = false;
            asz_kf_button.Enabled = false;

            karakter = new Karakter();
            karakter.Er = Kocka(kasztok[comboBox1.SelectedIndex].Erő);
            karakter.Gy = Kocka(kasztok[comboBox1.SelectedIndex].Gyorsaság);
            karakter.Ü = Kocka(kasztok[comboBox1.SelectedIndex].Ügyesség );
            karakter.ÁK = Kocka(kasztok[comboBox1.SelectedIndex].Állóképesség);
            karakter.Eg = Kocka(kasztok[comboBox1.SelectedIndex].Egészség);
            karakter.Sz = Kocka(kasztok[comboBox1.SelectedIndex].Szépség);
            karakter.Int = Kocka(kasztok[comboBox1.SelectedIndex].Intelligencia);
            karakter.AE = Kocka(kasztok[comboBox1.SelectedIndex].Akaraterő);
            karakter.Asz = Kocka(kasztok[comboBox1.SelectedIndex].Asztrál);
            check_kf();


        }

        private void check_kf()
        {            
            if (kasztok[comboBox1.SelectedIndex].Erő.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Erő.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Erő.Contains("k10+10+kf")) && karakter.Er==20)
                {
                    er_kf_button.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Erő.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Erő.Contains("k10+10+kf")) && karakter.Er == 18)
                {
                    er_kf_button.Enabled = true;
                }
                else
                    er_kf_button.Enabled = false;                
            }

            if (kasztok[comboBox1.SelectedIndex].Állóképesség.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Állóképesség.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Állóképesség.Contains("k10+10+kf")) && karakter.ÁK == 20)
                {
                    ák_kf_button.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Állóképesség.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Állóképesség.Contains("k10+10+kf")) && karakter.ÁK == 18)
                {
                    ák_kf_button.Enabled = true;
                }
                else
                    ák_kf_button.Enabled = false;                              
            }

            if (kasztok[comboBox1.SelectedIndex].Gyorsaság.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Gyorsaság.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Gyorsaság.Contains("k10+10+kf")) && karakter.Gy == 20)
                {
                    gy_kf_button.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Gyorsaság.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Gyorsaság.Contains("k10+10+kf")) && karakter.Gy == 18)
                {
                    gy_kf_button.Enabled = true;
                }
                else
                    gy_kf_button.Enabled = false;                                
            }

            if (kasztok[comboBox1.SelectedIndex].Ügyesség.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Ügyesség.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Ügyesség.Contains("k10+10+kf")) && karakter.Ü == 20)
                {
                    ü_kf_button.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Ügyesség.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Ügyesség.Contains("k10+10+kf")) && karakter.Ü == 18)
                {
                    ü_kf_button.Enabled = true;
                }
                else
                    ü_kf_button.Enabled = false;  
            }
            
            if (kasztok[comboBox1.SelectedIndex].Egészség.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Egészség.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Egészség.Contains("k10+10+kf")) && karakter.Eg == 20)
                {
                    eg_kf_button.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Egészség.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Egészség.Contains("k10+10+kf")) && karakter.Eg == 18)
                {
                    eg_kf_button.Enabled = true;
                }
                else
                    eg_kf_button.Enabled = false;                                
            }

            if (kasztok[comboBox1.SelectedIndex].Szépség.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Szépség.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Szépség.Contains("k10+10+kf")) && karakter.Sz==20)
                {
                    sz_kf_button.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Szépség.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Szépség.Contains("k10+10+kf")) && karakter.Sz == 18)
                {
                    sz_kf_button.Enabled = true;
                }
                else
                    sz_kf_button.Enabled = false;                
            }

            if (kasztok[comboBox1.SelectedIndex].Szépség.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Szépség.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Szépség.Contains("k10+10+kf")) && karakter.Sz==20)
                {
                    sz_kf_button.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Szépség.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Szépség.Contains("k10+10+kf")) && karakter.Sz == 18)
                {
                    sz_kf_button.Enabled = true;
                }
                else
                    sz_kf_button.Enabled = false;                
            }

            if (kasztok[comboBox1.SelectedIndex].Intelligencia.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Intelligencia.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Intelligencia.Contains("k10+10+kf")) && karakter.Int==20)
                {
                    //.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Intelligencia.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Intelligencia.Contains("k10+10+kf")) && karakter.Int == 18)
                {
                    //int_kf_button.Enabled = true;
                }
                else{}
                    //int_kf_button.Enabled = false;                
            }

            if (kasztok[comboBox1.SelectedIndex].Szépség.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Szépség.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Szépség.Contains("k10+10+kf")) && karakter.Sz==20)
                {
                    sz_kf_button.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Szépség.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Szépség.Contains("k10+10+kf")) && karakter.Sz == 18)
                {
                    sz_kf_button.Enabled = true;
                }
                else
                    sz_kf_button.Enabled = false;                
            }

            if (kasztok[comboBox1.SelectedIndex].Szépség.Contains("+kf"))
            {
                if ((kasztok[comboBox1.SelectedIndex].Szépség.Contains("k6+14+kf") || kasztok[comboBox1.SelectedIndex].Szépség.Contains("k10+10+kf")) && karakter.Sz==20)
                {
                    sz_kf_button.Enabled = true;
                }
                else if ((!kasztok[comboBox1.SelectedIndex].Szépség.Contains("k6+14+kf") && !kasztok[comboBox1.SelectedIndex].Szépség.Contains("k10+10+kf")) && karakter.Sz == 18)
                {
                    sz_kf_button.Enabled = true;
                }
                else
                    sz_kf_button.Enabled = false;                
            }

            karakter.Er += fajok[comboBox2.SelectedIndex].Er;     
            karakter.ÁK += fajok[comboBox2.SelectedIndex].Ák;
            karakter.Gy += fajok[comboBox2.SelectedIndex].Gy;
            karakter.Ü += fajok[comboBox2.SelectedIndex].Ü;
            karakter.Eg += fajok[comboBox2.SelectedIndex].Eg;
            karakter.Sz += fajok[comboBox2.SelectedIndex].Sz;
            karakter.Sz += fajok[comboBox2.SelectedIndex].Sz;
            karakter.Int += fajok[comboBox2.SelectedIndex].Intell;
            karakter.AE += fajok[comboBox2.SelectedIndex].Ae;
            karakter.Asz += fajok[comboBox2.SelectedIndex].Asz;


            Erő_box.Text = karakter.Er.ToString();
            ÁK_box.Text = karakter.ÁK.ToString();
            Gy_box.Text = karakter.Gy.ToString();
            Ü_box.Text = karakter.Gy.ToString();
            Eg_box.Text = karakter.Eg.ToString();
            Sz_box.Text = karakter.Sz.ToString();
            Int_box.Text = karakter.Int.ToString();
            //Ae_box.Text = karakter.AE.ToString();        
            //Asz_box.Text = karakter.Asz.ToString();
        }

        int szam;
        Random rand = new Random();
        private int Kocka(string kocka)
        {
            
            //string eredmény;            
            switch (kocka)
            {
               case "k6+12":
                    szam = rand.Next(1, 7) + 12;                    
                    break;
                case "k6+14":
                    szam = rand.Next(1, 7) + 14;                    
                    break;
                case "2k6+6":
                    int k1 = rand.Next(1, 7);
                    int k2 = rand.Next(1, 7);
                    szam =k1 + k2+ 6;                    
                    break;
                case "3k6(2x)":                   
                    int k11 = rand.Next(1, 7)+ rand.Next(1, 7)+ rand.Next(1, 7);
                    int k12 = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                    if (k11 > k12)
                        szam = k11;
                    else
                        szam = k12;
                    break;
                case "3k6":
                    szam = rand.Next(1, 7)+ rand.Next(1, 7)+ rand.Next(1, 7);                                        
                    break;
                case "k10+8":
                    szam = rand.Next(1, 11) + 8;
                    break;
                case "k10+10":
                    szam = rand.Next(1, 11) + 10;
                    break;

                case "k6+12+kf":
                    szam = rand.Next(1, 7) + 12;
                    break;
                case "k6+14+kf":
                    szam = rand.Next(1, 7) + 14;
                    break;
                case "2k6+6+kf":
                    int k1k = rand.Next(1, 7);
                    int k2k = rand.Next(1, 7);
                    szam = k1k + k2k + 6;
                    break;
                case "3k6(2x)+kf":
                    int k21 = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                    int k22 = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                    if (k21 > k22)
                        szam = k21;
                    else
                        szam = k22;
                    break;
                case "3k6+kf":
                    szam = rand.Next(1, 7) + rand.Next(1, 7) + rand.Next(1, 7);
                    break;
                case "k10+8+kf":
                    szam = rand.Next(1, 11) + 8;
                    break;
                case "k10+10+kf":
                    szam = rand.Next(1, 11) + 10;
                    break;


                default:
                    szam = 0;
                    break;
            }
            //eredmény = szam.ToString();
            return szam;
        }
    }
}

