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
    public partial class KeyboardMapSelectionForm : Form {

        public KeyboardMapSelectionForm() {
            InitializeComponent();

            reload();
        }

        public void reload() {
            // load key board map names
            if (!Directory.Exists(Files_Utils.KeyBoardMap_folder_name)) {
                Directory.CreateDirectory(Files_Utils.KeyBoardMap_folder_name);
            }

            listBox1.Items.Clear();

            // add keybord map names to listbox
            string[] keyboardMapsPaths = Directory.GetDirectories(Files_Utils.KeyBoardMap_folder_name);
            foreach (var d in keyboardMapsPaths) {
                var dirName = new DirectoryInfo(d).Name;
                listBox1.Items.Add(dirName);
            }

            refresh_visuals();
        }

        public void refresh_visuals() {
            if (listBox1.SelectedIndex == -1 && listBox1.Items.Count != 0) {
                listBox1.SelectedIndex = 0;
            }

            try {
                // set image 
                string image_file = Files_Utils.get_image_file(get_path_to_current_map_folder());
                pictureBox1.Image = Image.FromFile(image_file);

                // set number of keys
                Dictionary<int, List<Point>> map = Files_Utils.load_pointMap_from_file(listBox1.SelectedItem as string);
                NumKeysLbl.Text = "number of keys: " + map.Count.ToString();
            } catch (Exception ex) { }
        }

        public string get_path_to_current_map_folder() {
            return Path.Join(Files_Utils.KeyBoardMap_folder_name, (listBox1.SelectedItem as string));
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            refresh_visuals();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Select
            Files_Utils.save_selected(get_path_to_current_map_folder());
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            string path = get_path_to_current_map_folder();
            // Delete
            DialogResult dialogResult = MessageBox.Show("Delete " + path, "confirm delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) {
                Files_Utils.DeleteDirectory(path);
                reload();
            }

        }

        private void button3_Click(object sender, EventArgs e) {
            // Add New
            KeyBoardMapCreationForm CreatMapForm = new KeyBoardMapCreationForm();
            CreatMapForm.ShowDialog();
            reload();
        }
    }
}
