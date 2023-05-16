using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Projekat_DM
{

    public partial class Form1 : Form
    {
        public int poz = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] temp = {"Биологија", "Географија", "Енглески језик", "Историја", "Италијански језик", "Немачки језик", "Руски језик", "Српски као нематерњи језик", "Физика", "Француски језик", "Хемија", "Шпански језик"};
            
            string[] temp1 = {"Зоотехничар", "Техничар за биотехнологију", "Техничар пољопривредне технике", "Техничар хортикултуре", "Техничар за пејзажну архитектуру", "Шумарски техничар", "Геолошки техничар за геотехнику и хидрогеологију", "Геолошки техничар за истраживање минералних сировина", "Рударски техничар", "Рударски техничар за припрему минералних сировина", "Бродомашински техничар", "Машински техничар за компјутерско конструисање", "Машински техничар мерне и регулационе технике", "Машински техничар моторних возила", "Техничар грејања и климатизације", "Техничар за компјутерско управљање(CNC) машина", "Техничар за роботику", "Техничар машинске енергетике", "Техничар оптике", "Електротехничар аутоматике", "Електротехничар електромоторних погона", "Електротехничар електронике", "Електротехничар енергетике", "Електротехничар за термичке и расхладне уређаје", "Електротехничар информационих технологија", "Електротехничар процесног управљања", "Електротехничар рачунара", "Техничар графичке дораде", "Техничар за заштиту животне средине", "Техничар за индустријску фармацеутску технологију", "Техничар штампе", "Фотограф", "Хемијски лаборант", "Хемијско - технолошки техничар", "Текстилни техничар", "Грађевински техничар за лабораторијска испитивања", "Грађевински техничар за хидроградњу", "Извођач инсталатерских и завршних грађевинских радова", "Наутички техничар – речни смер", "Саобраћајно - транспортни техничар", "Техничар вуче", "Техничар ПТТ саобраћаја", "Техничар унутрашњег транспорта", "Транспортни комерцијалиста", "Аранжер у трговини и Трговински техничар", "Кулинарски техничар", "Угоститељски техничар", "Економски техничар", "Финансијски техничар", "Царински техничар", "Гинеколошко - акушерска сестра", "Зубни техничар", "Медицинска сестра – васпитач", "Педијатријска сестра – техничар", "Санитарно - еколошки техничар", "Сценски маскер и власуљар"};

            comboBox4.SelectedIndex = 0;
            comboBox5.Text = "";
            switch (comboBox1.Text)
            {
                case "Општи":
                    comboBox5.Items.Clear();
                    temp.ToList().ForEach(item => comboBox5.Items.Add(item));
                    break;
                case "Стручни":
                    comboBox5.Items.Clear();
                    temp1.ToList().ForEach(item => comboBox5.Items.Add(item));
                    break;
                case "Уметнички":
                    comboBox5.Items.Clear();
                    comboBox5.Items.Add("Солфеђо и хармонија");
                    comboBox5.SelectedIndex = 0;
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            comboBox3.Text = Convert.ToString(comboBox2.SelectedItem) + " и књижевност";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox6.Text == "")
            {
                if(textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "")
                {
                    MessageBox.Show("Унесите све податке!");
                }
                else
                {
                    comboBox6.Text = textBox1.Text + ";" + textBox2.Text + ";" + comboBox1.Text + ";" + comboBox2.Text + ";" + comboBox3.Text + ";" + comboBox4.Text + ";" + comboBox5.Text + ";";
                }
            }
            else
            {
                if(textBox4.Text == "")
                {
                    MessageBox.Show("Унесите име фајла!");
                }
                else
                {
                    List<string> linije = File.ReadAllLines(textBox4.Text).ToList<string>();

                    if((linije.Count == 0) || (poz == -1))
                    {
                        linije.Add(comboBox6.Text);
                    }
                    else
                    {
                        linije[poz] = comboBox6.Text;
                    }

                    File.WriteAllLines((textBox4.Text), linije.ToArray());

                    comboBox6.Items.Clear();
                    linije.ForEach(item => comboBox6.Items.Add(item));
                }

                comboBox6.Text = "";

                poz = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Унесите име фајла!");
            }
            else
            {
                List<string> linije = File.ReadAllLines(textBox4.Text).ToList<string>();

                comboBox6.Items.Clear();
                linije.ForEach(item => comboBox6.Items.Add(item));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] niz = comboBox6.Text.Split(';');

            poz = comboBox6.SelectedIndex;

            for(int i = 0; i < 7; i++)
            {
                switch(i)
                {
                    case 0:
                        textBox1.Text = niz[0];
                        break;
                    case 1:
                        textBox2.Text = niz[1];
                        break;
                    case 2:
                        comboBox1.Text = niz[2];
                        break;
                    case 3:
                        comboBox2.Text = niz[3];
                        break;
                    case 4:
                        comboBox3.Text = niz[4];
                        break;
                    case 5:
                        comboBox4.Text = niz[5];
                        break;
                    case 6:
                        comboBox5.Text = niz[6];
                        break;

                }
            }

            comboBox6.Text = "";
            comboBox6.SelectedText = "";
        }
    }
}