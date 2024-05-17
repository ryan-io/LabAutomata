using System.Windows;

namespace LabAutomata.Wpf.Library.adapter;

public class DragWindowAdapter : IAdapter {
    public void Get () {
        _mainWindow.DragMove();
    }

    public DragWindowAdapter (Window mainWindow) {
        _mainWindow = mainWindow;
    }

    private readonly Window _mainWindow;
}