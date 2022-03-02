using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

using System;

namespace AvaloniaStylesTraining
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            var customStyle = (IStyle)AvaloniaXamlLoader.Load(new Uri("avares://AvaloniaStylesTraining/MyCustomStyles.axaml"));
            Application.Current.Styles.Add(customStyle);

            var buttonStyle = (IStyle)AvaloniaXamlLoader.Load(new Uri("avares://AvaloniaStylesTraining/MyButtonStyle.axaml"));
            Application.Current.Styles.Add(buttonStyle);

            base.OnFrameworkInitializationCompleted();
        }
    }
}
