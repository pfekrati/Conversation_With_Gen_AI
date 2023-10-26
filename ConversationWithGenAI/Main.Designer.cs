namespace ConversationWithGenAI
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
            btn_start_stop = new Button();
            txt_question = new TextBox();
            txt_answer = new TextBox();
            label1 = new Label();
            label2 = new Label();
            lbl_aiSpeaking = new Label();
            pnl_texts = new Panel();
            chk_showTexts = new CheckBox();
            pnl_texts.SuspendLayout();
            SuspendLayout();
            // 
            // btn_start_stop
            // 
            btn_start_stop.BackColor = Color.Green;
            btn_start_stop.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btn_start_stop.ForeColor = Color.White;
            btn_start_stop.Location = new Point(38, 28);
            btn_start_stop.Name = "btn_start_stop";
            btn_start_stop.Size = new Size(263, 80);
            btn_start_stop.TabIndex = 0;
            btn_start_stop.Text = "Start";
            btn_start_stop.UseVisualStyleBackColor = false;
            btn_start_stop.Click += btn_start_stop_Click;
            // 
            // txt_question
            // 
            txt_question.Location = new Point(3, 50);
            txt_question.Multiline = true;
            txt_question.Name = "txt_question";
            txt_question.Size = new Size(260, 179);
            txt_question.TabIndex = 1;
            // 
            // txt_answer
            // 
            txt_answer.Location = new Point(288, 50);
            txt_answer.Multiline = true;
            txt_answer.Name = "txt_answer";
            txt_answer.Size = new Size(246, 179);
            txt_answer.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 3;
            label1.Text = "Your Question";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(288, 9);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 4;
            label2.Text = "Answer";
            // 
            // lbl_aiSpeaking
            // 
            lbl_aiSpeaking.AutoSize = true;
            lbl_aiSpeaking.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_aiSpeaking.ForeColor = Color.Red;
            lbl_aiSpeaking.Location = new Point(307, 50);
            lbl_aiSpeaking.Name = "lbl_aiSpeaking";
            lbl_aiSpeaking.Size = new Size(256, 47);
            lbl_aiSpeaking.TabIndex = 5;
            lbl_aiSpeaking.Text = "AI Speaking ...";
            lbl_aiSpeaking.Visible = false;
            // 
            // pnl_texts
            // 
            pnl_texts.Controls.Add(txt_question);
            pnl_texts.Controls.Add(label1);
            pnl_texts.Controls.Add(label2);
            pnl_texts.Controls.Add(txt_answer);
            pnl_texts.Location = new Point(38, 153);
            pnl_texts.Name = "pnl_texts";
            pnl_texts.Size = new Size(537, 243);
            pnl_texts.TabIndex = 6;
            pnl_texts.Visible = false;
            // 
            // chk_showTexts
            // 
            chk_showTexts.AutoSize = true;
            chk_showTexts.Location = new Point(41, 119);
            chk_showTexts.Name = "chk_showTexts";
            chk_showTexts.Size = new Size(84, 19);
            chk_showTexts.TabIndex = 7;
            chk_showTexts.Text = "Show Texts";
            chk_showTexts.UseVisualStyleBackColor = true;
            chk_showTexts.CheckedChanged += chk_showTexts_CheckedChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 151);
            Controls.Add(chk_showTexts);
            Controls.Add(pnl_texts);
            Controls.Add(lbl_aiSpeaking);
            Controls.Add(btn_start_stop);
            MaximizeBox = false;
            Name = "Main";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Conversation with AI";
            pnl_texts.ResumeLayout(false);
            pnl_texts.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_start_stop;
        private TextBox txt_question;
        private TextBox txt_answer;
        private Label label1;
        private Label label2;
        private Label lbl_aiSpeaking;
        private Panel pnl_texts;
        private CheckBox chk_showTexts;
    }
}