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
                switch (rnd.Next() % 3) // ��������� ��������� ����� �� 0 �� 2 (�� ������� �� ������� �� 3)
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
                        // ��������� ������ ����� ������������
                }
            }
            ShowInfo();
        }

        // ������� ������� ���������� � ���������� ������� �� �����
        private void ShowInfo()
        {
            // ������� �������� ��� ������ ���
            int flowersCount = 0;
            int treesCount = 0;
            int shrubsCount = 0;

            // ������� ������ �������� �� ����� ����� �����������
            listBoxPlants.Items.Clear();

            // ��������� �� ����� ������ � ��������� ������� � ListBox
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

            // ������� ���������� � ���������� ������� ���� �������� �� �����
            txtInfo.Text = $"�����: {flowersCount}, �������: {treesCount}, ����������: {shrubsCount}";
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // ���� ������ ����, �� �������, ��� �����, � ������ �� �������
            if (this.plantsList.Count == 0)
            {
                txtOut.Text = "�����";
                return;
            }

            // ����� ������ ������ �� �������
            var plant = this.plantsList[0];
            this.plantsList.RemoveAt(0);

            // ������� ���������� �� �����
            txtOut.Text = plant.GetInfo();
            ShowInfo();
        }
    }
}
