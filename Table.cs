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

        //싱글턴 패턴을 적용합니다.
        private Table() { InitializeTable(); }

        private static Table s_instance = new Table();

        public static Table instance => s_instance;
        ///////////////////////////////////////////////////////////////

        public STATUS GetLevelStatusBonus(int level)
        {

            switch (level)
            {
            case 1:
                return new STATUS(0, 0, 0);
            case 2:
                return new STATUS(1, 0, 5);
            case 3:
                return new STATUS(1, 1, 10);
            case 4:
                return new STATUS(2, 1, 15);
            case 5:
                return new STATUS(2, 2, 20);
            }

            return new STATUS(0, 0, 0);

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

            m_monsterStatus.Add(new MONSTER_STATUS(0, "미니언", 2, new STATUS(5, 0, 15)));
            m_monsterStatus.Add(new MONSTER_STATUS(1, "공허충", 3, new STATUS(9, 0, 10)));
            m_monsterStatus.Add(new MONSTER_STATUS(2, "대포미니언", 5, new STATUS(8, 0, 25)));

        }

        private List<MONSTER_STATUS> m_monsterStatus = new List<MONSTER_STATUS>();

    }

}
