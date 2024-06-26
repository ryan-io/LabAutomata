﻿using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;

namespace LabAutomata.Wpf.Library.commands;

public class ApplicationEntryCommand : Command {

	private async void LoadAsync (object? sender) {
		var v = _vmc.GetValues().ToArray();
		//var tasks = new List<Task>();

		foreach (var vm in v) {
			//tasks.Add(vm.LoadAsync());
			await vm.LoadAsync();
			vm.Load();
		}
		//await Task.WhenAll(tasks);
	}

	public ApplicationEntryCommand (IVmc vmc) {
		_vmc = vmc;
		ContextAction = LoadAsync;
	}

	private readonly IVmc _vmc;
}