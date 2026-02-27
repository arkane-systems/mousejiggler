using System;

namespace ArkaneSystems.MouseJiggler;

/// <summary>
/// Specifies the available modes for jiggle behavior.
/// </summary>
/// <remarks>NotConfigured is a special value which is used in promotion from the old zen-jiggle toggle
/// functionality.</remarks>
[Serializable]
public enum JiggleMode
{
  NotConfigured,
  Normal,
  Zen,
  Circle,
  Linear
}
