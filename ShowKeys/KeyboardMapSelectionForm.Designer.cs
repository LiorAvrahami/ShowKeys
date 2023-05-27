namespace ShowKeys {
    partial class KeyboardMapSelectionForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            listBox1 = new ListBox();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            NumKeysLbl = new Label();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(233, 379);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(251, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(537, 379);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.Green;
            button1.Location = new Point(642, 397);
            button1.Name = "button1";
            button1.Size = new Size(146, 49);
            button1.TabIndex = 2;
            button1.Text = "Select";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // NumKeysLbl
            // 
            NumKeysLbl.AutoSize = true;
            NumKeysLbl.BorderStyle = BorderStyle.FixedSingle;
            NumKeysLbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            NumKeysLbl.Location = new Point(251, 406);
            NumKeysLbl.Name = "NumKeysLbl";
            NumKeysLbl.Size = new Size(145, 32);
            NumKeysLbl.TabIndex = 3;
            NumKeysLbl.Text = "Not Filled Out";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.Maroon;
            button2.Location = new Point(490, 397);
            button2.Name = "button2";
            button2.Size = new Size(146, 49);
            button2.TabIndex = 4;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(12, 397);
            button3.Name = "button3";
            button3.Size = new Size(233, 49);
            button3.TabIndex = 5;
            button3.Text = "Add New Keyboard";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // KeyboardMapSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(NumKeysLbl);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(listBox1);
            Name = "KeyboardMapSelectionForm";
            Text = "KeyboardMapSelectionForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private PictureBox pictureBox1;
        private Button button1;
        private Label NumKeysLbl;
        private Button button2;
        private Button button3;
    }
}