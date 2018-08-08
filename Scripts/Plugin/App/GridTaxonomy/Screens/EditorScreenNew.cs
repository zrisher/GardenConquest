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
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;
using Sandbox;
using Sandbox.Common;
using Sandbox.Engine.Utils;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Character;
using Sandbox.Game.Entities.Cube;
using Sandbox.Game.GUI.HudViewers;
using Sandbox.Game.Localization;
using Sandbox.Game.Screens.Helpers;
using Sandbox.Game.Screens.Terminal;
using Sandbox.Game.World;
using Sandbox.Graphics.GUI;
using System;
using System.Diagnostics;
using System.Text;
using Sandbox.Engine.Networking;
using VRage;
using VRage.Game;
using VRage.Input;
using VRage.Library.Utils;
using VRage.Utils;
using VRageMath;
using VRage.Game.Entity;
using VRage.Game.ModAPI;

namespace GC.App.GridTaxonomy
{
	public class EditorScreenNew : MyGuiScreenBase
	{

		MyGuiControlTabControl TabControl;

		public EditorScreenNew() : base (
			position: new Vector2(0.5f, 0.5f), 
			backgroundColor: MyGuiConstants.SCREEN_BACKGROUND_COLOR, 
			size: new Vector2(0.99f, 0.9f),
			backgroundTransition: MySandboxGame.Config.UIBkOpacity, 
			guiTransition: MySandboxGame.Config.UIOpacity
			)
		{	
			CloseButtonEnabled = true;
			CloseButtonOffset = new Vector2(-0.02f, 0.012f);
			EnabledBackgroundFade = true;
			RecreateControls(true);
		}

		public override string GetFriendlyName()
		{
			return "GC.EditorScreenNew";
		}

		public override void RecreateControls(bool constructor)
		{
			base.RecreateControls(constructor);

			Controls.Add(new MyGuiControlLabel(
				position: new Vector2(0f, -0.42f),
				size: new Vector2(0.06918918f, 0.0266666654f),
				text: "GC.EditorScreenNew Title", 
				//colorMask: null, 
				//textScale: 1.5f, //0.8f, 
				//font: "Blue",
				originAlign: MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_CENTER
			));

			CreateTabs();
		}

		void CreateTabs()
		{
			TabControl = new MyGuiControlTabControl
			{
				Position = new Vector2(-0f, -0.36f),
				Size = new Vector2(0.93f, 0.78f),
				Name = "GC.Tabs",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_TOP
			};

			MyGuiControlTabPage page1 = TabControl.GetTabSubControl(0);
			MyGuiControlTabPage page2 = TabControl.GetTabSubControl(1);


			// attach
			CreateTaxonomyPage(page1);			

			// init

			//TabControl.SelectedPage = (int)this.m_initialPage;
			//if (TabControl.SelectedPage != -1 && !TabControl.GetTabSubControl(TabControl.SelectedPage).Enabled)
			//{
			//	TabControl.SelectedPage = TabControl.Controls.IndexOf(tabSubControl2);
			//}

			Controls.Add(TabControl);
		}

		private void CreateTaxonomyPage(MyGuiControlTabPage page)
		{
			page.Name = "GC.TaxonomyPage";
			page.Text = new StringBuilder("Taxonomy");
			page.TextScale = 0.7005405f;

			MyGuiControlCompositePanel myGuiControlCompositePanel = new MyGuiControlCompositePanel
			{
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				//Position = new Vector2(0, 0),
				Size = new Vector2(0.6f, 0.39f),
				Name = "compositeIns"
			};

			page.Controls.Add(myGuiControlCompositePanel);
			*/
			/*
			MyGuiControlRadioButton control = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.465f, -0.36f),
				Size = new Vector2(0.056875f, 0.0575f),
				Name = "LeftSuitButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterCharacter
			};
			MyGuiControlRadioButton control2 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.405f, -0.36f),
				Size = new Vector2(0.056875f, 0.0575f),
				Name = "LeftGridButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterGrid
			};
			MyGuiControlRadioButton control3 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.175f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "LeftFilterStorageButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterStorage
			};
			MyGuiControlRadioButton control4 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.125f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "LeftFilterSystemButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterSystem
			};
			MyGuiControlRadioButton control5 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.075f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "LeftFilterEnergyButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterEnergy
			};
			MyGuiControlRadioButton control6 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.025f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "LeftFilterAllButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterAll
			};
			MyGuiControlTextbox control7 = new MyGuiControlTextbox
			{
				Position = new Vector2(-0.465f, -0.283f),
				Size = new Vector2(0.288f, 0.052f),
				Name = "BlockSearchLeft",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER
			};
			MyGuiControlButton control8 = new MyGuiControlButton
			{
				Position = new Vector2(-0.2f, -0.283f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "BlockSearchClearLeft",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER,
				VisualStyle = MyGuiControlButtonStyleEnum.Close,
				ActivateOnMouseRelease = true
			};
			MyGuiControlCheckbox control9 = new MyGuiControlCheckbox(null, null, null, false, MyGuiControlCheckboxStyleEnum.Default, MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_CENTER)
			{
				Position = new Vector2(-0.025f, -0.283f),
				Name = "CheckboxHideEmptyLeft",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER
			};
			MyGuiControlLabel control10 = new MyGuiControlLabel
			{
				Position = new Vector2(-0.155f, -0.283f),
				Name = "LabelHideEmptyLeft",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER,
				TextEnum = MySpaceTexts.HideEmpty
			};
			MyGuiControlList control11 = new MyGuiControlList
			{
				Position = new Vector2(-0.465f, -0.26f),
				Size = new Vector2(0.44f, 0.616f),
				Name = "LeftInventory",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP
			};
			page.Controls.Add(control);
			page.Controls.Add(control2);
			page.Controls.Add(control3);
			page.Controls.Add(control4);
			page.Controls.Add(control5);
			page.Controls.Add(control6);
			page.Controls.Add(control7);
			page.Controls.Add(control8);
			page.Controls.Add(control9);
			page.Controls.Add(control10);
			page.Controls.Add(control11);
			MyGuiControlRadioButton control12 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.025f, -0.36f),
				Size = new Vector2(0.056875f, 0.0575f),
				Name = "RightSuitButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterCharacter
			};
			MyGuiControlRadioButton control13 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.085f, -0.36f),
				Size = new Vector2(0.056875f, 0.0575f),
				Name = "RightGridButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterGrid
			};
			MyGuiControlRadioButton control14 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.315f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "RightFilterStorageButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterStorage
			};
			MyGuiControlRadioButton control15 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.365f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "RightFilterSystemButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterSystem
			};
			MyGuiControlRadioButton control16 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.415f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "RightFilterEnergyButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterEnergy
			};
			MyGuiControlRadioButton control17 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.465f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "RightFilterAllButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterAll
			};
			MyGuiControlTextbox control18 = new MyGuiControlTextbox
			{
				Position = new Vector2(0.025f, -0.283f),
				Size = new Vector2(0.288f, 0.052f),
				Name = "BlockSearchRight",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER
			};
			MyGuiControlButton control19 = new MyGuiControlButton
			{
				Position = new Vector2(0.29f, -0.283f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "BlockSearchClearRight",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER,
				VisualStyle = MyGuiControlButtonStyleEnum.Close,
				ActivateOnMouseRelease = true
			};
			MyGuiControlCheckbox control20 = new MyGuiControlCheckbox(null, null, null, false, MyGuiControlCheckboxStyleEnum.Default, MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_CENTER)
			{
				Position = new Vector2(0.465f, -0.283f),
				Name = "CheckboxHideEmptyRight",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER
			};
			MyGuiControlLabel control21 = new MyGuiControlLabel
			{
				Position = new Vector2(0.335f, -0.283f),
				Name = "LabelHideEmptyRight",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER,
				TextEnum = MySpaceTexts.HideEmpty
			};
			MyGuiControlList control22 = new MyGuiControlList
			{
				Position = new Vector2(0.465f, -0.295f),
				Size = new Vector2(0.44f, 0.65f),
				Name = "RightInventory",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP
			};
			page.Controls.Add(control12);
			page.Controls.Add(control13);
			page.Controls.Add(control14);
			page.Controls.Add(control15);
			page.Controls.Add(control16);
			page.Controls.Add(control17);
			page.Controls.Add(control18);
			page.Controls.Add(control19);
			page.Controls.Add(control20);
			page.Controls.Add(control21);
			page.Controls.Add(control22);
			MyGuiControlButton control23 = new MyGuiControlButton
			{
				Position = new Vector2(0f, 0.355f),
				Size = new Vector2(0.044375f, 0.13666667f),
				Name = "ThrowOutButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_BOTTOM,
				TextEnum = MySpaceTexts.Afterburner,
				TextScale = 0f,
				TextAlignment = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				DrawCrossTextureWhenDisabled = true,
				VisualStyle = MyGuiControlButtonStyleEnum.InventoryTrash,
				ActivateOnMouseRelease = true
			};
			page.Controls.Add(control23);
			*/
			/*
		}


		private void CreateInventoryPageControls(MyGuiControlTabPage page)
		{
			page.Name = "PageInventory";
			page.TextEnum = MySpaceTexts.Inventory;
			page.TextScale = 0.7005405f;
			MyGuiControlRadioButton control = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.465f, -0.36f),
				Size = new Vector2(0.056875f, 0.0575f),
				Name = "LeftSuitButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterCharacter
			};
			MyGuiControlRadioButton control2 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.405f, -0.36f),
				Size = new Vector2(0.056875f, 0.0575f),
				Name = "LeftGridButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterGrid
			};
			MyGuiControlRadioButton control3 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.175f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "LeftFilterStorageButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterStorage
			};
			MyGuiControlRadioButton control4 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.125f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "LeftFilterSystemButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterSystem
			};
			MyGuiControlRadioButton control5 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.075f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "LeftFilterEnergyButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterEnergy
			};
			MyGuiControlRadioButton control6 = new MyGuiControlRadioButton
			{
				Position = new Vector2(-0.025f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "LeftFilterAllButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterAll
			};
			MyGuiControlTextbox control7 = new MyGuiControlTextbox
			{
				Position = new Vector2(-0.465f, -0.283f),
				Size = new Vector2(0.288f, 0.052f),
				Name = "BlockSearchLeft",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER
			};
			MyGuiControlButton control8 = new MyGuiControlButton
			{
				Position = new Vector2(-0.2f, -0.283f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "BlockSearchClearLeft",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER,
				VisualStyle = MyGuiControlButtonStyleEnum.Close,
				ActivateOnMouseRelease = true
			};
			MyGuiControlCheckbox control9 = new MyGuiControlCheckbox(null, null, null, false, MyGuiControlCheckboxStyleEnum.Default, MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_CENTER)
			{
				Position = new Vector2(-0.025f, -0.283f),
				Name = "CheckboxHideEmptyLeft",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER
			};
			MyGuiControlLabel control10 = new MyGuiControlLabel
			{
				Position = new Vector2(-0.155f, -0.283f),
				Name = "LabelHideEmptyLeft",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER,
				TextEnum = MySpaceTexts.HideEmpty
			};
			MyGuiControlList control11 = new MyGuiControlList
			{
				Position = new Vector2(-0.465f, -0.26f),
				Size = new Vector2(0.44f, 0.616f),
				Name = "LeftInventory",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP
			};
			page.Controls.Add(control);
			page.Controls.Add(control2);
			page.Controls.Add(control3);
			page.Controls.Add(control4);
			page.Controls.Add(control5);
			page.Controls.Add(control6);
			page.Controls.Add(control7);
			page.Controls.Add(control8);
			page.Controls.Add(control9);
			page.Controls.Add(control10);
			page.Controls.Add(control11);
			MyGuiControlRadioButton control12 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.025f, -0.36f),
				Size = new Vector2(0.056875f, 0.0575f),
				Name = "RightSuitButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterCharacter
			};
			MyGuiControlRadioButton control13 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.085f, -0.36f),
				Size = new Vector2(0.056875f, 0.0575f),
				Name = "RightGridButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterGrid
			};
			MyGuiControlRadioButton control14 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.315f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "RightFilterStorageButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterStorage
			};
			MyGuiControlRadioButton control15 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.365f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "RightFilterSystemButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterSystem
			};
			MyGuiControlRadioButton control16 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.415f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "RightFilterEnergyButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterEnergy
			};
			MyGuiControlRadioButton control17 = new MyGuiControlRadioButton
			{
				Position = new Vector2(0.465f, -0.36f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "RightFilterAllButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP,
				Key = 0,
				VisualStyle = MyGuiControlRadioButtonStyleEnum.FilterAll
			};
			MyGuiControlTextbox control18 = new MyGuiControlTextbox
			{
				Position = new Vector2(0.025f, -0.283f),
				Size = new Vector2(0.288f, 0.052f),
				Name = "BlockSearchRight",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER
			};
			MyGuiControlButton control19 = new MyGuiControlButton
			{
				Position = new Vector2(0.29f, -0.283f),
				Size = new Vector2(0.045f, 0.05666667f),
				Name = "BlockSearchClearRight",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER,
				VisualStyle = MyGuiControlButtonStyleEnum.Close,
				ActivateOnMouseRelease = true
			};
			MyGuiControlCheckbox control20 = new MyGuiControlCheckbox(null, null, null, false, MyGuiControlCheckboxStyleEnum.Default, MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_CENTER)
			{
				Position = new Vector2(0.465f, -0.283f),
				Name = "CheckboxHideEmptyRight",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER
			};
			MyGuiControlLabel control21 = new MyGuiControlLabel
			{
				Position = new Vector2(0.335f, -0.283f),
				Name = "LabelHideEmptyRight",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER,
				TextEnum = MySpaceTexts.HideEmpty
			};
			MyGuiControlList control22 = new MyGuiControlList
			{
				Position = new Vector2(0.465f, -0.295f),
				Size = new Vector2(0.44f, 0.65f),
				Name = "RightInventory",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_TOP
			};
			page.Controls.Add(control12);
			page.Controls.Add(control13);
			page.Controls.Add(control14);
			page.Controls.Add(control15);
			page.Controls.Add(control16);
			page.Controls.Add(control17);
			page.Controls.Add(control18);
			page.Controls.Add(control19);
			page.Controls.Add(control20);
			page.Controls.Add(control21);
			page.Controls.Add(control22);
			MyGuiControlButton control23 = new MyGuiControlButton
			{
				Position = new Vector2(0f, 0.355f),
				Size = new Vector2(0.044375f, 0.13666667f),
				Name = "ThrowOutButton",
				OriginAlign = MyGuiDrawAlignEnum.HORISONTAL_CENTER_AND_VERTICAL_BOTTOM,
				TextEnum = MySpaceTexts.Afterburner,
				TextScale = 0f,
				TextAlignment = MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_TOP,
				DrawCrossTextureWhenDisabled = true,
				VisualStyle = MyGuiControlButtonStyleEnum.InventoryTrash,
				ActivateOnMouseRelease = true
			};
			page.Controls.Add(control23);
		}
	}
}
*/
