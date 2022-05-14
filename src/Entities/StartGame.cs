using static System.Console;
using EnemyEntity;
using CharacterEntity;
namespace StartGameEntity
{
    public class StartGame
    {   
        public static Character Player;
        public static string Name;
        public static string TypeCharacter;
        public static int PlayerHealth;
        public static int MonsterHealth;
        public static int Phase=1;
        public static string Entry="";
        public static Enemy Monster = new Enemy(Phase);
        public StartGame()
        {
            CharacterBuilder();
            Fight();
        }
        public void CharacterBuilder()
        {
            WriteLine(@"
            Como se chamará seu herói?
            ");
            Name = ReadLine();

            WriteLine(@"
            Escolha uma classe para seu herói:

            Knight - Um grande herói, temido pela sua habilidade com espadas.
            Ninja - Rapido, discreto e letal, ele possui um pouco de cada classe.
            Wizard - Com seu grande conhecimento em magia este mago pode se encarregar de qualquer inimigo.
            Black Wizard - Um mago que passou para o lado obscuro da magia e se tornou o mais forte de todos os magos.
            ");
            TypeCharacter = ReadLine().ToUpper();
            
            new Character(Name,TypeCharacter);
        }
        public void Fight()
        {
            PlayerHealth = Player.Health;
            MonsterHealth = Monster.Health;
            WriteLine($@"
            O Monstro {Monster.Name} surge em sua frente");
                
            while(PlayerHealth>0 && MonsterHealth>0)
            {
                Thread.Sleep(3000);
                WriteLine($@"
                Fase {Phase}
                ");
                WriteLine($@"
                {Monster.Name}      Level: {Monster.Level}      Força: {Monster.Strength}       Magia: {Monster.Magic}
                                Vida: {MonsterHealth}/{Monster.Health}");
                
                WriteLine($@"
                {Player.Name}       Level: {Player.Level}      Força: {Player.Strength}       Magia: {Player.Magic}
                                   Vida:{PlayerHealth}/{Player.Health}                      Energia:{Player.Energy}");
                WriteLine($@"
                Atacar
                Especial
                Defender");
                Entry = ReadLine().ToUpper();

                if(Entry[0]=='E'){
                    EspecialAttack();
                }
                else if(Entry[0]=='A')
                {
                    CommonAttack();
                }
                else if(Entry[0]=='D')
                {   
                    BlockAttack();
                }
            }
            FightResult();
        }
        public void EspecialAttack()
        {
            if(Player.Energy >= 2)
                    {
                        WriteLine(Player.Attack(1));
                        MonsterHealth-=Player.Damage;
                        Thread.Sleep(2000);

                        if(MonsterHealth>0)
                        {
                            WriteLine(Monster.Attack(0));
                        PlayerHealth-=Monster.Damage;
                        }
                        else
                        {
                            Write($@"
                        {Monster.Name} morreu
                        ");
                        }
                    }
                    else
                    {
                        WriteLine(@"
                        Você não possui energia suficiente");
                        Thread.Sleep(2000);
                        
                        WriteLine(Monster.Attack(0));
                        PlayerHealth-=Monster.Damage;
                    }
        }
        public void CommonAttack()
        {
            WriteLine(Player.Attack(0));
                    MonsterHealth-=Player.Damage;
                    Thread.Sleep(2000);
                    
                    if(MonsterHealth>0)
                    {
                        WriteLine(Monster.Attack(0));
                        PlayerHealth-=Monster.Damage;
                    }
                    else
                    {
                        Write($@"
                        {Monster.Name} morreu");
                    }
        }
        public void BlockAttack()
        {
            Player.Energy++;
            Monster.Attack(0);
            WriteLine($@"
            {Monster.Name} atacou mas não causou danos");
        }
        public void FightResult()
        {
            if(MonsterHealth<=0)
            {                
                Player.LevelUp();
                Monster.LevelUp();

                WriteLine($@"
                Parabens {Player.Name}, voce derrotou o {Monster.Name} e passou agr para o level {Player.Level}

                Deseja iniciar a proxima luta?
                Sim ou Não?
                ");
                Entry = ReadLine().ToUpper();
                if(Entry[0]=='S'){
                    Phase++;
                    Fight();
                }
            }
            else
            {
                WriteLine($@"
                Você foi derrotado por {Monster.Name}

                Deseja reiniciar esta luta?
                Sim ou Não?
                ");
                Entry = (ReadLine()+Entry).ToUpper();
                if(Entry[0]=='S')
                {
                    Fight();
                }
                else if(Entry[0]=='N')
                {
                    WriteLine(@"
                    GAME OVER
                    ");
                }
            }
        }
    }
}