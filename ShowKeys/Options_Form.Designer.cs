namespace ShowKeys {
    partial class Options_Form {
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
            BtnAddInitiator = new CheckBox();
            listBox1 = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // BtnAddInitiator
            // 
            BtnAddInitiator.Appearance = Appearance.Button;
            BtnAddInitiator.AutoSize = true;
            BtnAddInitiator.Location = new Point(12, 202);
            BtnAddInitiator.Name = "BtnAddInitiator";
            BtnAddInitiator.Size = new Size(109, 25);
            BtnAddInitiator.TabIndex = 0;
            BtnAddInitiator.Text = "Add Initiator keys";
            BtnAddInitiator.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(533, 184);
            listBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(411, 202);
            button1.Name = "button1";
            button1.Size = new Size(134, 25);
            button1.TabIndex = 2;
            button1.Text = "remove initiator keys";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Options_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 231);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(BtnAddInitiator);
            Name = "Options_Form";
            Text = "Options_Form";
            FormClosed += Options_Form_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox BtnAddInitiator;
        private ListBox listBox1;
        private Button button1;
    }
}