using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowKeys {
    public partial class KeyBoardMapCreationForm : Form {
        int cur_x;
        int cur_y;

        OpenFileDialog select_image_dialog;

        Dictionary<int, List<Point>> key_map = new Dictionary<int, List<Point>>();

        Image_Processor im_proces;

        public KeyBoardMapCreationForm() {
            InitializeComponent();
            picture_box_height_delta = this.Height - pictureBox1.Height;
            bottom_row_y_delta = this.Height - label1.Location.Y;
            mDummyControl.Location = new Point(-1000, -1000);
        }

        private void KeyBoardMapCreationForm_Load(object sender, EventArgs e) {
            select_image_dialog = new OpenFileDialog();
            DialogResult dialogResult = DialogResult.Cancel;
            dialogResult = select_image_dialog.ShowDialog();
            if(dialogResult == DialogResult.Cancel) {
                Close();
                return;
            }

            im_proces = new Image_Processor(select_image_dialog.FileName);
            pictureBox1.Image = im_proces.get_origional_image();
            pictureBox1_Resize(null, null);
        }

        private float get_ratio() {
            return (float)pictureBox1.Image.Height / pictureBox1.Height;
        }

        private void add_to_keymap(int key, Point p) {
            if (!key_map.ContainsKey(key)) {
                key_map.Add(key, new List<Point>());
            }
            key_map[key].Add(p);
        }

        public void set_x(int x, int y) {
            float ratio = get_ratio();
            cur_x = (int)(x * ratio);
            cur_y = (int)(y * ratio);
            pictureBox1.Image = im_proces.invert_single_rectangle(new Point(cur_x, cur_y));
        }

        public void clear_x() {
            pictureBox1.Image = im_proces.get_origional_image();
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            MouseEventArgs me = (e as MouseEventArgs);
            int x = me.X;
            int y = me.Y;
            set_x(x, y);
            mDummyControl.Focus();
            //this.Focus();
        }


        private void KeyBoardMapCreationForm_KeyDown(object sender, KeyEventArgs e) {
            add_to_keymap(e.KeyValue, new Point(cur_x, cur_y));
            label1.Text = e.KeyValue.ToString() + "| " + e.KeyData.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text != "") {
                Files_Utils.save_to_file(key_map, textBox1.Text, select_image_dialog.FileName);
                Close();
            } else {
                MessageBox.Show("fill in name");
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e) {
            float ratio = get_ratio();
            pictureBox1.Width = (int)(pictureBox1.Image.Width / ratio);
        }


        int picture_box_height_delta;
        int bottom_row_y_delta;
        private void KeyBoardMapCreationForm_Resize(object sender, EventArgs e) {
            pictureBox1.Height = this.Height - picture_box_height_delta;
            button1.Location = new Point(button1.Location.X, this.Height - bottom_row_y_delta);
            label1.Location = new Point(label1.Location.X, this.Height - bottom_row_y_delta);
        }
    }
}
