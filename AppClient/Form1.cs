using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AppShared;
using AppServer;

namespace AppClient
{
    public partial class Form1 : Form
    {
        IShoeBUS shoeBUS = (IShoeBUS)Activator.GetObject(typeof(IShoeBUS), "tcp://10.4.11.15:6969/xxx");
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
           
            List<Shoe> shoes = shoeBUS.GetAll();
            dgvShoe.DataSource = shoes;
        }

        private void dgvShoe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvShoe.SelectedRows.Count > 0)
            {
                int code = int.Parse(dgvShoe.SelectedRows[0].Cells["Code"].Value.ToString());
                Shoe shoe = shoeBUS.GetDetails(code);
                if (shoe != null)
                {
                    txtCode.Text = shoe.Code.ToString();
                    txtName.Text = shoe.Name.ToString();
                    txtType.Text = shoe.Type.ToString();
                    txtSize.Text = shoe.Size.ToString();
                    txtPrice.Text = shoe.Price.ToString();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtKeyword.Text.Trim();
            List<Shoe> shoes = shoeBUS.SearchByName(keyword);
            dgvShoe.DataSource = shoes;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Shoe newShoe = new Shoe()
            {
                Code = 0,
                Name = txtName.Text.Trim(),
                Type = txtType.Text.Trim(),
                Size = int.Parse(txtSize.Text.Trim()),
                Price = int.Parse(txtPrice.Text.Trim()),
            };
            bool result = new ShoeBUS().AddItem(newShoe);
            if (result)
            {
                List<Shoe> shoes = shoeBUS.GetAll();
                dgvShoe.DataSource = shoes;
            }
            else
            {
                MessageBox.Show("SORRY BABEEE !!!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int code = int.Parse(txtCode.Text.Trim());
            String name = txtName.Text.Trim();
            String type = txtType.Text.Trim();
            int size = int.Parse(txtSize.Text.Trim());
            int price = int.Parse(txtPrice.Text.Trim());
            Shoe newShoe = new Shoe()
            {
                Code = code,
                Name = name,
                Type = type,
                Size = size,
                Price = price,
            };
            bool result = shoeBUS.Update(newShoe);
            if (result)
            {
                List<Shoe> shoes = shoeBUS.GetAll();
                dgvShoe.DataSource = shoes;
            }
            else
            {
                MessageBox.Show("SORRY BABEEE !!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int code = int.Parse(txtCode.Text.Trim());
            DialogResult dialogResult = MessageBox.Show("ARE YOU SURE ?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = shoeBUS.Delete(code);
                if (result)
                {
                    List<Shoe> shoes = shoeBUS.GetAll();
                    dgvShoe.DataSource = shoes;
                }
                else
                {
                    MessageBox.Show("SORRY BABEEE !!!");
                }
            }
        }
    }
}
