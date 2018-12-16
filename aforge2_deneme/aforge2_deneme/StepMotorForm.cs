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
    public partial class StepMotorForm : Form
    {
        public StepMotorForm()
        {
            InitializeComponent();
        }

        Bitmap video, video2;
        Graphics g;
        int mode;
        bool onof = false;

        int th = 5, red1, green1, blue1;

        private FilterInfoCollection kamera;
        private VideoCaptureDevice kameraisim;

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
                case 1:

                    {

                        Mirror filter = new Mirror(false, true);
                        ColorFiltering renkfiltre = new ColorFiltering();
                        filter.ApplyInPlace(video2);
                        filter.ApplyInPlace(video);

                        renkfiltre.Red = new IntRange(red1, (int)numericUpDownred.Value);
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
                            int ortaX = video2.Width / 2;
                            int nesneX = nesne.X + (nesne.Width / 2);
                            int nesneY = nesne.Y + (nesne.Height / 2);
                            int kalan = 0;

                            if (nesneX > 80 && nesneX < 600)
                            {
                                kalan = nesneX - ortaX;
                                if (kalan < 0)
                                {
                                    // Console.WriteLine("sola dönücek kalan kucuk", kalan);
                                    serialPort1.Write("1");
                                }
                                if (kalan == 0)
                                {
                                    // Console.WriteLine("sola dönücek 0", kalan);
                                    serialPort1.Write("3");
                                }
                                if (kalan > 0)
                                {
                                    //  Console.WriteLine("sola dönücek kalan buyuk", kalan);
                                    serialPort1.Write("2");
                                }
                            }



                            Console.WriteLine(nesneX + " , " + nesneY + " , " + ortaX + " " + kalan);

                            pictureBox2.Image = video2;
                            graphics.Dispose();

                        }
                    }
                    break;
            }
            pictureBox1.Image = video;
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
                MessageBox.Show("Port Bağlayın");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mode = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialPort1.Write("2");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            red1 = (int)trackBar1.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            th--;
            if (th == 0)
            {
                timer1.Enabled = false;
                onof = false;
                pictureBox2.Image = video;
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            green1 = (int)trackBar1.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            blue1 = (int)trackBar1.Value;
        }

        private void StepMotorForm_Load(object sender, EventArgs e)
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

        private void StepMotorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kameraisim.IsRunning == true)
            {
                kameraisim.Stop();
            }
        }
    }
}