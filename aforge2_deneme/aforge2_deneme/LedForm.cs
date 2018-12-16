using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.IO.Ports;


namespace aforge2_deneme
{
    public partial class LedForm : Form
    {
        public LedForm()
        {
            InitializeComponent();
        }

        Bitmap video, video2;
        Graphics g;
        int mode;
        bool onof=false;

        int th = 5,red1,green1,blue1;

        private FilterInfoCollection kamera;
        private VideoCaptureDevice kameraisim;


        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox2.DataSource = SerialPort.GetPortNames();

            kamera = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo isim in kamera)
            {
                comboBox1.Items.Add(isim.Name);
            }
            comboBox1.SelectedIndex = 0;
            kameraisim = new VideoCaptureDevice();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kameraisim = new VideoCaptureDevice(kamera[comboBox1.SelectedIndex].MonikerString);
            kameraisim.NewFrame += new NewFrameEventHandler(video_karesi);
            kameraisim.Start();
        }

        private void video_karesi(object sender, NewFrameEventArgs eventArgs)
        {
           
            video2 = (Bitmap)eventArgs.Frame.Clone();
             video = (Bitmap)eventArgs.Frame.Clone();
            
            switch (mode)
            {

                case 2:

                    {
                        g = Graphics.FromImage(video2);
                        g.DrawString(th.ToString(), new Font("Arial", 20), new SolidBrush(Color.White), new PointF(2, 2));
                        g.Dispose();
                    }
                    break;
                case 1:

                    {


                        Mirror filter = new Mirror(false, true);
                        ColorFiltering renkfiltre = new ColorFiltering();
                        filter.ApplyInPlace(video2);
                        filter.ApplyInPlace(video);

                        renkfiltre.Red = new IntRange(red1,(int) numericUpDownred.Value);
                        renkfiltre.Green = new IntRange(green1, (int)numericUpDowngreen.Value);
                        renkfiltre.Blue = new IntRange(blue1, (int)numericUpDownblue.Value);                        
                        renkfiltre.ApplyInPlace(video2);

                        BlobCounter blob = new BlobCounter();
                        blob.MinHeight = 20;
                        blob.MinWidth = 20;
                        blob.ObjectsOrder = ObjectsOrder.Size;
                        blob.ProcessImage(video2);
                        Rectangle[] kare = blob.GetObjectsRectangles();

                        
                        if (kare.Length > 0)
                        {
                            
                            Rectangle nesne = kare[0];
                           Graphics graphics = Graphics.FromImage(video2);

                            using (Pen pen = new Pen(Color.White, 3))
                            {
                                graphics.DrawRectangle(pen, nesne);

                            
                              
                            }
                            int nesneX = nesne.X + (nesne.Width / 2);
                            int nesneY = nesne.Y + (nesne.Height / 2);

                            Console.WriteLine(nesneX + "," + nesneY);

                           if (nesneX > 0 && nesneX <400 && nesneY<225)
                            {
                                Console.WriteLine("nesne sol kösede kor:"+nesneX+","+nesneY);
                               serialPort1.Write("1");
                            }
                            if (nesneX > 401 && nesneX<800 && nesneY < 225)
                            {
                               Console.WriteLine("nesne ortada kor:" + nesneX + "," + nesneY);
                               serialPort1.Write("2");
                            }
                            if (nesneX > 801 && nesneX < 1200 && nesneY < 225)
                            {
                                Console.WriteLine("nesne sagda kösede kor:" + nesneX + "," + nesneY);
                               serialPort1.Write("3");
                            }


                            if (nesneX > 0 && nesneX < 400 && nesneY > 226 && nesneY < 450)
                            {
                                Console.WriteLine("nesne sol ortada kor:" + nesneX + "," + nesneY);
                                serialPort1.Write("4");
                            }
                            if (nesneX > 401 && nesneX <800 && nesneY > 226 && nesneY < 450)
                            {
                                Console.WriteLine("nesne ortada kor:" + nesneX + "," + nesneY);
                                 serialPort1.Write("5");
                            }
                            if (nesneX > 801 && nesneX < 1200 && nesneY > 226 && nesneY < 450)
                            {
                                Console.WriteLine("nesne sağ ortada kor:" + nesneX + "," + nesneY);
                                serialPort1.Write("6");
                            }

                            if (nesneX > 0 && nesneX < 400 && nesneY > 451 && nesneY < 700)
                            {
                                Console.WriteLine("nesne sol alt köşede kor:" + nesneX + "," + nesneY);
                               serialPort1.Write("7");
                            }
                            if (nesneX > 401 && nesneX < 800 && nesneY > 451 && nesneY < 700)
                            {
                                Console.WriteLine("nesne alt ortada kor:" + nesneX + "," + nesneY);
                                serialPort1.Write("8");
                            }
                            if (nesneX > 801 && nesneX < 1200 && nesneY > 451 && nesneY < 700)
                            {
                                Console.WriteLine("nesne sağ altta kor:" + nesneX + "," + nesneY);
                                serialPort1.Write("9");
                            }

                            pictureBox2.Image = video2;
                            graphics.Dispose();
                        }
                      
                    }
                    break;
            }
            pictureBox1.Image = video;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kameraisim.IsRunning==true)
            {
                kameraisim.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            th--;
            if (th==0)
            {
                timer1.Enabled = false;
                onof = false;
                pictureBox2.Image = video;
            }
           
        }

      

        private void button4_Click(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            mode = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mode = 1;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.PortName = comboBox2.SelectedItem.ToString();
            serialPort1.Open();

            if (serialPort1.IsOpen)
            {
                label1.Text = ("Port Acıldı");
            }
            else
            {
                label1.Text = ("Port Bağlayın");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = (Bitmap)pictureBox1.Image.Clone();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            red1 = (int)trackBar1.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            green1 = (int)trackBar1.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            blue1 = (int)trackBar1.Value;
        }

       


    }
}
