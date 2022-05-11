using CharacterEntity;

namespace KnightEntity{
    public class Knight : Character
    {
        public Knight(string Name)
        {
            this.Name = Name;
            this.TypeCharacter = "Knight";
            BuildStatus();
        }
        public override String Attack(int n)
        {
            if(n>0)
            {
                this.Energy-=2;
                Damage=this.Strength+this.Magic;
                return $@"
                {this.Name} Se enfureceu e atacou com toda sua força e causou {this.Damage} de dano!!!
                ";
            }
            else
            {
                Damage=this.Strength;
                return $@"
                {this.Name} atacou com sua espada e causou {this.Damage} de dano!!!";
            }
        }
        public override void LevelUp()
        {
            this.Level++;
            BuildStatus();
        }
        public void BuildStatus()
        {
            this.Energy = 2;
            this.Health = (this.Level*16)+20;
            this.Magic = this.Level;
            this.Strength = this.Level*4;
        }
    }
}