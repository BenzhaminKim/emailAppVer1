using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net.Mail;
using EASendMail;
namespace GUI
{
    public partial class Form1 : Form
    {

        private bool _dragging = false;
        //private Point _offset;
        private Point _start_point = new Point(0,0);
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBind();
        }
        void DataBind()
        {
            //store user in the grid
            this.dgvUserData.DataSource = Users.SelectAllUsers();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void destination_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtattachment.Text = openFileDialog1.FileName.ToString();
                
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

           // SendToMultipleUsers.SendEmail();
            ///*
           /* try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                MailMessage message = new MailMessage();
                message.From = new MailAddress(textEmail.Text);
                if (txtdestination.Text != "")
                {
                    message.To.Add(txtdestination.Text);
                    message.Body = txtbody.Text;
                    message.Subject = txtsubject.Text;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                }
                if (txtattachment.Text != "")
                {
                    message.Attachments.Add(new Attachment(txtattachment.Text));
                }
                client.Credentials = new System.Net.NetworkCredential(textEmail.Text, textPw.Text);
                client.Send(message);
                message = null;
                MessageBox.Show("E-mail sent");
            }
            catch(Exception s)
            {
                MessageBox.Show("Failed to send e-mail");
            }
            */
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtfrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(_dragging)
            {
                Point p = PointToScreen(e.Location);
                //getting the point to the location of e.x and e.y
                Location = new Point(p.X - this._start_point.X,p.Y - this._start_point.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtattachment_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {//search email
            string email = this.txtEmailAdd.Text;
            bool result = UserService.SelectUser(email, out Users user);
            {
                if (!result)
                {
                    MessageBox.Show("User does not exist");
                    return;
                }
                this.txtNameAdd.Text = user.Name;
                this.txtEmailAdd.Text = user.Email;

                this.dgvUserData.DataSource = Users.SelectAllUsers().Where(d=>d.Email==email).ToList();
            }
        }

        private void btnAddEmail_Click(object sender, EventArgs e)
        {
            string name = this.txtNameAdd.Text;
            string email = this.txtEmailAdd.Text;
            var msgresult = MessageBox.Show($"Are you sure you want to add {email}?", "yes or no", MessageBoxButtons.YesNo);

            if (msgresult != DialogResult.Yes)
                return;
            bool result = UserService.CreateUser(email,name, out string msg);
            this.dgvUserData.DataSource = Users.SelectAllUsers();
            MessageBox.Show(msg);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textEmailAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNameAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string name = this.txtNameAdd.Text;
            string email = this.txtEmailAdd.Text;
            UserService.UpdateUser(name, email, out string msg);
            DataBind();
            MessageBox.Show(msg);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            string email = this.txtEmailAdd.Text;
            var msgresult = MessageBox.Show($"Are you sure you want to delete {email}?","Delete", MessageBoxButtons.YesNo);

            if (msgresult != DialogResult.Yes)
                return;
            UserService.DeleteUser(email, out string msg);
            DataBind();
            MessageBox.Show(msg);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            var sendEmail = new SendToMultipleUsers();

            sendEmail.subject = txtsubject.Text;
            sendEmail.body = txtbody.Text;
            sendEmail.users = txtdestination.Text;
            sendEmail.SendEmail();
            MessageBox.Show("success!");
        }
    }


    
}
