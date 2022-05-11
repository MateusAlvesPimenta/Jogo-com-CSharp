using static System.Console;
using EnemyEntity;
using CreateCharacterEntity;
namespace StartGameEntity
{
    public class StartGame : CreateCharacter
    {   
        public static void Attack(){}
        public static int PlayerHealth;
        public static int MonsterHealth;
        public static int Phase=1;
        public static string Entry="";
        public static Enemy Monster = new Enemy(Phase);
        public StartGame()
        {
            WriteLine(@"
            Deseja iniciar uma luta?
            Sim ou Não?
            ");
            Entry = (ReadLine()+Entry).ToUpper();
            if(Entry[0]=='S'){
            Fight();
            }
            else if(Entry[0]=='N'){
                WriteLine("Volte quando estiver pronto");
            }
            else{
                throw new ArgumentException("Opção invalida");
            }
        }
        public static void Fight()
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
                Entry = (ReadLine()+Entry).ToUpper();

                if(Entry[0]=='E'){
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
                else if(Entry[0]=='A')
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
                else if(Entry[0]=='D')
                {   
                    Player.Energy++;
                    Monster.Attack(0);
                    WriteLine($@"
                    {Monster.Name} atacou mas não causou danos");
                }
            }
            FightResult();
        }
        public static void FightResult()
        {
            if(MonsterHealth<=0)
            {                

                WriteLine($@"
                Parabens {Player.Name}, voce derrotou o {Monster.Name} e passou agr para o level {Player.Level}

                Deseja iniciar a proxima luta?
                Sim ou Não?
                ");
                Entry = (ReadLine()+Entry).ToUpper();
                if(Entry[0]=='S'){
                    Phase++;
                    Player.LevelUp();
                    Monster.LevelUp();
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