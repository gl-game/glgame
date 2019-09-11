if (GetPlayer().Health  == 0) {
	GoTo("defaultevents/dead");
	return;
}
if (GetPlayer().Health < 0) {
	GetPlayer().Health = 0;
}
if (GetPlayer().Strength < 1) {
	GetPlayer().Strength = 1;
}
if (GetPlayer().Vitality < 1) {
	GetPlayer().Vitality = 1;
}
if (GetPlayer().Intellect > 100) {
	GetPlayer().Intellect = 100;
}

if (GetPlayer().Energy > GetPlayer().maxEnergy * 1.4) {
	GetPlayer().Energy = Convert.ToInt32(GetPlayer().maxEnergy * 1.4);
}
if (GetPlayer().Drink > GetPlayer().maxDrink * 1.4) {
	GetPlayer().Drink = Convert.ToInt32(GetPlayer().maxDrink * 1.4);
}
if (GetPlayer().Excite > 100) {
	GetPlayer().Excite = 100;
}

