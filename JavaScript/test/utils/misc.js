function AllTrim(aInpStr)
{
   if(arguments.length<1)
     throw new Error("Too few parameters in call to 'AllTrim(string)'");

   if(arguments.length>1)
     throw new Error("Extra parameter in call to 'AllTrim(string)'");

   if(typeof(aInpStr)!="string")
     throw new Error("Type mismatch in parameter 'string'");

   var
     AllSpaceRegExp=new RegExp("^[\\s]+|[\\s]+$","g");

   return(aInpStr.replace(AllSpaceRegExp,""));
}
//---------------------------------------------------------------------------

function IsBlank(aInpStr)
{
   if(arguments.length<1)
     throw new Error("Too few parameters in call to 'IsBlank(string)'");

   if(arguments.length>1)
     throw new Error("Extra parameter in call to 'IsBlank(string)'");

   if(typeof(aInpStr)!="string")
     throw new Error("Type mismatch in parameter 'string'");

   var
     tmpStr=aInpStr.replace(/\s/g,"");

   return(!Boolean(tmpStr.length));
}
//---------------------------------------------------------------------------

function IsInt(aStr)
{
   var
     RegEx=new RegExp("^[-+]?\\d+$"),
     result=false;

   aStr=AllTrim(aStr);
   if(IsBlank(aStr))
     return(result);

   result=RegEx.test(aStr);
   if(result)
     result&=!isNaN(parseInt(aStr,10));

   return(result);
}
//---------------------------------------------------------------------------

function ToInt(aStr)
{
   var
     result=NaN;

   if(!IsBlank(aStr=AllTrim(aStr)) && IsInt(aStr))
     result=parseInt(aStr,10);

   return(result);
}
//---------------------------------------------------------------------------

function FindDecimalSeparator(aStr)
{
   var
     IndexOf=-1,
     Char;

   aStr=AllTrim(aStr);
   for(var i=aStr.length-1; i>=0; --i)
   {
      Char=aStr.charAt(i);
      if(Char.search(/\d/)==-1 && Char.search(/[\.,-]/)==0 && (Char=="-" ? i!=0 : true ))
      {
         IndexOf=i;
         break;
      }
   }

   return(IndexOf);
}
//---------------------------------------------------------------------------

function CheckDecimalSeparator(aStr)
{
   var
     idx,
     Char,
     DecimalSeparator=".";

   aStr=AllTrim(aStr);
   if(!IsBlank(aStr))
   {
      if((idx=FindDecimalSeparator(aStr))!=-1)
      {
         Char=aStr.charAt(idx);
         if(Char!=DecimalSeparator)
           aStr=aStr.substring(aStr,idx)+DecimalSeparator+aStr.substring(idx+1);
      }
   }

   return(aStr);
}
//---------------------------------------------------------------------------

function IsDouble(aStr)
{
   var
     result=false,
     RegEx=new RegExp("^[-+]?(\\d+|\\d*\\.\\d+)$");

   aStr=AllTrim(aStr);
   if(IsBlank(aStr))
     return(result);

   aStr=CheckDecimalSeparator(aStr);
   if(result=RegEx.test(aStr))
     result&=!isNaN(parseFloat(aStr));

   return(result);
}
//---------------------------------------------------------------------------

function ToDouble(aStr)
{
   var
     result=NaN;

   if(!IsBlank(aStr=AllTrim(aStr)) && IsDouble(aStr))
   {
     aStr=CheckDecimalSeparator(aStr);
     result=parseFloat(aStr);
   }

   return(result);
}
//---------------------------------------------------------------------------

function FormatCurrencyStr(aCurrencyStr, aCurrencySeparator)
{
   aCurrencyStr=AllTrim(aCurrencyStr);

   var
     IsNegative=aCurrencyStr.charAt(0)=="-";

   if(IsNegative)
     aCurrencyStr=AllTrim(aCurrencyStr.substr(1));

   aCurrencyStr=aCurrencyStr.replace(/[-,\.]/g,aCurrencySeparator);

   var
     cp=aCurrencyStr.split(aCurrencySeparator);

   return((IsNegative ? "-" : "")+(cp.length>=1 && cp[0].length ? cp[0] : "0") + aCurrencySeparator + (cp.length>=2 && cp[1].length ? (cp[1].length<2 ? cp[1]+"0" : cp[1]) : "00"));
}
//---------------------------------------------------------------------------

function FormatCurrencyStrComma(aCurrencyStr)
{
   return(FormatCurrencyStr(aCurrencyStr,","));
}
//---------------------------------------------------------------------------

function PadL(aStr,aLen,aFillChar)
{
   if(aStr.length>=aLen)
     return(aStr);

   if(arguments.length==2)
     aFillChar=" ";

   var
     PadCount=aLen-aStr.length;
     PadStr="";

   for(var i=0; i<PadCount; ++i)
      PadStr+=aFillChar;

   return(PadStr+aStr);
}
//---------------------------------------------------------------------------

function PadR(aStr,aLen,aFillChar)
{
   if(aStr.length>=aLen)
     return(aStr);

   if(arguments.length==2)
     aFillChar=" ";

   var
     PadCount=aLen-aStr.length;
     PadStr="";

   for(var i=0; i<PadCount; ++i)
      PadStr+=aFillChar;

   return(aStr+PadStr);
}
//---------------------------------------------------------------------------

function RoundTo(aValue, aDigit)
{
   var
     LFactor = arguments.length>=2 ? Math.pow(10,-aDigit) : 1,
     tmpInt;

   aValue*=LFactor;
   tmpInt = aValue<0 ? aValue-0.5 : aValue+0.5;
   tmpInt=Math.floor(tmpInt);

   return(tmpInt/LFactor);
}
//---------------------------------------------------------------------------

function IsDigit(aStr)
{
   var
     RegEx=new RegExp("^\\d+$"),
     result=false;

   aStr=AllTrim(aStr);
   if(IsBlank(aStr))
     return(result);

   result=RegEx.test(aStr);

   return(result);
}
//---------------------------------------------------------------------------

function IsAlpha(aStr)
{
   var
     RegEx=new RegExp("^[a-zA-Z]+$"),
     result=false;

   aStr=AllTrim(aStr);
   if(IsBlank(aStr))
     return(result);

   result=RegEx.test(aStr);

   return(result);
}
//---------------------------------------------------------------------------

function IsCharCyrillicUpperCase(aChar)
{
   return((aChar>='ј' && aChar<='я')
          || aChar=='≤'
          || aChar=='™'
          || aChar=='ѓ'
          || aChar=='•'
          || aChar=='®'
         );
}
//---------------------------------------------------------------------------

function IsCharCyrillicLowerCase(aChar)
{
   return((aChar>='а' && aChar<='€')
          || aChar=='≥'
          || aChar=='Ї'
          || aChar=='њ'
          || aChar=='і'
          || aChar=='Є'
         );
}
//---------------------------------------------------------------------------

function IsCharCyrillic(aChar)
{
   return(IsCharCyrillicUpperCase(aChar) || IsCharCyrillicLowerCase(aChar));
}
//---------------------------------------------------------------------------

function IsCyrillic(aStr)
{
   var
     Result=true,
     length=aStr.length;

   for(var i=0; i<length && Result; ++i)
      if(!IsCharCyrillic(aStr.charAt(i)))
        Result=false;

   return(Result);
}
//---------------------------------------------------------------------------

function CharCyrillicUpperCase(aChar)
{
   if(IsCharCyrillicLowerCase(aChar))
     {
        if(aChar>='а' && aChar<='€')
          aChar=String.fromCharCode(aChar.charCodeAt(0)-32);

        if(aChar=='≥')
          aChar='≤';

        if(aChar=='Ї')
          aChar='™';

        if(aChar=='њ')
          aChar='ѓ';

        if(aChar=='і')
        aChar='•';

        if(aChar=='Є')
          aChar='®';
     }

   return(aChar);
}
//---------------------------------------------------------------------------

function CharCyrillicLowerCase(aChar)
{
   if(IsCharCyrillicUpperCase(aChar))
     {
        if(aChar>='ј' && aChar<='я')
          aChar=String.fromCharCode(aChar.charCodeAt(0)+32);

        if(aChar=='≤')
          aChar='≥';

        if(aChar=='™')
          aChar='Ї';

        if(aChar=='ѓ')
          aChar='њ';

        if(aChar=='•')
        aChar='і';

        if(aChar=='®')
          aChar='Є';
     }

   return(aChar);
}
//---------------------------------------------------------------------------

function CyrillicUpperCase(aStr)
{
   var
     length=aStr.length,
     outStr="";

   for(var i=0; i<length; ++i)
      outStr+=CharCyrillicUpperCase(aStr.charAt(i));

   return(outStr);
}
//---------------------------------------------------------------------------

function CyrillicLowerCase(aStr)
{
   var
     length=aStr.length,
     outStr="";

   for(var i=0; i<length; ++i)
      outStr+=CharCyrillicLowerCase(aStr.charAt(i));

   return(outStr);
}
//---------------------------------------------------------------------------

function Num2Str(inp)
{
   var
     teen_digit=new Array("нуль","одна","дв≥","три","чотири","п\'€ть","ш≥сть","с≥м","в≥с≥м","дев\'€ть",
                          "дес€ть","одинадц€ть","дванадц€ть","тринадц€ть","чотирнадц€ть","п\'€тнадц€ть","ш≥стнадц€ть","с≥мнадц€ть","в≥с≥мнадц€ть","дев\'€тнадц€ть"),
     ten_digit=new Array("двадц€ть","тридц€ть","сорок","п\'€тдес€т","ш≥стдес€т","с≥мдес€т","в≥с≥мдес€т","дев\'€носто"),
     hundred_digit=new Array("сто","дв≥ст≥","триста","чотириста","п\'€тсот","ш≥стсот","с≥мсот","в≥с≥мсот","дев\'€тсот"),
     name=new Array("","тис€ч","м≥льйон","м≥ль€рд","трильйон"),
     OutputStr="",
     grn,
     end,
     triada=4,
     base,
     tmp_triada,
     CentStr;

   inp=RoundTo(Math.abs(inp),-2);

   CentStr=inp.toString();
   if((base=FindDecimalSeparator(CentStr))!=-1)
   {
      CentStr=CentStr.substring(base+1);
      CentStr=PadR(CentStr,2,"0");
   }
   else
     CentStr="00";

   while(triada>=0)
   {
      base=Math.pow(1000,triada);
      tmp_triada=Math.floor(inp/base);
      inp-=tmp_triada*base;

      if(tmp_triada==0 && triada!=0)
      {
         --triada;
         continue;
      }

      if(tmp_triada>=100)
      {
         OutputStr+=hundred_digit[Math.floor(tmp_triada/100)-1];
         OutputStr+=" ";
         tmp_triada-=Math.floor(tmp_triada/100)*100;
         grn="гривень";
         if(triada>=2)
           end="≥в";
         else
           end="";
      }

      if(tmp_triada>=20)
      {
         OutputStr+=ten_digit[Math.floor(tmp_triada/10)-2];
         OutputStr+=" ";
         tmp_triada-=Math.floor(tmp_triada/10)*10;
         grn="гривень";
         if(triada>=2)
           end="≥в";
         else
           end="";
      }

      if(tmp_triada>0)
      {
         if(tmp_triada==1 && triada>=2)
           OutputStr+="один";
         else if(tmp_triada==2 && triada>=2)
           OutputStr+="два";
         else
           OutputStr+=teen_digit[tmp_triada];
         OutputStr+=" ";
         switch(triada)
         {
            case 0 :
            {
               if(tmp_triada==1)
                 grn="гривн€";
               else if((tmp_triada>=2) && (tmp_triada<=4))
                 grn="гривн≥";
               else
                 grn="гривень";
               end="";
               break;
            }
            case 1 :
            {
               if(tmp_triada==1)
                 end="а";
               else if((tmp_triada>=2) && (tmp_triada<=4))
                 end="≥";
               else
                 end="";
               grn="гривень";
               break;
            }
            default:
            {
               if(tmp_triada==1)
                 end="";
               else if((tmp_triada>=2) && (tmp_triada<=4))
                 end="а";
               else
                 end="≥в";
               grn="гривень";
               break;
            }
         }
      }
      if(tmp_triada==0 && triada==0 && OutputStr.length==0)
      {
         OutputStr+=teen_digit[tmp_triada];
         OutputStr+=" ";
         grn="гривень";
         end="";
      }
      OutputStr+=name[triada--];
      OutputStr+=end;
      OutputStr+=" ";
      end="";
     }
   OutputStr+=grn;

   OutputStr+=" ";

   OutputStr+=CentStr;
   OutputStr+=" коп≥й";
   triada=parseInt(CentStr,10)
   if(triada>=11 && triada<=14)
     OutputStr+="ок";
   else
   {
     triada%=10;
     switch(triada)
     {
        case 0 :
        case 5 :
        case 6 :
        case 7 :
        case 8 :
        case 9 :
        {
           OutputStr+="ок";
           break;
        }
        case 1 :
        {
           OutputStr+="ка";
           break;
        }
        case 2 :
        case 3 :
        case 4 :
        {
           OutputStr+="ки";
           break;
        }
     }
   }

   OutputStr=CyrillicUpperCase(OutputStr.charAt(0))+OutputStr.substring(1);
   return(OutputStr);
}
//---------------------------------------------------------------------------

function DelimiterCount(Str, Delimiter)
{
   var
     Count=0,
     Len=Str.length;

   for(var i=0; i<Len; ++i)
   {
      if(Str.subst(i,1)==Delimiter)
        Count++;
   }

   return(Count);
}
//---------------------------------------------------------------------------

function ExtractToken(Str, Delimiter, Number)
{
   var 
     OutStr="",
     tmpArr=Str.split(Delimiter);

   if(Number<tmpArr.length)
     OutStr=tmpArr[Number];

   return(OutStr)
}
//---------------------------------------------------------------------------

function CreateArraySumDiv(aSum, aCount)
{
	var
		outArray=new Array(aCount),
		tmpS=RoundTo(aSum/aCount,-2),
		i=0;

	for(var i=0; i<outArray.length; ++i)
	{
		outArray[i] = i!=outArray.length-1 ? tmpS : RoundTo(aSum,-2);
		aSum-=tmpS;
	}

	return(outArray)
}
//---------------------------------------------------------------------------

function FindSelectValueIndex(aHTMLSelect, aValue)
{
	var
		idx=-1;

	if(typeof(aHTMLSelect)=="string")
		aHTMLSelect=document.getElementById(aHTMLSelect);

	if(!aHTMLSelect)
		return(idx);

	for(var i=0; i<aHTMLSelect.options.length; ++i)
		if(aHTMLSelect.options[i].value==aValue)
		{
			idx=i;
			break;
		}
	return(idx);
}
//---------------------------------------------------------------------------

function toFixed(val, f)
{
	f = parseInt(f/1 || 0);
	if( f<0 || f>20 ) 
		alert("The number of fractional digits is out of range");
	if( isNaN(val) ) 
		return "NaN";
	var s = val<0 ? "-" : "", 
		 x = Math.abs(val);
	if ( val>Math.pow(10,21) ) 
		return s + x.toString();
	var m = Math.round(x*Math.pow(10,f)).toString();
	if (!f) 
		return s + m;
	while (m.length<=f) 
		m = "0" + m;
	return s + m.substring(0,m.length-f)+"."+m.substring(m.length-f);
}
//---------------------------------------------------------------------------

function addHidden(form, id, value, bPostback)
{
	if( document.getElementById("id") )
	{
		document.getElementById.value = value;
		return;
	}
	var elem;
	if( bPostback )
	   elem = document.createElement("<input type='hidden' name='"+id+"'/>");
	else
	   elem = document.createElement("<input type='hidden'/>");
	
	form.appendChild(elem);
	elem.id = id;
	elem.value = value;
}
//---------------------------------------------------------------------------

function ArraySearch(a, v)
{
	var
		idx=-1;

	for(var i=0; i<a.length; ++i)
		if(a[i]==v)
		{
			idx=i;
			break;
		}

	return(idx);
}
//---------------------------------------------------------------------------