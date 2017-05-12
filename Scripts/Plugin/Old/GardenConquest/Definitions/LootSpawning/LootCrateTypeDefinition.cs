/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using VRage;

using SEGarden.Definitions;
using SEGarden.Extensions;

namespace GC.Definitions.LootSpawning {

    [XmlType("LootCrateType")]
    public class LootCrateTypeDefinition : DefinitionBase {

        [XmlAttribute("Name")]
        public String Name;

        [XmlElement("LootDrops")]
        public List<LootDropDefinition> LootDrops = 
            new List<LootDropDefinition>();

        protected override String ValidationName {
            get { return "LootCrateType"; }
        }

        public LootCrateTypeDefinition() { }

        public LootCrateTypeDefinition(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            Name = stream.getString();
            ushort len = stream.getUShort();
            for (ushort i = 0; i < len; ++i) {
                LootDrops.Add(new LootDropDefinition(stream));
            }
        }

         public void AddToByteSteam(ByteStream stream) {
             if (stream == null) throw new ArgumentException("null stream");

             stream.addString(Name);
             stream.addUShort((ushort)LootDrops.Count);
             foreach (var drop in LootDrops) {
                 drop.AddToByteSteam(stream);
             }
         }

        public override void Validate(ref List<ValidationError> errors) {
            ErrorIf(String.IsNullOrWhiteSpace(Name),
                "Name cannot be empty", ref errors);
            ValidateChildren(LootDrops, "LootDrops", ref errors);
        }

    }

}
*/