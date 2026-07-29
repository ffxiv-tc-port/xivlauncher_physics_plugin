using System.Numerics;
using Dalamud.Interface.Windowing;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility;

namespace HighFpsPhysicsPlugin;

internal class ConfigurationWindow : Window
{
    private static readonly Vector4 Green = new(0.0f, 1.0f, 0.0f, 1.0f);
    private static readonly Vector4 Orange = new(1.0f, 165.0f / 255.0f, 0.0f, 1.0f);
    private static readonly Vector4 Red = new(1.0f, 0.0f, 0.0f, 1.0f);

    public ConfigurationWindow() : base("High FPS Physics Fix - 設定")
    {
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(345, 230),
            MaximumSize = new Vector2(345, 230)
        };

        Flags |= ImGuiWindowFlags.NoResize;
    }

    public override void Draw()
    {
        ImGui.TextColored(Orange, "本插件可能會在過場動畫中造成短暫的顯示異常");
        ImGui.TextColored(Orange, "若遇到問題，請停用本插件");

        ImGuiHelpers.ScaledDummy(15.0f);

        if (ImGui.Checkbox("啟動時啟用", ref Service.Settings.EnableOnStartup))
        {
            Service.Settings.Save();
        }

        ImGuiHelpers.ScaledDummy(15.0f);

        ImGui.Text("High FPS 修正目前為");
        ImGui.SameLine();

        if (Service.PhysicsModification.GetStatus())
        {
            ImGui.TextColored(Green, "已啟用");
        }
        else
        {
            ImGui.TextColored(Red, "已停用");
        }

        if (Service.PhysicsModification.GetStatus())
        {
            if (ImGui.Button("停用", ImGuiHelpers.ScaledVector2(75.0f, 23.0f)))
            {
                Service.PhysicsModification.Disable();
            }
        }
        else
        {
            if (ImGui.Button("啟用", ImGuiHelpers.ScaledVector2(75.0f, 23.0f)))
            {
                Service.PhysicsModification.Enable();
            }
        }

        var target_fps = Service.Settings.TargetFPS;
        if (ImGui.SliderFloat("物理效果 FPS", ref target_fps, 1, 120))
        {
            Service.Settings.TargetFPS = target_fps;
            Service.Settings.Save();
            Service.PhysicsModification.RecalculateExpectedFrametime();
        }
        if (ImGui.IsItemHovered())
        {
            ImGui.SetTooltip("設定物理效果的目標 FPS，預設為 60。");
        }

    }
}
