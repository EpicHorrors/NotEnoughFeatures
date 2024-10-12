using MiraAPI.Colors;
using UnityEngine;

namespace PhantomPlus.Patches;

[RegisterCustomColors]
public static class Colors
{
    

    public static CustomColor Gold { get; } = new("Gold", new Color32(255, 215, 0, 255));

    public static CustomColor Lavander { get; } = new("Lavander", new Color32(173, 126, 201, 255));
    public static CustomColor Ocean { get; } = new("Ocean", new Color32(29, 162, 216, 255));
    public static CustomColor Wasabi { get; } = new("Wasabi", new Color32(112, 143, 46, 255));

    public static CustomColor invis { get; } = new("Wasabi", new Color32(112, 143, 46, 0));
}