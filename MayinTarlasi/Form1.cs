using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Değişkenler 
        //Burada kullanacağımız global değişkenleri oluşturduk.
        string[,] mayinlar;        //Mayın tarlasını içine koyacağımız 3 boyutlu bir matris
                                   //1. Boyutu Alanın sütunları, 2. Boyut Alanın Satırları
                                   //3.Boyut İse sütun * satır konumunda tutulacak veriler
                                   //  = [0]:Yer'in değeri,  [1]:Durumu // Örn=   [0]:X,1,2,3," "    [1]:Null(Açılmadı)/Açıldı.
        int satırSayisi, sutunSayisi, mayinSayisi;
        int bayrakSayisi;           //Koyabileceğimiz bayrakların sayısını tutmak için
        int skorSayar, bitisSkoru;  //AÇtığımız kutucuk sayısını tutmak için
        bool FirstClick;            //İlk kutucuğu açarken ilk kez mi tıklıyoruzu tutmak için.
        int saniye;                 //saniye
        string[] acilacakMayinlar;

        #endregion

        private void btnOyna_Click(object sender, EventArgs e) //Oyun başlıyor
        {
            DegerleriAyarla();          //Bşlangıç değerleri ayarlanıyor
            this.Text = "MAYIN TARLARSI - ALAN OLUŞTURULUYOR...";
            //Alani hazirla işlemi zaman alabileceği için Formun başlığına "oluşturuluyor..." şeklinde
            //çakma bir loading koydum :D

            AlaniHazirla();
            this.Text = "MAYIN TARLARSI";//Oluşumlar bitince form başlığı düzeltiliyor.
        }

        private void DegerleriAyarla() //Başlangıç değerleri ayarlanıyor
        {
            timer1.Stop();
            skorSayar = 0;
            saniye = 0;
            lblSure.Text = "0:00";
            ZorlukAyarla();
            bitisSkoru = (sutunSayisi * satırSayisi) - mayinSayisi;
            grpMayinAlani.Controls.Clear();
            mayinlar = new string[sutunSayisi, satırSayisi];
            bayrakSayisi = mayinSayisi;
            BayrakSayisiGuncelle(0);
            acilacakMayinlar = new string[0];
            FirstClick = true;
        }

        private void ZorlukAyarla() //Seçilen radiobox'a göre zorluk parametreleri
        {
            if (rdKolay.Checked == true)
            {
                ZorlukParametreleriniGir(9, 9, 10);

            }
            else if (rdOrta.Checked == true)
            {
                ZorlukParametreleriniGir(15, 15, 40);
            }
            else if (rdZor.Checked == true)
            {
                ZorlukParametreleriniGir(30, 15, 90);
            }
            else
            {
                if (nbrSutun.Value >= 3 && nbrSatır.Value >= 3)
                {
                    if (nbrBomba.Value < (nbrSutun.Value * nbrSatır.Value) / 2)
                    {
                        ZorlukParametreleriniGir(Convert.ToInt16(nbrSutun.Value), Convert.ToInt16(nbrSatır.Value), Convert.ToInt16(nbrBomba.Value));
                    }
                    else
                        MesajGoster("Mayın sayısı alandaki kutucukların yarısından fazla olamaz (mayin < (x*y)/2)!", "UYARI", MessageBoxButtons.OK);
                }
                else
                    MesajGoster("Satır ve sütun sayıları 3'ten küçük olamaz!", "UYARI", MessageBoxButtons.OK);

            }
        }

        private void ZorlukParametreleriniGir(int sut, int sat, int bom)
        {
            sutunSayisi = sut;
            satırSayisi = sat;
            mayinSayisi = bom;
            nbrSutun.Value = sut;
            nbrSatır.Value = sat;
            nbrBomba.Value = bom;
        }

        private void AlaniHazirla()
        {
            //oluşturulacak alanın sutun*satir sayisina göre butonlar oluşturuluyor
            for (int i = 0; i < sutunSayisi; i++)
            {
                for (int j = 0; j < satırSayisi; j++)
                {
                    Button btn = new Button();
                    string[] data = new string[4];
                    //bu butonların tag'larina içerisine bazı verileri tutmaları için dizi oluşturup,atayacağız.
                    //bu veriler [0]= "O butonun değeri":X(mayın),1,2,3,4,5 veya " "(boş)
                    //data[1],data[2] = x,y düzleminde konumu [12],[23]
                    //data[3] = K,A : Kapalı veyahut açılmış.
                    btn.Size = new Size(40, 40);
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.White;
                    btn.Location = new Point((i * 39) + 50, (j * 39) + 20);
                    btn.Font = new Font(btn.Font.FontFamily, 18);
                    data[1] = i.ToString();
                    data[2] = j.ToString();
                    data[3] = "K";
                    btn.Name = i.ToString() + "-" + j.ToString();
                    btn.MouseDown += new MouseEventHandler(btn_MayinClick);
                    //butonun mousedown'una event atıyoruz
                    //click'e atamadık çünkü sağ veyahut sol click farkını bilmek için down'a atadık
                    // down'a gelen tuşa bakarak sağ mı, sol mu anlayacağız

                    if (FirstClick != true)//eğer ilk tıklama değilse mayın butonlarına özellikleri giriliyor
                    {
                        this.Text = "MAYIN TARLARSI - ÇEVRE MAYINLAR HESAPLANIYOR...";
                    }
                    btn.Tag = data;
                    //içerisine butonun verilerini eklediğimiz data dizisini butonun tag'ına ekliyoruz
                    grpMayinAlani.Controls.Add(btn);//butonu groupbox a ekledik
                }
            }
        }

        private void btn_MayinClick(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            string[] data = btn.Tag as string[];

            if (FirstClick == true)//İlk tıklanan hücre ise o hücrenin etrafında oyunu kurduruyoruz.
            {
                OyunuKur(data[1], data[2]);
            }
            else
            {
                if (e.Button == MouseButtons.Left)//sol clicklendiyse 
                {
                    if (data[0] == "X")//mayina basildiysa mayinlari patlat metodu ile tüm mayınları patlatıp game over veriyoruz.
                    {
                        MayinlariPatlat();
                        MesajGoster("Mayın patlatarak kaybettiniz! Yeniden oynamak ister misiniz?", "GAME OVER", MessageBoxButtons.YesNo);
                    }
                    else//mayinsüz bir hücre ise hücreyi aciyoruz
                    {
                        if (data[3] == "K" && data[0] != "0")//Hücre numaralı ise sadece açıyoruz
                        {
                            HucreAc(btn, data);
                        }
                        else//Boş hücre ise etrafındaki diğer boş hücreleri açan metota hücrenin koordinatını gönderiyoruz.
                        {
                            BosHucreninEtrafiniAc(Convert.ToInt16(data[1]), Convert.ToInt16(data[2]));
                        }
                    }
                }
                else//Sağ click ise Bayrak koymak için metotlar
                {

                    if (data[3] == "A")
                    {
                        AcikHucreyeIslemYap(data, btn);
                    }
                    else
                    {
                        KapaliHucreyeIslemYap(data, btn);
                    }
                }
                btn.Tag = data;
            }
        }

        private void AcikHucreyeIslemYap(string[] data, Button btn)
        {
            if (btn.Text == "F")
            {
                AcikHucredenBayrakKaldir(data, btn);
            }
            else
            {
                AcikHucreyeBayrakKoy(data, btn);
            }
        }

        private void KapaliHucreyeIslemYap(string[] data, Button btn)
        {
            if (btn.Text == "F")
            {
                KapaliHucredenBayrakKaldir(data, btn);
            }
            else
            {
                KapaliHucreyeBayrakKoy(data, btn);
            }
        }

        private void AcikHucredenBayrakKaldir(string[] data, Button btn)
        {
            btn.Text = data[0].ToString();
            BayrakSayisiGuncelle(1);
        }

        private void AcikHucreyeBayrakKoy(string[] data, Button btn)
        {
            data[0] = btn.Text;
            btn.Text = "F";
            BayrakSayisiGuncelle(-1);
        }

        private void KapaliHucredenBayrakKaldir(string[] data, Button btn)
        {
            btn.ForeColor = Color.White;
            btn.Text = data[0].ToString();
            btn.BackColor = Color.White;
            BayrakSayisiGuncelle(1);
        }

        private void KapaliHucreyeBayrakKoy(string[] data, Button btn)
        {
            data[0] = btn.Text;
            btn.Text = "F";
            btn.ForeColor = Color.White;
            btn.BackColor = Color.Green;
            BayrakSayisiGuncelle(-1);
        }

        private void OyunuKur(string sutun, string satır)//Oyun Alanını kuran metot
        {

            int x = Convert.ToInt16(sutun);
            int y = Convert.ToInt16(satır);
            MayinlariOlustur(x, y);
            MayinlarinEtrafiniDuzenle();
            IlkMayininEtrafiniAc(x, y);
            FirstClick = false;
            MayinlariDoldur();
            IlkHucreninEtrafiniAc();
            ZamanlayiciBaslat();
        }

        private void MayinlariOlustur(int sutun, int satır)//tıkladığımız konum hariç etrafına rastgele 
        {                                       //mayınlar döşemek için bir mayın dizisi oluşturuyor
            Random rnd = new Random();
            int x, y;
            for (int i = 0; i < mayinSayisi; i++)
            {
                do
                {
                    x = rnd.Next(0, sutunSayisi);
                    y = rnd.Next(0, satırSayisi);
                    if (x != sutun && y != satır)
                    {
                        if (mayinlar[x, y] == null)
                        {
                            mayinlar[x, y] = "X";
                            break;
                        }
                    }
                } while (true);

            }
            for (int i = 0; i < sutunSayisi; i++)
            {
                for (int j = 0; j < satırSayisi; j++)
                {
                    if (mayinlar[i, j] != "X")
                    {
                        mayinlar[i, j] = "0";
                    }
                }
            }
        }

        private void MayinlarinEtrafiniDuzenle()//mayınların etrafındaki kutucuklara çevre mayın sayılarını
        {                                         //yazıyor
            for (int i = 0; i < sutunSayisi; i++)
            {
                for (int j = 0; j < satırSayisi; j++)
                {
                    if (mayinlar[i, j] == "X")
                    {
                        for (int a = i - 1; a <= i + 1; a++)
                        {
                            if (a < 0 || a >= sutunSayisi)
                            {
                                continue;
                            }

                            for (int b = j - 1; b <= j + 1; b++)
                            {
                                if (b < 0 || b >= satırSayisi)
                                {
                                    continue;
                                }
                                if (mayinlar[a, b] == "X")
                                {
                                    continue;
                                }
                                mayinlar[a, b] = (1 + Convert.ToInt32(mayinlar[a, b])).ToString();
                            }
                        }
                    }
                }
            }
        }

        private void IlkMayininEtrafiniAc(int x, int y)//ilk tıkladığımız yerin etrafındaki tüm boş alanlar
        {                           //ve o boş alanlara komşu içinde mayın hariç sayı olan alanları açmak için
            for (int a = x - 1; a <= x + 1; a++)      //bu konumları bulup bir diziye kaydediyoruz.
            {
                if (a < 0 || a >= sutunSayisi)
                {
                    continue;
                }
                for (int b = y - 1; b <= y + 1; b++)
                {
                    if (b < 0 || b >= satırSayisi)
                    {
                        continue;
                    }
                    string ac = a.ToString() + "-" + b.ToString();
                    if (mayinlar[a, b] == "0" && (acilacakMayinlar.Any(d => d == ac) == false))
                    {
                        Array.Resize(ref acilacakMayinlar, acilacakMayinlar.Length + 1);
                        acilacakMayinlar[acilacakMayinlar.Length - 1] = ac;
                        IlkMayininEtrafiniAc(a, b);
                    }
                    else
                    {
                        if (acilacakMayinlar.Any(d => d == ac) == false && mayinlar[a, b] != "X")
                        {
                            Array.Resize(ref acilacakMayinlar, acilacakMayinlar.Length + 1);
                            acilacakMayinlar[acilacakMayinlar.Length - 1] = ac;
                        }
                    }
                }
            }
        }


        private void MayinlariDoldur()//mayinlar dizimizi butonlar ile eşliyoruz.
        {
            for (int i = 0; i < sutunSayisi; i++)
            {
                for (int j = 0; j < satırSayisi; j++)
                {
                    string btnName = i.ToString() + "-" + j.ToString();
                    Button btn = this.Controls.Find(btnName, true).FirstOrDefault() as Button;
                    string[] data = btn.Tag as string[];
                    btn.Text = mayinlar[i, j].ToString();
                    if (btn.Text == "0")
                    {
                        btn.Text = " ";
                    }
                    data[0] = mayinlar[i, j];
                    btn.Tag = data;
                }
            }
        }

        private void IlkHucreninEtrafiniAc()//acilacak mayinlar dizimize göre gerekli hücreleri açıyoruz
        {
            foreach (var item in acilacakMayinlar)
            {
                Button btn = this.Controls.Find(item, true).FirstOrDefault() as Button;
                string[] data = btn.Tag as string[];
                if (btn != null)
                {
                    HucreAc(btn, data);
                }
            }
        }

        private void BosHucreninEtrafiniAc(int x, int y)//bir bos hücrenin etrafındaki diğer boş hücreler ve onlara
        {                                           //komşu mayınsız hücreleri toplu açmak için metot
            for (int a = x - 1; a <= x + 1; a++)
            {
                if (a < 0 || a >= sutunSayisi)
                {
                    continue;
                }
                for (int b = y - 1; b <= y + 1; b++)
                {
                    if (b < 0 || b >= satırSayisi)
                    {
                        continue;
                    }
                    string ac = a.ToString() + "-" + b.ToString();
                    Button btn = this.Controls.Find(ac, true).FirstOrDefault() as Button;
                    string[] data = btn.Tag as string[];
                    if (mayinlar[a, b] == "0")
                    {
                        if (btn != null && btn.Text == " " && data[3] == "K")
                        {
                            HucreAc(btn, data);
                            BosHucreninEtrafiniAc(a, b);
                        }
                    }
                    else
                    {
                        if (btn != null && btn.Text != "X" && data[3] == "K")
                        {
                            HucreAc(btn, data);
                        }
                    }
                }
            }
        }

        private void HucreAc(Button btn, string[] data)//Tıkladığımız mayınsız hücreleri açtığımız metot
        {
            skorSayar++;
            SkorCheck();
            data[3] = "A";
            btn.ForeColor = Color.Black;
            btn.BackColor = Color.LightGray;
        }

        private void SkorCheck()//skor sayımız bitis skoruna ulaştığında bitiş mesajı veren metot 
        {
            if (skorSayar == bitisSkoru)
            {
                timer1.Stop();
                MesajGoster($"Oyunu kazandınız! \nToplam Süre = {lblSure.Text} \nTekrar Oynamak İster Misiniz?", "TEBKRİKLER", MessageBoxButtons.YesNo);

            }
        }

        private void MesajGoster(string v1, string v2, MessageBoxButtons button)//mesajlar için bir metot
        {
            DialogResult result = MessageBox.Show(v1, v2, button, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)     //evet denirse baştan başlıyor
            {
                btnOyna.PerformClick();
            }
            else if (result == DialogResult.No)     //hayır denirse uygulamayı kapatıyor
            {
                Application.Exit();
            }
        }

        private void BayrakSayisiGuncelle(int v)    //Bayrak sayısını güncelliyor.
        {
            bayrakSayisi += v;
            lblBayrak.Text = bayrakSayisi.ToString();
        }

        private void MayinlariPatlat()  //bir mayına tıklanırsa tüm mayınları patlatıyor
        {
            foreach (var item in grpMayinAlani.Controls)
            {
                Button btn = item as Button;
                string[] data = btn.Tag as string[];
                if (data[0] == "X")
                {
                    btn.BackColor = Color.Red;
                }
            }
        }

        private void rdOzel_CheckedChanged(object sender, EventArgs e)
        {
            if (rdOzel.Checked == true)
            {
                nbrSutun.Enabled = true;
                nbrSatır.Enabled = true;
                nbrBomba.Enabled = true;
            }
            else
            {
                nbrSutun.Enabled = false;
                nbrSatır.Enabled = false;
                nbrBomba.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)    //timer her saniye çalışan bir nesne
        {
            saniye++;
            TimeSpan sure = TimeSpan.FromSeconds(saniye);
            lblSure.Text = sure.Minutes.ToString() + ":" + sure.Seconds.ToString("D2");
        }

        private void ZamanlayiciBaslat()
        {
            saniye = 0;
            timer1.Start();
        }
    }
}
