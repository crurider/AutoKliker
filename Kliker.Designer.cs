namespace AutoKliker
{
    partial class Kliker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kliker));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pocetnaPozicija = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtBrojPonavljanja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rightClickYes = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDelayTo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.txtDelayFrom = new System.Windows.Forms.TextBox();
            this.txtPozicijaY = new System.Windows.Forms.TextBox();
            this.txtPozicijaX = new System.Windows.Forms.TextBox();
            this.btnIzaberi = new System.Windows.Forms.Button();
            this.opcijeDesnogKlika = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.izbrišiPozicijuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.opcijeDesnogKlika.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pocetnaPozicija);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtBrojPonavljanja);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opcije";
            // 
            // pocetnaPozicija
            // 
            this.pocetnaPozicija.AutoSize = true;
            this.pocetnaPozicija.Location = new System.Drawing.Point(10, 156);
            this.pocetnaPozicija.Name = "pocetnaPozicija";
            this.pocetnaPozicija.Size = new System.Drawing.Size(128, 17);
            this.pocetnaPozicija.TabIndex = 8;
            this.pocetnaPozicija.Text = "Vrati kursor gde je bio";
            this.pocetnaPozicija.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(10, 107);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(157, 43);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 58);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(157, 43);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtBrojPonavljanja
            // 
            this.txtBrojPonavljanja.Location = new System.Drawing.Point(95, 22);
            this.txtBrojPonavljanja.Name = "txtBrojPonavljanja";
            this.txtBrojPonavljanja.Size = new System.Drawing.Size(72, 20);
            this.txtBrojPonavljanja.TabIndex = 1;
            this.txtBrojPonavljanja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj ponavljanja";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rightClickYes);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDelayTo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dataGrid);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnDodaj);
            this.groupBox2.Controls.Add(this.txtDelayFrom);
            this.groupBox2.Controls.Add(this.txtPozicijaY);
            this.groupBox2.Controls.Add(this.txtPozicijaX);
            this.groupBox2.Controls.Add(this.btnIzaberi);
            this.groupBox2.Location = new System.Drawing.Point(205, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 177);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pozicija kursora";
            // 
            // rightClickYes
            // 
            this.rightClickYes.AutoSize = true;
            this.rightClickYes.Location = new System.Drawing.Point(283, 59);
            this.rightClickYes.Name = "rightClickYes";
            this.rightClickYes.Size = new System.Drawing.Size(72, 17);
            this.rightClickYes.TabIndex = 12;
            this.rightClickYes.Text = "Desni klik";
            this.rightClickYes.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(213, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "-";
            // 
            // txtDelayTo
            // 
            this.txtDelayTo.Location = new System.Drawing.Point(226, 32);
            this.txtDelayTo.Name = "txtDelayTo";
            this.txtDelayTo.Size = new System.Drawing.Size(50, 20);
            this.txtDelayTo.TabIndex = 4;
            this.txtDelayTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Lista dodatih pozicija kursora po redu";
            // 
            // dataGrid
            // 
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(6, 79);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGrid.Size = new System.Drawing.Size(346, 90);
            this.dataGrid.TabIndex = 8;
            this.dataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGrid_CellMouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(162, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kašnjenje u rasponu (.ms)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "X";
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(283, 19);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(66, 33);
            this.btnDodaj.TabIndex = 5;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // txtDelayFrom
            // 
            this.txtDelayFrom.Location = new System.Drawing.Point(158, 32);
            this.txtDelayFrom.Name = "txtDelayFrom";
            this.txtDelayFrom.Size = new System.Drawing.Size(50, 20);
            this.txtDelayFrom.TabIndex = 3;
            this.txtDelayFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPozicijaY
            // 
            this.txtPozicijaY.Location = new System.Drawing.Point(116, 32);
            this.txtPozicijaY.Name = "txtPozicijaY";
            this.txtPozicijaY.Size = new System.Drawing.Size(36, 20);
            this.txtPozicijaY.TabIndex = 2;
            this.txtPozicijaY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPozicijaX
            // 
            this.txtPozicijaX.Location = new System.Drawing.Point(74, 32);
            this.txtPozicijaX.Name = "txtPozicijaX";
            this.txtPozicijaX.Size = new System.Drawing.Size(36, 20);
            this.txtPozicijaX.TabIndex = 1;
            this.txtPozicijaX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnIzaberi
            // 
            this.btnIzaberi.Location = new System.Drawing.Point(6, 19);
            this.btnIzaberi.Name = "btnIzaberi";
            this.btnIzaberi.Size = new System.Drawing.Size(62, 33);
            this.btnIzaberi.TabIndex = 0;
            this.btnIzaberi.Text = "Izaberi";
            this.btnIzaberi.UseVisualStyleBackColor = true;
            this.btnIzaberi.Click += new System.EventHandler(this.btnIzaberi_Click);
            // 
            // opcijeDesnogKlika
            // 
            this.opcijeDesnogKlika.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.izbrišiPozicijuToolStripMenuItem});
            this.opcijeDesnogKlika.Name = "contextMenuStrip1";
            this.opcijeDesnogKlika.Size = new System.Drawing.Size(149, 26);
            this.opcijeDesnogKlika.Click += new System.EventHandler(this.opcijeDesnogKlika_Click);
            // 
            // izbrišiPozicijuToolStripMenuItem
            // 
            this.izbrišiPozicijuToolStripMenuItem.Name = "izbrišiPozicijuToolStripMenuItem";
            this.izbrišiPozicijuToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.izbrišiPozicijuToolStripMenuItem.Text = "Izbriši poziciju";
            // 
            // Kliker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 202);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Kliker";
            this.Text = "AutoKliker v.1 by Brian Sandro";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.opcijeDesnogKlika.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtBrojPonavljanja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.TextBox txtDelayFrom;
        public System.Windows.Forms.TextBox txtPozicijaY;
        public System.Windows.Forms.TextBox txtPozicijaX;
        private System.Windows.Forms.Button btnIzaberi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDelayTo;
        private System.Windows.Forms.CheckBox rightClickYes;
        private System.Windows.Forms.ContextMenuStrip opcijeDesnogKlika;
        private System.Windows.Forms.ToolStripMenuItem izbrišiPozicijuToolStripMenuItem;
        private System.Windows.Forms.CheckBox pocetnaPozicija;
    }
}

