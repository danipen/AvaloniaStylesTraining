using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

using System;
using System.Linq;

namespace AvaloniaStylesTraining
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            var fontsComboBox = this.Find<ComboBox>("mFontsComboBox");
            fontsComboBox.Items = FontManager.Current.GetInstalledFontFamilyNames().Select(x => new FontFamily(x));

            var stackPanel = this.Find<StackPanel>("mPanel");

            CustomButton button = new CustomButton();
            button.Content = "SUPER BUTTON!";

            Button myCustomButton = new Button();
            myCustomButton.Content = "HELLO CUSTOM!";
            myCustomButton.Template = new FuncControlTemplate<Button>(CreateTemplate);

            stackPanel.Children.Add(button);
            stackPanel.Children.Add(myCustomButton);
        }

        IControl CreateTemplate(Button button, INameScope ns)
        {
            Border border = new Border();
            border.Padding = new Thickness(20);
            border.CornerRadius = new CornerRadius(4);
            border.Background = Brushes.LightGreen;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Avalonia.Layout.Orientation.Horizontal;
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = Brushes.Red;
            ellipse.Width = ellipse.Height = 16;

            ContentPresenter presenter = new ContentPresenter();
            presenter[ContentPresenter.ContentProperty] = button[Button.ContentProperty];

            stackPanel.Children.Add(ellipse);
            stackPanel.Children.Add(presenter);

            border.Child = stackPanel;

            return border;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        class CustomButton : Button
        {
            internal CustomButton()
            {
                Classes.Add("custom");
            }

            protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
            {
                base.OnApplyTemplate(e);

                Ellipse ellipse = (Ellipse)e.NameScope.Find("PART_LeftEllipse");
                ellipse.Width = 24;
                ellipse.Height = 24;
            }
        }
    }
}
