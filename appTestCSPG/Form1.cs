namespace appTestCSPG
{
  public partial class Form1 : Form
  {
    string query;
    public Form1()
    {
      InitializeComponent();
      query = "SELECT * FROM datos;";
      dataGridView1.DataSource = Connection.SelectQuery(query);

    }
  }
}
