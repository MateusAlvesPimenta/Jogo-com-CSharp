using static System.Console;
using CharacterEntity;
using KnightEntity;
using NinjaEntity;
using WizardEntity;
using BlackWizardEntity;
namespace CreateCharacterEntity
{
    public class CreateCharacter
    {
        public static Character Player;
        public string Name = "";
        public string TypeCharacter="";
        public CreateCharacter()
        {            
            WriteLine(@"
            Como se chamará seu herói?
            ");
            Name = ReadLine()+Name;

            WriteLine(@"
            Escolha uma classe para seu herói:

            Knight - Um grande herói, temido pela sua habilidade com espadas.
            Ninja - Rapido, discreto e letal, ele possui um pouco de cada classe.
            Wizard - Com seu grande conhecimento em magia este mago pode se encarregar de qualquer inimigo.
            Black Wizard - Um mago que passou para o lado obscuro da magia e se tornou o mais forte de todos os magos.
            ");
            TypeCharacter = (ReadLine()+TypeCharacter).ToUpper();

            if(TypeCharacter == "KNIGHT"){
                Player = new Knight(Name);
            }
            else if(TypeCharacter=="NINJA"){
                Player = new Ninja(Name);
            }
            else if(TypeCharacter=="WIZARD"){
                Player = new Wizard(Name);
            }
            else if(TypeCharacter=="BLACK WIZARD" || TypeCharacter=="BLACKWIZARD"){
                Player = new BlackWizard(Name);
            }
            else{
                throw new ArgumentException($"Escolha invalida de personagem!!");
            }
            WriteLine($@"
                Este é o seu herói {Player}
                ");
        }
    }
}