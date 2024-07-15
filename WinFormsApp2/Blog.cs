using AHThawmDotNetCore.Shared;
using WinFormsApp2.Models;
using WinFormsApp2.Queries;

namespace WinFormsApp2
{
    public partial class Blog : Form
    {
        private readonly DapperService _dapperService;

        public Blog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionString._sqlConnectionStringBuilder.ConnectionString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel();
                blog.BlogTitle = txtTitle.Text.Trim();
                blog.BlogAuthor = txtAuthor.Text.Trim();
                blog.BlogContent = txtContent.Text;

                int result = _dapperService.Execute(BlogQuery.BlogCreate, blog);
                string msg = result > 0 ? "Saving Successful." : "Saving Failed.";
                MessageBox.Show(msg, "Blog", MessageBoxButtons.OK, result>0? MessageBoxIcon.Information: MessageBoxIcon.Error);

                ClearControl();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void ClearControl()
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear();

            txtTitle.Focus();
        }
    }
}
