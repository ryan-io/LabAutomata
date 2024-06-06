using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace LabAutomata.setup;

internal sealed class ConfigureSecrets {
	public void Configure () {
		_builder.AddUserSecrets(_asm);
	}

	public ConfigureSecrets (IConfigurationBuilder builder, Assembly asm) {
		_builder = builder;
		_asm = asm;
	}

	private readonly IConfigurationBuilder _builder;
	private readonly Assembly _asm;
}