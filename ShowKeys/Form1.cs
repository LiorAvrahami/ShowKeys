using System.Diagnostics;
using System.Runtime.InteropServices;
using static KeyboardHook;

namespace ShowKeys {
    public partial class Form1 : Form {
        bool is_paused = false;

        // each cell is an array which is the combinations of keys that initiat the program.
        List<List<int>> INITUATOR_KEY_SETS;

        KeyboardHook keyboardHook;

        bool inituator_pressed;

        bool[] key_down_table = new bool[1000];

        Dictionary<int, List<Point>> keyboard_point_map;

        Image_Processor img_proc;

        public Form1() {
            InitializeComponent();
            keyboardHook = new KeyboardHook();
            keyboardHook.KeyIntercepted += On_Global_Key_Update;
            keyboardHook.ShouldBlockKey += should_supress;

            keyboard_point_map = Files_Utils.load_selecttd_keyboard_pointMap();

            img_proc = new Image_Processor(Files_Utils.get_selecttd_image_file());

            INITUATOR_KEY_SETS = Files_Utils.get_initiators().Item1;
        }

        private List<int> get_down_keys() {
            List<int> ret = new List<int>();
            for (int i = 0; i < key_down_table.Length; i++) {
                if (key_down_table[i]) {
                    ret.Add(i);
                }
            }
            return ret;
        }

        private bool is_inituator_pressed() {
            foreach (List<int> key_set in INITUATOR_KEY_SETS) {
                bool succes = true;
                foreach (int key in key_set) {
                    if (!key_down_table[key]) {
                        succes = false;
                        break;
                    }
                }
                if (succes) {
                    return true;
                }
            }
            return false;
        }

        public void On_Global_Key_Update(KeyboardHookEventArgs e) {
            if (is_paused) {
                return;
            }

            bool state_changed = key_down_table[e.KeyCode] != e.IsPressed;
            key_down_table[e.KeyCode] = e.IsPressed;

            if (is_inituator_pressed()) {
                if (inituator_pressed == false) {
                    inituator_pressed = true;
                    this.bring_to_front();
                }

            } else {
                if (inituator_pressed) {
                    inituator_pressed = false;
                    Hide();
                }
            }

            if (inituator_pressed && state_changed) {
                List<int> down_keys = get_down_keys();
                List<Point> points_array = new List<Point>();

                foreach (int key_code in down_keys) {
                    if (keyboard_point_map.ContainsKey(key_code))
                        points_array.AddRange(keyboard_point_map[key_code]);
                }

                pictureBox1.Image = img_proc.invert_rectangles(points_array);
            }
        }

        public bool should_supress(KeyboardHookEventArgs e) {
            return inituator_pressed;
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern IntPtr SetForegroundWindow();

        private void bring_to_front() {
            // don't know why, but this seems to always bring this from to the front.
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            timer1.Enabled = false;
            Hide();
        }


        private void Form1_SizeChanged(object sender, EventArgs e) {
            pictureBox1.Size = ClientSize;
        }

        private void keyboardSelectToolStripMenuItem_Click(object sender, EventArgs e) {
            new KeyboardMapSelectionForm().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            new Options_Form().ShowDialog();
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e) {
            is_paused = !is_paused;
            if (is_paused) {
                (sender as ToolStripMenuItem).Text = "Unpause";
            } else {
                (sender as ToolStripMenuItem).Text = "Pause";
            }
        }
    }
}