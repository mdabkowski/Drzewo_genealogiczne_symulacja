using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace GenTree
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GenTree());
        }
    }

    class Osoba
    {
        private static ThreadLocal<Random> losuj;
        static Osoba()
        {
            losuj = new ThreadLocal<Random>(() => new Random());
        }
        public Osoba matka = null;
        public Osoba ojciec = null;
        public Osoba partner = null;
        public int pokolenie;
        public double x;
        public double y;
        public Osoba(int pokolenie, double x)
        {
            this.pokolenie = pokolenie;
            this.y = 5 + 20 * pokolenie;
            this.x = x;
        }
        public Osoba(int pokolenie, double x, double y)
        {
            this.pokolenie = pokolenie;
            this.y = y + 20 * pokolenie;
            this.x = x;
        }
        public void Generuj(decimal last_pokolenie, List<Pokolenie> osoby, long[] limit, int szansa)
        {
            if((this.pokolenie + 1) <= last_pokolenie)
            {
                int szansa_check = losuj.Value.Next(1, 101);
                if ((long)osoby[this.pokolenie + 1].lista_pok.Count >= limit[this.pokolenie + 1])
                {
                    Osoba rodzenstwo = osoby[this.pokolenie].Losujosobe();
                    while(this.partner == rodzenstwo)
                    {
                        rodzenstwo = osoby[this.pokolenie].Losujosobe();
                    }
                    this.matka = rodzenstwo.matka;
                    this.ojciec = rodzenstwo.ojciec;
                }
                else if (szansa_check <= szansa & this.pokolenie > 6 & osoby[this.pokolenie + 1].lista_pok.Count > 4)
                {
                    Osoba rodzenstwo = osoby[this.pokolenie].Losujosobe();
                    while (this.partner == rodzenstwo)
                    {
                        rodzenstwo = osoby[this.pokolenie].Losujosobe();
                    }
                    this.matka = rodzenstwo.matka;
                    this.ojciec = rodzenstwo.ojciec;
                }
                else if (this.pokolenie > 0)
                {
                    this.matka = new Osoba(this.pokolenie + 1, this.x + 20 * this.pokolenie*0.5);
                    this.ojciec = new Osoba(this.pokolenie + 1, this.x - 20 * this.pokolenie*0.5);
                    this.matka.partner = this.ojciec;
                    this.ojciec.partner = this.matka;
                    osoby[this.pokolenie + 1].Dodajosobe(this.matka);
                    osoby[this.pokolenie + 1].Dodajosobe(this.ojciec);
                    this.matka.Generuj(last_pokolenie, osoby, limit, szansa);
                    this.ojciec.Generuj(last_pokolenie, osoby, limit, szansa);
                }
                else //root
                {
                    this.matka = new Osoba(this.pokolenie + 1, this.x + 50);
                    this.ojciec = new Osoba(this.pokolenie + 1, this.x - 50, this.y + 5);
                    this.matka.partner = this.ojciec;
                    this.ojciec.partner = this.matka;
                    osoby[this.pokolenie + 1].Dodajosobe(this.matka);
                    osoby[this.pokolenie + 1].Dodajosobe(this.ojciec);
                    this.matka.Generuj(last_pokolenie, osoby, limit, szansa);
                    this.ojciec.Generuj(last_pokolenie, osoby, limit, szansa);
                }
            }
        }
        public double Zwroc_x()
        {
            return this.x;
        }
        public double Zwroc_y()
        {
            return this.y;
        }
        public double Zwroc_m_x()
        {
            if (this.matka == null)
            {
                return this.x;
            }
            else
            {
                return this.matka.x;
            }
        }
        public double Zwroc_m_y()
        {
            if (this.matka == null)
            {
                return this.y;
            }
            else
            {
                return this.matka.y;
            }
        }
        public double Zwroc_o_x()
        {
            if (this.ojciec == null)
            {
                return this.x;
            }
            else
            {
                return this.ojciec.x;
            }
        }
        public double Zwroc_o_y()
        {
            if (this.ojciec == null)
            {
                return this.y;
            }
            else
            {
                return this.ojciec.y;
            }
        }
    }
    class Zbior
    {
        public List<Pokolenie> pokolenie = new List<Pokolenie>();
        public Osoba root = new Osoba(0, 160);
        public long[] max_populacja = new long[102] {7794798739, 6143493823, 4458003514, 3034949748, 2556633166, 2078316584, 1600000000, 1481428572, 1362857144, 1244285716, 1125714288, 1007142860, 888571432, 770000000, 716666667, 663333334, 610000000, 588000000, 566000000, 544000000, 522000000, 500000000, 490000000, 480000000, 470000000, 460000000, 450000000, 430000000, 410000000, 390000000, 370000000, 350000000, 330000000, 310000000, 443000000, 401500000, 360000000, 380000000, 400000000, 386666667, 373333334, 360000000, 352000000, 344000000, 336000000, 328000000, 320000000, 311000000, 302000000, 293000000, 284000000, 275000000, 268000000, 261000000, 254000000, 247000000, 240000000, 236000000, 232000000, 228000000, 224000000, 220000000, 218000000, 216000000, 214000000, 212000000, 210000000, 208000000, 206000000, 204000000, 202000000, 200000000, 199000000, 198000000, 197000000, 196000000, 195000000, 194000000, 193000000, 192000000, 191000000, 190000000, 190000000, 190000000, 190000000, 190000000, 190000000, 190000000, 190000000, 190000000, 190000000, 190000000, 187777778, 185555556, 183333334, 181111112, 178888890, 176666668, 174444446, 172222224, 170000002, 167777780 };
        public Zbior(decimal last_pokolenie, int szansa)
        {
            for(int i = 0; i <= last_pokolenie; i++)
            {
                this.pokolenie.Add(new Pokolenie(i));
            }
            this.pokolenie[0].lista_pok.Add(root);
            if (last_pokolenie < 6)
            {
                root.Generuj(last_pokolenie, this.pokolenie, this.max_populacja, szansa);
            }
            else
            {
                root.Generuj(2, this.pokolenie, max_populacja, szansa);
                Generator generator1 = new Generator(last_pokolenie, this.pokolenie[2].lista_pok[0], this.pokolenie, this.max_populacja, szansa);
                Generator generator2 = new Generator(last_pokolenie, this.pokolenie[2].lista_pok[1], this.pokolenie, this.max_populacja, szansa);
                Generator generator3 = new Generator(last_pokolenie, this.pokolenie[2].lista_pok[2], this.pokolenie, this.max_populacja, szansa);
                Generator generator4 = new Generator(last_pokolenie, this.pokolenie[2].lista_pok[3], this.pokolenie, this.max_populacja, szansa);
                Thread gen1 = new Thread(generator1.WatekGen);
                Thread gen2 = new Thread(generator2.WatekGen);
                Thread gen3 = new Thread(generator3.WatekGen);
                Thread gen4 = new Thread(generator4.WatekGen);
                gen1.Start();
                gen2.Start();
                gen3.Start();
                gen4.Start();
                gen1.Join();
                gen2.Join();
                gen3.Join();
                gen4.Join();
            }
        }
        public int Liczgen()
        {
            int licz = 0;
            for (int i = 0; i < this.pokolenie.Count; i++)
            {
                licz += this.pokolenie[i].lista_pok.Count;
            }
            return licz;
        }
    }

    class Pokolenie
    {
        public decimal pokolenie;
        public List<Osoba> lista_pok = new List<Osoba>();
        private static ThreadLocal<Random> losuj_os;
        static Pokolenie()
        {
            losuj_os = new ThreadLocal<Random>(() => new Random());
        }
    public Pokolenie(int pokolenie)
        {
            this.pokolenie = pokolenie;
        }
        public void Dodajosobe(Osoba osoba)
        {
            lock(this)
            {
                this.lista_pok.Add(osoba);
            }
        }
        public Osoba Losujosobe()
        {
            int index = losuj_os.Value.Next(this.lista_pok.Count);
            while (this.lista_pok[index].matka == null)
            {
                index = losuj_os.Value.Next(this.lista_pok.Count);
            }
            return this.lista_pok[index];
        }
    }
    class Generator
    {
        readonly decimal pokolenie;
        readonly Osoba root;
        readonly List<Pokolenie> osoby;
        readonly long[] limit;
        readonly int szansa;

        public Generator(decimal _pokolenie, Osoba _root, List<Pokolenie> _osoby, long[] _limit, int _szansa)
        {
            this.pokolenie = _pokolenie;
            this.root = _root;
            this.osoby = _osoby;
            this.limit = _limit;
            this.szansa = _szansa;
        }
        public void WatekGen()
        {
            this.root.Generuj(this.pokolenie, this.osoby, this.limit, this.szansa);
        }
    }
}
