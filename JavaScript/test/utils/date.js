var
  MonthDays=new Array();

  MonthDays[false]=new Array(31,28,31,30,31,30,31,31,30,31,30,31);
  MonthDays[true]=new Array(31,29,31,30,31,30,31,31,30,31,30,31);

function IsLeapYear(aYear)
{ 
   return(((aYear%4==0) && (aYear%100!=0)) || (aYear%400==0));
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
   if(year<1753 || year>9999)
     return(1);

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
          && !isNaN(year=parseInt(DateParts[aPosY],10))
          && !isNaN(month=parseInt(DateParts[aPosM],10))
          && !isNaN(day=parseInt(DateParts[aPosD],10))
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

function DaySpan(ANow,AThen)
{
	return(!isNaN(ANow) && !isNaN(AThen) && (ANow instanceof Date) && (AThen instanceof Date) ? (Math.abs(ANow.getTime()-AThen.getTime())+Math.abs(Math.abs(ANow.getTimezoneOffset())-Math.abs(AThen.getTimezoneOffset()))*60*1000)/(1000*60*60*24) : NaN);
}

function WeekSpan(ANow,AThen)
{
	return(DaySpan(ANow,AThen)/7);
}

function MonthSpan(ANow,AThen)
{
	return(DaySpan(ANow,AThen)/30.4375 /* ApproxDaysPerMonth */);
}

function YearSpan(ANow,AThen)
{
	return(DaySpan(ANow,AThen)/365.25 /* ApproxDaysPerYear */);
}

function DaysBetween(ANow,AThen)
{
	return((ANow instanceof Date) && (AThen instanceof Date) ? Math.floor(DaySpan(ANow,AThen)) : NaN);
}

function WeeksBetween(ANow,AThen)
{
	return((ANow instanceof Date) && (AThen instanceof Date) ? Math.floor(WeekSpan(ANow,AThen)) : NaN);
}

function MonthsBetween(ANow,AThen)
{
	return((ANow instanceof Date) && (AThen instanceof Date) ? Math.floor(MonthSpan(ANow,AThen)) : NaN);
}

function YearsBetween(ANow,AThen)
{
	return((ANow instanceof Date) && (AThen instanceof Date) ? Math.floor(YearSpan(ANow,AThen)) : NaN);
}
