namespace IceMoldForm
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.BuildButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IceMoldLengthTextBox = new System.Windows.Forms.TextBox();
            this.IceMoldWidthTextBox = new System.Windows.Forms.TextBox();
            this.IceMoldDeepTextBox = new System.Windows.Forms.TextBox();
            this.ExternalWallTextBox = new System.Windows.Forms.TextBox();
            this.InnerWallTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IceMoldBottomTextBox = new System.Windows.Forms.TextBox();
            this.CellsWidthCountTextBox = new System.Windows.Forms.TextBox();
            this.CellsLengthCountTextBox = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(327, 288);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(82, 23);
            this.BuildButton.TabIndex = 0;
            this.BuildButton.Text = "BUILD";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.IceMoldLengthTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.IceMoldWidthTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.IceMoldDeepTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ExternalWallTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.InnerWallTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.IceMoldBottomTextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.CellsWidthCountTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.CellsLengthCountTextBox, 1, 7);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(25, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.69841F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.69841F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.69841F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.69841F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.69841F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.69841F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.69841F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(343, 270);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Количестов ячеек по длине (7-13 шт)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Количество ячеек по ширине (2-4 шт)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Длина формы (100-150 мм)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ширина формы (250-300 мм)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Глубина формы (20-40 мм)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Толщина днища формы (5-10мм)";
            // 
            // IceMoldLengthTextBox
            // 
            this.IceMoldLengthTextBox.Location = new System.Drawing.Point(260, 3);
            this.IceMoldLengthTextBox.Name = "IceMoldLengthTextBox";
            this.IceMoldLengthTextBox.Size = new System.Drawing.Size(79, 20);
            this.IceMoldLengthTextBox.TabIndex = 6;
            this.IceMoldLengthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // IceMoldWidthTextBox
            // 
            this.IceMoldWidthTextBox.Location = new System.Drawing.Point(260, 37);
            this.IceMoldWidthTextBox.Name = "IceMoldWidthTextBox";
            this.IceMoldWidthTextBox.Size = new System.Drawing.Size(79, 20);
            this.IceMoldWidthTextBox.TabIndex = 7;
            this.IceMoldWidthTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // IceMoldDeepTextBox
            // 
            this.IceMoldDeepTextBox.Location = new System.Drawing.Point(260, 71);
            this.IceMoldDeepTextBox.Name = "IceMoldDeepTextBox";
            this.IceMoldDeepTextBox.Size = new System.Drawing.Size(79, 20);
            this.IceMoldDeepTextBox.TabIndex = 8;
            this.IceMoldDeepTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // ExternalWallTextBox
            // 
            this.ExternalWallTextBox.Location = new System.Drawing.Point(260, 105);
            this.ExternalWallTextBox.Name = "ExternalWallTextBox";
            this.ExternalWallTextBox.Size = new System.Drawing.Size(79, 20);
            this.ExternalWallTextBox.TabIndex = 9;
            this.ExternalWallTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // InnerWallTextBox
            // 
            this.InnerWallTextBox.Location = new System.Drawing.Point(260, 139);
            this.InnerWallTextBox.Name = "InnerWallTextBox";
            this.InnerWallTextBox.Size = new System.Drawing.Size(79, 20);
            this.InnerWallTextBox.TabIndex = 10;
            this.InnerWallTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Толщина внешних стенок(5-10 мм)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Толщина внутренних стенок(5-10 мм)";
            // 
            // IceMoldBottomTextBox
            // 
            this.IceMoldBottomTextBox.Location = new System.Drawing.Point(260, 173);
            this.IceMoldBottomTextBox.Name = "IceMoldBottomTextBox";
            this.IceMoldBottomTextBox.Size = new System.Drawing.Size(79, 20);
            this.IceMoldBottomTextBox.TabIndex = 11;
            this.IceMoldBottomTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // CellsWidthCountTextBox
            // 
            this.CellsWidthCountTextBox.Location = new System.Drawing.Point(260, 207);
            this.CellsWidthCountTextBox.Name = "CellsWidthCountTextBox";
            this.CellsWidthCountTextBox.Size = new System.Drawing.Size(79, 20);
            this.CellsWidthCountTextBox.TabIndex = 14;
            this.CellsWidthCountTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // CellsLengthCountTextBox
            // 
            this.CellsLengthCountTextBox.Location = new System.Drawing.Point(260, 241);
            this.CellsLengthCountTextBox.Name = "CellsLengthCountTextBox";
            this.CellsLengthCountTextBox.Size = new System.Drawing.Size(79, 20);
            this.CellsLengthCountTextBox.TabIndex = 15;
            this.CellsLengthCountTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 316);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.BuildButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "IceMold";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox IceMoldLengthTextBox;
        private System.Windows.Forms.TextBox IceMoldWidthTextBox;
        private System.Windows.Forms.TextBox IceMoldDeepTextBox;
        private System.Windows.Forms.TextBox ExternalWallTextBox;
        private System.Windows.Forms.TextBox InnerWallTextBox;
        private System.Windows.Forms.TextBox IceMoldBottomTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CellsWidthCountTextBox;
        private System.Windows.Forms.TextBox CellsLengthCountTextBox;
    }
}

