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
        int dem = 0;
        bool end = false;
        public CoCaro()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoCaro));
            this.restart = new System.Windows.Forms.Button();
            this.exitGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // restart
            // 
            this.restart.BackColor = System.Drawing.Color.Yellow;
            this.restart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restart.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.restart.ForeColor = System.Drawing.Color.Blue;
            this.restart.Location = new System.Drawing.Point(20, 10);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(200, 50);
            this.restart.TabIndex = 0;
            this.restart.Text = "Làm mới";
            this.restart.UseVisualStyleBackColor = false;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // exitGame
            // 
            this.exitGame.BackColor = System.Drawing.Color.Yellow;
            this.exitGame.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitGame.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.exitGame.ForeColor = System.Drawing.Color.Blue;
            this.exitGame.Location = new System.Drawing.Point(230, 10);
            this.exitGame.Name = "exitGame";
            this.exitGame.Size = new System.Drawing.Size(100, 50);
            this.exitGame.TabIndex = 0;
            this.exitGame.Text = "Thoát";
            this.exitGame.UseVisualStyleBackColor = false;
            this.exitGame.Click += new System.EventHandler(this.exit_Click);
            //
            // Grid Table
            //
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 50; j++)
                {
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
            //
            // Label user
            //
            Label User = new Label();
            User.Text = "Lượt đánh: Người 1 (X)";
            User.Width = 300;
            User.Height = 50;
            User.Top = 10;
            User.Left = 500;
            User.Name = "User";
            User.Font = new Font("Times New Roman",20,FontStyle.Regular);
            User.Padding = new Padding(10);
            User.BackColor = Color.White;
            User.ForeColor = Color.Blue;
            this.Controls.Add(User);
            // 
            // CoCaro
            //
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(30, 20);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.exitGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoCaro";
            this.Padding = new Padding(20);
            this.Text = "Cờ Caro";
            this.ResumeLayout(false);

        }
        private void replay()
        {
            dem = 0;
            end = false;
            this.Controls["User"].Text = "Lượt đánh: Người 1 (X)";
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 50; j++)
                {
                    string name = "square_" + i.ToString() + "_" + j.ToString();
                    this.Controls[name].Text = "";
                }
        }
        private int[] getIJ(string str)
        {
            str=str.Remove(0,7);
            int[] ij = new int[2];
            string[] s = str.Split('_');
            ij[0] = Int32.Parse(s[0]);
            ij[1] = Int32.Parse(s[1]);
            return ij;
        }
        string last_btn="square_0_0";
        private void square_Click(object sender, EventArgs e)
        {
            if (end == true) MessageBox.Show("Click 'Làm mới' để bắt đầu ván khác!");
            else
            {
                Button btn = (Button)sender;
                if (btn.Text == "")
                {
                    Button lastbtn = this.Controls.Find(last_btn,false)[0] as Button;
                    lastbtn.FlatAppearance.BorderColor = Color.Green;
                    last_btn = btn.Name;
                    btn.FlatAppearance.BorderColor = Color.Orange;
                    dem++;
                    if (dem % 2 == 0)
                    {
                        btn.ForeColor = Color.Red;
                        btn.Text = "o";
                        this.Controls["User"].Text = "Lượt đánh: Người 1 (X)";
                    }
                    else
                    {
                        btn.ForeColor = Color.Blue;
                        btn.Text = "x";
                        this.Controls["User"].Text = "Lượt đánh: Người 2 (O)";
                    }
                    int[] ij = new int[2];
                    ij = getIJ(btn.Name);
                    int c = 0;
                    for (int i = -4; i <= 4; i++)
                    {
                        if (ij[0] + i < 0 || ij[0] + i >= 20 || ij[1] + i < 0 || ij[1] + i >= 50) continue;
                        string name = "square_" + (ij[0] + i).ToString() + "_" + (ij[1] + i).ToString();
                        if (this.Controls[name].Text == btn.Text) c++;
                        else c = 0;
                        if (c == 5) break;
                    }
                    if (c == 5) end = true;
                    else c = 0;
                    for (int i = -4; i <= 4; i++)
                    {
                        if (ij[1] + i < 0 || ij[1] + i >= 50) continue;
                        string name = "square_" + ij[0].ToString() + "_" + (ij[1] + i).ToString();
                        if (this.Controls[name].Text == btn.Text) c++;
                        else c = 0;
                        if (c == 5) break;
                    }
                    if (c == 5) end = true;
                    else c = 0;
                    for (int i = -4; i <= 4; i++)
                    {
                        if (ij[0] + i < 0 || ij[0] + i >= 20) continue;
                        string name = "square_" + (ij[0] + i).ToString() + "_" + ij[1].ToString();
                        if (this.Controls[name].Text == btn.Text) c++;
                        else c = 0;
                        if (c == 5) break;
                    }
                    if (c == 5) end = true;
                    else c = 0;
                    for (int i = -4; i <= 4; i++)
                    {
                        if (ij[0] - i < 0 || ij[0] - i >= 20 || ij[1] + i < 0 || ij[1] + i >= 50) continue;
                        string name = "square_" + (ij[0] - i).ToString() + "_" + (ij[1] + i).ToString();
                        if (this.Controls[name].Text == btn.Text) c++;
                        else c = 0;
                        if (c == 5) break;
                    }
                    if (c == 5) end = true;
                    else c = 0;
                    if (end == true)
                    {
                        if (dem % 2 == 0) MessageBox.Show("Người 2 (O) thắng!");
                        else MessageBox.Show("Người 1 (X) thắng!");
                    }
                    else if (dem == 1000)
                    {
                        MessageBox.Show("Hết ô đánh. Bất phân thắng bại!");
                        end = true;
                    }
                }
            }
        }
        private void restart_Click(object sender, EventArgs e)
        {
            this.replay();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}