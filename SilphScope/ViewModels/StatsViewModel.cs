using SilphScope.Models.Games.State.Common;
using SilphScope.Models.Games.StaticData.Enums;
using System.Collections.Generic;

namespace SilphScope.ViewModels
{
	public partial class StatsViewModel : ViewModelBase
	{
		public List<StatViewModel> Values { get; } = [
			new(Stat.HP.ToString()),
			new(Stat.Attack.ToString()),
			new(Stat.Defense.ToString()),
			new(Stat.SpAttack.ToString()),
			new(Stat.SpDefense.ToString()),
			new(Stat.Speed.ToString())
		];

		public StatsViewModel() { }

		public void UpdateGameState(Pkmn? pokemon)
		{
			if (pokemon == null)
			{
				foreach (StatViewModel value in Values)
				{
					value.UpdateGameState(0, 0, 0);
				}
				return;
			}

			UpdateGameState(Values[0], pokemon, Stat.HP);
			UpdateGameState(Values[1], pokemon, Stat.Attack);
			UpdateGameState(Values[2], pokemon, Stat.Defense);
			UpdateGameState(Values[3], pokemon, Stat.SpAttack);
			UpdateGameState(Values[4], pokemon, Stat.SpDefense);
			UpdateGameState(Values[5], pokemon, Stat.Speed);
		}

		private void UpdateGameState(StatViewModel ui, Pkmn pokemon, Stat stat)
		{
			ui.UpdateGameState(pokemon.Stats[stat], pokemon.IVs[stat], pokemon.EVs[stat]);
		}
	}
}
