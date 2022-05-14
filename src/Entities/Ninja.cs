using CharacterEntity;

namespace ClassesEntity
{
    public class Ninja : Character
    {
        public Ninja(string Name)
        {
            this.Name = Name;
            this.TypeCharacter = "Ninja";
            BuildStatus();
        }
        public override String Attack(int n)
        {
            if(n>0)
            {
                this.Energy-=2;
                Damage=this.Strength+this.Magic;
                return $@"
                {this.Name} Lançou uma shuriken explosiva e causou {this.Damage} de dano!!!
                ";
            }
            else
            {
                Damage=this.Strength;
                return $@"
                {this.Name} Lançou shuriken e causou {this.Damage} de dano!!!
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
            this.Energy = 4;            
            this.Health = (this.Level*14)+26;
            this.Magic = this.Level*3;
            this.Strength = this.Level*3;
        }
    }
}