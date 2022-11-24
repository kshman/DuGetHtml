namespace DuGetHtml
{
	partial class GetForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.UrlText = new System.Windows.Forms.TextBox();
			this.LetGoButton = new System.Windows.Forms.Button();
			this.TextText = new System.Windows.Forms.TextBox();
			this.CountText = new System.Windows.Forms.TextBox();
			this.WorkList = new System.Windows.Forms.ListBox();
			this.SiteCombo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.NameText = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "주소";
			// 
			// UrlText
			// 
			this.UrlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UrlText.Location = new System.Drawing.Point(78, 12);
			this.UrlText.Name = "UrlText";
			this.UrlText.Size = new System.Drawing.Size(432, 27);
			this.UrlText.TabIndex = 1;
			// 
			// LetGoButton
			// 
			this.LetGoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.LetGoButton.Location = new System.Drawing.Point(516, 5);
			this.LetGoButton.Name = "LetGoButton";
			this.LetGoButton.Size = new System.Drawing.Size(108, 67);
			this.LetGoButton.TabIndex = 2;
			this.LetGoButton.Text = "하자고";
			this.LetGoButton.UseVisualStyleBackColor = true;
			this.LetGoButton.Click += new System.EventHandler(this.LetGoButton_Click);
			// 
			// TextText
			// 
			this.TextText.AcceptsReturn = true;
			this.TextText.AcceptsTab = true;
			this.TextText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TextText.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.TextText.Location = new System.Drawing.Point(13, 482);
			this.TextText.Multiline = true;
			this.TextText.Name = "TextText";
			this.TextText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TextText.Size = new System.Drawing.Size(612, 95);
			this.TextText.TabIndex = 3;
			// 
			// CountText
			// 
			this.CountText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CountText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CountText.Location = new System.Drawing.Point(413, 78);
			this.CountText.Name = "CountText";
			this.CountText.ReadOnly = true;
			this.CountText.Size = new System.Drawing.Size(97, 27);
			this.CountText.TabIndex = 4;
			// 
			// WorkList
			// 
			this.WorkList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WorkList.FormattingEnabled = true;
			this.WorkList.ItemHeight = 20;
			this.WorkList.Location = new System.Drawing.Point(12, 112);
			this.WorkList.Name = "WorkList";
			this.WorkList.Size = new System.Drawing.Size(611, 364);
			this.WorkList.TabIndex = 6;
			// 
			// SiteCombo
			// 
			this.SiteCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SiteCombo.FormattingEnabled = true;
			this.SiteCombo.Items.AddRange(new object[] {
            "[지원 안되요~]",
            "비오라트",
            "네이버 블로그"});
			this.SiteCombo.Location = new System.Drawing.Point(78, 78);
			this.SiteCombo.Name = "SiteCombo";
			this.SiteCombo.Size = new System.Drawing.Size(197, 28);
			this.SiteCombo.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(333, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(74, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "읽은 개수";
			// 
			// NameText
			// 
			this.NameText.Location = new System.Drawing.Point(78, 45);
			this.NameText.Name = "NameText";
			this.NameText.Size = new System.Drawing.Size(432, 27);
			this.NameText.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 20);
			this.label3.TabIndex = 10;
			this.label3.Text = "글 이름";
			// 
			// GetForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(636, 589);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.NameText);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SiteCombo);
			this.Controls.Add(this.WorkList);
			this.Controls.Add(this.CountText);
			this.Controls.Add(this.TextText);
			this.Controls.Add(this.LetGoButton);
			this.Controls.Add(this.UrlText);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "GetForm";
			this.Text = "DuGetHtml";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label label1;
		private TextBox UrlText;
		private Button LetGoButton;
		private TextBox TextText;
		private TextBox CountText;
		private ListBox WorkList;
		private ComboBox SiteCombo;
		private Label label2;
		private TextBox NameText;
		private Label label3;
	}
}