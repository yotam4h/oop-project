using Item.Drink;
using Item;

namespace burgerwindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Order> menu = new()
            {
                new Item.Food.Burger("small", new List<string>{"lettuce", "tomato", "onion"}),
                new Item.Food.Burger("medium", new List<string>{"lettuce", "tomato", "onion", "cheese"}),
                new Item.Food.Burger("large", new List<string>{"lettuce", "tomato", "onion", "cheese", "bacon"}),
                new Item.Food.BurgerWithFries("medium", new List<string>{"lettuce", "tomato", "onion", "cheese"}),
                new Item.Food.BurgerWithFries("large", new List<string>{"lettuce", "tomato", "onion", "cheese", "bacon"}),
                new Item.Drink.Water(),
                new Item.Drink.Soda("Coke", 500),
                new Item.Drink.Soda("Sprite", 330),
                new Item.Drink.Soda("Fanta", 330)
            };

            foreach (var item in menu)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
        }
    }
}