using CharacterEntity;
namespace WizardEntity
{
    public class Wizard : Character
    {
        public Wizard(string Name)
        {
            this.Name = Name;
            this.TypeCharacter = "Wizzard";
            BuildStatus();
        }
        public override String Attack(int n)
        {
            if(n>0)
            {
                this.Energy-=2;
                Damage=this.Strength*2+this.Magic;
                return $@"
                {this.Name} Lançou uma bola de fogo e causou {this.Damage} de dano!!!
                ";
            }
            else
            {
                Damage=this.Magic;
                return $@"
                {this.Name} Lançou magia e causou {this.Damage} de dano!!!
                ";
            }
        }
        public override void LevelUp()
        {
            this.Level++;
            BuildStatus();
        }
        public void BuildStatus()
        {
            this.Energy = 3;
            this.Health = (this.Level*12)+20;
            this.Magic = this.Level*4;
            this.Strength = this.Level*2;
        }
    }
}