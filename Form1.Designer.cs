namespace Mana_Khemia_FP_Magic
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraerTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraerSeleccionadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarSeleccionadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.extraerToolStripMenuItem,
            this.insertarToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(297, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // extraerToolStripMenuItem
            // 
            this.extraerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extraerTodoToolStripMenuItem,
            this.extraerSeleccionadoToolStripMenuItem});
            this.extraerToolStripMenuItem.Enabled = false;
            this.extraerToolStripMenuItem.Name = "extraerToolStripMenuItem";
            this.extraerToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.extraerToolStripMenuItem.Text = "Extraer";
            // 
            // extraerTodoToolStripMenuItem
            // 
            this.extraerTodoToolStripMenuItem.Name = "extraerTodoToolStripMenuItem";
            this.extraerTodoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.extraerTodoToolStripMenuItem.Text = "Extraer todo";
            this.extraerTodoToolStripMenuItem.Click += new System.EventHandler(this.extraerTodoToolStripMenuItem_Click);
            // 
            // extraerSeleccionadoToolStripMenuItem
            // 
            this.extraerSeleccionadoToolStripMenuItem.Name = "extraerSeleccionadoToolStripMenuItem";
            this.extraerSeleccionadoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.extraerSeleccionadoToolStripMenuItem.Text = "Extraer seleccionado";
            this.extraerSeleccionadoToolStripMenuItem.Click += new System.EventHandler(this.extraerSeleccionadoToolStripMenuItem_Click);
            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertarTodoToolStripMenuItem,
            this.insertarSeleccionadoToolStripMenuItem});
            this.insertarToolStripMenuItem.Enabled = false;
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.insertarToolStripMenuItem.Text = "Insertar";
            // 
            // insertarTodoToolStripMenuItem
            // 
            this.insertarTodoToolStripMenuItem.Name = "insertarTodoToolStripMenuItem";
            this.insertarTodoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.insertarTodoToolStripMenuItem.Text = "Insertar todo";
            this.insertarTodoToolStripMenuItem.Click += new System.EventHandler(this.insertarTodoToolStripMenuItem_Click);
            // 
            // insertarSeleccionadoToolStripMenuItem
            // 
            this.insertarSeleccionadoToolStripMenuItem.Name = "insertarSeleccionadoToolStripMenuItem";
            this.insertarSeleccionadoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.insertarSeleccionadoToolStripMenuItem.Text = "Insertar seleccionado";
            this.insertarSeleccionadoToolStripMenuItem.Click += new System.EventHandler(this.insertarSeleccionadoToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Enabled = false;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(297, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 17);
            this.lblStatus.Text = "Hola.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Archivos FP|*fp";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(260, 444);
            this.listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 517);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MK FP Magic";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripMenuItem extraerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraerTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraerSeleccionadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarSeleccionadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
    }
}

