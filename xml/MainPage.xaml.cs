using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace xml;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnClickLoad(object sender, EventArgs e)
	{		
		// try catch if xml doc exits
		try
        {
			// load xml elements
			XElement root = XElement.Load(@"E:\code\repos\xml_maui\xml\blabla2.xml");
			// parse trough element and test if its equal the NummerEntry
			IEnumerable<XElement> eintrag =
				from element in root.Elements("Eintrag")
				where (string)element.Element("Nummer") == NummerEntry.Text
				select element;
			
			// display output to Editor
			foreach (XElement element in eintrag)
            {
				StatusMsg.Text = "sniff sniff i found something!";
				ausgabeEditor.Text = $"{element}";
			}
		}
		catch (Exception ex)
        {
			//! need to shorten exception
			StatusMsg.Text = "XML file lost to the matrix";
        }
		

	}
	private void OnClickSave(object sender, EventArgs e)
    {
		StatusMsg.Text = "Saved data to xml";
		// load xml doc
		XDocument xdoc = XDocument.Load(@"E:\code\repos\xml_maui\xml\blabla2.xml");

		// check if one entry is empty
		if(NummerEntry.Text == "" | BetragEntry.Text == "" | BezeichnungEntry.Text == "")
      		StatusMsg.Text = "F'ing prick fill out everything!";
        else
        {
			// add entry to the top
			xdoc.Root.AddFirst(new XElement("Eintrag", new XAttribute("Name", BezeichnungEntry.Text), new XAttribute("Betrag", BetragEntry.Text),
							       new XElement("Nummer", NummerEntry.Text))
			);
			// save xml doc
			xdoc.Save(@"E:\code\repos\xml_maui\xml\blabla2.xml");
			// if xml successfully saved reset all fields
			NummerEntry.Text = "";
			BetragEntry.Text = "";
			BezeichnungEntry.Text = "";

		}
	}
}

