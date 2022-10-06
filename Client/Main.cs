using Controller;
using Model;

namespace Client
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void ButtonFinishOrder_Click(object sender, EventArgs e)
        {
            // Update order to finished state
            if (listBoxOrders.SelectedIndex == -1)
                return;
            OrderHandling.Instance.FinishOrder(((Order)listBoxOrders.SelectedItem).CustomerName);
            ReloadOrders();
        }

        private void ButtonNewOrder_Click(object sender, EventArgs e)
        {
            using NewOrderDialog newOrderDialog = new();
            newOrderDialog.ShowDialog();
            ReloadOrders();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ReloadOrders();
        }

        private void ReloadOrders()
        {
            listBoxOrders.Items.Clear();

            foreach (var item in OrderHandling.Instance.GetActiveOrders())
            {
                listBoxOrders.Items.Add(item);
            }
        }
    }
}