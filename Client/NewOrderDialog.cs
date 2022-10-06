using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class NewOrderDialog : Form
    {
        public NewOrderDialog()
        {
            InitializeComponent();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (textBoxCustomerName.Text.Trim() != String.Empty)
            {
                Order order = new(textBoxCustomerName.Text.Trim())
                {
                    Discount = CalculateDiscount()
                };

                foreach (Orderline orderline in listBoxOrderlines.Items)
                {
                    order.Orderlines.Add(orderline);
                }

                try
                {
                    OrderHandling.Instance.CreateOrder(order);
                }
                catch (OrderHandlingException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.None;
                }
            }
        }

        private void NewOrderDialog_Load(object sender, EventArgs e)
        {
            Product[] products = OrderHandling.Instance.GetProducts().ToArray();
            comboBoxProducts.Items.AddRange(products);
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            Product product = (Product)comboBoxProducts.SelectedItem;
            bool added = false;
            List<Orderline> orderlines = new();

            foreach (Orderline orderline in listBoxOrderlines.Items)
            {
                orderlines.Add(orderline);
                if (orderline.Item.Id == product.Id)
                {
                    orderline.Quantity += 1;
                    added = true;
                    break;
                }                
            }
            if (!added)
            {
                orderlines.Add(new(1, product));
            }

            listBoxOrderlines.Items.Clear();
            foreach (Orderline orderline in orderlines)
            {
                listBoxOrderlines.Items.Add(orderline);
            }
           
            CalculateTotalPrice();
        }

        private void textBoxDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private decimal CalculateDiscount()
        {
            return textBoxDiscount.Text.Trim() == string.Empty ? 0 : Convert.ToDecimal(textBoxDiscount.Text) / 100;
        }

        private void CalculateTotalPrice()
        {
            decimal totalPrice = 0M;
            foreach (Orderline orderline in listBoxOrderlines.Items)
            {
                totalPrice += orderline.Quantity * orderline.Item.Price;
            }
            textBoxTotalPrice.Text = string.Format("{0:0.00}", totalPrice - totalPrice * CalculateDiscount());
        }
    }
}
