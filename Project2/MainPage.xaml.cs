namespace Project2;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    public String currentInput = "";
    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Button b = sender as Button;
        if (b.Text != "Clear" && b.Text != "Delete") // Clear and Delete are spec.
        {
            if (b.Text == "0" && theLabel.Text == "0") // no leading zeroes
            {
            }
            else if (theLabel.Text == "0") // if empty
            {
                theLabel.Text = b.Text;
            }
            else                          // if not empty
            {
                theLabel.Text += b.Text;
            }
        }
        else if (b.Text == "Clear") // if Clear input
        {
            theLabel.Text = "0";
        }
        else // if Delete input
        {
            theLabel.Text = theLabel.Text.Substring(0, theLabel.Text.Length - 1);
        }
        if (theLabel.Text == "") // "" should just be 0 always
        {
            theLabel.Text = "0";
        }

        // when a button is clicked we want to check what system we're using
        // and change the values based on that.
        if (currentInput == "binary")
        {

            decimalConvert(Convert.ToInt32(theLabel.Text, 2));
        }
        else if (currentInput == "octal")
        {
            decimalConvert(Convert.ToInt32(theLabel.Text, 8));
        }
        else if (currentInput == "decimal")
        {
            decimalConvert(Convert.ToInt32(theLabel.Text, 10));
        }
        else if (currentInput == "hex")
        {
            decimalConvert(Convert.ToInt32(theLabel.Text, 16));
        }


    }

    void Picker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        int index = myPicker.SelectedIndex;
        if (myPicker.SelectedIndex == 0) // binary input
        {
            currentInput = "binary";
            disableLetters();
            disableNums();
        }
        else if (myPicker.SelectedIndex == 1) // octal input
        {
            currentInput = "octal";
            disableLetters();
            enableNums();
            eight.IsEnabled = false;
            nine.IsEnabled = false;
        }
        else if (myPicker.SelectedIndex == 2) // decimal input
        {
            currentInput = "decimal";
            disableLetters();
            enableNums();
        }
        else if (myPicker.SelectedIndex == 3) // Hex input
        {
            currentInput = "hex";
            enableLetters();
            enableNums();
        }

        void disableLetters()
        {
            a.IsEnabled = false;
            b.IsEnabled = false;
            c.IsEnabled = false;
            d.IsEnabled = false;
            e1.IsEnabled = false;
            f.IsEnabled = false;
        }
        void enableLetters()
        {
            a.IsEnabled = true;
            b.IsEnabled = true;
            c.IsEnabled = true;
            d.IsEnabled = true;
            e1.IsEnabled = true;
            f.IsEnabled = true;
        }
        void disableNums()
        {
            two.IsEnabled = false;
            three.IsEnabled = false;
            four.IsEnabled = false;
            five.IsEnabled = false;
            six.IsEnabled = false;
            seven.IsEnabled = false;
            eight.IsEnabled = false;
            nine.IsEnabled = false;
        }
        void enableNums()
        {
            two.IsEnabled = true;
            three.IsEnabled = true;
            four.IsEnabled = true;
            five.IsEnabled = true;
            six.IsEnabled = true;
            seven.IsEnabled = true;
            eight.IsEnabled = true;
            nine.IsEnabled = true;
        }
    }
    void decimalConvert(int num)
    {
        String s = num.ToString();
        decimalIn.Text = s;
        octal.Text = Convert.ToString(int.Parse(s), 8);
        hex.Text = Convert.ToString(int.Parse(s), 16);
        binary.Text = Convert.ToString(int.Parse(s), 2);
    }
}

