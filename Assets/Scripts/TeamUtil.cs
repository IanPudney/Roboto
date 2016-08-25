using UnityEngine;
using System.Collections;

public class TeamUtil {
	public enum Team {
		Red,
		Blue,
	}

	public static Color GetColorByTeam(Team team) {
		switch(team) {
			case Team.Red:
				return Color.red;
			case Team.Blue:
				return Color.blue;
		}
		return Color.white;
	}

}
