using covid_console.persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace covid_console
{
    class Program : Form
    {
        private Button button1;
        private ListView list_cs;
        private ColumnHeader cin;
        private ColumnHeader prenom;
        private ColumnHeader nom;
        private TextBox textBox1;
        Persistence persistence;
        private ColumnHeader date_naissence;
        private ColumnHeader age;
        List<Citoyen> citoyens;

        public Program()
        {
            persistence = new Persistence();
            citoyens = persistence.getAllCitoyens();
            InitializeComponent();
            foreach (Citoyen c in citoyens)
            {
                Console.WriteLine("CIN CITOYEN  : " + c.Cin);
                Console.WriteLine("PRENOM CITOYEN  : " + c.Prenom);
                Console.WriteLine("NOM CITOYEN  : " + c.Nom);
                Console.WriteLine("######################################################");
                String[] rows = { c.Cin, c.Prenom, c.Nom,c.Date_naissance.ToString(),c.Age.ToString() };
                var item_row = new ListViewItem(rows);
                list_cs.Items.Add(item_row);
            }
        }

         static void Main(string[] args){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Program());
        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.list_cs = new System.Windows.Forms.ListView();
            this.cin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prenom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date_naissence = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.age = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(586, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(331, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 51);
            this.button1.TabIndex = 2;
            this.button1.Text = "Afficher statistiques";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // list_cs
            // 
            this.list_cs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cin,
            this.prenom,
            this.nom,
            this.date_naissence,
            this.age});
            this.list_cs.HideSelection = false;
            this.list_cs.Location = new System.Drawing.Point(12, 89);
            this.list_cs.Name = "list_cs";
            this.list_cs.Size = new System.Drawing.Size(905, 504);
            this.list_cs.TabIndex = 3;
            this.list_cs.UseCompatibleStateImageBehavior = false;
            this.list_cs.View = System.Windows.Forms.View.Details;
            // 
            // cin
            // 
            this.cin.Tag = "cin";
            this.cin.Text = "CIN";
            this.cin.Width = 100;
            // 
            // prenom
            // 
            this.prenom.Text = "PRENOM";
            this.prenom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.prenom.Width = 100;
            // 
            // nom
            // 
            this.nom.Text = "NOM";
            this.nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nom.Width = 100;
            // 
            // date_naissence
            // 
            this.date_naissence.Text = "DATE NAISSANCE";
            this.date_naissence.Width = 148;
            // 
            // age
            // 
            this.age.Text = "Age";
            // 
            // Program
            // 
            this.ClientSize = new System.Drawing.Size(939, 605);
            this.Controls.Add(this.list_cs);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Program";
            this.Text = "Covid Suivi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
