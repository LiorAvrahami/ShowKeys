using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KeyboardHook;

namespace ShowKeys {
    public partial class Options_Form : Form {

        List<List<int>> key_codes;
        List<List<string>> key_names;

        KeyboardHook keyboardHook;

        public Options_Form() {
            InitializeComponent();
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyIntercepted += On_Global_Key_Update;

            (key_codes, key_names) = Files_Utils.get_initiators();
            redraw();
        }

        private void redraw() {
            listBox1.Items.Clear();
            for (int i = 0; i < key_codes.Count(); i++) {
                string entry = "";
                for (int j = 0; j < key_codes[i].Count(); j++) {
                    entry += ", " + key_names[i][j] + ": " + key_codes[i][j].ToString();
                }
                listBox1.Items.Add(entry);
            }
        }

        List<int> keys_pressed_ints = new List<int>();
        List<string> keys_pressed_strings = new List<string>();
        public void On_Global_Key_Update(KeyboardHookEventArgs e) {
            if (BtnAddInitiator.Checked) {
                if (e.IsPressed) {
                    keys_pressed_ints.Add(e.KeyCode);
                    keys_pressed_strings.Add(e.KeyName);
                } else {
                    if (keys_pressed_ints.Count() == 0) { return; }
                    key_codes.Add(keys_pressed_ints.Distinct().ToList());
                    key_names.Add(keys_pressed_strings.Distinct().ToList());
                    keys_pressed_ints.Clear();
                    keys_pressed_strings.Clear();

                    Files_Utils.save_initiators(key_codes, key_names);
                    redraw();
                    BtnAddInitiator.Checked = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            key_codes.RemoveAt(listBox1.SelectedIndex);
            key_names.RemoveAt(listBox1.SelectedIndex);

            Files_Utils.save_initiators(key_codes, key_names);
            redraw();
        }

        private void Options_Form_FormClosed(object sender, FormClosedEventArgs e) {
            keyboardHook.Dispose();
        }
    }
}
