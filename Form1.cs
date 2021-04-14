using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusTask
{
    public partial class Form1 : Form
    {

        struct Bus
        {
            public int number;
            public string type;
            public string destination;
            public DateTime departureTime;
            public DateTime arrivalTime;

            public Bus(int num, string t, string dest, DateTime dTime, DateTime aTime)
            {
                number = num;
                type = t;
                destination = dest;//Структура данных
                departureTime = dTime;
                arrivalTime = aTime;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        List<Bus> arr = new List<Bus>(); //Инициализирование списка(уместнее, чем массив, при работе со структурами)
        private void Form1_Load(object sender, EventArgs e)
        {
            arr.AddRange(new Bus[] { //Заполняем стартовый список
                new Bus(80, "long", "Zima", new DateTime(2021, 1, 18), new DateTime(2021, 1, 19)),
                new Bus(480, "long", "Angarsk", new DateTime(2021, 1, 17), new DateTime(2021, 1, 21)),
                new Bus(7, "short", "Sayansk", new DateTime(2021, 1, 18), new DateTime(2021, 1, 20)),
                new Bus(3, "short", "Sayansk", new DateTime(2021, 1, 21), new DateTime(2021, 1, 25)),
                new Bus(74, "short", "Angarsk", new DateTime(2021, 1, 10), new DateTime(2021, 1, 15))
            });
            dataGridView1.Rows.Clear(); //На всекий случай очищаем нашу табилцу
            
            for (int i = 0; i < arr.Count; i++) // Заполняем табицу данными из списка
            {
                
                if(i!=arr.Count-1) dataGridView1.Rows.Add();

                dataGridView1[0, i].Value = arr[i].number.ToString();
                dataGridView1[1, i].Value = arr[i].type.ToString();
                dataGridView1[2, i].Value = arr[i].destination.ToString();
                dataGridView1[3, i].Value = arr[i].departureTime.ToString("dd.MM.yy"); //Приведение отображения даты в божеский вид
                dataGridView1[4, i].Value = arr[i].arrivalTime.ToString("dd.MM.yy");

                if(!comboBox1.Items.Contains(arr[i].destination)) comboBox1.Items.Add(arr[i].destination); //Добавляем в комбобокс пункты назначения, еслит аких еще нет
            }
            comboBox1.SelectedIndex = 0; //Что бы комбобокс по умолчанию пустым не казался
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";
            for (int i = 0; i < arr.Count; i++)// Обработка запроса пользователя
            {
                if (arr[i].destination.Equals(comboBox1.SelectedItem))
                {
                    
                    if (arr[i].arrivalTime > dateTimePicker1.Value)
                    {
                        result+="Youre choice is "+arr[i].number+", going to " + arr[i].destination + ", arrival time "+
                                arr[i].arrivalTime.ToString("dd.MM.yy") + ", time save "+
                                    (arr[i].departureTime-dateTimePicker1.Value).Days+" days"+"\n";
                    }//Выводим данные
                }
            }
            MessageBox.Show(result, "Result");
        }
    }
}
