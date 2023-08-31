using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{

    

    public class LevelSystem : ISaveLoadable
    {

        public const int MAX_LEVEL = 5;

        //현재 경험치
        public int experience => m_experience;

        //현재 레벨의 목표 경험치
        public int currentRequiredExperience => Table.instance.GetRequiredExperience(m_level);

        public STATUS currentLevelStatusBonus => Table.instance.GetLevelStatusBonus(m_level);

        //현재 레벨
        public int level => m_level;

        //ISaveLoadable override

        public void Save(JObject json)
        {
            json?.Add("LEVEL", m_level);
            json?.Add("EXPERIENCE", m_experience);
        }

        public void Load(JObject json)
        {
            Debug.Assert(int.TryParse(json?["LEVEL"]?.ToString(), out m_level));
            Debug.Assert(int.TryParse(json?["EXPERIENCE"]?.ToString(), out m_experience));
        }



        //몬스터를 사냥해 경험치를 얻습니다.
        //monsterIdentifier: 사냥한 몬스터의 식별자
        //return: 정상 작동 유무.
        public bool AddMonsterKillExperience(int monsterIdentifier)
        {

            m_experience += Table.instance.GetMonsterExperience(monsterIdentifier);

            CheckExperience();

            return true;

        }

        private void LevelUp()
        {
            m_level = Math.Min(MAX_LEVEL, m_level + 1);
        }

        //경험치가 변했을 경우 필요한 처리가 있다면 처리합니다.
        private void CheckExperience()
        {

            //경험치가 충분하다면 레벨업합니다.
            if (m_experience >= currentRequiredExperience)
            {
                m_experience = m_experience - currentRequiredExperience;
                LevelUp();
            }

        }

        private int m_experience    = 0;
        private int m_level         = 1;

    }

}
