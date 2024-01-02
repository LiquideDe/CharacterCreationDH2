using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prophecy
{
    private List<string> prophecies = new List<string>();

    public Prophecy()
    {
        prophecies.Add("Мутация снаружи, порча внутри.");
        prophecies.Add("Верь своему страху.");
        prophecies.Add("Для выживания Человечества люди должны умирать.");
        prophecies.Add("В сравнении с проклятьем боль есть экстаз.");
        prophecies.Add("Будь благом друзей и бичом врагов.");
        prophecies.Add("Мудрые учатся на чужих смертях.");
        prophecies.Add("Убей чужака прежде чем он солжёт.");
        prophecies.Add("Истина субъективна.");
        prophecies.Add("Раздумья порождают ересь.");
        prophecies.Add("Ересь порождает возмездие.");
        prophecies.Add("Разум без цели блуждает во тьме.");
        prophecies.Add("Если работа важна за неё можно умереть.");
        prophecies.Add("Тёмные мечты лежат на сердце.");
        prophecies.Add("Насилию подвластно всё.");
        prophecies.Add("Невежество суть лучшая мудрость.");
        prophecies.Add("Лишь безумцы достаточно сильны для процветания.");
        prophecies.Add("Подозрительный разум — здоровый разум.");
        prophecies.Add("Страдание — безжалостный учитель.");
        prophecies.Add("Есть лишь один истинный страх — умереть не исполнив долг.");
        prophecies.Add("Лишь со смертью завершается долг.");
        prophecies.Add("Невинность есть иллюзия.");
        prophecies.Add("Человек рождён для войны.");
        prophecies.Add("Нет замены рвению.");
        prophecies.Add("Даже не имеющий ничего может отдать свою жизнь.");
        prophecies.Add("Не спрашивай почему ты служишь. Спрашивай, как.");
    }

    private int GenerateValue(int max)
    {
        //return UnityEngine.Random.Range(1, max);
        System.Random random = new System.Random();
        return random.Next(3, max);
    }

    private string PoleChudes(List<string> baraban, int naBarabane = 0)
    {
        int variants = 100 / baraban.Count;
        if (naBarabane == 0)
        {
            naBarabane = GenerateValue(100);
        }

        int id = (int)(naBarabane / variants);
        if (id >= baraban.Count)
        {
            id = baraban.Count - 1;
        }
        return baraban[id];
    }

    public string GenerateProphecy(Character character, int kubik = 0)
    {
        string choice = PoleChudes(prophecies, kubik);
        switch (choice)
        {
            case "Мутация снаружи, порча внутри.":

                break;

            case "Верь своему страху.":
                character.Characteristics[6].Amount += 5;
                character.MentalDisorders.Add("Фобия");
                break;

            case "Для выживания Человечества люди должны умирать.":
                var tal = new Talent("Искушённый");
                if (tal.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal);
                }
                else
                {
                    character.Characteristics[7].Amount += 2;
                }
                break;

            case "В сравнении с проклятьем боль есть экстаз.":
                character.Characteristics[4].Amount -= 3;
                break;

            case "Будь благом друзей и бичом врагов.":
                character.Characteristics[2].Amount += 2;
                break;

            case "Мудрые учатся на чужих смертях.":
                character.Characteristics[4].Amount += 3;
                character.Characteristics[0].Amount -= 3;
                break;

            case "Убей чужака прежде чем он солжёт.":
                var tal1 = new Talent("Выхватить Оружие");
                if (tal1.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal1);
                }
                else
                {
                    character.Characteristics[4].Amount += 2;
                }
                break;

            case "Истина субъективна.":
                character.Characteristics[6].Amount += 3;
                
                break;

            case "Раздумья порождают ересь.":
                character.Characteristics[5].Amount -= 3;
                break;

            case "Ересь порождает возмездие.":
                character.Characteristics[8].Amount += 3;
                character.Characteristics[3].Amount -= 3;
                break;

            case "Разум без цели блуждает во тьме.":

                break;

            case "Если работа важна за неё можно умереть.":
                character.Characteristics[3].Amount += 3;
                character.Characteristics[8].Amount -= 3;

                break;

            case "Тёмные мечты лежат на сердце.":

                break;

            case "Насилию подвластно всё.":
                character.Characteristics[0].Amount += 3;
                character.Characteristics[4].Amount -= 3;           
                break;

            case "Невежество суть лучшая мудрость.":
                character.Characteristics[6].Amount -= 3;
                break;

            case "Лишь безумцы достаточно сильны для процветания.":
                character.Characteristics[7].Amount += 3;
                break;

            case "Подозрительный разум — здоровый разум.":
                character.Characteristics[6].Amount += 2;
                break;

            case "Страдание — безжалостный учитель.":
                character.Characteristics[3].Amount -= 3;
                break;

            case "Есть лишь один истинный страх — умереть не исполнив долг.":
                var tal2 = new Talent("Сопротивление Холод");
                if (tal2.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal2);
                }
                else
                {
                    character.Characteristics[3].Amount += 2;
                }
                break;

            case "Лишь со смертью завершается долг.":

                break;

            case "Невинность есть иллюзия.":
                var tal3 = new Talent("Чуткая Интуиция");
                if (tal3.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal3);
                }
                else
                {
                    character.Characteristics[5].Amount += 2;
                }
                break;

            case "Человек рождён для войны.":
                if(character.Skills[7].LvlLearned < 1)
                {
                    character.Skills[7].SetNewLvl();
                }
                else
                {
                    character.Characteristics[4].Amount += 2;
                }
                break;

            case "Нет замены рвению.":
                var tal4 = new Talent("Разговор с Толпой");
                if (tal4.CheckTalentRepeat(character.Talents))
                {
                    character.AddTalent(tal4);
                }
                else
                {
                    character.Characteristics[8].Amount += 2;
                }
                break;

            case "Даже не имеющий ничего может отдать свою жизнь.":

                break;

            case "Не спрашивай почему ты служишь. Спрашивай, как.":
                character.FatePoint += 1;
                break;
        }
        return choice;
    }
}
