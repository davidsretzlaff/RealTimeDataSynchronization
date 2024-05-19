namespace ApplicationOne
{
	partial class Main
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			labelInput = new Label();
			textInput = new TextBox();
			buttonSend = new Button();
			labelOutput = new Label();
			textOutput = new TextBox();
			errorProvider = new ErrorProvider(components);
			((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
			SuspendLayout();
			// 
			// labelInput
			// 
			labelInput.AutoSize = true;
			labelInput.Location = new Point(85, 323);
			labelInput.Name = "labelInput";
			labelInput.Size = new Size(277, 25);
			labelInput.TabIndex = 0;
			labelInput.Text = "Send message to ApplicationOne";
			labelInput.Click += label_Input;
			// 
			// textInput
			// 
			textInput.Location = new Point(85, 351);
			textInput.Multiline = true;
			textInput.Name = "textInput";
			textInput.Size = new Size(499, 43);
			textInput.TabIndex = 1;
			textInput.TextChanged += textInput_TextChanged;
			// 
			// buttonSend
			// 
			buttonSend.Location = new Point(624, 351);
			buttonSend.Name = "buttonSend";
			buttonSend.Size = new Size(94, 44);
			buttonSend.TabIndex = 2;
			buttonSend.Text = "Send";
			buttonSend.UseVisualStyleBackColor = true;
			buttonSend.Click += buttonSend_Click;
			// 
			// labelOutput
			// 
			labelOutput.AutoSize = true;
			labelOutput.Location = new Point(85, 36);
			labelOutput.Name = "labelOutput";
			labelOutput.Size = new Size(328, 25);
			labelOutput.TabIndex = 3;
			labelOutput.Text = "Message received from Application Two";
			labelOutput.Click += label_Output;
			// 
			// textOutput
			// 
			textOutput.BackColor = SystemColors.HighlightText;
			textOutput.Cursor = Cursors.No;
			textOutput.Enabled = false;
			textOutput.Location = new Point(85, 64);
			textOutput.Multiline = true;
			textOutput.Name = "textOutput";
			textOutput.Size = new Size(633, 230);
			textOutput.TabIndex = 4;
			textOutput.TextChanged += text_Output;
			// 
			// errorProvider
			// 
			errorProvider.ContainerControl = this;
			// 
			// Main
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(textOutput);
			Controls.Add(labelOutput);
			Controls.Add(buttonSend);
			Controls.Add(textInput);
			Controls.Add(labelInput);
			Name = "Main";
			Text = "Application one";
			Load += Main_Load;
			((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelInput;
		private TextBox textInput;
		private Button buttonSend;
		private Label labelOutput;
		private TextBox textOutput;
		private ErrorProvider errorProvider;
	}
}
