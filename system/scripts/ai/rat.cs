//--- Aura Script -----------------------------------------------------------
// Rat AI
//--- Description -----------------------------------------------------------
// AI for rats.
//---------------------------------------------------------------------------

[AiScript("rat")]
public class RatAi : AiScript
{
	public RatAi()
	{
		SetVisualField(600, 90);
		SetAggroRadius(400);

		Hates("/pc/", "/pet/");

		On(AiState.Aggro, AiEvent.DefenseHit, OnDefenseHit);
		On(AiState.Aggro, AiEvent.KnockDown, OnKnockDown);
	}

	protected override IEnumerable Idle()
	{
		Do(Wander());
		Do(Wait(2000, 5000));
	}

	protected override IEnumerable Aggro()
	{
		Do(Attack(3));
		Do(Wait(3000));
	}

	private IEnumerable OnDefenseHit()
	{
		Do(Attack(3));
		Do(Wait(3000));
	}

	private IEnumerable OnKnockDown()
	{
		SwitchRandom();
		if (Case(30))
		{
			Do(PrepareSkill(SkillId.Defense));
			Do(Wait(4000, 8000));
			Do(CancelSkill());
		}
		else if (Case(40))
		{
			Do(Wait(7000, 8000));
		}
		else if (Case(30))
		{
			Do(Attack(1, 4000));
		}
	}
}
