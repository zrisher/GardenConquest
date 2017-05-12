/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sandbox.Definitions;

using VRage;
using VRage.Game;

using SEGarden;
using SEGarden.Definitions;
using SEGarden.Logging;
using SEGarden.World;
using SEGarden.World.Inventory;

using GC.App.BlockTaxonomy;
using GC.App.GridTaxonomy;
using GC.App.LootSpawning;
using GC.Definitions;
using GC.Definitions.GridTaxonomy;
using GC.Definitions.BlockTaxonomy;
using GC.Definitions.LootSpawning;


namespace GC {

    public partial class Settings {

        const String LicenseTypeName = "MyObjectBuilder_Component";
        const String CivLicenseSubtype = "GCLicenseCivilian";
        const String IndLicenseSubtype = "GCLicenseIndustrial";
        const String MilLicenseSubtype = "GCLicenseMilitary";
        const String TchLicenseSubtype = "GCLicenseTechnology";

        const double DefaultLargeBlockCostMultiplier = 2;
        const double DefaultEnabledBlockCostMultiplier = 5;

        public static Settings GetDefaultSettings() {
            var defaults = new Settings();
            defaults.LargeBlockCostMultiplier = 
                DefaultLargeBlockCostMultiplier;
            defaults.EnabledBlockCostMultiplier = 
                DefaultEnabledBlockCostMultiplier;
            defaults.BlockTypeCategories = GetDefaultBlockTypeCategories(
                defaults.EnabledBlockCostMultiplier, 
                defaults.LargeBlockCostMultiplier
            );
            defaults.LootCrateTypes = GetDefaultLootCrateTypes();
            defaults.ControlPoints = GetDefaultControlPoints(
                defaults.LootCrateTypes
            );
            defaults.GridTaxonomy = GetDefaultTaxonomy();
            return defaults;
        }

        private static List<LootCrateType> GetDefaultLootCrateTypes() {
            // Some example loot items
            var CivLicense =
                new PhysicalItemType(LicenseTypeName, CivLicenseSubtype);
            var IndLicense =
                new PhysicalItemType(LicenseTypeName, IndLicenseSubtype);
            var MilLicense =
                new PhysicalItemType(LicenseTypeName, MilLicenseSubtype);
            var TchLicense =
                new PhysicalItemType(LicenseTypeName, TchLicenseSubtype);

            var e = new PhysicalItemType("MyObjectBuilder_AmmoMagazine", "Missile200mm");
            var f = new PhysicalItemType("MyObjectBuilder_Ore", "Platinum");
            var g = new PhysicalItemType("MyObjectBuilder_Ingot", "Uranium");
            var h = new PhysicalItemType("MyObjectBuilder_PhysicalGunObject", "UltimateAutomaticRifleItem");
            var i = new PhysicalItemType("MyObjectBuilder_OxygenContainerObject", "OxygenBottle");
            var j = new PhysicalItemType("MyObjectBuilder_GasContainerObject", "HydrogenBottle");

            var civCrate = new LootCrateType(
                "Civilian",
                new List<LootDrop>() {
                    new LootDrop(1, new ItemCount(100, CivLicense)),
                    new LootDrop(.5, new ItemCount(1, i)),
                    new LootDrop(.5, new ItemCount(1, j)),
                }
            );

            var milCrate = new LootCrateType(
                "Military",
                new List<LootDrop>() {
                    new LootDrop(1, new ItemCount(10, MilLicense)),
                    new LootDrop(.5, new ItemCount(10, e)),
                    new LootDrop(.5, new ItemCount(1, h)),
                }
            );

            var indCrate = new LootCrateType(
                "Industrial",
                new List<LootDrop>() {
                    new LootDrop(1, new ItemCount(10, IndLicense)),
                    new LootDrop(.5, new ItemCount(10, f)),
                    new LootDrop(.5, new ItemCount(10, g)),
                }
            );

            var techCrate = new LootCrateType(
                "Tech",
                new List<LootDrop>() {
                    new LootDrop(1, new ItemCount(10, TchLicense)),
                    new LootDrop(.5, new ItemCount(10, e)),
                    new LootDrop(.5, new ItemCount(10, f)),
                    new LootDrop(.5, new ItemCount(10, g)),
                    new LootDrop(.5, new ItemCount(1, h)),
                    new LootDrop(.5, new ItemCount(1, i)),
                    new LootDrop(.5, new ItemCount(1, j)),
                }
            );

            return new List<LootCrateType>(){
                civCrate, indCrate, milCrate, techCrate
            };
        }

        private static List<ControlPoint> GetDefaultControlPoints(
            List<LootCrateType> crateTypes
        ) {               
            return new List<ControlPoint> {
                new ControlPoint(
                    "CP Alpha",
                    new VRageMath.Vector3D(0, 0, 0),
                    15000,
                    crateTypes.Select(x => new LootCrateCount(3, x)).ToList()
                ),
            };
        }

        private static List<BlockTypeCategory> GetDefaultBlockTypeCategories(
            double enabledMultiplier, double bigMultiplier
        ) {
            var CivLicense =
                new PhysicalItemType(LicenseTypeName, CivLicenseSubtype);
            var IndLicense =
                new PhysicalItemType(LicenseTypeName, IndLicenseSubtype);
            var MilLicense =
                new PhysicalItemType(LicenseTypeName, MilLicenseSubtype);
            var TchLicense =
                new PhysicalItemType(LicenseTypeName, TchLicenseSubtype);

            var civCategory = new BlockTypeCategory(
                "Civilian", new ItemCount(1, CivLicense), 
                enabledMultiplier, bigMultiplier
            );
            var indCategory = new BlockTypeCategory(
                "Industrial", new ItemCount(1, IndLicense),
                enabledMultiplier, bigMultiplier
            );
            var milCategory = new BlockTypeCategory(
                "Military", new ItemCount(1, MilLicense),
                enabledMultiplier, bigMultiplier
            );
            var tchCategory = new BlockTypeCategory(
                "Technology", new ItemCount(1, TchLicense),
                enabledMultiplier, bigMultiplier
            );

            var armor = new BlockTypeDefinition() {
                Name = "Armor", 
                CostMultiplier = 1, 
                SubtypePartialNames = new List<String> {"Armor", "BlastDoor"}
            };
            var interior = new BlockTypeDefinition() {
                Name = "Interior",
                CostMultiplier = 5,
                SubtypePartialNames = new List<String>{ 
                    "Passage", "Window", "Stairs", "Ramp", "Catwalk", 
                    "CoverWall", "InteriorWall", "InteriorPillar"
                }
            };
            var conveyors = new BlockTypeDefinition() {
                Name = "Conveyors",
                CostMultiplier = 5,
                SubtypePartialNames = new List<String>{"Conveyor"}
            };
            var controls = new BlockTypeDefinition() {
                Name = "Cameras, Cockpits, & Controls",
                CostMultiplier = 5,
                SubtypePartialNames = new List<String>{
                    "ButtonPanel", "ControlPanel", "Cockpit", 
                    "PassengerSeat", "RemoteControl", "Camera"
                }
            };
            var cargo = new BlockTypeDefinition() {
                Name = "Cargo, Connectors, & Sorters",
                CostMultiplier = 10,
                SubtypePartialNames = new List<String>{
                    "Container", "Connector", "Sorter", "OxygenTank", 
                    "HydrogenTank", "AirVent", "Collector", "Merge" 
                }
            };
            var doors = new BlockTypeDefinition() {
                Name = "Doors",
                CostMultiplier = 10,
                SubtypePartialNames = new List<String>{
                    "HangarDoor", "SlideDoor"
                }
            };
            var power = new BlockTypeDefinition() {
                Name = "Power",
                CostMultiplier = 10,
                SubtypePartialNames = new List<String>{
                    "Reactor", "Battery"
                }
            };
            var thrusters = new BlockTypeDefinition() {
                Name = "Thrusters & Gyros",
                CostMultiplier = 10,
                SubtypePartialNames = new List<String>{"Thrust", "Gyro"}
            };
            var wheels = new BlockTypeDefinition() {
                Name = "Wheels & Suspension",
                CostMultiplier = 10,
                EnablePriority = 10,
                SubtypePartialNames = new List<String> {"Suspension", "Wheel"}
            };
            var medical = new BlockTypeDefinition() {
                Name = "Medical & Cryo",
                CostMultiplier = 100,
                SubtypePartialNames = new List<String>{
                    "MedicalRoom", "CryoChamber"
                }
            };
            var solar = new BlockTypeDefinition() {
                Name = "Solar Power",
                CostMultiplier = 3,
                EnablePriority = 100,
                SubtypePartialNames = new List<String>{ "Solar"}
            };
            var display = new BlockTypeDefinition() {
                Name = "Lights, Displays, & Sound",
                CostMultiplier = 3,
                EnablePriority = 95,
                SubtypePartialNames = new List<String>{
                    "SmallLight", "FrontLight", "Sound", "TextPanel",
                    "LCDPanel"
                }
            };
            var comms = new BlockTypeDefinition() {
                Name = "Communications",
                CostMultiplier = 10,
                EnablePriority = 90,
                SubtypePartialNames = new List<String>{
                    "RadioAntenna", "Beacon"
                }
            };
            var logic = new BlockTypeDefinition() {
                Name = "Logic",
                CostMultiplier = 20,
                EnablePriority = 85,
                SubtypePartialNames = new List<String>{
                    "Programmable", "Sensor", "Timer", "Autopilot" 
                }
            };
            var physics = new BlockTypeDefinition() {
                Name = "Physics",
                CostMultiplier = 20,
                EnablePriority = 10,
                SubtypePartialNames = new List<String>{
                    "LandingGear", "Piston", "Stator", "Suspension", 
                    "Rotor", "Wheel", "SpaceBall"
                }
            };

            civCategory.BlockTypes.AddRange(new List<BlockType>() {
                new BlockType(armor, civCategory),
                new BlockType(interior, civCategory),
                new BlockType(conveyors, civCategory),
                new BlockType(controls, civCategory),
                new BlockType(cargo, civCategory),
                new BlockType(doors, civCategory),
                new BlockType(power, civCategory),
                new BlockType(thrusters, civCategory),
                new BlockType(wheels, civCategory),
                new BlockType(medical, civCategory),
                new BlockType(solar, civCategory),
                new BlockType(display, civCategory),
                new BlockType(comms, civCategory),
                new BlockType(logic, civCategory),
                new BlockType(physics, civCategory),
            });

            var modules = new BlockTypeDefinition() {
                Name = "Upgrade Modules",
                CostMultiplier = 5,
                SubtypePartialNames = new List<String>{
                    "ProductivityModule", "EffectivenessModule", 
                    "EnergyModule", 
                }
            };
            var production = new BlockTypeDefinition() {
                Name = "Production",
                CostMultiplier = 10,
                EnablePriority = 60,
                SubtypePartialNames = new List<String>{
                    "Assembler", "Refinery", "OxygenGenerator", 
                    "OxygenFarm" 
                }
            };
            var detectors = new BlockTypeDefinition() {
                Name = "Ore Detectors",
                CostMultiplier = 10,
                EnablePriority = 50,
                SubtypePartialNames = new List<String> {"OreDetector"}
            };
            var tools = new BlockTypeDefinition() {
                Name = "Tools",
                CostMultiplier = 30,
                EnablePriority = 40,
                SubtypePartialNames = new List<String>{
                    "Drill", "Grinder", "Welder", "Nanite"
                }
            };
            var projectors = new BlockTypeDefinition() {
                Name = "Projectors",
                CostMultiplier = 50,
                EnablePriority = 30,
                SubtypePartialNames = new List<String> {"Projector"}
            };

            indCategory.BlockTypes.AddRange(new List<BlockType>() {
                new BlockType(modules, indCategory),
                new BlockType(production, indCategory),
                new BlockType(detectors, indCategory),
                new BlockType(tools, indCategory),
                new BlockType(projectors, indCategory),
            });

            var staticWeapons = new BlockTypeDefinition() {
                Name = "Static Weapons",
                CostMultiplier = 10,
                SubtypePartialNames = new List<String>{
                    "Launcher", "GatlingGun", "Warhead", "Decoy"
                }
            };
            var turrets = new BlockTypeDefinition() {
                Name = "Turrets",
                CostMultiplier = 40,
                EnablePriority = 80,
                SubtypePartialNames = new List<String>{"Turret"}
            };

            milCategory.BlockTypes.AddRange(new List<BlockType>() {
                new BlockType(staticWeapons, milCategory),
                new BlockType(turrets, milCategory),
            });

            var jumpdrives = new BlockTypeDefinition() {
                Name = "Jump Drive",
                CostMultiplier = 20,
                SubtypePartialNames = new List<String> { "JumpDrive" }
            };
            var gravity = new BlockTypeDefinition() {
                Name = "Gravity & Mass",
                CostMultiplier = 20,
                EnablePriority = 20,
                SubtypePartialNames = new List<String>{
                    "Gravity", "VirtualMass"
                }
            };
            var advComms = new BlockTypeDefinition() {
                Name = "Adv. Communications",
                CostMultiplier = 50,
                EnablePriority = 70,
                SubtypePartialNames = new List<String> { 
                    "LaserAntenna", "Radar" 
                }
            };

            tchCategory.BlockTypes.AddRange(new List<BlockType>() {
                new BlockType(jumpdrives, tchCategory),
                new BlockType(gravity, tchCategory),
                new BlockType(advComms, tchCategory),
            });

            return new List<BlockTypeCategory>() {
                civCategory, indCategory, milCategory, tchCategory
            };
        }

        private static Node GetDefaultTaxonomy() {
            Node stations = new Node(
                Condition.TotalBlocksLtoE(2700),
                new Node(
                    Condition.TotalBlocksLtoE(900),
                    new Node("Outpost"),
                    new Node("Installation")
                ),
                new Node(
                    Condition.TotalBlocksLtoE(4500),
                    new Node("Fortress"),
                    new Node("Citadel")
                )
            );

            Node militarySmallShips = new Node(
                Condition.TotalBlocksLtoE(1200),
                new Node(
                    Condition.TotalBlocksLtoE(300),
                    new Node("Scout"),
                    new Node("Fighter")
                ),
                new Node(
                    Condition.TotalBlocksLtoE(2000),
                    new Node("Heavy Fighter"),
                    new Node("Gunship")
                )
            );

            Node militarySmallVehicles = new Node(
                Condition.TotalBlocksLtoE(900),
                new Node(
                    Condition.TotalBlocksLtoE(450),
                    new Node("Armored Car"),
                    new Node("Heavy Armored Car")
                ),
                new Node(
                    Condition.TotalBlocksLtoE(2700),
                    new Node("Tank"),
                    new Node("Heavy Tank")
                )
            );

            Node militaryLargeShips = new Node(
                Condition.TotalBlocksLtoE(3000),
                new Node(
                    Condition.TotalBlocksLtoE(1200),
                    new Node(
                        Condition.TotalBlocksLtoE(300),
                        new Node("Corvette"),
                        new Node("Frigate")
                    ),
                    new Node(
                        Condition.TotalBlocksLtoE(1600),
                        new Node("Heavy Frigate"),
                        new Node("Destroyer")
                    )
                ),
                new Node(
                    Condition.TotalBlocksLtoE(4500),
                    new Node("Cruiser"),
                    new Node("Battleship")
                )
            );

            Node militaryLargeVehicles = new Node(
                Condition.TotalBlocksLtoE(900),
                new Node(
                    Condition.TotalBlocksLtoE(450),
                    new Node("Armored Rover"),
                    new Node("Heavy Armored Rover")
                ),
                new Node(
                    Condition.TotalBlocksLtoE(2700),
                    new Node("Land Raider"),
                    new Node("Heavy Land Raider")
                )
            );

            Node civilianSmallShips = new Node(
                Condition.BlockTypeGtoE("tools", "production"),
                new Node(
                    Condition.BlockTypeGreater("tools", 0),
                    new Node("Small Worker Ship"),
                    new Node("Small Surveyor Ship")
                ),
                new Node("Small Production Ship")
            );

            Node civilianSmallVehicles = new Node(
                Condition.BlockTypeGtoE("tools", "production"),
                new Node(
                    Condition.BlockTypeGreater("tools", 0),
                    new Node("Small Worker Vehicle"),
                    new Node("Small Surveyor Vehicle")
                ),
                new Node("Small Production Vehicle")
            );

            Node civilianLargeShips = new Node(
                Condition.BlockTypeGtoE("tools", "production"),
                new Node(
                    Condition.BlockTypeGreater("tools", 0),
                    new Node("Large Worker Ship"),
                    new Node("Large Surveyor Ship")
                ),
                new Node("Large Production Ship")
            );

            Node civilianLargeVehicles = new Node(
                Condition.BlockTypeGtoE("tools", "production"),
                new Node(
                    Condition.BlockTypeGreater("tools", 0),
                    new Node("Large Worker Vehicle"),
                    new Node("Large Surveyor Vehicle")
                ),
                new Node("Large Production Vehicle")
            );

            return new Node(
                Condition.GridTypeComparison(GridType.Station),
                stations,
                new Node(
                    Condition.GridTypeComparison(GridType.SmallShip),
                    new Node(
                        Condition.BlockTypeLtoE("Wheels", "Thrusters"),
                        new Node(
                            Condition.BlockCategoryLtoE("industrial", "military"),
                            civilianSmallShips,
                            militarySmallShips
                        ),
                        new Node(
                            Condition.BlockCategoryLtoE("industrial", "military"),
                            civilianSmallVehicles,
                            militarySmallVehicles
                        )
                    ),
                    new Node(
                        Condition.BlockTypeLtoE("Wheels", "Thrusters"),
                        new Node(
                            Condition.BlockCategoryLtoE("industrial", "military"),
                            civilianLargeShips,
                            militaryLargeShips
                        ),
                        new Node(
                            Condition.BlockCategoryLtoE("industrial", "military"),
                            civilianLargeVehicles,
                            militaryLargeVehicles
                        )
                    )
                )
            );
        }

    }

}
*/
