using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WMPLib;

namespace GameGhepHinh
{
    public partial class Form1 : Form
    {
        private PictureBox[,] ptb;
        private Bitmap[,] aBmp;
        private Label lbShowTime;
        private static int edgBm;
        private static int RowColum;
       // private static WindowsMediaPlayer mc;
        private static Timer timer;
        private static Timer timer2;
        private int time;
        private static Font fOv = new Font("Time New Roman", 32);
        private static Font fTime = new Font("Time New Roman", 14);
        private static bool xepSo;
        private Button btnMenu1;
        private Button btnMenu2;
        private Button btn3x3;
        private Button btn4x4;
        private Button btn5x5;
        private int iMenu;

        public Form1()
        {
            timer2 = new Timer();
            timer = new Timer();
            InitializeComponent();

            iMenu = 0;
            timer2.Interval = 15;
            timer.Interval = 1000;
            timer2.Tick += Timer2_Tick;
            timer.Tick += Timer_Tick;
            //backGroudMenu();
            MenuNewGame();
            timer2.Start();
        }



        private void backGroudMenu()
        {
            this.BackgroundImage = Properties.Resources.ImgBG;

        }

        private void lbNewGame()
        {
            Label lb = new Label();
            lb.Top = 350;
            lb.Left = 580;
            lb.Text = "Game Mới";
            lb.Font = fOv;
            lb.AutoSize = true;
            lb.BackColor = Color.MistyRose;
            lb.Parent = this;

            Label lb2 = new Label();
            lb2.Top = 450;
            lb2.Left = 600;
            lb2.Text = "Save ảnh";
            lb2.Font = fTime;
            lb2.AutoSize = true;
            lb2.BackColor = Color.MistyRose;
            lb2.Parent = this;

            lb2.Click += Lb2_Click;

            lb.Click += Lb_Click;
        }

        private void Lb2_Click(object sender, EventArgs e)
        {
            LayAnh();
        }

        private void Lb_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            timer.Stop();
          //  mc.controls.stop();
            MenuNewGame();
            timer2.Start();
            iMenu = 0;
        }

        private void MenuNewGame()
        {
            btnMenu1 = new Button();
            btnMenu2 = new Button();
            btnMenu1.Top = 200;
            btnMenu1.Left = -440;
            btnMenu1.Text = "Xếp Số";
            btnMenu2.Text = "Xếp Ảnh";
            btnMenu1.Font = fOv;
            btnMenu2.Font = fOv;
            btnMenu1.BackColor = Color.PaleGreen;
            btnMenu2.BackColor = Color.LightSeaGreen;
            btnMenu1.AutoSize = true;
            btnMenu2.AutoSize = true;
            btnMenu2.Top = 300;
            btnMenu2.Left = 1050;
            btnMenu2.Parent = this;
            btnMenu1.Parent = this;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (iMenu < 150)
            {
                btnMenu1.Left += 5;
                btnMenu2.Left -= 5;
                iMenu++;
            }
            else
            {
                timer2.Stop();
                btnMenu1.Click += Btn1_Click;
                btnMenu2.Click += Btn2_Click;
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            xepSo = false;
            cheDoChoi();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            xepSo = true;
            cheDoChoi();
        }

        private void cheDoChoi()
        {
            btn4x4 = new Button();
            btn5x5 = new Button();
            btn3x3 = new Button();

            btn4x4.Top = 150;
            btn4x4.Left = 350;

            btn3x3.Top = 50;
            btn3x3.Left = 350;

            btn5x5.Top = 250;
            btn5x5.Left = 350;

            btn3x3.Text = "3 x 3";
            btn4x4.Text = "4 x 4";
            btn5x5.Text = "5 x 5";

            btn3x3.Font = fOv;
            btn4x4.Font = fOv;
            btn5x5.Font = fOv;

            btn3x3.BackColor = Color.AliceBlue;
            btn4x4.BackColor = Color.PaleGreen;
            btn5x5.BackColor = Color.PaleVioletRed;

            btn3x3.AutoSize = true;
            btn4x4.AutoSize = true;
            btn5x5.AutoSize = true;

            btn3x3.Parent = this;
            btn4x4.Parent = this;
            btn5x5.Parent = this;

            btn3x3.Click += Btn3x3_Click;
            btn4x4.Click += Btn4x4_Click;
            btn5x5.Click += Btn5x5_Click;
        }

        private void Btn3x3_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            edgBm = 150;
            RowColum = 3;
            aBmp = new Bitmap[RowColum, RowColum];
            ptb = new PictureBox[RowColum, RowColum];
            if (xepSo)
            {
                loadNumber3();
                ShowPtNumber3();
            }
            else catHinh3();

            SetPtr();
            TronAnh();
            ShowTime();
            lbNewGame();
        }

        private void Btn5x5_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            edgBm = 100;
            RowColum = 5;
            aBmp = new Bitmap[RowColum, RowColum];
            ptb = new PictureBox[RowColum, RowColum];
            if (xepSo)
            {
                LoadNumberPt();
                ShowPtNumber();
            }
            else CatHinh();

            SetPtr();
            TronAnh();
            ShowTime();
            lbNewGame();
        }

        private void Btn4x4_Click(object sender, EventArgs e)
        {
            Controls.Clear();
            edgBm = 125;
            RowColum = 4;
            aBmp = new Bitmap[RowColum, RowColum];
            ptb = new PictureBox[RowColum, RowColum];
            if (xepSo)
            {
                loadNumber4();
                ShowPtNumber4();
            }
            else catHinh4();

            SetPtr();
            TronAnh();
            ShowTime();
            lbNewGame();
        }

        private void ShowTime()
        {
           // mc = new WindowsMediaPlayer();
         //   mc.URL = "EDM-China.mp3";
          //  mc.controls.play();

            Label lb = new Label();
            lb.Top = 280;
            lb.Left = 600;
            lb.AutoSize = true;
            lb.Text = "Thời gian:";
            lb.Font = fTime;
            lb.BackColor = Color.Transparent;
            lb.Parent = this;
            lbShowTime = new Label();
            lbShowTime.Top = 280;
            lbShowTime.Left = 695;
            lbShowTime.AutoSize = true;
            lbShowTime.BackColor = Color.Transparent;
            lbShowTime.Font = fTime;
            lbShowTime.Parent = this;
            time = 0;
            lbShowTime.Text = time.ToString();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lbShowTime.Text = time.ToString() + " s";

            if (time == 210 || time == 420 || time == 630)
            {
              //  mc.controls.stop();
              //  mc.controls.play();
            }
            time++;
        }

        public void SetPtr()
        {
            for (int i = 0; i < RowColum; i++)
            {
                for (int j = 0; j < RowColum; j++)
                {
                    ptb[i, j] = new PictureBox();
                    ptb[i, j].Parent = this;
                    ptb[i, j].Top = i * (edgBm + 2) + 20;
                    ptb[i, j].Left = j * (edgBm + 2) + 20;
                    ptb[i, j].Size = new Size(edgBm, edgBm);
                    ptb[i, j].BackColor = Color.BurlyWood;

                    ptb[i, j].Click += Form1_Click;
                }
            }

            for (int i = 0; i < RowColum - 1; i++)
            {
                for (int j = 0; j < RowColum; j++)
                {
                    ptb[i, j].Image = aBmp[i, j];
                }
            }
            for (int j = 0; j < RowColum - 1; j++)
            {
                ptb[RowColum - 1, j].Image = aBmp[RowColum - 1, j];
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (CheckComplete()) return;
            PictureBox pt = (PictureBox)sender;
            if (pt.Image == null) return;
            int x = (pt.Top - 20) / (edgBm + 2);
            int y = (pt.Left - 20) / (edgBm + 2);

            if (x > 0 && ptb[x - 1, y].Image == null)
            {
                ptb[x - 1, y].Image = pt.Image;
                pt.Image = null;
            }
            else if (x < (RowColum - 1) && ptb[x + 1, y].Image == null)
            {
                ptb[x + 1, y].Image = pt.Image;
                pt.Image = null;
            }
            else if (y > 0 && ptb[x, y - 1].Image == null)
            {
                ptb[x, y - 1].Image = pt.Image;
                pt.Image = null;
            }
            else if (y < (RowColum - 1) && ptb[x, y + 1].Image == null)
            {
                ptb[x, y + 1].Image = pt.Image;
                pt.Image = null;
            }

            if (CheckComplete()) GameComple();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (CheckComplete()) return;
            bool br = false;
            if (e.KeyCode == Keys.Up)
            {
                for (int i = 1; i < RowColum; i++)
                {
                    for (int j = 0; j < RowColum; j++)
                    {
                        if (ptb[i - 1, j].Image == null)
                        {
                            ptb[i - 1, j].Image = ptb[i, j].Image;
                            ptb[i, j].Image = null;
                            br = true;
                            break;
                        }
                    }
                    if (br) break;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                for (int i = 0; i < RowColum - 1; i++)
                {
                    for (int j = 0; j < RowColum; j++)
                    {
                        if (ptb[i + 1, j].Image == null)
                        {
                            ptb[i + 1, j].Image = ptb[i, j].Image;
                            ptb[i, j].Image = null;
                            br = true;
                            break;
                        }
                    }
                    if (br) break;
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                for (int i = 0; i < RowColum; i++)
                {
                    for (int j = 1; j < RowColum; j++)
                    {
                        if (ptb[i, j - 1].Image == null)
                        {
                            ptb[i, j - 1].Image = ptb[i, j].Image;
                            ptb[i, j].Image = null;
                            br = true;
                            break;
                        }
                    }
                    if (br) break;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                for (int i = 0; i < RowColum; i++)
                {
                    for (int j = 0; j < RowColum - 1; j++)
                    {
                        if (ptb[i, j + 1].Image == null)
                        {
                            ptb[i, j + 1].Image = ptb[i, j].Image;
                            ptb[i, j].Image = null;
                            br = true;
                            break;
                        }
                    }
                    if (br) break;
                }
            }
            else return;
            if (CheckComplete()) GameComple();
        }

        private void GameComple()
        {
            Label lb = new Label();
            lb.Top = 200;
            lb.Left = 150;
            lb.AutoSize = true;
            lb.Text = "BẠN THẮNG";
            lb.BackColor = Color.Pink;
            lb.Font = fOv;
            lb.Parent = this;
            lb.BringToFront();

            timer.Stop();
           // mc.controls.stop();
        }

        private bool CheckComplete()
        {
            for (int i = 0; i < RowColum - 1; i++)
            {
                for (int j = 0; j < RowColum; j++)
                {
                    if (ptb[i, j].Image != aBmp[i, j]) return false;
                }
            }
            for (int j = 0; j < RowColum - 1; j++)
            {
                if (ptb[RowColum - 1, j].Image != aBmp[RowColum - 1, j]) return false;
            }

            return true;
        }

        private void TronAnh()
        {
            Random random = new Random();
            int r;
            bool f;
            int x = RowColum - 1, y = RowColum - 1;
            for (int i = 0; i < 200; i++)
            {
                do
                {
                    r = random.Next(1, 5);
                    if (r == 1)
                    {
                        if (x - 1 >= 0)
                        {
                            ptb[x, y].Image = ptb[x - 1, y].Image;
                            ptb[x - 1, y].Image = null;
                            x--;
                            f = false;
                        }
                        else f = true;
                    }
                    else if (r == 2)
                    {
                        if (y + 1 < RowColum)
                        {
                            ptb[x, y].Image = ptb[x, y + 1].Image;
                            ptb[x, y + 1].Image = null;
                            y++;
                            f = false;
                        }
                        else f = true;

                    }
                    else if (r == 3)
                    {
                        if (x + 1 < RowColum)
                        {
                            ptb[x, y].Image = ptb[x + 1, y].Image;
                            ptb[x + 1, y].Image = null;
                            x++;
                            f = false;
                        }
                        f = true;
                    }
                    else
                    {
                        if (y - 1 >= 0)
                        {
                            ptb[x, y].Image = ptb[x, y - 1].Image;
                            ptb[x, y - 1].Image = null;
                            y--;
                            f = false;
                        }
                        else f = true;
                    }
                } while (f);
            }
        }
        private void catHinh3()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            Bitmap bmp;
            Bitmap ptShow;

            openFile.ShowDialog();
            string s = openFile.FileName;
            Image img = Image.FromFile(s);
            bmp = new Bitmap(img, 500, 500);
            ptShow = new Bitmap(img, 246, 246);

            for (int i = 0; i < RowColum; i++)
            {
                for(int j = 0; j < RowColum; j++)
                {
                    aBmp[i, j] = new Bitmap(edgBm, edgBm);
                    for (int k = 0; k < edgBm; k++)
                    {
                        for(int l = 0; l < edgBm; l++)
                        {
                            aBmp[i, j].SetPixel(l, k, bmp.GetPixel(edgBm * j + l, edgBm * i + k));
                        }
                    }
                }
            }
            Graphics g = Graphics.FromImage(bmp);
            for(int i = 0; i < RowColum; i++)
            {
                g.DrawLine(Pens.Black, 0, i * 74, 246, i * 74);
                g.DrawLine(Pens.Black, i * 74, 0, i * 74, 246);
            }
            PictureBox ptb = new PictureBox();
            ptb.Image = ptShow;
            ptb.Top = 20;
            ptb.Left = 550;
            ptb.Width = 246;
            ptb.Height = 246;
            ptb.Parent = this;
        }

        private void catHinh4()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            Bitmap bmp;
            Bitmap ptShow;

            openFile.ShowDialog();
            string s = openFile.FileName;
            Image img = Image.FromFile(s);
            bmp = new Bitmap(img, 500, 500);
            ptShow = new Bitmap(img, 248, 248);

            for (int i = 0; i < RowColum; i++)
            {
                for (int j = 0; j < RowColum; j++)
                {
                    aBmp[i, j] = new Bitmap(edgBm, edgBm);
                    for (int k = 0; k < edgBm; k++)
                    {
                        for (int l = 0; l < edgBm; l++)
                        {
                            aBmp[i, j].SetPixel(l, k, bmp.GetPixel(edgBm * j + l, edgBm * i + k));
                        }
                    }
                }
            }

            Graphics g = Graphics.FromImage(ptShow);
            for (int i = 1; i < RowColum; i++)
            {
                g.DrawLine(Pens.Black, 0, i * 62, 248, i * 62);
                g.DrawLine(Pens.Black, i * 62, 0, i * 62, 248);
            }
            PictureBox ptb = new PictureBox();
            ptb.Image = ptShow;
            ptb.Top = 20;
            ptb.Left = 550;
            ptb.Width = 248;
            ptb.Height = 248;
            ptb.Parent = this;
        }

        private void CatHinh()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            Bitmap bmp;
            Bitmap ptShow;

            openFile.ShowDialog();
            string s = openFile.FileName;
            Image img = Image.FromFile(s);
            bmp = new Bitmap(img, 500, 500);
            ptShow = new Bitmap(img, 250, 250);

            for (int i = 0; i < RowColum; i++)
            {
                for (int j = 0; j < RowColum; j++)
                {
                    aBmp[i, j] = new Bitmap(edgBm, edgBm);
                    for (int k = 0; k < edgBm; k++)
                    {
                        for (int l = 0; l < edgBm; l++)
                        {
                            aBmp[i, j].SetPixel(l, k, bmp.GetPixel(edgBm * j + l, edgBm * i + k));
                        }
                    }
                }
            }

            Graphics g = Graphics.FromImage(ptShow);
            for (int i = 1; i < RowColum; i++)
            {
                g.DrawLine(Pens.Black, 0, i * 50, 250, i * 50);
                g.DrawLine(Pens.Black, i * 50, 0, i * 50, 250);
            }
            PictureBox ptb = new PictureBox();
            ptb.Image = ptShow;
            ptb.Top = 20;
            ptb.Left = 550;
            ptb.Width = 250;
            ptb.Height = 250;
            ptb.Parent = this;

        }

        private void LayAnh()
        {
            Image ptN = new Bitmap(500, 500);
            Graphics g = Graphics.FromImage(ptN);
            for (int i = 0; i < RowColum; i++)
            {
                for (int j = 0; j < RowColum; j++)
                {
                    if (ptb[i, j].Image != null)
                    {
                        g.DrawImage(ptb[i, j].Image, j * 100, i * 100, 100, 100);
                    }
                }
            }
            ptN.Save("D:/Hoc Tap/HK7/AnhGhepHinh/AnhGameGhepHinh.png"); 
            //ptN.Save("D:/Users/Dell/Desktop/AnhGameGhepHinh.png");
        }
        private void ShowPtNumber3()
        {
            Image ptN = new Bitmap(246, 246);
            Graphics g = Graphics.FromImage(ptN);
            for (int i = 0; i < RowColum -1; i++)
                for (int j = 0; j < RowColum; j++)
                {
                    g.DrawImage(aBmp[i, j], j * 74, i * 74, 74, 74);
                }
            for (int j = 0; j < RowColum; j++)
            {
                g.DrawImage(aBmp[RowColum - 1, j], j * 74, (RowColum - 1) * 74, 74, 74);
            }
            PictureBox ptb = new PictureBox();
            ptb.Image = ptN;
            ptb.Top = 20;
            ptb.Left = 550;
            ptb.Width = 246;
            ptb.Height = 246;
            ptb.BackColor = Color.BurlyWood;
            ptb.Parent = this;
        }


        private void ShowPtNumber()
        {
            Image ptN = new Bitmap(250, 250);
            Graphics g = Graphics.FromImage(ptN);
            for (int i = 0; i < RowColum - 1; i++)
                for (int j = 0; j < RowColum; j++)
                {
                    g.DrawImage(aBmp[i, j], j * 50, i * 50, 50, 50);
                }
            for (int j = 0; j < RowColum - 1; j++)
            {
                g.DrawImage(aBmp[RowColum - 1, j], j * 50, (RowColum - 1) * 50, 50, 50);
            }
            PictureBox ptb = new PictureBox();
            ptb.Image = ptN;
            ptb.Top = 20;
            ptb.Left = 550;
            ptb.Width = 250;
            ptb.Height = 250;
            ptb.BackColor = Color.BurlyWood;
            ptb.Parent = this;
        }

        private void ShowPtNumber4()
        {
            Image ptN = new Bitmap(248, 248);
            Graphics g = Graphics.FromImage(ptN);
            for (int i = 0; i < RowColum - 1; i++)
                for (int j = 0; j < RowColum; j++)
                {
                    g.DrawImage(aBmp[i, j], j * 62, i * 62, 62, 62);
                }
            for (int j = 0; j < RowColum - 1; j++)
            {
                g.DrawImage(aBmp[RowColum - 1, j], j * 62, (RowColum - 1) * 62, 62, 62);
            }
            PictureBox ptb = new PictureBox();
            ptb.Image = ptN;
            ptb.Top = 20;
            ptb.Left = 550;
            ptb.Width = 248;
            ptb.Height = 248;
            ptb.BackColor = Color.BurlyWood;
            ptb.Parent = this;
        }

        private void loadNumber3()
        {
            aBmp[0, 0] = Properties.Resources._1;
            aBmp[0, 1] = Properties.Resources._2;
            aBmp[0, 2] = Properties.Resources._3;
            aBmp[1, 0] = Properties.Resources._4;
            aBmp[1, 1] = Properties.Resources._5;
            aBmp[1, 2] = Properties.Resources._6;
            aBmp[2, 0] = Properties.Resources._7;
            aBmp[2, 1] = Properties.Resources._8;
            aBmp[2, 2] = Properties.Resources._9;
        }

        private void loadNumber4()
        {
            aBmp[0, 0] = Properties.Resources._1;
            aBmp[0, 1] = Properties.Resources._2;
            aBmp[0, 2] = Properties.Resources._3;
            aBmp[0, 3] = Properties.Resources._4;
            aBmp[1, 0] = Properties.Resources._5;
            aBmp[1, 1] = Properties.Resources._6;
            aBmp[1, 2] = Properties.Resources._7;
            aBmp[1, 3] = Properties.Resources._8;
            aBmp[2, 0] = Properties.Resources._9;
            aBmp[2, 1] = Properties.Resources._10;
            aBmp[2, 2] = Properties.Resources._11;
            aBmp[2, 3] = Properties.Resources._12;
            aBmp[3, 0] = Properties.Resources._13;
            aBmp[3, 1] = Properties.Resources._14;
            aBmp[3, 2] = Properties.Resources._15;
            aBmp[3, 3] = Properties.Resources._16;
        }

        private void LoadNumberPt()
        {
            aBmp[0, 0] = Properties.Resources._1;
            aBmp[0, 1] = Properties.Resources._2;
            aBmp[0, 2] = Properties.Resources._3;
            aBmp[0, 3] = Properties.Resources._4;
            aBmp[0, 4] = Properties.Resources._5;
            aBmp[1, 0] = Properties.Resources._6;
            aBmp[1, 1] = Properties.Resources._7;
            aBmp[1, 2] = Properties.Resources._8;
            aBmp[1, 3] = Properties.Resources._9;
            aBmp[1, 4] = Properties.Resources._10;
            aBmp[2, 0] = Properties.Resources._11;
            aBmp[2, 1] = Properties.Resources._12;
            aBmp[2, 2] = Properties.Resources._13;
            aBmp[2, 3] = Properties.Resources._14;
            aBmp[2, 4] = Properties.Resources._15;
            aBmp[3, 0] = Properties.Resources._16;
            aBmp[3, 1] = Properties.Resources._17;
            aBmp[3, 2] = Properties.Resources._18;
            aBmp[3, 3] = Properties.Resources._19;
            aBmp[3, 4] = Properties.Resources._20;
            aBmp[4, 0] = Properties.Resources._21;
            aBmp[4, 1] = Properties.Resources._22;
            aBmp[4, 2] = Properties.Resources._23;
            aBmp[4, 3] = Properties.Resources._24;

        }


    }
}
