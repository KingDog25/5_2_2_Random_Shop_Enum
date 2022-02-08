/*Задача 5.2.1 Условие: Имеются следующие данные о товарах обувного магазина: наименование(ботинки, сапоги, босоножки т.д.), 
тип(мужская, женская или детская обувь), сезон, цвет, размеры, стоимость.Вывести сведения о летней детской обуви и ее среднюю стоимость. */

/*Task 5.2.1 Condition: There is the following data about the goods of a shoe store: name (boots, boots, sandals, etc.),
type (men's, women's or children's shoes), season, color, size, cost. Display information about summer children's shoes and their average cost. */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23_variant_CSharp_5_2_2
{
    public partial class ShopShoesSummer : Form
    {
        public ShopShoesSummer()
        {
            InitializeComponent(); 
        }
            public enum NameShoes : byte
        {
            Ботинки, Сапоги, Босоножки, Сандали, Туфли, Кроссовки, Кеды, Шлепанцы
        }
        public enum Season : byte
        {
            Весна, Лето, Зима, Осень
        }
        public enum TypeofShoes : byte
        {
            Мужская, Женская, Детская
        }

        public enum ColorShoes : byte
        {
            Бежевый, Белый, Бордовый, Зеленый, Желтый, Золотой, Оранжевый, Коричневый,
            Серый, Черный, Синий, Красный, Фиолетовый
        }
        double costShoes;                                                        //стоимость
        byte size;                                                              //размеры
        double averVal = 0;                                                       //среднее значение

        private void buttonShow_Click(object sender, EventArgs e)
        {
            int shoesCount = 30;                                                 //кол-во товаров
            int paramColumn = 6;                                                    //кол-во столбцов (параметров)
            double summGrades = 0;                                                  //сумма стоимости
            dataGridView1.RowCount = shoesCount;                                       //кол-во строк
            dataGridView1.ColumnCount = paramColumn;                                                 //столбцов
            dataGridView1.Columns[0].HeaderText = "Наименование";
            dataGridView1.Columns[1].HeaderText = "Сезон";
            dataGridView1.Columns[2].HeaderText = "Тип";
            dataGridView1.Columns[3].HeaderText = "Цвет";
            dataGridView1.Columns[4].HeaderText = "Размер";
            dataGridView1.Columns[5].HeaderText = "Стоимость";
            Random rnd = new Random();
            int LengthName = Enum.GetNames(typeof(ShopShoesSummer.NameShoes)).Length;
            int LengthSeason = Enum.GetNames(typeof(ShopShoesSummer.Season)).Length;
            int LengthType = Enum.GetNames(typeof(ShopShoesSummer.TypeofShoes)).Length;
            int LengthColorShoes = Enum.GetNames(typeof(ShopShoesSummer.ColorShoes)).Length;
            ShopShoesSummer.NameShoes nameShoes = (ShopShoesSummer.NameShoes)rnd.Next(LengthName);
            ShopShoesSummer.Season seasonShoes = (ShopShoesSummer.Season)rnd.Next(LengthSeason);
            ShopShoesSummer.TypeofShoes typeShoes = (ShopShoesSummer.TypeofShoes)rnd.Next(LengthType);
            ShopShoesSummer.ColorShoes colorShoes = (ShopShoesSummer.ColorShoes)rnd.Next(LengthColorShoes);
            int rowsCount = shoesCount;
            int columnCount = paramColumn;
            string[,] tableShoes = new string[rowsCount, columnCount];
            for (int count_row = 0; count_row < shoesCount; count_row++)           
            {
                seasonShoes = (Season)rnd.Next(LengthSeason);
                if (checkBoxSummerShoes.Checked && ((int)seasonShoes != 1) && ((int)typeShoes ==0) && ((int)typeShoes == 1)) 
                {
                    count_row--;
                    continue;
                }
                nameShoes = (NameShoes)rnd.Next(LengthName);
                tableShoes[count_row, 0] = Convert.ToString(nameShoes);
                dataGridView1.Rows[count_row].Cells[0].Value = tableShoes[count_row, 0];

                tableShoes[count_row, 1] = Convert.ToString(seasonShoes);
                dataGridView1.Rows[count_row].Cells[1].Value = tableShoes[count_row, 1];

                typeShoes = (TypeofShoes)rnd.Next(LengthType);
                tableShoes[count_row, 2] = Convert.ToString(typeShoes);
                dataGridView1.Rows[count_row].Cells[2].Value = tableShoes[count_row, 2];

                colorShoes = (ColorShoes)rnd.Next(LengthColorShoes);
                tableShoes[count_row, 3] = Convert.ToString(colorShoes);
                dataGridView1.Rows[count_row].Cells[3].Value = tableShoes[count_row, 3];

                size = (byte)rnd.Next(34, 46);
                tableShoes[count_row, 4] = Convert.ToString(size);
                dataGridView1.Rows[count_row].Cells[4].Value = tableShoes[count_row, 4];

                costShoes = rnd.NextDouble()*1000;
                tableShoes[count_row, 5] = costShoes.ToString("0 руб. ## коп.");
                dataGridView1.Rows[count_row].Cells[5].Value = tableShoes[count_row, 5];
                summGrades += costShoes;

            }
            averVal = summGrades / shoesCount;
            label2.Text += averVal.ToString("0 руб. ## коп.");
            averVal = 0;                                                                            //обнуляем переменные
            summGrades = 0;
        }
    }
        }