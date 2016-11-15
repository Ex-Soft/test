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
     result&=!isNaN(parseInt(aStr));

   return(result);
}

function ToInt(aStr)
{
   var
     result=NaN;

   if(!IsBlank(aStr=AllTrim(aStr)) && IsInt(aStr))
     result=parseInt(aStr);

   return(result);
}

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

var
  DDLElement=new Array();

function DDLChanged(aDDLId)
{
   var
     DDL;

   for(var i=0; i<DDLElement.length; ++i)
      if(DDLElement[i]==aDDLId)
        return;

   DDLElement.push(aDDLId);

   DDL=document.getElementById(aDDLId);
   if(DDL!=undefined && DDL!=null)
   {
      for(var i=0; i<DDL.options.length; ++i)
      {
         if(IsBlank(DDL.options[i].value))
         {
            DDL.remove(i);
            break;  
         }
      }
   }
}

function PrepareForm()
{
   var
     tmpObj;

   for(var i=0; i<CheckElement.length; ++i)
   {
      if(CheckElement[i].Id)
        tmpObj=CheckElement[i].Id;
      else
        continue;

      if(tmpObj=document.getElementById(tmpObj))
      {
         tmpObj.CheckValid=true;
         if(CheckElement[i].Required)
           tmpObj.Required=true;
         if(CheckElement[i].typeofStore)
           tmpObj.typeofStore=CheckElement[i].typeofStore;
      }
   }
}

function CheckEmptyType(aWin,aInvalidColor)
{
   var
     e,
     val,
     OkRequired,
     OkType;

   for(var iForm=0; iForm<aWin.document.forms.length; ++iForm)
   {
      for(var iElement=0; iElement<aWin.document.forms[iForm].length; ++iElement)
      {
         e=aWin.document.forms[iForm].elements[iElement];

         if(!e.CheckValid)
           continue;

         switch(e.type.toLowerCase())
         {
            case "text" :
            case "textarea" :
            {
               val=e.value;
               break;
            }
            case "select-one" :
            {
               val=e.options[e.selectedIndex].value;
               break;
            }
            default :
            {
               val="";
               break;
            }
         }

         if(e.Required)
           OkRequired=!IsBlank(val);
         else
           OkRequired=true;

         if(e.typeofStore)
         {
           switch(e.typeofStore.toLowerCase())
            {
               case "int" :
               {
                  OkType=IsInt(val);
                  break;
               }
               case "double" :
               {
                  OkType=IsDouble(val);
                  break;
               }
               default :
               {
                  OkType=false;
                  break;
               }
            }
         }
         else
           OkType=true;

         if(!OkRequired || !OkType)
           e.style.backgroundColor=aInvalidColor;
         else
           e.style.backgroundColor="";
      }
   }

   for(var iFrame=0; iFrame<aWin.frames.length; ++iFrame)
   {
      CheckEmptyType(aWin.frames[iFrame],aInvalidColor);
   }
}

var
  handler;

function delaySet(obj, val, mSec)
{
   handler=setInterval(function(){MakeDalay(obj,val)},mSec);
}

function MakeDalay(obj, val)
{
   clearInterval(handler);
   obj.style.backgroundColor=val;
}

function FlashControl(aWin,aInvalidColor)
{
   var
     e,
     currColor,
     tmpObj;

   for(var iForm=0; iForm<aWin.document.forms.length; ++iForm)
   {
      for(var iElement=0; iElement<aWin.document.forms[iForm].length; ++iElement)
      {
         e=aWin.document.forms[iForm].elements[iElement];
         if(e.style.backgroundColor)
         {
            currColor=e.style.backgroundColor;
            currColor=currColor.replace(/\s/g,"");
            if(currColor==aInvalidColor)
            {
               if(tmpObj = (aWin.parent!=aWin.self) ? document.getElementById(aWin.name) : e)
               {
                 if((tmpObj=tmpObj.parentNode) && tmpObj.className.toLowerCase()=="tab-page")
                   tmpObj.tabPage.select();
               }
               if(aWin.parent!=aWin.self)
               {     
                  if((tmpObj=idxFrame(aWin))!=-1)
                    aWin.parent.frames[tmpObj].focus();
               }
               e.focus();
               e.style.backgroundColor='red';
               delaySet(e,aInvalidColor,250);
               return(false);
            }
         }
      }
   }

   for(var iFrame=0; iFrame<aWin.frames.length; ++iFrame)
      if(!FlashControl(aWin.frames[iFrame],aInvalidColor))
        return(false);

   return(true);
}

function idxFrame(aFrame)
{
   var
     result=-1;

   if(aFrame.parent==aFrame.self)
     return(result);

   if(("name" in aFrame) && (aFrame.name.length!=0))
     for(var i=0; aFrame.parent.frames.length; ++i)
        if(aFrame.parent.frames[i].name==aFrame.name)
        {
           result=i;
           break;
        }

   return(result);
}