/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using VRage;
using VRageMath;

using SEGarden.Definitions;
using SEGarden.Extensions;

namespace GC.Definitions.LootSpawning {

    [XmlType("ControlPoint")]
    public class ControlPointDefinition : DefinitionBase {

        /// <summary>
        /// Display Name used in Notifications and Dialogs.
        /// </summary>
        [XmlElement("Name")]
        public String Name = "";

        /// <summary>
        /// Center of the distribution area
        /// </summary>
        [XmlElement("Position")]
        public Vector3D Position;

        /// <summary>
        /// Radius of the distribution area
        /// </summary>
        [XmlElement("Radius")]
        public uint Radius;

        /// <summary>
        /// How many of which crates are desired to exist at any time
        /// </summary>
        [XmlArray("DesiredCrates")]
        public List<LootCrateCountDefinition> DesiredCrates =
            new List<LootCrateCountDefinition>();

        protected override String ValidationName {
            get { return "LootPoint"; }
        }

        public ControlPointDefinition() { }

        public ControlPointDefinition(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            Name = stream.getString();
            Position = stream.getVector3D();
            Radius = (uint)stream.getUlong();
            ushort len = stream.getUShort();
            for (ushort i = 0; i < len; ++i) {
                DesiredCrates.Add(new LootCrateCountDefinition(stream));
            }
        }

         public void AddToByteSteam(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

             stream.addString(Name);
             stream.addVector3D(Position);
             stream.addUlong((ulong)Radius);
             stream.addUShort((ushort)DesiredCrates.Count);
             foreach (var drop in DesiredCrates) {
                 drop.AddToByteSteam(stream);
             }
         }

         public override void Validate(ref List<ValidationError> errors) {
             ErrorIf(String.IsNullOrWhiteSpace(Name),
                 "Name cannot be empty", ref errors);
             ErrorIf(Radius == 0,
                 "Radius cannot be zero", ref errors);
             ValidateChildren(DesiredCrates, "DesiredCrates", ref errors);
         }

         public void ValidateCrateReferences(
             ref IEnumerable<String> lootCrateTypeNames,
             ref List<ValidationError> errors
         ) {

             foreach (var crateCount in DesiredCrates) {
                 var crate = crateCount.CrateTypeName;
                 ErrorIf(
                     !lootCrateTypeNames.Contains(crate),
                     String.Format(
                         "{0} calls for unknown crate type {1}", Name, crate
                     ),
                     ref errors
                 );
             }
         }

    }

}
*/