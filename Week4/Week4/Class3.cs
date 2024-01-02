//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Week4
//{
//    //internal class Class3
//    //{
//    //    //열거형 구현
//    //    enum MyEnum
//    //    {
//    //        Value1, //0
//    //        Value2, //1
//    //        Value3  //2
//    //    }

//    //    MyEnum myEnum = MyEnum.Value1;
//    //    //임의대로 값 지정
//    //    enum mineEnum
//    //    {
//    //        Value1 =10,
//    //        Value2,
//    //        Value3 =20
//    //    }

//    //    static void Main(string[] args)
//    //    {
//    //        //,열거형 형변환
//    //        int intValue = (int)MyEnum.Value1; //열거형 값을 정수로 변환
//    //        MyEnum enumValue = (MyEnum)intValue; //정수를 열거형으로 변환

//    //        //스위치문과의 사용
//    //        switch (enumValue)
//    //        {
//    //            case MyEnum.Value1:
//    //                //value1에 대한 처리
//    //                break; 
//    //            case MyEnum.Value2:
//    //                //value2에 대한 처리
//    //                break; 
//    //            case MyEnum.Value3:
//    //                //value3에 대한 처리
//    //                break;
//    //            default:
//    //                //기본 처리
//    //                break;
//    //        }
//    //    }
        

//    //}

//    //internal class practice1
//    //{
//    //    enum DaysOfWeek
//    //    {
//    //        Sunday,
//    //        Monday,
//    //        Tuesday,
//    //        Wednesday,
//    //        Thursday,
//    //        Friday,
//    //        Saturday,
//    //    }

//    //    static void Main(string[] args)
//    //    {
//    //        DayOfWeek day = DayOfWeek.Monday;
//    //        Console.WriteLine("Today is " + day);
//    //    }
//    //}

//    internal class Practice2
//    {
//        public enum Month
//        {
//            Jan=1,
//            Feb,
//            Mar,
//            Apr,
//            May,
//            Jun,
//            Jul,
//            Aug,
//            Sep,
//            Oct,
//            Nov,
//            Dec
//        }

//        public static void PrcessMonth(int month)
//        {
//            if (month >= (int)Month.Jan && month <= (int)Month.Dec)
//            {
//                Month selectMonth =(Month)month;
//                Console.WriteLine("선택한 월은 {0}입니다.", selectMonth);
//            }
//            else
//            {
//                Console.WriteLine("올바른 월을 입력해주세요.");
//            }
//        }
        
//        static void Main()
//        {
//            int userInput = 7;
//            PrcessMonth(userInput);
//        }
//    }
//}
