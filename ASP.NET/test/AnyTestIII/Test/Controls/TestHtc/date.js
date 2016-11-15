var
  MonthDays=new Array();

  MonthDays[false]=new Array(31,28,31,30,31,30,31,31,30,31,30,31);
  MonthDays[true]=new Array(31,29,31,30,31,30,31,31,30,31,30,31);

function IsLeapYear(aYear)
{ 
   return((((aYear%4==0) && (aYear%100!=0)) || (aYear%400==0)) ? true : false);
}

function IncDay(aDate,aIncValue)
{
   if(!(aDate instanceof Date))
     return(NaN);

   if(arguments.length==1)
     aIncValue=1;

   return(new Date(aDate.getTime()+1000*60*60*24*aIncValue));
}

function IncMonth(aDate,aIncValue)
{
   var
     sign,
     leapyear,
     day,
     month,
     year;

   if(!(aDate instanceof Date))
     return(NaN);

   if(arguments.length==1)
     aIncValue=1;

   day=aDate.getDate();
   month=aDate.getMonth();
   year=aDate.getFullYear();

   sign = aIncValue>=0 ? 1 : -1;
   year+=(aIncValue-aIncValue%12)/12;
   aIncValue%=12;
   month+=aIncValue;
   if(month > 11 || month<0)
   {
      year+=sign;
      month+=-12*sign;
   }
   leapyear=IsLeapYear(year);
   if(day>MonthDays[leapyear][month])
     day=MonthDays[leapyear][month];

   return(new Date(year,month,day));
}

function IncYear(aDate,aIncValue)
{
   if(!(aDate instanceof Date))
     return(NaN);

   if(arguments.length==1)
     aIncValue=1;

   return(IncMonth(aDate,12*aIncValue));
}

function CheckDate(year,month,day)
{
   if(month<=0 || month>12)
     return(2);

   if(day<=0 || day>MonthDays[IsLeapYear(year)][month-1])
     return(3);

   return(0);
}

function CheckDateStr(aDateStr, aPosY, aPosM, aPosD)
{
   var
     DateParts=aDateStr.split(/[-,\.\/]/),
     year,
     month,
     day;

   return(DateParts.length==3
          && !isNaN(year=parseInt(DateParts[aPosY]))
          && !isNaN(month=parseInt(DateParts[aPosM]))
          && !isNaN(day=parseInt(DateParts[aPosD]))
          && CheckDate(year,month,day)==0)
}

function CheckDateStrDMY(aDateStr)
{
   return(CheckDateStr(aDateStr,2,1,0));
}

function CheckDateStrMDY(aDateStr)
{
   return(CheckDateStr(aDateStr,2,0,1));
}

function CheckDateStrYMD(aDateStr)
{
   return(CheckDateStr(aDateStr,0,1,2));
}

function FormatDateStr(aDateStr, aDateSeparator)
{
   aDateStr=aDateStr.replace(/[-,\.\/]/g,aDateSeparator);

   var
     dp=aDateStr.split(aDateSeparator);

   aDateStr="";
   for(var i=0; i<dp.length; ++i)
   {
     if(aDateStr.length)
       aDateStr+=aDateSeparator;
     aDateStr+= dp[i].length<2 ? "0"+dp[i] : dp[i];
   }

   return(aDateStr);
}

function FormatDateStrDot(aDateStr)
{
   return(FormatDateStr(aDateStr,"."));
}

function DaysBetween(ANow,AThen)
{
   if(!(ANow instanceof Date)
      || !(AThen instanceof Date))
     return(NaN);

   var
     ANowMS=ANow.getTime(),
     AThenMS=AThen.getTime(),
     result = ANowMS>AThenMS ? ANowMS-AThenMS : AThenMS-ANowMS;

   return(Math.floor(result/(1000*60*60*24))+1);
}

function YearsBetween(ANow,AThen)
{
   if(!(ANow instanceof Date)
      || !(AThen instanceof Date))
     return(NaN);

   return(Math.floor(DaysBetween(ANow,AThen)/365.25));
}