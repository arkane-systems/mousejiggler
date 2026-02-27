namespace ArkaneSystems.MouseJiggler;

internal static class JigglePatterns
{
  static JigglePatterns () => ComputePatterns (1);

  private static void ComputePatterns (int distance = 1)
  {
    // Normal pattern: move right and down, then left and up
    Normal = new (int deltax, int deltay)[]
    {
      (4 * distance, 4 * distance), // Move right and down
      (-4 * distance, -4 * distance) // Move left and up
    };

    // Zen pattern: do not move at all
    Zen = new (int deltax, int deltay)[]
    {
      (0, 0) // No movement
    };

    // Circle pattern: move in a circle (right, down, left, up)
    Circle = new (int deltax, int deltay)[]
    {
      (3 * distance, 2 * distance),
      (2 * distance, 3 * distance),
      (-2 * distance, 3 * distance),
      (-3 * distance, 2 * distance),
      (-3 * distance, -2 * distance),
      (-2 * distance, -3 * distance),
      (2 * distance, -3 * distance),
      (3 * distance, -2 * distance)
    };

    // Linear pattern: slide left and right, without vertical movement
    Linear = new (int deltax, int deltay)[]
    {
      (4 * distance, 0),
      (-4 * distance, 0)
    };
  }

  public static void UpdatePatterns (int distance) => ComputePatterns (distance);

  public static (int deltax, int deltay)[] Normal { get; private set; } = null!;

  public static (int deltax, int deltay)[] Zen { get; private set; } = null!;

  public static (int deltax, int deltay)[] Circle { get; private set; } = null!;

  public static (int deltax, int deltay)[] Linear { get; private set; } = null!;
}
