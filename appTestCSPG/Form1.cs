namespace appTestCSPG
{
  public partial class Form1 : Form
  {
    string query;
    public Form1()
    {
      InitializeComponent();
      //https://www.kaggle.com/datasets/migeruj/videogames-predictive-model/data?select=dato.csv
      query = "SELECT * FROM datos;";
      dataGridView1.DataSource = Connection.SelectQuery(query);

    }
  }
}
