using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

// Token: 0x020000A9 RID: 169
[StandardModule]
public sealed class Helper
{
	// Token: 0x06000985 RID: 2437 RVA: 0x0003D210 File Offset: 0x0003B410
	public static LinearGradientBrush CreateGlassGradientBrush(Rectangle Rectangle, Color Color1, Color Color2)
	{
		LinearGradientBrush linearGradientBrush = new LinearGradientBrush(Rectangle, Color1, Color2, LinearGradientMode.Vertical);
		Bitmap bitmap = new Bitmap(1, Rectangle.Height);
		Graphics graphics = Graphics.FromImage(bitmap);
		graphics.FillRectangle(linearGradientBrush, new Rectangle(0, 0, 1, Rectangle.Height));
		ColorBlend colorBlend = new ColorBlend(4);
		colorBlend.Colors[0] = bitmap.GetPixel(0, 0);
		checked
		{
			colorBlend.Colors[1] = bitmap.GetPixel(0, (int)Math.Round((double)bitmap.Height / 3.0));
			colorBlend.Colors[2] = bitmap.GetPixel(0, bitmap.Height - 1);
			colorBlend.Colors[3] = bitmap.GetPixel(0, (int)Math.Round((double)bitmap.Height / 3.0));
			colorBlend.Positions[0] = 0f;
			colorBlend.Positions[1] = 0.335f;
			colorBlend.Positions[2] = 0.335f;
			colorBlend.Positions[3] = 1f;
			linearGradientBrush.InterpolationColors = colorBlend;
			graphics.Dispose();
			bitmap.Dispose();
			return linearGradientBrush;
		}
	}

	// Token: 0x040004D1 RID: 1233
	public static Helper.Colors RenderColors = new Helper.Colors();

	// Token: 0x020000AA RID: 170
	public class Colors
	{
		// Token: 0x06000987 RID: 2439 RVA: 0x0003D330 File Offset: 0x0003B530
		public Color BackHighColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.ToolStripGradientEnd;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0003D35C File Offset: 0x0003B55C
		public Color BackLowColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.ToolStripGradientBegin;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0003D388 File Offset: 0x0003B588
		public Color BorderColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.ControlDarkDark;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.GripDark;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0003D3B4 File Offset: 0x0003B5B4
		public Color BorderColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.ControlDark;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.SeparatorDark;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x0003D3E0 File Offset: 0x0003B5E0
		public Color ControlButtonBackHighColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.ButtonHighlight;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.ButtonSelectedGradientBegin;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x0003D40C File Offset: 0x0003B60C
		public Color ControlButtonBackLowColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.ButtonHighlight;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.ButtonSelectedGradientEnd;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0003D438 File Offset: 0x0003B638
		public Color ControlButtonBorderColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.HotTrack;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.ButtonPressedBorder;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0003D464 File Offset: 0x0003B664
		public Color TabBackHighColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.Control;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.MenuItemPressedGradientBegin;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0003D490 File Offset: 0x0003B690
		public Color TabBackLowColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.Control;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.MenuItemPressedGradientEnd;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x0003D4BC File Offset: 0x0003B6BC
		public Color TabBackHighColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.Control;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.ToolStripDropDownBackground;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x0003D4E8 File Offset: 0x0003B6E8
		public Color TabBackLowColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.Control;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = ProfessionalColors.ToolStripGradientMiddle;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x0003D514 File Offset: 0x0003B714
		public Color TabCloseButtonBackHighColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Transparent;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0003D514 File Offset: 0x0003B714
		public Color TabCloseButtonBackHighColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Transparent;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x0003D540 File Offset: 0x0003B740
		public Color TabCloseButtonBackHighColorHot(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.ButtonHighlight;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.WhiteSmoke;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x0003D514 File Offset: 0x0003B714
		public Color TabCloseButtonBackLowColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Transparent;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0003D514 File Offset: 0x0003B714
		public Color TabCloseButtonBackLowColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = Color.Transparent;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Transparent;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x0003D56C File Offset: 0x0003B76C
		public Color TabCloseButtonBackLowColorHot(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.ButtonHighlight;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.LightGray;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x0003D598 File Offset: 0x0003B798
		public Color TabCloseButtonBorderColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.ControlDark;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Transparent;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x0003D5C4 File Offset: 0x0003B7C4
		public Color TabCloseButtonBorderColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.GrayText;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Transparent;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x0003D5F0 File Offset: 0x0003B7F0
		public Color TabCloseButtonBorderColorHot(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.HotTrack;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Gray;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0003D61C File Offset: 0x0003B81C
		public Color TabCloseButtonForeColor(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.ControlText;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Gray;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0003D648 File Offset: 0x0003B848
		public Color TabCloseButtonForeColorDisabled(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.GrayText;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Gray;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0003D674 File Offset: 0x0003B874
		public Color TabCloseButtonForeColorHot(ToolStripRenderMode RenderMode, Color ManagedColor)
		{
			Color result;
			if (RenderMode == ToolStripRenderMode.System)
			{
				result = SystemColors.ControlText;
			}
			else if (RenderMode == ToolStripRenderMode.Professional)
			{
				result = Color.Firebrick;
			}
			else
			{
				result = ManagedColor;
			}
			return result;
		}
	}
}
