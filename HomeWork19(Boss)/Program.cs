internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(" ФИНАЛЬНАЯ БИТВА ");

        string userInput;
        int heroHealth = 250;
        int heroHealthMax = 250;
        int bossHealth = 1100;
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
        Random randomDamage = new Random();

        Console.WriteLine("\nМаг! Добро пожаловать на финальную битву c БОССом.");
        Console.WriteLine($"\nВаша жизнь равна {heroHealth}, БОССа {bossHealth}." +
            $"\n\nДоступные заклинания:" +
            $"\n\nОГОНЬ - Яркий адский огонь, превращает врагов в пепел. Наносит тройной урон.                            - нажми 1" +
            $"\nЗАМЕЩЕНИЕ - Восстанавливается часть ХР мага за часть здоровья БОССа. Урона от БОССа нет.                - нажми 2" +
            $"\nГОЛЕМ - Призывает Голема. Голем наносит три раза небольшой урон, но при этом теряется часть ХР героя.   - нажми 3" +
            $"\nНЕВИДИМОСТЬ - Урон от БОССа не проходит, восполняет герою ХР. Активирует Адский огонь.                  - нажми 4" +
            $"\n\nВАЖНО!!! Все заклинания можно использовать только {attemptOfHeal} раза. Если НЕВИДИМОСТЬ израсходована, АДСКИЙ ОГОНЬ не доступен.");
        Console.WriteLine("\n!!!Да начнётся битва!!!");            

        while (heroHealth > 0 && bossHealth > 0)
        {
            int heroDamage = randomDamage.Next(40, 60);
            int bossDamage = randomDamage.Next(60, 80);
            int bossAddDamage = randomDamage.Next(35, 50);
            int lostHealth = randomDamage.Next(70, 100);
            int golemDamage = randomDamage.Next(45, 60);
            int addHealth = randomDamage.Next(80, 120);

            Console.WriteLine("\nВаш ход: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    {
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
                    }

                case "2":
                    {
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
                    }

                case "3":
                    {
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
                    }

                case "4":
                    {
                        attemptOfInvisible--;

                        if (attemptOfInvisible >= minAttemptOfInvisible)
                        {
                            heroHealth += addHealth;
                            Console.WriteLine("Активировано заклинание ОГОНЬ.");

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
                    }

                default:
                    {
                        Console.WriteLine("Тебе не сбежать.");
                        heroHealth = 0;
                        break;
                    }
            }
            Console.Clear();
            Console.WriteLine($"\nУ героя осталось {heroHealth} здоровья, у БОССа осталось {bossHealth} здоровья.");
            Console.WriteLine($"\nНажми: | Осталось заклинаний: |" +
                $"\n  1    | ОГОНЬ            - {attemptOfFireAttack} |" +
                $"\n  2    | ЗАМЕЩЕНИЕ        - {attemptOfHeal} |" +
                $"\n  3    | ГОЛЕМ            - {attemptOfGolemAttack} |" +
                $"\n  4    | НЕВИДИМОСТЬ      - {attemptOfInvisible} |");

            if (heroHealth <= 0 && bossHealth <= 0)
                Console.WriteLine("\nНичья. Только кому от этого легче...");

            if (heroHealth <= 0)
                Console.WriteLine("\nСожалеем! Герой пал.");

            if (bossHealth <= 0)
                Console.WriteLine("\nПоздравляем! БОСС пал.");
        }
    }
}