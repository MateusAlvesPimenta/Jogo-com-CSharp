using CharacterEntity;

namespace ClassesEntity
{
    public class BlackWizard : Character
    {
        private int Multiplier=5;
        public BlackWizard(string name)
        {
            this.Name = name;
            this.TypeCharacter = "Black Wizzard";
            this.Energy = 2;
            BuildStats();
        }
        public override String Attack(int n)
        {
            if(n>0)
            {
                this.Energy-=2;
                this.Multiplier+=5;
                BuildStats();
                return $@"
                {this.Name} Elevou seu poder magico!!!
                ";
            }
            else
            {
                Damage=this.Magic;
                return $@"
                {this.Name} Lançou magia obscura e causou {this.Damage} de dano!!!
                ";
            }
        }
        public override void LevelUp()
        {
            this.Level++;
            this.Multiplier=5;
            this.Energy = 2;            
            BuildStats();
        }
        public void BuildStats()
        {
            this.Health = (this.Level*12)+20;
            this.Magic = this.Level*Multiplier;
            this.Strength = 0;
        }
    }
}