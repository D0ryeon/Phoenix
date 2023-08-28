using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    static public class View
    {
        static public void StartView()
        {
            string[] str = {
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,..,,,..,,;    .....        ;1.........   1  ............. ....fLLG...LLLLLLLLftfLfffLLLfi1LfffLC,,. ",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,..,,1                  t t            G                   ..LLL@..fLLLLftLLLLLLLt1fLLLLLLLt1;,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,t                  f  t         ...;t                  ..;LLLG:;LffLLLLLLtffLLLLLLf1fLLGf,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,i                 .t   C       .....:8;.               ....LLLLC1LLLLLffLLLLLLLfLLLC08C,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,             .....i    C........f...:0 :.....         .....tLLLLL @LLLLLLLLLLLLLL0,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,         .........:.     ,......:@...iC  .:.................;LLLLLL0LLLLLLLLLLLLLL0,,,,,,,,,,,,,,",
"     ..,,,,,,,,,,,,,,,,,,,,,,,,i  .................1,1fLCG0G080008GCCf00,   f................:LLLLLLLGLLLLLLLLLLLLG,,,,,,..    ...",
",,,,,,,,,,,.  ...,,,,,,,,,,,,,; .................ifLf      t ,,.fL ,L1G0tf11fC81.............,LLLLLLLLCLLLCCCCGCt. ..,.... ..,,,,,",
",,,,,,...,,,,,,,,,,,,,.....,,,..................fL;                           G0.............:LLLLLLLLLLf11i......,,,,,,.........,",
"    ......,,,,,,,,,,,,,,,,,,,:.................,@0.   \"       :;;1i      \"     G0f............tLLLLLLLLLLC,,,,,,,,,,,,,,,,,,,,..",
",,,,,,,,,,,,,,,,,,,.,.,.,.,,;..................L@C       ,LfG: ●iGCL         G@ @...........LLLLLLLLLLLLG,,,,,,,,,,,,..........  ",
",,,,,,,,,,,,..... ...,...,,...................LG,0f:::iCC01    ㅣ    t0fL    iG0:..Cf........fLLLLLLLLLLLLL;,,,,,,,,...,.........,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,f.................1L8..,111:.;f1i1Ci,iCt1;;if0CGGf,....ff@,.....;LLLLLLLLLLLLLLL,,,,,,,,,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,;.................,LG,           ;          C        ...:fff8...:LLLLLLLLLLLLLLLLt,,,,,,,,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,C.................LL@             C         0           .ffffCf:LLLLLLLLLLLL@LLLLC,,,,,,,,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,........,,,,:................fLL;             .;        C            fttttt8GLLLLLLLLLLLL;0LLf,,,,,,,,,,,,,,,,,,,,,,",
".      .,,,,,,,,,,,..,,,,:................;LL8               G        t            ttttttL,fCLLLLLLfLLLC,,,,......,,,,,,,,,,,,,,,,",
",,,,,,,.......,,,,,,,,,,,:................LLL@                G      1.           ,tttttf;,,,;CLLLLLLLL:....,,,.....,,,. ....,,,,,",
"  .,,,,,,,,,,,,,,....,,,,,L......,.......fLLL@                ,i     0            tttttf;,,,,,,,iCCLLG;,,,,,,,,.. ..,,,,.....,,,,.",
",.....,,,.....,,,,,,,,,,,,,t;.,iif......;LLLL1                 G     G           ,ttttGCCfi,,,,,,,,,,,,,,,,,,,,,,,,,,,,.  ..,,,,..",
",... .,,,,,,,,,,,,,,,,,,,,,,,,,,,f......LLLL01                  0   L            tttt@tttttttC0L;,,,,,,,,,,,,,,,,,,,,,..,,,,,,.   ",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.....LLLLLi,C,                 f,;G          .ttt8Ltttttttttt11iit1,,,,,,,,,,,,,,,,,,,,,,....,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,L.:LLLLLLf,,,,Li                            ttf8tttGtttt1             i,,,,,,,,,,,,,,,,,,,,,,,,.",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,fCLLLL0,,:f1    Li                     ,1tf@@@@ttttCtt,                .8,,,,,,,,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;,,tL            1fi,       ,:ittfLC8@@@@@@@ttf0fi                   .t0,,,,,,,,,,,,,,,,,,,,"
                };

            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine(str[i]);
            }
            Console.WriteLine(String.Format("{0}", "PRESS ENTER KEY TO START").PadLeft(130 - (65 - ("PRESS ENTER KEY TO START".Length / 2))));
            Console.ReadLine();
        }
    }



    

}
