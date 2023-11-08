using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorWorlds
{
    private List<Homeworld> homeworlds = new List<Homeworld>();

    public CreatorWorlds()
    {
        homeworlds.Add(new Homeworld(GameStat.WorldName.WildWorld, GameStat.CharacterName.Strength, GameStat.CharacterName.Toughness, GameStat.CharacterName.Influence, 2,
            "Старые Пути: В руках выходца с дикого мира любое Низкотехнологичное оружие теряет качество Примитивное (если имеет его) и получает качество Проверенное(3).", GameStat.Inclinations.Toughness, 9));

        homeworlds.Add(new Homeworld(GameStat.WorldName.ForgeWorld, GameStat.CharacterName.Intelligence, GameStat.CharacterName.Toughness, GameStat.CharacterName.Fellowship, 3,
            "Избранный Омниссии: Выходец с мира-кузницы начинает игру с талантом Искусный Стук или Длань Омниссии.", GameStat.Inclinations.Intelligence, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.HighBorn, GameStat.CharacterName.Fellowship, GameStat.CharacterName.Influence, GameStat.CharacterName.Toughness, 4,
            "Бессчётное Богатство: Каждый раз, когда Влияние персонажа уменьшается, оно уменьшается на 1 очко меньше чем должно было бы (до минимума в 1).", GameStat.Inclinations.Fellowship, 9));

        homeworlds.Add(new Homeworld(GameStat.WorldName.HiveWorld, GameStat.CharacterName.Agility, GameStat.CharacterName.Perception, GameStat.CharacterName.Willpower, 2,
            "Бесчисленные Толпы в Металлических Горах: Персонажи с мира-улья игнорируют толпы при движении, считая их за открытую местность. Кроме того, когда персонаж находится в закрытом помещении, он получает бонус +20 к проверкам Навигация (Наземная).", 
            GameStat.Inclinations.Perception, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.TempleWorld, GameStat.CharacterName.Fellowship, GameStat.CharacterName.Willpower, GameStat.CharacterName.Perception, 3,
            "Вера в Кредо: Всякий раз когда персонаж с мира-храма тратит очко Судьбы, игрок бросает 1к10. При выпадении 1 общее количество очков Судьбы персонажа не уменьшается.", GameStat.Inclinations.Willpower, 7));

        homeworlds.Add(new Homeworld(GameStat.WorldName.VoidBorn, GameStat.CharacterName.Intelligence, GameStat.CharacterName.Willpower, GameStat.CharacterName.Strength, 3,
            "Дитя Темноты: Пустоторождённый персонаж начинает игру с талантом Непреклонный и в условиях нулевой гравитации получает бонус +30 к проверкам перемещения.", GameStat.Inclinations.Intelligence, 7));
        homeworlds[^1].AddTalent("Непреклонный");

        homeworlds.Add(new Homeworld(GameStat.WorldName.AgroWorld, GameStat.CharacterName.Strength, GameStat.CharacterName.Agility, GameStat.CharacterName.Fellowship, 2,
            "Сила земли: Персонажи с агро-миров начинают с чертой Жестокий Натиск (2).", GameStat.Inclinations.Strength, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.FeodalWorld, GameStat.CharacterName.Perception, GameStat.CharacterName.WeaponSkill, GameStat.CharacterName.Intelligence, 3,
            "Моя броня — часть меня: Персонаж с феодального мира игнорирует ограничения на максимум Ловкости, налагаемые любой бронёй, которую он носит.", GameStat.Inclinations.Weapon, 9));

        homeworlds.Add(new Homeworld(GameStat.WorldName.FrontWorld, GameStat.CharacterName.Perception, GameStat.CharacterName.BallisticSkill, GameStat.CharacterName.Fellowship, 3,
            "Полагайся только на себя: Персонажи с пограничного мира получают бонус +20 к умению Техпользование когда модифицируют своё оружие и +10 когда чинят предметы.", GameStat.Inclinations.Ballistic, 7));

        homeworlds.Add(new Homeworld(GameStat.WorldName.DemonWorld, GameStat.CharacterName.Perception, GameStat.CharacterName.Willpower, GameStat.CharacterName.Fellowship, 3,
            "Касание варпа: Персонаж с демонического мира начинает с одним рангом в умении Психонаука. " +
            "Если он получит это умение снова на следующих шагах генерации персонажа, он взамен получает один дополнительный ранг этого умения. " +
            "Учтите, что он не может покупать больше рангов в этом умении, если только он не получит склонность Псайкер. Этот персонаж также начинает с 1к10+5 очков Порчи.", 
            GameStat.Inclinations.Willpower, 7));
        homeworlds[^1].AddSkill(GameStat.SkillName.Psyniscience.ToString());

        homeworlds.Add(new Homeworld(GameStat.WorldName.PrisonWorld, GameStat.CharacterName.Toughness, GameStat.CharacterName.Perception, GameStat.CharacterName.Influence, 3,
            "Рука на пульсе: На мире-тюрьме выживает тот, кто инстинктивно знает кто здесь всем заправляет и кто представляет угрозу. " +
            "Персонаж с мира-тюрьмы начинает с одним уровнем в умениях Общие знания (Преступность) и Проницательность, а также талантом Связи (Криминальные Картели).", GameStat.Inclinations.Toughness, 10));
        homeworlds[^1].AddSkill(GameStat.SkillName.Awareness.ToString());
        homeworlds[^1].AddSkill(GameStat.KnowledgeName.Criminal.ToString());
        homeworlds[^1].AddTalent("Связи (Криминальные Картели)");

        homeworlds.Add(new Homeworld(GameStat.WorldName.QuarantineWorld, GameStat.CharacterName.BallisticSkill, GameStat.CharacterName.Intelligence, GameStat.CharacterName.Strength, 3,
            "Скрытный по натуре: Те, кто умудряются покинуть карантинные мир, хорошо учатся хранить секреты. " +
            "Когда Секретность отряда должна уменьшиться, она изменяется на две единицы меньше (до минимального уменьшения в 1).", GameStat.Inclinations.Fieldcraft, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.GardenWorld, GameStat.CharacterName.Fellowship, GameStat.CharacterName.Agility, GameStat.CharacterName.Toughness, 2,
            "Безмятежность зелени: Персонажи с мира-сада вдвое (округляя в большую сторону) сокращают продолжительность любого результата " +
            "Шок Умственные Травмы, и могут удалять Очки Безумия за 50 очков опыта, а не обычные 100.", GameStat.Inclinations.Fellowship, 7));

        homeworlds.Add(new Homeworld(GameStat.WorldName.ScienseStation, GameStat.CharacterName.Intelligence, GameStat.CharacterName.Perception, GameStat.CharacterName.Fellowship, 3,
            "Охота за информацией: Всякий раз, когда персонаж с исследовательской станции достигает уровня 2 (обучен) в умении Ученые Знания, он также получает уровень 1 (знает) " +
            "в одной из связанных или идентичных специализаций умения Запретных Знаний по своему выбору.", GameStat.Inclinations.Knowledge, 8));

        homeworlds.Add(new Homeworld(GameStat.WorldName.FeodalWorld, GameStat.CharacterName.Perception, GameStat.CharacterName.WeaponSkill, GameStat.CharacterName.Intelligence, 3,
            "Моя броня — часть меня: Персонаж с феодального мира игнорирует ограничения на максимум Ловкости, налагаемые любой бронёй, которую он носит.", GameStat.Inclinations.Weapon, 9));
    }

    public Homeworld GetHomeworld(string worldName)
    {
        foreach(Homeworld homeworld in homeworlds)
        {
            if (homeworld.Name == worldName)
            {
                return homeworld;
            }
        }
        return null;
    }
}
