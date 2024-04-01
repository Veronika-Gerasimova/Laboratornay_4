using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Laboratornay_4
{
    public partial class Form1 : Form
    {
        private List<Plants> plantsList = new List<Plants>();

        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.plantsList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2 (ну остаток от деления на 3)
                {
                    case 0:
                        this.plantsList.Add(Flowers.Generate());
                        break;
                    case 1:
                        this.plantsList.Add(Trees.Generate());
                        break;
                    case 2:
                        this.plantsList.Add(Shrubs.Generate());
                        break;
                        // появление других чисел маловероятно
                }
            }
            ShowInfo();
        }

        // функция выводит информацию о количестве фруктов на форму
        private void ShowInfo()
        {
            // Заведем счетчики под каждый тип
            int flowersCount = 0;
            int treesCount = 0;
            int shrubsCount = 0;

            // Очистим список объектов на форме перед обновлением
            listBoxPlants.Items.Clear();

            // Пройдемся по всему списку и отобразим объекты в ListBox
            foreach (var plant in this.plantsList)
            {
                listBoxPlants.Items.Add(plant.GetInfo());

                if (plant is Flowers)
                    flowersCount++;
                else if (plant is Trees)
                    treesCount++;
                else if (plant is Shrubs)
                    shrubsCount++;
            }

            // Обновим информацию о количестве каждого типа объектов на форме
            txtInfo.Text = $"Цветы: {flowersCount}, Деревья: {treesCount}, Кустарники: {shrubsCount}";
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // Если список пуст, то напишем, что пусто, и выйдем из функции
            if (this.plantsList.Count == 0)
            {
                txtOut.Text = "Пусто";
                return;
            }

            // Взяли первый объект из очереди
            var plant = this.plantsList[0];
            this.plantsList.RemoveAt(0);

            // Обновим информацию на форме
            txtOut.Text = plant.GetInfo();
            ShowInfo();
        }
    }
}
