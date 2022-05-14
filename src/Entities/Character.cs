using static System.Console;
using static StartGameEntity.StartGame;

using ClassesEntity;

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
        public Character(){}
        public Character(string name, string typeCharacter)
        {
            if(typeCharacter == "KNIGHT"){
                Player = new Knight(name);
            }
            else if(typeCharacter=="NINJA"){
                Player = new Ninja(name);
            }
            else if(typeCharacter=="WIZARD"){
                Player = new Wizard(name);
            }
            else if(typeCharacter=="BLACK WIZARD" || typeCharacter=="BLACKWIZARD"){
                Player = new BlackWizard(name);
            }
            else{
                throw new ArgumentException($"Escolha invalida de personagem!!");
            }
            WriteLine($@"
                Este é o seu herói {Player}
                ");
        }
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