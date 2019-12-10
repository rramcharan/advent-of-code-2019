﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using adventofcode2019_day8.Day8Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace adventofcode2019_day8.Day8Part1.Tests
{
    [TestClass()]
    public class SpaceImageTests
    {

        #region AntiCorruptionNumber
        [TestMethod()]
        public void Example_Test01()
        {
            // Arrange
            var image = SpaceImage.Load(4, 3, "124540785665124541782625120540785665");
            /*
             1245
             4078
             5665

             1245
             4178
             2625

             1205
             4078
             5665
             */

            // Act

            // Assert
            image.Layers.Count.ShouldBe(3);
            var layer = image.LayerWithLeast(0);
            layer.LayerNumber.ShouldBe(2);
            layer.CountDigits[1].ShouldBe(2);
            layer.CountDigits[2].ShouldBe(3);
            image.AntiCorruptionNumber().ShouldBe(6);

            image.Layers[0].ToText().ShouldBe(@"1245
4078
5665
");
        }


        #endregion

        #region Examples

        [TestMethod()]
        public void LoadTest()
        {
            // Arrange
            var image = SpaceImage.Load(3,2,"123456789012");

            // Act

            // Assert
            image.Layers.Count.ShouldBe(2);
            image.Layers[0].CountDigits[0].ShouldBe(0);
            image.Layers[0].CountDigits[1].ShouldBe(1);
            image.Layers[0].CountDigits[2].ShouldBe(1);
            image.Layers[0].CountDigits[3].ShouldBe(1);
            image.Layers[0].CountDigits[4].ShouldBe(1);
            image.Layers[0].CountDigits[5].ShouldBe(1);
            image.Layers[0].CountDigits[6].ShouldBe(1);
            image.Layers[0].CountDigits[7].ShouldBe(0);
            image.Layers[0].CountDigits[8].ShouldBe(0);
            image.Layers[0].CountDigits[9].ShouldBe(0);

            image.Layers[1].CountDigits[0].ShouldBe(1);
            image.Layers[1].CountDigits[1].ShouldBe(1);
            image.Layers[1].CountDigits[2].ShouldBe(1);
            image.Layers[1].CountDigits[3].ShouldBe(0);
            image.Layers[1].CountDigits[4].ShouldBe(0);
            image.Layers[1].CountDigits[5].ShouldBe(0);
            image.Layers[1].CountDigits[6].ShouldBe(0);
            image.Layers[1].CountDigits[7].ShouldBe(1);
            image.Layers[1].CountDigits[8].ShouldBe(1);
            image.Layers[1].CountDigits[9].ShouldBe(1);

            image.Layers[0].ToText().ShouldBe(@"123
456
");
            image.Layers[1].ToText().ShouldBe(@"789
012
");
        }

        //        [TestMethod()]
        //        public void Example_Test01()
        //        {
        //            // Arrange
        //            var image = SpaceImage.Load(3, 2, "123456789012");

        //            // Act

        //            // Assert
        //            image.Layers.Count.ShouldBe(2);
        //            image.Layers[0].CountDigits[0].ShouldBe(0);
        //            image.Layers[0].CountDigits[1].ShouldBe(1);
        //            image.Layers[0].CountDigits[2].ShouldBe(1);
        //            image.Layers[0].CountDigits[3].ShouldBe(1);
        //            image.Layers[0].CountDigits[4].ShouldBe(1);
        //            image.Layers[0].CountDigits[5].ShouldBe(1);
        //            image.Layers[0].CountDigits[6].ShouldBe(1);
        //            image.Layers[0].CountDigits[7].ShouldBe(0);
        //            image.Layers[0].CountDigits[8].ShouldBe(0);
        //            image.Layers[0].CountDigits[9].ShouldBe(0);

        //            image.Layers[1].CountDigits[0].ShouldBe(1);
        //            image.Layers[1].CountDigits[1].ShouldBe(1);
        //            image.Layers[1].CountDigits[2].ShouldBe(1);
        //            image.Layers[1].CountDigits[3].ShouldBe(0);
        //            image.Layers[1].CountDigits[4].ShouldBe(0);
        //            image.Layers[1].CountDigits[5].ShouldBe(0);
        //            image.Layers[1].CountDigits[6].ShouldBe(0);
        //            image.Layers[1].CountDigits[7].ShouldBe(1);
        //            image.Layers[1].CountDigits[8].ShouldBe(1);
        //            image.Layers[1].CountDigits[9].ShouldBe(1);

        //            image.Layers[0].ToText().ShouldBe(@"123
        //456
        //");
        //            image.Layers[1].ToText().ShouldBe(@"789
        //012
        //");
        //        }

        #endregion

        #region Puzzle day 8 part 1

        #region AntiCorruptionNumber
        [TestMethod()]
        public void Puzzle()
        {
            // Arrange
            var image = SpaceImage.Load(25, 6, "221222222022222222222222020222222222022220012102002220222222222222222222220122202222022122222222220212222122222222222222222202221222222222102222212222220222222222222222222222220222222222022220222102122220222222222222222222222122212222122122222222220202222222222222222222222212220222222222002222222222222222222122222222222222121222222222222220012202222221222222222222222222221122212222122222222222222202222222222222222222222222221222222222002222202222222222022222222222222222220222122222122221202102112222222222222222222222220022212022022222222222222212222022222222222222222202221022222222022222202222220222122022222222222222222222122222122220012002022221222222222222222222221222202022022122222222222222222022222222222222222222220022222222222222202222222222222022222222222222222222222222022222122122222221222222222222222222222222212122122122222222220222222122202222222222222222220222222222002222222222221222122022222222222222220222222222122221122022022221222222222222222222220222212122122122222222222202222222212222222222222202221220222222022222202222220222222222222222222222220222122222222222012012012220222222222222222222222022222222222022222222221212222122212222222222222202222021222222102222202222220222122222222222222222221222122222122220212112222220222220222222222222221022202222022022222222220202222122202222222222222212222221222222122222212222220222222222222222222221222222022222222221102102222221222222222222222222221022212122222022222222222202222222202222222222222222222220212222222222222222220222022222222222222220122222022222122220112022222220222222222222222222221022202222122122222122220222222022212222212222222222220220202222012222202222220122022122222222222221220222122222022221212102202221222221222222222222220122222022122122222222222222222222222222202220222212122121212222102222222222212222022022222222221222120222022222122220112002202220222220222222222222202222222122022122222122220212222122222222212221222202220222222222002222222222220122022222222222222220120222122222022222122212002222222221222222222222210222212222122222222121222202222122222222202220222202121222222222102222212222220022122022222222220222022222222222122222212222202222222220222222222222212022222122022022222121220212222222222220002222222212121221212222202222202222212222122022222222221222220222222222122222102112012221222222222222222222221122212122122222222221221222222122212221122220222212122221202222112222222222222022022222222222221220122222022222222220122202202220222222222222222222212222212122022122222021221202222222202221022222222202022220212222202222222222200022022222222222220221022222222222022221002222022220222221222222222222221222222222222122222222222202222122212221012220222211222021222222102222222222212122122122222222220220221222222222022221202222102220222221222222222222211122202122022122222220221212222222202222112221222201222121202222022222222222200122222222222222221221221222222222122221012112212222222222222222222222212222202222222122220220220212222122202221212221222221021222222222002222202222201222222122222222222220222222122222222222002022212222222220222222222222201122202022022022220220222202222222222220112221222212121120202222022222202222221022222222222222222221022222222222022220102102222221222222222222222222211222202122022022222021220222222122212220022221222220222220222222212222202222211122022222222222222221220222222222122220122202102220222222222222222222220122212222122122220122220202222122222220212221222220121022212222000222222222212022122222222222221221122222222222122222202202102220222220220222221222211022222022022222220020220212222022212220120221122200221220202222022222202222220122022022222222200220220222122222122222012212202222222221220222220022201122202222122222220121221222222022202221121220222200220222212222220222212222222122122222222222222222222222222222222221122122022220022220221222220022211222202222122122222122220222222022212220100220022220222222222222101222222222210122222222222222200222020222122222122220012002022220222220221222221122211022212222222122220021220202222222212221100221122221221120202222212222212222201022222022222222202220122222022222122221222122002222022221221222222222200222222122122122220020221222222122212221020220022211220121202222101222212222210122022022222222200222220222222222022220012012022221122221222222220222212022202122122122220120222202222222222222010220022211221122022222210222212222220222122222222222221222022222022222022222022112022222122221221222220222201122202222022222222222222202222222212222000221022212022120202222012222222222212122122022222222212221022222022222122221102202102220122220220222220022222222222122022122221121222212222122202220120212222211022021112222212222222222201222022022222222212221221222222222222222012122102222122220222222221022202022222222022022220021221202222222202222201212122211222221222222222222212222201022122122222222200221121222122222122222002202102220222220220222222122201222212022222122220122221222222022212222212201022222121122222222100222202222212022122222222222210220022222022222222221122002222220122220221222222222222122212122122022222121220222222222202220010211022212121021002222202222012222222122122022222222220222022222122222022221002112202220222221221222220022210022222122022022221222221212222122202222202210022220122120112222002222102222220122122022222222201222221222022222022221112112102220222222220222221222220122212122122122221122221212222122212221120202122210120220102222221222012222202122022022222222211222121222022222022221122222122221222222201222222022221022212122122222220222221202222222222220110222022201121222202222211222202222211222122122222222211221021222122222122220112122002222222221202222220022201122202222222122222022222202222222222222101212222220221221122222021222012222200222122122222222201221022222122222022220012002002221122220222222220022212222212222222222220220021212222122222220001201022222122022122222110222202222221222222022222222202222220222022222022222002102222222022222221222222222201122212022022022220220120202222122222222211200122200020222212222222222022222200222222022222222201221120222222222022222122112012222122220211222222022200122212022122122221222020202222022212221012202122201222122122222220222102222220122222022222222210221122222022222202220002102112222222221202222222222211022222022222022220220220202222122222222101222022212122121102222110222122222212122122122222222212220121222022222122221002222202220122221220222221022212022212022122222221022122212222122212222220202122220120022122222201222112222210122222022222222221221221222222222102222222012122222222222212222220022202222022222222122221020122202222222222222102220122210120122002222212222202222201122122122222222201221220222222202112222202102002222022222211221221022222122212022222222221120220212022022212222222221022212221221122222211222222222200022122022222222222221122222222212122221012122012222022220212220222222222122212122122022221121220222222222202222110202002220120021122222110222202122210022022022222222201221222222122212212220002122002120122221221222221122201022202222022222221020021212222222202220002210112220220221102222211222212022220122222222222222200220020222122202012221112102102022122222200201222122210022122022022022221220222202122122202222211222212202022120012222101222002122201122022222222222222220122222022202212221022112202220122220221201221022210222202122022222220022222202122222222221120202022222020022122222202222212022202122222212222222221221220222022212122220022002022021122222212212221022201222112122022022222122220212122022222220001211202220220021212222001222122122210022122002222222221222121222122222102222222202002222122220200211221022202222112022022022220122221212022222222222002200022211122022222222222222202122202122022012222220222222121222220222212221002112222222122220202220221122221222201022222222221220120202122022202222200201012211022022102222100222122122202222222102222220202221022222220212002221202102012022212220201202222022210022022022122222220020020202222122212221222011002211120122122222021222022122201222122002222222200222222222220222202221122022102021221221212212221122210122022122022122222020022222122022222221210012112222221221202222200222212022220122222212222221221220121222221112022221102202212220112220220220221022222022220222022222222020020212222222212220210002022200220122222222212222122220202122222122222221200220121222221202222221112222122021210222220212220122211122020222022122220220220222122022202220012111102212120120102222022222022221221222222022222221221220221222122002102221202202022022210220220220221022200022022122122222221021021222022122212222202101022211221122002222121222222121212222222222202220222220121222020202222221112022012022112221211222222122202222212122122122220022122212022122212222021220122222122120212222022222202022200122022202212220201221120222121122012220212002002221001222202200221022202222112222122222220122220202022022222221012002202201022120122222010222022021201022222012202221212221221222221112222222112102202120102220201210221022201022122122012222221021022222222122212221122002212201121021202222112222022120220122022012212220202222021222121112222222122002112121011220210222220122210222010022022122221021122212222020222222102210212200222022022222021222112221222222122102212220211221022222022212212220112002102021120220210211222222221122111122002022222221021222022221202222012222012221222021112222021222022221200122222212222222221221020222222022212220122222122120112222211221220022222122102222202222222021020212222121212220002002222220121020202222101222122120100222122102202220211222120222120212202221212102202220012221202222221022222222202121022022222220222212222020222221121011112220011022022222200222012220110222122002202221221221120222021202012221022002022021010221221202222022200022011221002122220222020222022122222220220020212201202022122222222222202221110022222212212222201221010222021222122222002202122221110220200212222222201022000220012222221222221212222121202222100211002222200021212222111222212022201122022112212221210222102222021112202220022012122020120210211201220122202122000020002022221022220212022222212221011222022220011021022222210222202120222022022002212202210222020222120022202222102022212122210222201220222222200122212220022022220122221222122022212221001000012222120220102222220222102022110122222122222201122222121222021012212221112102222220110200220222222222200020202121122022222222220202222022222222221010222210101020102222212222212021102022222202222221012220010222021002012220112222212122011211201201221222222120112222222122221020020202122221222222221010022201022222122222221222122020211222221212212200002212000222222012102221122022222121000200212201222022212021011120012222220120022212022120202220201100112222220221102222021222112211122222122022222212011200110222222102002222122202222220222211210200220121200120202220212022222121120222122122222220101100212221110122112222102222222020021222121012202211002212202222122002012220112122112021100202212221221120211220221221112122222221021212122020202220201100022220022220102222202222222012000222220012222222011221222222121212212221102010102220210222222202220022201221110201102022222222221202022121212222220212222201201222122222122222112021000022220022212220000210001222020202212221002202122022110222211221220121212121111002222022221220020222022021202221222011122022011222102222210222212120100122122122202220121222000222022222022222222210002220122222210210220221201022201111202222220220020202222220222220100211002001200122122222120222202202022221120012212210202201010222220022112220102100112221020222211212220221210120101110022022220121122222022220202221221001022101022221112222111222102102111022021102202220010202211222222202112220202022022020020221210200221020210221102222112222221220021222022022212222121212212211121121012222112222102101200102020202222211112202022222221202002021122211202021111200202201221021220022001020202022222020122212022122222220222000012211021122012222111222212011200021022112212212120210112202121122202221112100222122101211202202221021210022201001122022221220120212222221222222002020012011122220122222011222002220000102120222202210211220201202021222102010002221022120101211221222222120220122210210112122220121121212022022212222011010012201010222202222211222212000022102022022202212100212200212221222112112202022022220212202210221220121202020201022202022220120121222222022212220221000012202220020122222220222122121212120022012202220022212210202022022012101022120022222220200221211022220210120101001122022220120020212122020222221010210002200202222012222100222122202012111002022212201200110021222121112011111102220222120012210211200122121210120010202012022220221121202022122212221110002202021100121222222221222212101222102220012212221112222222212222122221010102202012220002220202202222222200121100222021022122021222222122122212220220022212012011122122222112222212202011100200222222222021112210202022202002120002201022122220211220201120122220121112212122022222021121212222120222222021210002120110020022222221222222000020021211112202222200000001222222222102000002222122121010211221110120122222022001221010222120022222202222021202221020011222200002022022222211222012120120020012222212201220012002202220022010112022111122121020201201000002021220122021001000122022021122222122121202221002201012011222222022222102222012012022220110022202220221121120212221012002200012020002020201202221022101110221021222021122122121000122212222221202221221011122021102221022222101212212021000100000212222221122112100212121122100121222001102220121202220220101110211122102010122222222222121202122122202222202101202120212021012222220202112102021000021002212200002221211212022002001112212110012121112221222101112211222100211211122222120112122212022121222022220011012101020020012222100212002001000120102102202201121000211212020102211222122202202121122221202112220102202002122211120022102101000202122120222121011011200101110221212222122112012012021201201022212220110120120222121112102120222202122022002212221000012122202222001110202122112112020222022022202122011001111211112021202222211002022212011210122202222201011011212212221122000210212121012020221220212002022102201212120202202122120112001212022220212220210202210121121022112222120122012222221202201222202201122201111212022101120022022210002120111212201120022010212021211222211022202010100212222220202122011100112100220020122222010102202122100110201202202211212201010222122122021220022111102122011120202211100121202120122001112222211212022212222022212222101111121022000020102222112122222202011200211002202200222002201202122222012022122022111121221012211202210210221122201202122122122201011222022220202220211112201211110221202222210102002002210221220212202222010212011202220112102210112101220121011211222010201111201200012020111122202100102202022200212012220012021002211220102222121022212202102100010212202201001012222222120221010020102021202121110010212121110200210121121210020122102002120202222210212121012222010012101222122222010012112011120220200201100101000011111000001020000010110011122111011121101102000010112021002010011100202212110010000002121101010110222221001011100100210100021201");
            
            // Act

            // Assert
            image.AntiCorruptionNumber().ShouldBe(2975);
        }


        #endregion
        
        #endregion
    }
}