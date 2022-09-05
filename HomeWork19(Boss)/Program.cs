internal class Program
{
    private static void Main(string[] args)
    {
        const string ActivationOfMagicOne = "1";
        const string ActivationOfMagicTwo = "2";
        const string ActivationOfMagicThree = "3";
        const string ActivationOfMagicFour = "4";

        Console.WriteLine(" ФИНАЛЬНАЯ БИТВА ");

        string userInput;
        int heroHealth = 250;
        int heroHealthMax = 250;
        int bossHealth = 1100;
        int minValueOfHeroDamage = 40;
        int maxValueOfHeroDamage = 60;
        int minValueOfBossDamage = 60;
        int maxValueOfBossDamage = 80;
        int minValueOfBossAddDamage = 35;
        int maxValueOfBossAddDamage = 50;
        int minValueOfLostHealth = 70;
        int maxValueOfLostHealth = 100;
        int minValueOfGolemDamage = 45;
        int maxValueOfGolemDamage = 50;
        int minValueOfAddHealth = 80;
        int maxValueOfAddHealth = 120;
        string fire = "ОГОНЬ";
        string heal = "ЗАМЕЩЕНИЕ";
        string golem = "ГОЛЕМ";
        string invisible = "НЕВИДИМОСТЬ";        
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
            $"\n\n{fire} - Яркий адский огонь, превращает врагов в пепел. Наносит подряд {numberOfFireAttack} удара.                          - нажми {ActivationOfMagicOne}" +
            $"\n{heal} - Восстанавливается часть ХР мага за часть здоровья БОССа. Урона от БОССа нет.                - нажми {ActivationOfMagicTwo}" +
            $"\n{golem} - Призывает Голема. {golem} наносит {numberOfGolemAttack} раза небольшой урон, но при этом теряется часть ХР героя.     - нажми {ActivationOfMagicThree}" +
            $"\n{invisible} - Урон от БОССа не проходит, восполняет герою ХР. Активирует заклинание {fire}.              - нажми {ActivationOfMagicFour}" +
            $"\n\nВАЖНО!!! Все заклинания можно использовать только {attemptOfHeal} раза. Если {invisible} израсходована, {fire} не доступен.");
        Console.WriteLine("\n!!!Да начнётся битва!!!");

        while (heroHealth > 0 && bossHealth > 0)
        {
            int heroDamage = random.Next(minValueOfHeroDamage, maxValueOfHeroDamage);
            int bossDamage = random.Next(minValueOfBossDamage, maxValueOfBossDamage);
            int bossAddDamage = random.Next(minValueOfBossAddDamage, maxValueOfBossAddDamage);
            int lostHealth = random.Next(minValueOfLostHealth, maxValueOfLostHealth);
            int golemDamage = random.Next(minValueOfGolemDamage, maxValueOfGolemDamage);
            int addHealth = random.Next(minValueOfAddHealth, maxValueOfAddHealth);

            Console.WriteLine("\nВаш ход: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case ActivationOfMagicOne:
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

                case ActivationOfMagicTwo:
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

                case ActivationOfMagicThree:
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

                case ActivationOfMagicFour:
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
                $"\n  {ActivationOfMagicOne}    | {fire}            - {attemptOfFireAttack} |" +
                $"\n  {ActivationOfMagicTwo}    | {heal}        - {attemptOfHeal} |" +
                $"\n  {ActivationOfMagicThree}    | {golem}            - {attemptOfGolemAttack} |" +
                $"\n  {ActivationOfMagicFour}    | {invisible}      - {attemptOfInvisible} |");            
        }
        if (heroHealth <= 0 && bossHealth <= 0)
            Console.WriteLine("\nНичья. Только кому от этого легче...");

        if (heroHealth <= 0)
            Console.WriteLine("\nСожалеем! Герой пал.");
        else        
            Console.WriteLine("\nПоздравляем! БОСС пал.");
    }
}