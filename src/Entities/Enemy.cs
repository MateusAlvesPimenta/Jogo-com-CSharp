using CharacterEntity;
namespace EnemyEntity
{
    public class Enemy : Character
    {
        public Enemy(int phase)
        {
            this.Level = phase+1;
            BuildStats();
        }
        public override String Attack(int n)
        {
            if(this.Energy<3){
            Damage = this.Strength;
            this.Energy++;
            return $@"
            {this.Name} Atacou você com suas garras causando {Damage} de dano!!!";
            }
            else{
            Damage = this.Strength+this.Magic;
            this.Energy-=3;
            return $@"
            {this.Name} Carregou magia nas garras de atacou causando {Damage} de dano!!!";
            }
        }
        public override void LevelUp()
        {
            this.Level++;
            BuildStats();
        }
        public void BuildStats()
        {
            this.Name="LOBO SOMBRIO";
            this.Energy=1;
            this.Health = (this.Level*8)+20;
            this.Magic = this.Level*2;
            this.Strength = this.Level*2;

            if((this.Level-1)%10==0)
            {
                this.Name = "LOBO ALPHA";
                this.Health = (this.Level*16)+20;
                this.Magic = this.Level*6;
                this.Strength = this.Level*5;
            }
        }
    }
}