using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CharacterCreation
{
    public class PsyPower : IName
    {
        private string namePower, description, action, shortDescription;
        private int cost, psyRateRequire, id, lvl, reqCorruption = 0;
        private List<int> _parentsId = new List<int>();
        private bool isBase;
        private List<Characteristic> requireCharacteristics;
        private string textCost;
        private List<Skill> requireSkills = new List<Skill>();
        private List<Talent> _requireTalents = new List<Talent>();
        private List<PsyPower> _requirePsyPowers = new List<PsyPower>();

        public PsyPower(JSONPsyReader psyReader, string path)
        {
            description = GameStat.ReadText(path + "/Описание.txt");
            namePower = psyReader.name;
            cost = psyReader.cost;
            psyRateRequire = psyReader.psyRate;
            id = psyReader.id;
            action = psyReader.action;
            lvl = psyReader.lvl;

            _parentsId.Add(psyReader.parentId);
            if (psyReader.secondParent > 0)
                _parentsId.Add(psyReader.secondParent);
            if (psyReader.thirdParent > 0)
                _parentsId.Add(psyReader.thirdParent);
            if (psyReader.fourthParent > 0)
                _parentsId.Add(psyReader.fourthParent);

            shortDescription = GameStat.ReadText(path + "/Кратко.txt");

            if (id == 0)
            {
                isBase = true;
            }
            if (Directory.Exists(path + "/Req"))
            {
                path += "/Req";
                if (Directory.Exists(path + "/Characteristics"))
                {
                    requireCharacteristics = new List<Characteristic>();
                    foreach (GameStat.CharacteristicName charName in Enum.GetValues(typeof(GameStat.CharacteristicName)))
                    {
                        string searchFile = $"{path}/Characteristics/{charName}.txt";
                        if (File.Exists(searchFile))
                        {
                            requireCharacteristics.Add(new Characteristic(charName, int.Parse(GameStat.ReadText(searchFile))));
                        }
                    }
                }

                if (Directory.Exists(path + "/Skills"))
                {
                    requireSkills = new List<Skill>();
                    string[] files = Directory.GetFiles(path + "/Skills", "*.JSON");
                    foreach (string file in files)
                    {
                        string[] jSonData = File.ReadAllLines(file);
                        JSONSmallSkillLoader jSONSmall = JsonUtility.FromJson<JSONSmallSkillLoader>(jSonData[0]);
                        requireSkills.Add(new Skill(jSONSmall.name, jSONSmall.lvl));
                    }
                }
                if (File.Exists(path + "/Corruption.txt"))
                {
                    reqCorruption = int.Parse(GameStat.ReadText(path + "/Corruption.txt"));
                }

                if (File.Exists(path + "/ReqTalents.txt"))
                {
                    string textTalents = GameStat.ReadText(path + "/ReqTalents.txt");
                    var talents = textTalents.Split(new char[] { '/' }).ToList();
                    foreach (string talent in talents)
                    {
                        _requireTalents.Add(new Talent(talent));
                    }
                }

                if (File.Exists(path + "/ReqPsyPower.txt"))
                {
                    string textPsypowers = GameStat.ReadText(path + "/ReqPsyPower.txt");
                    var psypowers = textPsypowers.Split(new char[] { '/' }).ToList();
                    foreach (string psypower in psypowers)
                    {
                        _requirePsyPowers.Add(new PsyPower(psypower));
                    }
                }

            }

            SetTextCost();
        }

        public PsyPower(string name)
        {
            namePower = name;
        }

        public string Name => namePower;
        public string Description => description;
        public int Cost => cost;
        public int PsyRateRequire => psyRateRequire;
        public int Id => id;
        public bool IsBase => isBase;
        public string Action => action;
        public int Lvl => lvl;
        public List<int> IdParents => _parentsId;
        public List<Characteristic> RequireCharacteristics => requireCharacteristics;
        public string TextCost => textCost;
        public string ShortDescription => shortDescription;
        public List<Skill> RequireSkills => requireSkills;
        public int ReqCorruption => reqCorruption;

        public List<Talent> RequireTalents => _requireTalents;

        public List<PsyPower> RequirePsyPowers => _requirePsyPowers;

        private void SetTextCost()
        {
            textCost = $"Требования:\nОО {cost}, ПР{psyRateRequire}";
            if (requireCharacteristics != null)
                foreach (Characteristic characteristic in requireCharacteristics)
                    textCost += $", {characteristic.Name} {characteristic.Amount}";

            if (reqCorruption > 0)
                textCost += $", Порча {reqCorruption}";

            if (requireSkills.Count > 0)
                foreach (var skill in requireSkills)
                    textCost += $", {skill.Name} - {skill.LvlLearned}ур.";

            if (_requireTalents.Count > 0)
                foreach (var talent in _requireTalents)
                    textCost += $", {talent.Name}";

            if (_requirePsyPowers.Count > 0)
                foreach (var psy in _requirePsyPowers)
                    textCost += $", Пси сила {psy.namePower}";

        }

    }
}