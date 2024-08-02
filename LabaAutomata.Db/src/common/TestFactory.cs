//using LabAutomata.Db.models;

//namespace LabAutomata.Db.common;

//public static class TestFactory {

//	public static Test CreateSteadyStateTemperatureTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.SteadyStateTemperature()
//		};
//	}

//	public static Test CreateSteadyStateHumidityTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.SteadyStateHumidity()
//		};
//	}

//	public static Test CreateThermalShockTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.ThermalShock()
//		};
//	}

//	public static Test CreatePowerTemperatureCyclingTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.PowerTemperatureCycling()
//		};
//	}

//	public static Test CreateCyclicHumidityTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.CyclicHumidity()
//		};
//	}

//	public static Test CreateChemicalCorrosionTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.ChemicalCorrosion()
//		};
//	}

//	public static Test CreateFreeFallTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.FreeFall()
//		};
//	}

//	public static Test CreateImmersionTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.Immersion()
//		};
//	}

//	public static Test CreateSaltFogTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.SaltFog()
//		};
//	}

//	public static Test CreateSaltSprayTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.SaltSpray()
//		};
//	}

//	public static Test CreateHighPressureWaterSprayTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.HighPressureWaterSpray()
//		};
//	}

//	public static Test CreateSealTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.Seal()
//		};
//	}

//	public static Test CreateVibrationTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.Vibration()
//		};
//	}

//	public static Test CreateMechanicalShockTest (string name, int instanceId) {
//		return new Test(name, instanceId) {
//			Type = TestTypeFactory.MechanicalShock()
//		};
//	}
//}