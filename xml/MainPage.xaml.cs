using System.Text;
using System.Xml;

namespace xml;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnClickLoad(object sender, EventArgs e)
	{
		StatusMsg.Text = "Stop loading me idiot";
	}
	private void OnClickSave(object sender, EventArgs e)
    {
		StatusMsg.Text = "Stop saving me idiot";
    }
}

