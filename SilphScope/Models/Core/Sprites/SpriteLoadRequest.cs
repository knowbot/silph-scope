using SilphScope.Models.Games.Data.Enums;

namespace SilphScope.Models.Core.Sprites
{
	public class SpriteLoadRequest
	{
		public readonly SpriteLoadResult Result;
		public readonly Species Species;
		public readonly SpriteFlags Flags;

		public SpriteLoadRequest(SpriteLoadResult task, Species species, SpriteFlags flags)
		{
			Result = task;
			Species = species;
			Flags = flags;
		}
	}
}
