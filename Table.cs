using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPhoenix
{
    public class Table
    {

        public Table()
        {
            InitializeTable();
        }

        public STATUS GetLevelStatusBonus(int level)
        {

            switch (level)
            {
            case 1:
                return new STATUS(0, 0, 0, 0);
            case 2:
                return new STATUS(1, 0, 5, 0);
            case 3:
                return new STATUS(1, 1, 10, 0);
            case 4:
                return new STATUS(2, 1, 15, 0);
            case 5:
                return new STATUS(2, 2, 20, 0);
            }

            return new STATUS(0, 0, 0, 0);

        }

        //레벨별 필요 경험치를 얻습니다.
        public int GetRequiredExperience(int level)
        {

            switch (level)
            {
            case 1:
                return 10;
            case 2:
                return 30;
            case 3:
                return 65;
            case 4:
                return 100;
            case 5:
                return 1;
            }

            return 1;

        }

        //몬스터별 획득 경험치를 얻습니다.
        public MONSTER_STATUS GetMonsterStatus(int identifier)
        {
            return m_monsterStatus[identifier];
        }

        public int GetMonsterExperience(int identifier)
        {
            return GetMonsterStatus(identifier).level;
        }

        private void InitializeTable()
        {

            m_monsterStatus.Add(new MONSTER_STATUS(0, "미니언", 2, new STATUS(5, 0, 15, 0)));
            m_monsterStatus.Add(new MONSTER_STATUS(1, "공허충", 3, new STATUS(9, 0, 10, 0)));
            m_monsterStatus.Add(new MONSTER_STATUS(2, "대포미니언", 5, new STATUS(8, 0, 25, 0)));

        }

        private List<MONSTER_STATUS> m_monsterStatus = new List<MONSTER_STATUS>();

    }

}
