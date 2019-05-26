using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSearcherVk
{
    public partial class Form1 : Form
    {
        Vk.AccessToken accessToken;
        Vk.Builder builder;
        Vk.SearchableObject searchableObject;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            accessToken = new Vk.AccessToken();

            textBox1.Text = Vk.AccessToken.STRING_TO_GET_ACCESS_TOKEN;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            accessToken.Token = textBox2.Text;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            builder = new Vk.Builder(DoProgress);

            builder.AccessToken = accessToken;

            searchableObject = new Vk.SearchableObject();

            searchableObject.IdObject = long.Parse(textBox3.Text);
            IEnumerable<string> toSearch = textBox4.Text.Trim().Split(' ').Distinct();
            searchableObject.ValuesToSearch = toSearch.ToList();
            searchableObject.SinceDate = dateTimePicker1.Value;

            builder.SearchableObject = searchableObject;
            var result = await builder.SearchAsync();            

            if (result.IsError)
            {
                MessageBox.Show(result.TextOfError);
            }else if (result.IsCanceled)
            {
                MessageBox.Show("canceled");
            }else
            {
                var posts = result.Posts;
                var builder = new StringBuilder();
                builder.Append(result.SearchedPost + " count of post");
                builder.Append(Environment.NewLine);
                foreach (var item in result.Posts)
                {
                    builder.Append(item.Text + " with date " + item.CreatedDate);
                    builder.Append(Environment.NewLine);

                    foreach (var i in item.Comments)
                    {
                        builder.Append(i.Text + " comments to comment" + i.CreatedDate);
                        builder.Append(Environment.NewLine);
                    }
                }

                richTextBox1.Text = builder.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            builder.CancelSearch();
        }

        private void DoProgress(int value)
        {
            progressBar1.Value = value;
        }
    }
}
