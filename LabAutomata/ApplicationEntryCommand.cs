using System.Windows.Threading;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.Logging;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace LabAutomata;

public class ApplicationEntryCommand : CommandAsync {
    async Task InvokeVmLoadAsync (object? sender) {

        Logger?.LogInformation("Application has been loaded.");

        var v = _vmc.GetValues().ToArray();
        var tasks = new List<Task>();

        foreach (var vm in v) {
            //await vm.LoadAsync(_cancellation.Token);
            tasks.Add(vm.LoadAsync(Token));
            vm.Load();
        }

        await Task.WhenAll(tasks);
    }

    public ApplicationEntryCommand (IVmc vmc,
        IAdapter<Dispatcher> adapter,
        ILogger logger)
        : base(adapter, logger) {
        ApplicationThemeManager.Apply(ApplicationTheme.Dark, WindowBackdropType.Auto);
        _vmc = vmc;
        Context = InvokeVmLoadAsync;
    }

    private readonly IVmc _vmc;
}