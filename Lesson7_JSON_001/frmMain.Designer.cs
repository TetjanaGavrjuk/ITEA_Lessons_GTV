namespace Lesson7_JSON_001
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSerialize = new System.Windows.Forms.Button();
            this.btnDeserialize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbIsMale = new System.Windows.Forms.RadioButton();
            this.rbFemaile = new System.Windows.Forms.RadioButton();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.btnCreateXSD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSerialize
            // 
            this.btnSerialize.Location = new System.Drawing.Point(525, 35);
            this.btnSerialize.Name = "btnSerialize";
            this.btnSerialize.Size = new System.Drawing.Size(154, 29);
            this.btnSerialize.TabIndex = 0;
            this.btnSerialize.Text = "Serialize";
            this.btnSerialize.UseVisualStyleBackColor = true;
            this.btnSerialize.Click += new System.EventHandler(this.btnSerialize_Click);
            // 
            // btnDeserialize
            // 
            this.btnDeserialize.Location = new System.Drawing.Point(525, 87);
            this.btnDeserialize.Name = "btnDeserialize";
            this.btnDeserialize.Size = new System.Drawing.Size(154, 29);
            this.btnDeserialize.TabIndex = 1;
            this.btnDeserialize.Text = "DESerialize";
            this.btnDeserialize.UseVisualStyleBackColor = true;
            this.btnDeserialize.Click += new System.EventHandler(this.btnDeserialize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(264, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(92, 89);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(59, 20);
            this.txtAge.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Возраст";
            // 
            // rbIsMale
            // 
            this.rbIsMale.AutoSize = true;
            this.rbIsMale.Checked = true;
            this.rbIsMale.Location = new System.Drawing.Point(92, 115);
            this.rbIsMale.Name = "rbIsMale";
            this.rbIsMale.Size = new System.Drawing.Size(70, 17);
            this.rbIsMale.TabIndex = 6;
            this.rbIsMale.TabStop = true;
            this.rbIsMale.Text = "Мужчина";
            this.rbIsMale.UseVisualStyleBackColor = true;
            // 
            // rbFemaile
            // 
            this.rbFemaile.AutoSize = true;
            this.rbFemaile.Location = new System.Drawing.Point(92, 138);
            this.rbFemaile.Name = "rbFemaile";
            this.rbFemaile.Size = new System.Drawing.Size(75, 17);
            this.rbFemaile.TabIndex = 7;
            this.rbFemaile.Text = "Женщина";
            this.rbFemaile.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(41, 182);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(469, 201);
            this.txtLog.TabIndex = 9;
            this.txtLog.Text = "";
            // 
            // btnCreateXSD
            // 
            this.btnCreateXSD.Location = new System.Drawing.Point(525, 138);
            this.btnCreateXSD.Name = "btnCreateXSD";
            this.btnCreateXSD.Size = new System.Drawing.Size(154, 29);
            this.btnCreateXSD.TabIndex = 10;
            this.btnCreateXSD.Text = "CreateXSD";
            this.btnCreateXSD.UseVisualStyleBackColor = true;
            this.btnCreateXSD.Click += new System.EventHandler(this.btnCreateXSD_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 435);
            this.Controls.Add(this.btnCreateXSD);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.rbFemaile);
            this.Controls.Add(this.rbIsMale);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeserialize);
            this.Controls.Add(this.btnSerialize);
            this.Name = "frmMain";
            this.Text = "Сериализация JSON";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSerialize;
        private System.Windows.Forms.Button btnDeserialize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbIsMale;
        private System.Windows.Forms.RadioButton rbFemaile;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnCreateXSD;
    }
}

