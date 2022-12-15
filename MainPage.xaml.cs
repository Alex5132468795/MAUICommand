using System.Windows.Input;

namespace MauiApp4;

public partial class MainPage : ContentPage
{
	public bool one;
	public bool two;
	public bool three;
	public ICommand CDommand { get; set; }
    public ICommand Command2 { get; private set; }
    public ICommand Command3 { get; private set; }
    public MainPage()
	{
        CDommand = new Command<string>(
			execute: (string s) =>
			{
				BB.Text = s;
			},
			canExecute: (string s) =>
			{
				return one;
			}
		);
        Command2 = new Command<string>(
            execute: (string s) =>
            {
                BB.Text = s;
            },
            canExecute: (string s) =>
            {
                return two;
            }
        );
        Command3 = new Command<string>(
            execute: (string s) =>
            {
                BB.Text = s;
            },
            canExecute: (string s) =>
            {
                return three;
            }
        );
        BindingContext = this;
		InitializeComponent();
    }
	private void Switch_Toggled(object sender, ToggledEventArgs e)
	{
		one = e.Value;
		((Command)CDommand).ChangeCanExecute();
	}

	private void Switch_Toggled_1(object sender, ToggledEventArgs e)
	{
        two = e.Value;
        ((Command)Command2).ChangeCanExecute();
    }

	private void Switch_Toggled_2(object sender, ToggledEventArgs e)
	{
        three = e.Value;
        ((Command)Command3).ChangeCanExecute();
    }
}

