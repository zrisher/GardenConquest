/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sandbox.Common;

using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.Engine.Multiplayer;
using Sandbox.Engine.Utils;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Character;
using Sandbox.Game.GUI;
using Sandbox.Game.Localization;
using Sandbox.Game.Multiplayer;
using Sandbox.Game.Screens.Helpers;
using Sandbox.Game.World;
using Sandbox.Gui.RichTextLabel;
using Sandbox.Graphics;
using Sandbox.Graphics.GUI;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage;
using VRage.Utils;
using VRageMath;
using Sandbox.Game.Gui;
using VRage.Game.ModAPI;


namespace GC.App.GridTaxonomy
{
	class EditorScreen : EditorBase
	{
		public EditorScreen(
			string missionTitle = null,
			string currentObjectivePrefix = null,
			string currentObjective = null,
			string description = null,

			Action<ResultEnum> resultCallback = null,
			string okButtonCaption = null,
			Vector2? windowSize = null,
			Vector2? descSize = null,
			bool editEnabled = false,
			bool canHideOthers = true,
			bool enableBackgroundFade = false,
			MyMissionScreenStyleEnum style = MyMissionScreenStyleEnum.BLUE)
			: base(missionTitle, currentObjectivePrefix, currentObjective, description, resultCallback, okButtonCaption, windowSize, descSize, editEnabled, canHideOthers, enableBackgroundFade, style)
		{

		}

		public override void RecreateControls(bool constructor)
		{
			base.RecreateControls(constructor);
		}



		public override bool Draw()
		{
			bool ret = base.Draw();
			//DrawInternal();
			return ret;
		}

//        private void DrawInternal()
//        {
//            m_description_RTF.Draw(1, 1);
//        }

	}
}
*/