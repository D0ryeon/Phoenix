using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    public class ExperienceTable
    {

        public const int MAX_LEVEL = 5;

        //싱글턴 패턴을 적용합니다.
        private ExperienceTable() { }

        private static ExperienceTable s_instance = new ExperienceTable();

        public static ExperienceTable instance => s_instance;
        ///////////////////////////////////////////////////////////////


        //레벨별 필요 경험치 양을 얻습니다.
        public int GetRequiredExperience(int level)
        {
            return 0;
        }

    }

    public class LevelSystem
    {

        //현재 경험치
        public int experience => m_experience;

        //현재 레벨의 목표 경험치
        public int currentRequiredExperience => ExperienceTable.instance.GetRequiredExperience(m_level);

        //현재 레벨
        public int level => m_level;

        //몬스터를 사냥해 경험치를 얻습니다.
        //monsterIdentifier: 사냥한 몬스터의 식별자
        public bool AddMonsterKillExperience(int monsterIdentifier)
        {

            m_experience += 100;
            if(m_experience >= currentRequiredExperience)
            {
                m_experience = m_experience - currentRequiredExperience;
                LevelUp();
            }

            return true;

        }

        private void LevelUp()
        {
            m_level = Math.Min(ExperienceTable.MAX_LEVEL, m_level + 1);
        }

        private int m_experience    = 0;
        private int m_level         = 1;

    }

}
