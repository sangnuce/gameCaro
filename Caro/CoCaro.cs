using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public partial class CoCaro : Form
    {
        private int mode = 1;
        private int[][] diem = new int[20][];
        public CoCaro()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoCaro));
            this.SuspendLayout();
            // 
            // Mode
            // 
            Button mode1 = new Button();
            mode1.BackColor = System.Drawing.Color.Yellow;
            mode1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            mode1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            mode1.Font = new System.Drawing.Font("Times New Roman", 15, FontStyle.Regular);
            mode1.ForeColor = System.Drawing.Color.Blue;
            mode1.Location = new System.Drawing.Point(20, 10);
            mode1.Name = "mode1";
            mode1.Size = new System.Drawing.Size(100, 50);
            mode1.TabIndex = 0;
            mode1.Text = "1 Player";
            mode1.UseVisualStyleBackColor = false;
            mode1.Click += new System.EventHandler(this.mode1_Click);
            this.Controls.Add(mode1);

            Button mode2 = new Button();
            mode2.BackColor = System.Drawing.Color.Yellow;
            mode2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            mode2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            mode2.Font = new System.Drawing.Font("Times New Roman",15, FontStyle.Regular);
            mode2.ForeColor = System.Drawing.Color.Blue;
            mode2.Location = new System.Drawing.Point(122, 10);
            mode2.Name = "mode2";
            mode2.Size = new System.Drawing.Size(100, 50);
            mode2.TabIndex = 0;
            mode2.Text = "2 Players";
            mode2.UseVisualStyleBackColor = false;
            mode2.Click += new System.EventHandler(this.mode2_Click);
            this.Controls.Add(mode2);
            // 
            // exitGame
            // 
            Button exitGame = new Button();
            exitGame.BackColor = System.Drawing.Color.Yellow;
            exitGame.FlatAppearance.BorderColor = System.Drawing.Color.White;
            exitGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            exitGame.Font = new System.Drawing.Font("Times New Roman", 20F);
            exitGame.ForeColor = System.Drawing.Color.Blue;
            exitGame.Location = new System.Drawing.Point(230, 10);
            exitGame.Name = "exitGame";
            exitGame.Size = new System.Drawing.Size(100, 50);
            exitGame.TabIndex = 0;
            exitGame.Text = "Thoát";
            exitGame.UseVisualStyleBackColor = false;
            exitGame.Click += new System.EventHandler(this.exit_Click);
            this.Controls.Add(exitGame);
            // 
            // CoCaro
            //
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(30, 20);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoCaro";
            this.Padding = new Padding(20);
            this.Text = "Cờ Caro";
            this.ResumeLayout(false);
        }
        private void mode1_Click(object sender, EventArgs e)
        {
            this.mode = 1;
            Button mod1 = this.Controls.Find("mode1", true)[0] as Button;
            Button mod2 = this.Controls.Find("mode2", true)[0] as Button;
            mod1.Visible = false;
            mod2.Visible = false;
            this.khoiTao();
        }
        private void mode2_Click(object sender, EventArgs e)
        {
            this.mode = 2;
            Button mod1 = this.Controls.Find("mode1", true)[0] as Button;
            Button mod2 = this.Controls.Find("mode2", true)[0] as Button;
            mod1.Visible = false;
            mod2.Visible = false;
            this.khoiTao();
        }
        private void khoiTao()
        {
            // 
            // restart
            // 
            Button restart = new Button();
            restart.BackColor = System.Drawing.Color.Yellow;
            restart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            restart.Font = new System.Drawing.Font("Times New Roman", 20F);
            restart.ForeColor = System.Drawing.Color.Blue;
            restart.Location = new System.Drawing.Point(20, 10);
            restart.Name = "restart";
            restart.Size = new System.Drawing.Size(200, 50);
            restart.TabIndex = 0;
            restart.Text = "Làm mới";
            restart.UseVisualStyleBackColor = false;
            restart.Click += new System.EventHandler(this.restart_Click);
            this.Controls.Add(restart);
            //
            // Grid Table
            //
            for (int i = 0; i < 20; i++)
            {
                if (mode == 1) this.diem[i] = new int[50];
                for (int j = 0; j < 50; j++)
                {
                    if (mode == 1) this.diem[i][j] = 0;
                    Button square = new Button();
                    square.Text = "";
                    square.Width = 25;
                    square.Height = 25;
                    square.Top = 25 * i + 62;
                    square.Left = 25 * j + 20;
                    square.Name = "square_" + i.ToString() + "_" + j.ToString();
                    square.TextAlign = ContentAlignment.MiddleCenter;
                    square.Font = new Font("Times New Roman", 10, FontStyle.Regular);
                    square.BackColor = Color.White;
                    square.FlatStyle = FlatStyle.Flat;
                    square.FlatAppearance.BorderColor = Color.Green;
                    square.FlatAppearance.BorderSize = 1;
                    square.Click += new EventHandler(this.square_Click);
                    this.Controls.Add(square);
                }
            }
            //
            // Label user
            //
            if (mode == 2)
            {
                Label User = new Label();
                User.Text = "Lượt đánh: Người 1 (X)";
                User.Width = 300;
                User.Height = 50;
                User.Top = 10;
                User.Left = 500;
                User.Name = "user";
                User.Font = new Font("Times New Roman", 20, FontStyle.Regular);
                User.Padding = new Padding(10);
                User.BackColor = Color.White;
                User.ForeColor = Color.Blue;
                this.Controls.Add(User);
            }
        }
        private int[] getIJ(string str)
        {
            str = str.Remove(0, 7);
            int[] ij = new int[2];
            string[] s = str.Split('_');
            ij[0] = Int32.Parse(s[0]);
            ij[1] = Int32.Parse(s[1]);
            return ij;
        }
        private bool endGame(Button btn)
        {
            int[] ij = new int[2];
            ij = getIJ(btn.Name);
            int c = 0;
            for (int i = -4; i <= 4; i++)
            {
                if (ij[0] + i < 0 || ij[0] + i >= 20 || ij[1] + i < 0 || ij[1] + i >= 50) continue;
                string name = "square_" + (ij[0] + i).ToString() + "_" + (ij[1] + i).ToString();
                if (this.Controls[name].Text == btn.Text) c++;
                else c = 0;
                if (c == 5) return true;
            }
            c = 0;
            for (int i = -4; i <= 4; i++)
            {
                if (ij[1] + i < 0 || ij[1] + i >= 50) continue;
                string name = "square_" + ij[0].ToString() + "_" + (ij[1] + i).ToString();
                if (this.Controls[name].Text == btn.Text) c++;
                else c = 0;
                if (c == 5) return true;
            }
            c = 0;
            for (int i = -4; i <= 4; i++)
            {
                if (ij[0] + i < 0 || ij[0] + i >= 20) continue;
                string name = "square_" + (ij[0] + i).ToString() + "_" + ij[1].ToString();
                if (this.Controls[name].Text == btn.Text) c++;
                else c = 0;
                if (c == 5) return true;
            }
            c = 0;
            for (int i = -4; i <= 4; i++)
            {
                if (ij[0] - i < 0 || ij[0] - i >= 20 || ij[1] + i < 0 || ij[1] + i >= 50) continue;
                string name = "square_" + (ij[0] - i).ToString() + "_" + (ij[1] + i).ToString();
                if (this.Controls[name].Text == btn.Text) c++;
                else c = 0;
                if (c == 5) return true;
            }
            return false;
        }
        private void tinhDiem(Button btn, int i, int j)
        {
            this.diem[i][j] = 0;
            //Tinh diem cheo trai->phai
            for (int k = 4; k >= -4; k--)
            {
                if (k == 0 || i - k < 0 || i - k > 19 || j - k < 0 || j - k > 49) continue;
                Button btn1 = this.Controls.Find("square_" + (i - k).ToString() + "_" + (j - k).ToString(), false)[0] as Button;
                if (btn1.Text == "")
                {
                    int count = 0;
                    string first="";
                    string prev = "";
                    for (int u = k + 1; u <= k + 4; u++)
                    {
                        if (i - u < 0 || i - u > 19 || j - u < 0 || j - u > 49) continue;
                        Button btn2 = this.Controls.Find("square_" + (i - u).ToString() + "_" + (j - u).ToString(), false)[0] as Button;
                        if (btn2.Text != "" && prev == "")
                        {
                            prev = btn2.Text;
                            first = prev;
                        }
                        if (btn2.Text == prev && prev!="")
                            count++;
                        else break;
                    }
                    prev = "";
                    int c2 = 0;
                    for (int u = k - 1; u >= k - 4; u--)
                    {
                        if (i - u < 0 || i - u > 19 || j - u < 0 || j - u > 49) continue;
                        Button btn2 = this.Controls.Find("square_" + (i - u).ToString() + "_" + (j - u).ToString(), false)[0] as Button;
                        if (btn2.Text != "" && prev == "")
                        {
                            prev = btn2.Text;
                        }
                        if (btn2.Text == prev && prev != "")
                            if(btn2.Text == first)
                                count++;
                            else c2++;
                        else break;
                    }
                    if (c2 == 0)
                    {
                        if (this.diem[i - k][j - k] < count) this.diem[i - k][j - k] = count;
                    }
                    else
                    {
                        int max = count > c2 ? count : c2;
                        if (this.diem[i - k][j - k] < max) this.diem[i - k][j - k] = max;
                    }
                }
            }
            //Tinh diem cheo phai->trai
            for (int k = 4; k >= -4; k--)
            {
                if (k == 0 || i - k < 0 || i - k > 19 || j + k < 0 || j + k > 49) continue;
                Button btn1 = this.Controls.Find("square_" + (i - k).ToString() + "_" + (j + k).ToString(), false)[0] as Button;
                if (btn1.Text == "")
                {
                    int count = 0;
                    string first = "";
                    string prev = "";
                    for (int u = k + 1; u <= k + 4; u++)
                    {
                        if (i - u < 0 || i - u > 19 || j + u < 0 || j + u > 49) continue;
                        Button btn2 = this.Controls.Find("square_" + (i - u).ToString() + "_" + (j + u).ToString(), false)[0] as Button;
                        if (btn2.Text != "" && prev == "")
                        {
                            prev = btn2.Text;
                            first = prev;
                        }
                        if (btn2.Text == prev && prev != "")
                            count++;
                        else break;
                    }
                    prev = "";
                    int c2 = 0;
                    for (int u = k - 1; u >= k - 4; u--)
                    {
                        if (i - u < 0 || i - u > 19 || j + u < 0 || j + u > 49) continue;
                        Button btn2 = this.Controls.Find("square_" + (i - u).ToString() + "_" + (j + u).ToString(), false)[0] as Button;
                        if (btn2.Text != "" && prev == "")
                        {
                            prev = btn2.Text;
                        }
                        if (btn2.Text == prev && prev != "")
                            if (btn2.Text == first)
                                count++;
                            else c2++;
                        else break;
                    }
                    if (c2 == 0)
                    {
                        if (this.diem[i - k][j + k] < count) this.diem[i - k][j + k] = count;
                    }
                    else
                    {
                        int max = count > c2 ? count : c2;
                        if (this.diem[i - k][j + k] < max) this.diem[i - k][j + k] = max;
                    }
                }
            }
            //Tinh diem doc
            for (int k = 4; k >= -4; k--)
            {
                if (k == 0 || i - k < 0 || i - k > 19) continue;
                Button btn1 = this.Controls.Find("square_" + (i - k).ToString() + "_" + j.ToString(), false)[0] as Button;
                if (btn1.Text == "")
                {
                    int count = 0;
                    string first = "";
                    string prev = "";
                    for (int u = k + 1; u <= k + 4; u++)
                    {
                        if (i - u < 0 || i - u > 19) continue;
                        Button btn2 = this.Controls.Find("square_" + (i - u).ToString() + "_" + j.ToString(), false)[0] as Button;
                        if (btn2.Text != "" && prev == "")
                        {
                            prev = btn2.Text;
                            first = prev;
                        }
                        if (btn2.Text == prev && prev != "")
                            count++;
                        else break;
                    }
                    prev = "";
                    int c2 = 0;
                    for (int u = k - 1; u >= k - 4; u--)
                    {
                        if (i - u < 0 || i - u > 19) continue;
                        Button btn2 = this.Controls.Find("square_" + (i - u).ToString() + "_" + j.ToString(), false)[0] as Button;
                        if (btn2.Text != "" && prev == "")
                        {
                            prev = btn2.Text;
                        }
                        if (btn2.Text == prev && prev != "")
                            if (btn2.Text == first)
                                count++;
                            else c2++;
                        else break;
                    }
                    if (c2 == 0)
                    {
                        if (this.diem[i - k][j] < count) this.diem[i - k][j] = count;
                    }
                    else
                    {
                        int max = count > c2 ? count : c2;
                        if (this.diem[i - k][j - k] < max) this.diem[i - k][j] = max;
                    }
                }
            }
            //Tinh diem ngang
            for (int k = 4; k >= -4; k--)
            {
                if (k == 0 || j - k < 0 || j - k > 49) continue;
                Button btn1 = this.Controls.Find("square_" + i.ToString() + "_" + (j - k).ToString(), false)[0] as Button;
                if (btn1.Text == "")
                {
                    int count = 0;
                    string first = "";
                    string prev = "";
                    for (int u = k + 1; u <= k + 4; u++)
                    {
                        if (j - u < 0 || j - u > 49) continue;
                        Button btn2 = this.Controls.Find("square_" + i.ToString() + "_" + (j - u).ToString(), false)[0] as Button;
                        if (btn2.Text != "" && prev == "")
                        {
                            prev = btn2.Text;
                            first = prev;
                        }
                        if (btn2.Text == prev && prev != "")
                            count++;
                        else break;
                    }
                    prev = "";
                    int c2 = 0;
                    for (int u = k - 1; u >= k - 4; u--)
                    {
                        if (j - u < 0 || j - u > 49) continue;
                        Button btn2 = this.Controls.Find("square_" + i.ToString() + "_" + (j - u).ToString(), false)[0] as Button;
                        if (btn2.Text != "" && prev == "")
                        {
                            prev = btn2.Text;
                        }
                        if (btn2.Text == prev && prev != "")
                            if (btn2.Text == first)
                                count++;
                            else c2++;
                        else break;
                    }
                    if (c2 == 0)
                    {
                        if (this.diem[i][j - k] < count) this.diem[i][j - k] = count;
                    }
                    else
                    {
                        int max = count > c2 ? count : c2;
                        if (this.diem[i][j - k] < max) this.diem[i][j - k] = max;
                    }
                }
            }
        }
        private string timMax()
        {
            string name = "square_0_0";
            int max = 0;
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 50; j++)
                    if (this.diem[i][j] > max)
                    {
                        max = this.diem[i][j];
                        name = "square_" + i.ToString() + "_" + j.ToString();
                    }
            return name;
        }
        private int dem = 0;
        private bool end = false;
        private string last_btn = "square_0_0";
        private void square_Click(object sender, EventArgs e)
        {
            if (end == true) MessageBox.Show("Click 'Làm mới' để bắt đầu ván khác!");
            else
            {
                Button btn = (Button)sender;
                if (btn.Text == "")
                {
                    Button lastbtn = this.Controls.Find(last_btn, false)[0] as Button;
                    lastbtn.FlatAppearance.BorderColor = Color.Green;
                    last_btn = btn.Name;
                    btn.FlatAppearance.BorderColor = Color.Orange;
                    dem++;
                    if (mode == 2)
                    {
                        if (dem % 2 == 0)
                        {
                            btn.ForeColor = Color.Red;
                            btn.Text = "o";
                            this.Controls["user"].Text = "Lượt đánh: Người 1 (X)";
                        }
                        else
                        {
                            btn.ForeColor = Color.Blue;
                            btn.Text = "x";
                            this.Controls["user"].Text = "Lượt đánh: Người 2 (O)";
                        }
                    }
                    else
                    {
                        btn.ForeColor = Color.Blue;
                        btn.Text = "x";
                    }
                    end = endGame(btn);
                        if (end == true)
                        {
                            if (dem % 2 == 0)
                                if (mode == 1) MessageBox.Show("Máy (O) thắng!");
                                else MessageBox.Show("Người 2 (O) thắng!");
                            else MessageBox.Show("Người 1 (X) thắng!");
                        }
                        else if (dem == 1000)
                        {
                            MessageBox.Show("Hết ô đánh. Bất phân thắng bại!");
                            end = true;
                        }
                    if(mode==1)
                    {
                        if (end == false)
                        {
                            dem++;
                            int[] ij = new int[2];
                            ij = getIJ(btn.Name);
                            tinhDiem(btn, ij[0], ij[1]);
                            string name = timMax();
                            Button btn1 = this.Controls.Find(name, false)[0] as Button;
                            btn.FlatAppearance.BorderColor = Color.Green;
                            last_btn = btn1.Name;
                            btn1.FlatAppearance.BorderColor = Color.Orange;
                            btn1.ForeColor = Color.Red;
                            btn1.Text = "o";
                            end = endGame(btn1);
                            if (end == true)
                            {
                                if (dem % 2 == 0) MessageBox.Show("Máy (O) thắng!");
                                else MessageBox.Show("Người 1 (X) thắng!");
                            }
                            else if (dem == 1000)
                            {
                                MessageBox.Show("Hết ô đánh. Bất phân thắng bại!");
                                end = true;
                            }
                            ij = getIJ(name);
                            tinhDiem(btn1, ij[0], ij[1]);
                        }
                    }
                }
            }
        }
        private void restart_Click(object sender, EventArgs e)
        {
            dem = 0;
            Button lastbtn = this.Controls.Find(last_btn, false)[0] as Button;
            lastbtn.FlatAppearance.BorderColor = Color.Green;
            last_btn = "square_0_0";
            end = false;
            if (mode == 2) this.Controls["user"].Text = "Lượt đánh: Người 1 (X)";
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 50; j++)
                {
                    if (mode == 1) this.diem[i][j] = 0;
                    string name = "square_" + i.ToString() + "_" + j.ToString();
                    this.Controls[name].Text = "";
                }
        }
        private void exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}