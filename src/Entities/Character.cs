namespace CharacterEntity
{
    public class Character
    {  
        public string Name = "";
        public int Level = 1;
        public string TypeCharacter = "";
        public int Health;
        public int Magic;
        public int Strength;
        public int Damage;
        public int Energy;
        public virtual String Attack(int n){
            return "";
        }
        public virtual void LevelUp(){
        }

        public override String ToString()
        {
            return $@"
            Nome: {this.Name}
            Level: {this.Level}
            Classe: {this.TypeCharacter}
            Vida: {this.Health}
            Força: {this.Strength}
            Magia: {this.Magic}
            ";
        }
    }
}