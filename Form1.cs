using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
using WMPLib;
using System.Threading;

namespace BuatJa
{
    public partial class Form1 : Form
    {
       
        List<Point> basspoint;
        List<Point> hihatpoint;
        List<Point> ridepoint;
        List<Point> crashpoint;
        List<Point> tom1point;
        List<Point> tom2point;
        List<Point> snarepoint;
        List<Point> floorpoint;
        List<Point> ccbdpoint;
        List<Point> ccspoint;
        List<Point> rcbdpoint;
        List<Point> rcspoint;
        List<Point> xhspoint;
        List<Point> xhbdpoint;
        Bitmap oriImage;
  
        public Form1()
        {
            InitializeComponent();

            basspoint = new List<Point>();
            hihatpoint = new List<Point>();
            floorpoint = new List<Point>();
            crashpoint = new List<Point>();
            ridepoint = new List<Point>();
            snarepoint = new List<Point>();
            tom1point = new List<Point>();
            tom2point = new List<Point>();
            ccbdpoint = new List<Point>();
            ccspoint = new List<Point>();
            rcbdpoint = new List<Point>();
            rcspoint = new List<Point>();
            xhspoint = new List<Point>();
            xhbdpoint = new List<Point>();

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            foreach (string line in File.ReadAllLines("hihat.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    hihatpoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            foreach (string line in File.ReadAllLines("bass.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    basspoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }
            
                                  
            //foreach (string line in File.ReadAllLines("bass.txt"))
            //{
            //    string[] parts = line.Split(',');

            //    foreach (string part in parts)
            //    {
            //        //Console.Write(parts[0] + "," + part[1]);
            //        //Console.WriteLine();
            //        basspoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));
            //    }
            //}

            //foreach (string line in File.ReadAllLines("hihat.txt"))
            //{
            //    string[] parts = line.Split(',');

            //    foreach (string part in parts)
            //    {
            //        //Console.Write(parts[0] + "," + part[1]);
            //        //Console.WriteLine();
            //        hihat.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));
            //    }// For demonstration.
            //}

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            //Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            //Bitmap tempo = (Bitmap)pictureBox1.Image;

            

            //foreach (Point temp in basspoint)
            //{
            //    tempo.SetPixel(temp.X, temp.Y, Color.Aqua);
            //}

            //foreach (Point temp in hihat)
            //{
            //    tempo.SetPixel(temp.X, temp.Y, Color.Aqua);
            //}

            //pictureBox1.Image = tempo;
            //pictureBox1.Refresh();

            ////pictureBox1.Image = oriImage;
         }

        Bitmap img = null;
        ////Bitmap coloredImg = null;            

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        public void hihat()
        {            
            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in hihatpoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.CornflowerBlue);
            }
            
           

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer hihat = new WMPLib.WindowsMediaPlayer();
                hihat.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\hihat.mp3";
                hihat.controls.play();

            }).Start();

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void bass()
        {
                       
            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in basspoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.Chocolate);
            }          

            new System.Threading.Thread(() =>
            {
            WMPLib.WindowsMediaPlayer bass = new WMPLib.WindowsMediaPlayer();
            bass.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\bass.mp3";
            bass.controls.play();
            }).Start();
                       
            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void crash()
        {            
            foreach (string line in File.ReadAllLines("crash.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    crashpoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in crashpoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.DarkRed);
            }
                      

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer bass = new WMPLib.WindowsMediaPlayer();
                bass.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\crash.mp3";
                bass.controls.play();
            }).Start();

            

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void floor()
        {            
            foreach (string line in File.ReadAllLines("floor.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    floorpoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in floorpoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.DeepPink);
            }

            

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer bass = new WMPLib.WindowsMediaPlayer();
                bass.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\floor.mp3";
                bass.controls.play();
            }).Start();

            

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();

        }

        public void ride()
        {            
            foreach (string line in File.ReadAllLines("rd.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    ridepoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in ridepoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.DarkOrchid);
            }

            

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer ride = new WMPLib.WindowsMediaPlayer();
                ride.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\ride.mp3";
                ride.controls.play();

            }).Start();

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();

        }

        public void snare()
        {
            
            foreach (string line in File.ReadAllLines("snare.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    snarepoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in snarepoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.Cyan);
            }

           
            

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer bass = new WMPLib.WindowsMediaPlayer();
                bass.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\snare.mp3";
                bass.controls.play();
            }).Start();


            

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void tom1()
        {
            
            foreach (string line in File.ReadAllLines("tom1.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    tom1point.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in tom1point)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.Crimson);
            }

            

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer ride = new WMPLib.WindowsMediaPlayer();
                ride.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\tom1.mp3";
                ride.controls.play();
            }).Start();

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void tom2()
        {
            
            foreach (string line in File.ReadAllLines("tom2.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    tom2point.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in tom2point)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.Aqua);
            }

            
            

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer bass = new WMPLib.WindowsMediaPlayer();
                bass.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\tom2.mp3";
                bass.controls.play();
            }).Start();

            

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void ccbd()
        {

            foreach (string line in File.ReadAllLines("ccbd.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    ccbdpoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in ccbdpoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.DarkGoldenrod);
            }

            

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer ccbd = new WMPLib.WindowsMediaPlayer();
                ccbd.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\ccbd.mp3";
                ccbd.controls.play();
            }).Start();

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void ccs()
        {

            foreach (string line in File.ReadAllLines("ccs.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    ccspoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in ccspoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.DarkKhaki);
            }

            

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer ccs = new WMPLib.WindowsMediaPlayer();
                ccs.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\ccs.mp3";
                ccs.controls.play();
            }).Start();

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void rcbd()
        {

            foreach (string line in File.ReadAllLines("rcbd.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    rcbdpoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in rcbdpoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.DarkMagenta);
            }

           

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer rcbd = new WMPLib.WindowsMediaPlayer();
                rcbd.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\rcbd.mp3";
                rcbd.controls.play();
            }).Start();

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void rcs()
        {

            foreach (string line in File.ReadAllLines("rcs.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    rcspoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in rcspoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.DarkOrange);
            }

            

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer rcs = new WMPLib.WindowsMediaPlayer();
                rcs.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\rcs.mp3";
                rcs.controls.play();
            }).Start();

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void xhs()
        {

            foreach (string line in File.ReadAllLines("xhs.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    xhspoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in xhspoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.DarkSeaGreen);
            }

            

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer xhs = new WMPLib.WindowsMediaPlayer();
                xhs.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\xhs.mp3";
                xhs.controls.play();
            }).Start();

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        public void xhbd()
        {

            foreach (string line in File.ReadAllLines("xhbd.txt"))
            {
                string[] parts = line.Split(',');

                foreach (string part in parts)
                {
                    //Console.Write(parts[0] + "," + part[1]);
                    //Console.WriteLine();
                    xhbdpoint.Add(new System.Drawing.Point(Convert.ToInt16(parts[0]), Convert.ToInt16(parts[1])));

                }
            }

            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
            Bitmap oriImage = (Bitmap)Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");

            Bitmap tempo = (Bitmap)pictureBox1.Image;

            foreach (Point temp in xhbdpoint)
            {
                tempo.SetPixel(temp.X, temp.Y, Color.DarkTurquoise);
            }

           

            new System.Threading.Thread(() =>
            {
                WMPLib.WindowsMediaPlayer xhbd = new WMPLib.WindowsMediaPlayer();
                xhbd.URL = @"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumsound\xhbd.mp3";
                xhbd.controls.play();
            }).Start();

            pictureBox1.Image = tempo;
            pictureBox1.Refresh();
        }

        
        private void button7_Click(object sender, EventArgs e)
        {
            string x = System.IO.File.ReadAllText(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset\yougiveloveabadname - bon jovi.txt");

            string[] z = x.Split('-');
            foreach (String y in z)
            {
                if (y.Equals("bd") || y.Equals("BD"))
                {
                    bass();
                    Thread.Sleep(100);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();                   
                }              

                else if (y.Equals("rd") || y.Equals("RD"))
                {
                    ride();
                    Thread.Sleep(100);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("rd1") || y.Equals("RD1"))
                {
                    ride();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("rd2") || y.Equals("RD2"))
                {
                    ride();
                    Thread.Sleep(2000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("hh") || y.Equals("HH"))
                {
                    hihat();
                    Thread.Sleep(100);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("hh1") || y.Equals("HH1"))
                {
                    hihat();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("hh2") || y.Equals("HH20"))
                {
                    hihat();
                    Thread.Sleep(2000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("hh3") || y.Equals("HH3"))
                {
                    hihat();
                    Thread.Sleep(3000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("t1") || y.Equals("t1"))
                {
                    tom1();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("t12") || y.Equals("t12"))
                {
                    tom1();
                    Thread.Sleep(2000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("t13") || y.Equals("t13"))
                {
                    tom1();
                    Thread.Sleep(3000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("t2") || y.Equals("T2"))
                {
                    tom2();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("t22") || y.Equals("T22"))
                {
                    tom2();
                    Thread.Sleep(2000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("t23") || y.Equals("T23"))
                {
                    tom2();
                    Thread.Sleep(3000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("sn") || y.Equals("SN"))
                {
                    snare();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("ft") || y.Equals("FT"))
                {
                    floor();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("cr") || y.Equals("CR"))
                {
                    tom1();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("ccbd") || y.Equals("CCBD")|| y.Equals("bdcc") || y.Equals("BDCC"))
                {
                    ccbd();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("ccs") || y.Equals("CCS") || y.Equals("scc") || y.Equals("SCC"))
                {
                    ccs();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("rcbd") || y.Equals("RCBD") || y.Equals("ccrc") || y.Equals("CCRC"))
                {
                    rcbd();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("xhs") || y.Equals("XHS") || y.Equals("sxh") || y.Equals("SXH"))
                {
                    xhs();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }
                else if (y.Equals("xhbd") || y.Equals("XHBD") || y.Equals("bdxh") || y.Equals("BDXH"))
                {
                    xhbd();
                    Thread.Sleep(1000);
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
                    pictureBox1.Refresh();
                }              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();

            if (of.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(of.FileName);
                StreamWriter writer = new StreamWriter("xhbd.txt");

                //string[] filePaths = Directory.GetFiles(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset\drumsetpng");


                //FiltersSequence fs = new FiltersSequence();
                //fs.Add(new Grayscale(0.2125, 0.7154, 0.0721));
                //fs.Add(new Threshold());
                //pictureBox1.Image = fs.Apply(img);
                //Bitmap threshImg = threshFil.Apply(img);

                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {

                        if (img.GetPixel(i, j).R != 255 && img.GetPixel(i, j).G != 255 && img.GetPixel(i, j).B != 255)
                        {
                            img.SetPixel(i, j, Color.Red);
                            writer.WriteLine(i + "," + j);

                        }

                    }
                    string line;
                    using (StreamReader reader = new StreamReader("snare.txt"))
                    {
                        line = reader.ReadLine();
                    }
                    Console.Write(line);
                }

                writer.Close();
                
                pictureBox1.Image = img;

               
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bass();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tom1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            floor();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tom2();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            snare();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            crash();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ride();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hihat();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            xhs();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            xhbd();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ccs();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ccbd();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            rcs();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            rcbd();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Acer\Documents\Visual Studio 2010\Projects\BuatJa\drumset.png");
        }

             
    }
}

             
            
        
    
