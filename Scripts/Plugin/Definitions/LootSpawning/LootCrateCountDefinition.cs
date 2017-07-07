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

    [XmlType("LootCrateCount")]
    public class LootCrateCountDefinition : DefinitionBase {

        [XmlAttribute("CrateTypeName")]
        public String CrateTypeName = "";

        [XmlAttribute("DesiredCount")]
        public ushort DesiredCount;

        protected override String ValidationName {
            get { return "LootCrateCount"; }
        }

        public LootCrateCountDefinition() { }

        public LootCrateCountDefinition(ByteStream stream) {
            if (stream == null) throw new ArgumentException("null stream");

            CrateTypeName = stream.getString();
            DesiredCount = stream.getUShort();
        }

         public void AddToByteSteam(ByteStream stream) {
             if (stream == null) throw new ArgumentException("null stream");

             stream.addString(CrateTypeName);
             stream.addUShort(DesiredCount);
         }

        public override void Validate(ref List<ValidationError> errors) {
            ErrorIf(String.IsNullOrWhiteSpace(CrateTypeName),
                "CrateTypeName cannot be blank.", ref errors);
            ErrorIf(DesiredCount == 0,
                "DesiredCount must be > 0.", ref errors);
        }

    }

}
*/
