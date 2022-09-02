internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(" ФИНАЛЬНАЯ БИТВА ");
        
        string userInput;
        int heroHealth = 250, heroHealthMax = 250, bossHealth = 1200;        
        int numberOfFireAttack = 0, healAttempt = 0, attemptOfGolemAttack = 0, invisibleAttempt = 0;
        int maxNumberOfFireAttack = 3, maxHealAttempt = 3, maxAttemptOfGolemAttack = 3, numberOfGolemAttack = 3, maxInvisibleAttempt = 3;
        int countFire = 3, countHeal = 3, countGolem = 3, countInvisible = 3;
        Random randomDamage = new Random();
        
        Console.WriteLine("\nДобро пожаловать маг на финальную битву c БОССом.");
        Console.WriteLine($"\nВаша жизнь равна {heroHealth}, БОССа {bossHealth}." +
            $"\n\nДоступные заклинания:" +
            $"\n\nАДСКИЙ ОГОНЬ - Яркий адский огонь, превращает врагов в пепел. Наносит тройной урон. Используется {maxNumberOfFireAttack} раз. - 1" +
            $"\nЗАМЕЩЕНИЕ - Восстанавливается часть ХР мага за часть здоровья БОССа. Урона от БОССа нет.                - 2" +
            $"\nГОЛЕМ - Призывает Голема. Голем наносит три раза небольшой урон, но при этом теряется часть ХР героя.   - 3" +
            $"\nНЕВИДИМОСТЬ - Урон от БОССа не проходит, восполняет герою ХР. Активирует Адский огонь.                  - 4" +
            $"\n\nВАЖНО!!! Все заклинания можно использовать только {maxHealAttempt} раза. Если НЕВИДИМОСТЬ израсходована, АДСКИЙ ОГОНЬ не доступен.");
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
                        numberOfFireAttack++;
                        countFire--;

                        if (invisibleAttempt == 0)
                        {
                            Console.WriteLine("Нужна активация заклинания.");
                            heroHealth -= bossDamage;
                            heroDamage = 0;                            
                        }
                        else
                        {
                            if (invisibleAttempt == maxInvisibleAttempt || invisibleAttempt > maxNumberOfFireAttack || numberOfFireAttack == maxNumberOfFireAttack)
                            {
                                Console.WriteLine("Заклинание больше не активно.");
                                heroHealth -= bossDamage;
                                heroDamage = 0;
                            }
                            else
                            {                                
                                heroDamage *= maxNumberOfFireAttack;
                                bossDamage += bossAddDamage;
                                bossHealth -= heroDamage;
                                heroHealth -= bossDamage;
                            }                            
                        }
                        break;
                    }
                case "2":
                    {
                        healAttempt++;
                        countHeal--;

                        if (healAttempt < maxHealAttempt && heroHealth < heroHealthMax)
                        {                            
                            bossHealth -= lostHealth;
                            heroHealth += lostHealth;

                            if (heroHealth >= heroHealthMax)
                            {
                                heroHealth = heroHealthMax;
                                Console.WriteLine("Вы полностью вылечены");
                                bossDamage = 0;
                                heroDamage = 0;
                            }
                            else
                            {
                                Console.WriteLine($"Вы восполнили {lostHealth} здоровья");
                                bossDamage = 0;
                                heroDamage = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Заклинание невозможно использовать.");
                            heroHealth -= bossDamage;
                            heroDamage = 0;
                        }
                        break;
                    }
                case "3":
                    {
                        attemptOfGolemAttack++;
                        countGolem--;

                        if (attemptOfGolemAttack < maxAttemptOfGolemAttack)
                        {
                            heroDamage = golemDamage * numberOfGolemAttack;
                            bossHealth -= heroDamage;
                            heroHealth -= bossDamage;
                        }
                        else
                        {
                            Console.WriteLine("Заклинание невозможно использовать.");
                            heroHealth -= bossDamage;
                            heroDamage = 0;
                        }
                        break;
                    }
                case "4":
                    {
                        countInvisible--;
                        invisibleAttempt++;
                        bossDamage = 0;
                        heroDamage = 0;
                        heroHealth += addHealth;                        

                        if(invisibleAttempt <= maxInvisibleAttempt)
                        {
                            if (heroHealth > heroHealthMax)
                            {
                                heroHealth = heroHealthMax;
                                Console.WriteLine("Вы полностью вылечены");
                            }

                            if (heroHealth == heroHealthMax)
                            {
                                Console.WriteLine("Активирован АДСКИЙ ОГОНЬ.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Заклинание больше не активно.");
                            heroHealth = heroHealthMax;
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Вам не сбежать");
                        heroHealth -= bossDamage;
                        heroDamage = 0;
                        break;
                    }
            }
            Console.WriteLine($"Вы нанесли {heroDamage} урона.");
            Console.WriteLine($"BOSS нанёс {bossDamage} урона.");
            Console.WriteLine($"\nУ героя осталось {heroHealth} здоровья, у БОССа осталось {bossHealth} здоровья.");
            Console.WriteLine($"\nОсталось заклинаний:" +
                $"\nАДСКИЙ ОГОНЬ - {countFire}" +
                $"\nЗАМЕЩЕНИЕ - {countHeal}" +
                $"\nГОЛЕМ - {countGolem}" +
                $"\nНЕВИДИМОСТЬ - {countInvisible}");

            if (heroHealth <= 0)
            {
                Console.WriteLine("Сожалеем! Герой пал.");
            }

            if (bossHealth <= 0)
            {
                Console.WriteLine("Поздравляем! БОСС пал.");
            }

            if(heroHealth <= 0 && bossHealth <= 0)
            {
                Console.WriteLine("Ничья. Только кому от этого легче...");
            }
        }
    }
}