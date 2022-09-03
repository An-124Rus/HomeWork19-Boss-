internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(" ФИНАЛЬНАЯ БИТВА ");

        string userInput;
        int heroHealth = 250;
        int heroHealthMax = 250;
        int bossHealth = 1100;
        string fire = "ОГОНЬ";
        string heal = "ЗАМЕЩЕНИЕ";
        string golem = "ГОЛЕМ";
        string invisible = "НЕВИДИМОСТЬ";
        const string MagicOne = "1";
        const string MagicTwo = "2";
        const string MagicThree = "3";
        const string MagicFour = "4";
        int attemptOfFireAttack = 3;
        int numberOfFireAttack = 3;
        int minAttemptOfFireAttack = 0;
        int attemptOfHeal = 3;
        int minAttemptOfHeal = 0;
        int attemptOfGolemAttack = 3;
        int minAttemptOfGolemAttack = 0;
        int numberOfGolemAttack = 3;
        int attemptOfInvisible = 3;
        int minAttemptOfInvisible = 0;

        Random random = new Random();

        Console.WriteLine("\nМаг! Добро пожаловать на финальную битву c БОССом.");
        Console.WriteLine($"\nВаша жизнь равна {heroHealth}, БОССа {bossHealth}." +
            $"\n\nДоступные заклинания:" +
            $"\n\n{fire} - Яркий адский огонь, превращает врагов в пепел. Наносит подряд {numberOfFireAttack} удара.                          - нажми {MagicOne}" +
            $"\n{heal} - Восстанавливается часть ХР мага за часть здоровья БОССа. Урона от БОССа нет.                - нажми {MagicTwo}" +
            $"\n{golem} - Призывает Голема. {golem} наносит {numberOfGolemAttack} раза небольшой урон, но при этом теряется часть ХР героя.     - нажми {MagicThree}" +
            $"\n{invisible} - Урон от БОССа не проходит, восполняет герою ХР. Активирует заклинание {fire}.              - нажми {MagicFour}" +
            $"\n\nВАЖНО!!! Все заклинания можно использовать только {attemptOfHeal} раза. Если {invisible} израсходована, {fire} не доступен.");
        Console.WriteLine("\n!!!Да начнётся битва!!!");

        while (heroHealth > 0 && bossHealth > 0)
        {
            int heroDamage = random.Next(40, 60);
            int bossDamage = random.Next(60, 80);
            int bossAddDamage = random.Next(35, 50);
            int lostHealth = random.Next(70, 100);
            int golemDamage = random.Next(45, 50);
            int addHealth = random.Next(80, 120);

            Console.WriteLine("\nВаш ход: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case MagicOne:
                        if (attemptOfInvisible == attemptOfFireAttack)
                        {
                            Console.WriteLine("Нужна активация заклинания.");
                            heroHealth -= bossAddDamage;
                        }
                        else
                        {
                            if (attemptOfFireAttack == minAttemptOfFireAttack)
                            {
                                Console.WriteLine("Заклинание невозможно использовать.");
                                heroHealth -= bossAddDamage;
                                attemptOfFireAttack = 0;
                            }
                            else
                            {
                                attemptOfFireAttack--;
                                heroDamage *= numberOfFireAttack;
                                bossHealth -= heroDamage;
                                bossDamage += bossAddDamage;
                                heroHealth -= bossDamage;
                            }
                        }
                        break;

                case MagicTwo:
                    attemptOfHeal--;

                    if (attemptOfHeal >= minAttemptOfHeal)
                    {
                        if (heroHealth >= heroHealthMax)
                        {
                            heroHealth = heroHealthMax;
                            Console.WriteLine($"Вы полностью вылечены, но по вам проходит {bossAddDamage} урона.");
                            heroHealth -= bossAddDamage;
                        }
                        else
                        {
                            bossHealth -= lostHealth;
                            heroHealth = heroHealthMax;
                            Console.WriteLine($"Вы восполнили {lostHealth} здоровья");
                            heroHealth -= bossAddDamage;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Заклинание невозможно использовать.");
                        heroHealth -= bossAddDamage;
                        attemptOfHeal = 0;
                    }
                    break;

                case MagicThree:
                    attemptOfGolemAttack--;

                    if (attemptOfGolemAttack >= minAttemptOfGolemAttack)
                    {
                        heroDamage = golemDamage * numberOfGolemAttack;
                        bossHealth -= heroDamage;
                        heroHealth -= bossDamage;
                    }
                    else
                    {
                        Console.WriteLine("Заклинание невозможно использовать.");
                        heroHealth -= bossDamage;
                        attemptOfGolemAttack = 0;
                    }
                    break;

                case MagicFour:
                    attemptOfInvisible--;

                    if (attemptOfInvisible >= minAttemptOfInvisible)
                    {
                        heroHealth += addHealth;
                        Console.WriteLine($"Активировано заклинание {fire}.");

                        if (heroHealth > heroHealthMax)
                        {
                            heroHealth = heroHealthMax;
                            Console.WriteLine("Ваше здоровье максимально.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Заклинание невозможно использовать.");
                        heroHealth -= bossAddDamage;
                        attemptOfInvisible = 0;
                    }
                    break;

                default:
                    Console.WriteLine("Тебе не сбежать.");
                    heroHealth = 0;
                    break;
            }
            Console.WriteLine($"\nУ героя осталось {heroHealth} здоровья, у БОССа осталось {bossHealth} здоровья.");
            Console.WriteLine($"\nНажми: | Осталось заклинаний: |" +
                $"\n  {MagicOne}    | {fire}            - {attemptOfFireAttack} |" +
                $"\n  {MagicTwo}    | {heal}        - {attemptOfHeal} |" +
                $"\n  {MagicThree}    | {golem}            - {attemptOfGolemAttack} |" +
                $"\n  {MagicFour}    | {invisible}      - {attemptOfInvisible} |");            
        }
        if (heroHealth <= 0 && bossHealth <= 0)
            Console.WriteLine("\nНичья. Только кому от этого легче...");

        if (heroHealth <= 0)
            Console.WriteLine("\nСожалеем! Герой пал.");
        else        
            Console.WriteLine("\nПоздравляем! БОСС пал.");
    }
}