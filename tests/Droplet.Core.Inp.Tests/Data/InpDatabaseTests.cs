using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Droplet.Core.Inp.Tests.Data
{
    public class InpDatabaseTests : FileTestsBase
    {
        public InpDatabaseTests(ITestOutputHelper logger) : base(logger)
        {
        }

        #region ToInpStrings Tests

        [Theory]
        [ClassData(typeof(ToInpStringsTestData))]
        public void ToInpStringTest(string value)
        {
            var project = SetupProject(value);
            var finalString = new StringBuilder();

            foreach (var line in project.Database.GetInpStrings())
            {
                finalString.AppendLine(line);
            }

            var test = finalString.ToString();
        }

        private class ToInpStringsTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    // File Strings
                    @"
[TITLE]
;;Project Title/Notes

[OPTIONS]
;;Option             Value
FLOW_UNITS           CMS
INFILTRATION         GREEN_AMPT
FLOW_ROUTING         KINWAVE
LINK_OFFSETS         ELEVATION
MIN_SLOPE            0.15
ALLOW_PONDING        NO
SKIP_STEADY_STATE    NO

START_DATE           07/28/2019
START_TIME           00:00:00
REPORT_START_DATE    07/28/2019
REPORT_START_TIME    00:00:00
END_DATE             07/28/2019
END_TIME             06:00:00
SWEEP_START          01/01
SWEEP_END            12/31
DRY_DAYS             0
REPORT_STEP          00:15:00
WET_STEP             00:05:00
DRY_STEP             01:00:00
ROUTING_STEP         0:00:30 
RULE_STEP            00:00:00

INERTIAL_DAMPING     FULL
NORMAL_FLOW_LIMITED  SLOPE
FORCE_MAIN_EQUATION  H-W
VARIABLE_STEP        0.75
LENGTHENING_STEP     0
MIN_SURFAREA         1.167
MAX_TRIALS           8
HEAD_TOLERANCE       0.0015
SYS_FLOW_TOL         5
LAT_FLOW_TOL         5
MINIMUM_STEP         0.5
THREADS              8

[EVAPORATION]
;;Data Source    Parameters
;;-------------- ----------------
CONSTANT         0.0
DRY_ONLY         NO

[SUBCATCHMENTS]
;;Name           Rain Gage        Outlet           Area     %Imperv  Width    %Slope   CurbLen  SnowPack        
;;-------------- ---------------- ---------------- -------- -------- -------- -------- -------- ----------------
;My Subcatchment
1                *                myStorage        5        25       500      0.5      0                        
;This is a test
;To see what happens
3                *                1                5        50       500      0.5      0                        
5                *                *                5        25       500      0.5      0                        
6                *                *                5        25       500      0.5      0                        
7                *                *                5        25       500      0.5      0                        
8                *                *                5        25       500      0.5      0                        

[SUBAREAS]
;;Subcatchment   N-Imperv   N-Perv     S-Imperv   S-Perv     PctZero    RouteTo    PctRouted 
;;-------------- ---------- ---------- ---------- ---------- ---------- ---------- ----------
1                0.01       0.1        0.05       0.05       100        IMPERVIOUS 50        
3                0.01       0.1        0.05       0.05       25         OUTLET    
5                0.01       0.1        0.05       0.05       25         OUTLET    
6                0.01       0.1        0.05       0.05       25         OUTLET    
7                0.01       0.1        0.05       0.05       25         OUTLET    
8                0.01       0.1        0.05       0.05       25         OUTLET    

[INFILTRATION]
;;Subcatchment   Suction    Ksat       IMD       
;;-------------- ---------- ---------- ----------
1                80         0.5        7         
3                80         0.5        7         
5                3.0        0.5        4         
6                3.0        0.5        4         
7                3.0        0.5        4         
8                3.0        0.5        4         

[AQUIFERS]
;;Name           Por    WP     FC     Ksat   Kslope Tslope ETu    ETs    Seep   Ebot   Egw    Umc    ETupat 
;;-------------- ------ ------ ------ ------ ------ ------ ------ ------ ------ ------ ------ ------ ------
Test             0.5    0.15   0.30   5.0    10.0   15.0   0.35   14.0   0.002  0.0    10.0   0.30         

[GROUNDWATER]
;;Subcatchment   Aquifer          Node             Esurf  A1     B1     A2     B2     A3     Dsw    Egwt   Ebot   Wgr    Umc   
;;-------------- ---------------- ---------------- ------ ------ ------ ------ ------ ------ ------ ------ ------ ------ ------
3                Test             *                0      0      0      0      0      0      0      *     

[OUTFALLS]
;;Name           Elevation  Type       Stage Data       Gated    Route To        
;;-------------- ---------- ---------- ---------------- -------- ----------------
2                0          FIXED      1                NO       1               

[STORAGE]
;;Name           Elev.    MaxDepth   InitDepth  Shape      Curve Name/Params            N/A      Fevap    Psi      Ksat     IMD     
;;-------------- -------- ---------- ----------- ---------- ---------------------------- -------- --------          -------- --------
myStorage        0        0          0          FUNCTIONAL 1000      0         0        0        0       
4                0        0          0          FUNCTIONAL 1000      0         0        0        0       

[OUTLETS]
;;Name           From Node        To Node          Offset     Type            QTable/Qcoeff    Qexpon     Gated   
;;-------------- ---------------- ---------------- ---------- --------------- ---------------- ---------- --------
1                myStorage        2                0          FUNCTIONAL/DEPTH 10.0             0.5        NO      

[DWF]
;;Node           Constituent      Baseline   Patterns  
;;-------------- ---------------- ---------- ----------
2                FLOW             4          'test'

[PATTERNS]
; ; Name Type       Multipliers
; ; -----------------------------------
test             MONTHLY    1.0   1.0   1.0   1.0   1.0   1.0
test                        1.0   1.0   1.0   1.0   1.0   1.0

[REPORT]
; ; Reporting Options
SUBCATCHMENTS ALL
NODES ALL
LINKS ALL

[TAGS]

[MAP]
            DIMENSIONS 0.000 0.000 10000.000 10000.000
Units None

[COORDINATES]
;;Node X-Coord Y-Coord           
;;-------------- ------------------ ------------------
2                767.013            6955.017          
myStorage        -2773.933          7843.137          
4                -4211.429          7017.143          

[VERTICES]
;;Link X-Coord Y-Coord           
;;-------------- ------------------ ------------------

[Polygons]
;;Subcatchment X-Coord Y-Coord           
;;-------------- ------------------ ------------------
1                -2681.661          9826.990          
1                -2704.729          8396.770          
1                -5207.612          8200.692          
1                -5011.534          9365.629          
3                -485.714           9954.286          
3                -62.857            8457.143          
3                -2474.286          8434.286          
3                -2462.857          9840.000          
5                1788.571           8205.714          
5                2222.857           8674.286          
5                2211.429           9371.429          
5                1948.571           9794.286          
5                1228.571           9760.000          
5                1114.286           9417.143          
5                1525.714           8960.000          
6                725.714            8022.857          
6                371.429            8685.714          
6                -245.714           9645.714          
6                428.571            11051.429         
6                1548.571           10891.429         
6                1217.143           10320.000         
6                451.429            10000.000         
6                428.571            9268.571          
6                954.286            8754.286          
7                668.571            6342.857          
7                1777.143           5920.000          
7                2440.000           7017.143          
7                1857.143           7417.143          
7                1434.286           7142.857          
8                1137.143           7691.429          
8                -462.857           8000.000          
8                -577.143           7760.000          
8                885.714            7382.857
"
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}
