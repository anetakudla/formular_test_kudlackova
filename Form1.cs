using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakturyKudlackova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            faktury = sqlRepozitar.GetFaktury();
            RefreshGUI();
        }
        List<Faktury> faktury;
        SqlRepository sqlRepozitar = new SqlRepository();

        private void RefreshGUI()
        {
            listView1.Items.Clear();
            foreach (Faktury faktura in faktury)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { faktura.cislo.ToString(), faktura.datum.ToString("dd.MM.yyyy"), faktura.odberatel, faktura.nazev, faktura.pocet.ToString(), faktura.cena.ToString(), (faktura.cena*faktura.pocet).ToString(), (faktura.cena*faktura.pocet*0.21).ToString(), (faktura.cena * faktura.pocet * 0.21 + faktura.cena*faktura.pocet).ToString() });
                listView1.Items.Add(listViewItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
