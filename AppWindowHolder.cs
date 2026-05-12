#if WINDOWS
using Microsoft.UI.Windowing;
using Windows.Graphics;

namespace Users_DASM;

public class AppWindowHolder
{
    // =========================================
    // SINGLETON INSTANCE
    // =========================================

    private static AppWindowHolder? _instance;

    public static AppWindowHolder Instance
        => _instance ??= new AppWindowHolder();

    // =========================================
    // WINDOW REFERENCE
    // =========================================

    public AppWindow? Window { get; private set; }

    public void Set(AppWindow window)
    {
        Window = window;
    }

    // =========================================
    // LOGIN WINDOW MODE
    // =========================================

    public void RestoreLoginWindow()
    {
        if (Window == null)
            return;

        int loginWidth = 650;
        int loginHeight = 550;

        // RESTORE NORMAL WINDOW MODE
        Window.SetPresenter(
            AppWindowPresenterKind.Overlapped);

        // RESIZE WINDOW
        Window.Resize(
            new SizeInt32(
                loginWidth,
                loginHeight));

        // REMOVE TITLE BAR + BUTTONS
        if (Window.Presenter is OverlappedPresenter presenter)
        {
            presenter.IsResizable = false;

            presenter.IsMaximizable = false;

            presenter.IsMinimizable = false;

            presenter.SetBorderAndTitleBar(
                false,
                false);
        }

        // REMOVE TITLE
        Window.Title = string.Empty;

        // CENTER WINDOW
        var displayArea =
            DisplayArea.GetFromWindowId(
                Window.Id,
                DisplayAreaFallback.Primary);

        int x =
            (displayArea.WorkArea.Width
             - loginWidth) / 2;

        int y =
            (displayArea.WorkArea.Height
             - loginHeight) / 2;

        Window.Move(
            new PointInt32(x, y));
    }

    // =========================================
    // RESTORE FULL APP WINDOW
    // =========================================

    public void RestoreFullWindow()
    {
        if (Window == null)
            return;

        // RESTORE NORMAL WINDOW
        Window.SetPresenter(
            AppWindowPresenterKind.Overlapped);

        if (Window.Presenter is OverlappedPresenter presenter)
        {
            // ENABLE CONTROLS
            presenter.IsResizable = true;

            presenter.IsMaximizable = true;

            presenter.IsMinimizable = true;

            // SHOW TITLE BAR
            presenter.SetBorderAndTitleBar(
                true,
                true);

            // MAXIMIZE WINDOW
            presenter.Maximize();
        }

        Window.Title = "Admin DASM";
    }

    // =========================================
    // TRUE FULLSCREEN
    // =========================================

    public void SetFullScreen()
    {
        if (Window == null)
            return;

        Window.SetPresenter(
            AppWindowPresenterKind.FullScreen);
    }

    // =========================================
    // EXIT FULLSCREEN
    // =========================================

    public void ExitFullScreen()
    {
        if (Window == null)
            return;

        Window.SetPresenter(
            AppWindowPresenterKind.Overlapped);
    }
}
#endif