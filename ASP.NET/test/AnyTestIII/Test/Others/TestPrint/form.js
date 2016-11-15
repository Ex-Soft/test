var
  Defs,
  idxDefs,
  DDLElement=new Array(),
  RuleValues=new Array(),
  InvalidColor="rgb(255,191,191)",
  hTimerPrepareForm,
  hTimerFlashControl;

function DDLChanged(aDDLId)
{
   var
     DDL=document.getElementById(aDDLId);

   if(!DDL
      || (DDL.options.length==1 && IsBlank(DDL.options[0].value)))
     return;

   for(var i=0; i<DDLElement.length; ++i)
      if(DDLElement[i]==aDDLId)
        return;

   DDLElement.push(aDDLId);

   for(var i=0; i<DDL.options.length; ++i)
   {
      if(IsBlank(DDL.options[i].value))
      {
         DDL.remove(i);
         break;  
      }
   }
}

function TableBody(aTableId)
{
   var
     oTableBody=null,
     oTable = typeof(aTableId)=="string" ? document.getElementById(aTableId) : aTableId;

   if(oTable==null || oTable==undefined)
     return(oTableBody);
  
   for(var i=0; i<oTable.childNodes.length; ++i)
      if(oTable.childNodes[i].nodeType==1 && oTable.childNodes[i].nodeName.toLowerCase()=="tbody")
        {
           oTableBody=oTable.childNodes[i];
           break;
        }
        
   return(oTableBody);
}

function firstRule(ElementId)
{
   var
     element = typeof(ElementId)=="string" ? document.getElementById(ElementId) : ElementId,
     rule=null,
     FoundRule;

   if(rule=TableBody(element))
   {
      rule=rule.firstChild;
      FoundRule=false;
      while(!FoundRule && rule)
      {
         if(!(FoundRule=rule.nodeType==1 && rule.nodeName.toLowerCase()=="tr"))
           rule=rule.nextSibling;
      }
   }

   return(rule);
}

function nextRule(RuleId)
{
   var
     rule = typeof(RuleId)=="string" ? document.getElementById(RuleId) : RuleId,
     FoundRule=false;

   while(!FoundRule && rule)
   {
      if(rule=rule.nextSibling)
        FoundRule=rule.nodeType==1 && rule.nodeName.toLowerCase()=="tr";
   }

   return(rule);
}

function previousRule(RuleId)
{
   var
     rule = typeof(RuleId)=="string" ? document.getElementById(RuleId) : RuleId,
     FoundRule=false;

   while(!FoundRule && rule)
   {
      if(rule=rule.previousSibling)
        FoundRule=rule.nodeType==1 && rule.nodeName.toLowerCase()=="tr";
   }

   return(rule);
}

function getRuleValues(oRule,arrValue)
{
   for(var td=0; td<oRule.cells.length; ++td)
      for(var i=0; i<oRule.cells[td].childNodes.length; ++i)
         if(oRule.cells[td].childNodes[i].nodeType==3 && oRule.cells[td].childNodes[i].nodeName.toLowerCase()=="#text")
           arrValue.push(oRule.cells[td].childNodes[i].nodeValue);

   return(arrValue);
}

function PrepareForm(DefinitionName)
{
   var
     tmpObj,
     i,
     values=new Array();

   if(arguments.length==1 && typeof(DefinitionName)=="string")
   {
      if(!frames.length)
        return;

      Defs=null;
      idxDefs=-1;
      for(i=0; i<self.frames.length; ++i)
         if(self.frames[i].name==DefinitionName)
         {
            Defs=self.frames[i];
            idxDefs=i;
            break;
         }
      
      if(Defs==null || Defs==undefined)
        throw new Error("Unknown frame: \""+DefinitionName+"\"");

      if(!Defs.IsLoad)
        return;

      clearInterval(hTimerPrepareForm);

      for(var iForm=0; iForm<self.document.forms.length; ++iForm)
         for(i=0; i<self.document.forms[iForm].length; ++i)
         {
            if(!("id" in self.document.forms[iForm].elements[i])
               || self.document.forms[iForm].elements[i].id==null
               || self.document.forms[iForm].elements[i].id==undefined
               || self.document.forms[iForm].elements[i].id.length==0)
            continue;

            if(tmpObj=Defs.document.getElementById(self.document.forms[iForm].elements[i].id))
            {
               for(tmpObj=firstRule(tmpObj); tmpObj; tmpObj=nextRule(tmpObj))
               {  
                  RuleValues.length=0;
                  RuleValues=getRuleValues(tmpObj,RuleValues);

                  if(RuleValues.length==0)
                    continue; 

                  self.document.forms[iForm].elements[i].CheckValid=true;

                  switch(tmpObj.id)
                  {
                     case "Required" :
                     {
                        self.document.forms[iForm].elements[i].Required=eval(RuleValues[0]);

                        break;
                     }
                     case "typeofStore" :
                     {
                        self.document.forms[iForm].elements[i].typeofStore=RuleValues[0];

                        break;
                     }
                     case "Min" :
                     {
                        self.document.forms[iForm].elements[i].Min=eval(RuleValues[0]);

                        break;
                     }
                     case "Max" :
                     {
                        self.document.forms[iForm].elements[i].Max=eval(RuleValues[0]);

                        break;
                     }
                     case "Calculate" :
                     {
                        self.document.forms[iForm].elements[i].Calculate=eval(RuleValues[0]);

                        break;
                     }
                  }
               }
            }
         }
   }

   if(("CheckElement" in this)
      && (CheckElement instanceof Array))
   {
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
            if("Min" in CheckElement[i])
              tmpObj.Min=CheckElement[i].Min;
            if("Max" in CheckElement[i])
              tmpObj.Max=CheckElement[i].Max;
            if(CheckElement[i].Calculate)
              tmpObj.Calculate=CheckElement[i].Calculate;
         }
      }
   }

   CheckEmpty(self,InvalidColor);
}

function CheckEmpty(aWin,aInvalidColor)
{
   var
     e,
     val,
     OkRequired,
     OkType,
     OkMin,
     OkMax,
     CheckRange;

   for(var iForm=0; iForm<aWin.document.forms.length; ++iForm)
   {
      for(var iElement=0; iElement<aWin.document.forms[iForm].length; ++iElement)
      {
         e=aWin.document.forms[iForm].elements[iElement];

         if(!("CheckValid" in e))
           continue;

         if(e.CheckValid)
         {
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
                  val = e.options.length!=0 ? e.options[e.selectedIndex].value : "";
                  break;
               }
               default :
               {
                  val="";
                  break;
               }
            }

            if(!e.readOnly && e.Required)
              OkRequired=!IsBlank(val);
            else
              OkRequired=true;

            if(!e.readOnly && e.typeofStore)
            {
               CheckRange=false;
               switch(e.typeofStore.toLowerCase())
               {
                  case "int" :
                  {
                     OkType=IsInt(val);
                     CheckRange=true;
                     break;
                  }
                  case "double" :
                  {
                     OkType=IsDouble(val);
                     CheckRange=true;
                     break;
                  }
                  case "char" :
                  {
                     OkType=IsAlpha(val) || IsCyrillic(val);
                     break;
                  }
                  case "charlat" :
                  {
                     OkType=IsAlpha(val);
                     break;
                  }
                  case "charcyr" :
                  {
                     OkType=IsCyrillic(val);
                     break;
                  }
                  default :
                  {
                     OkType=false;
                     break;
                  }
               }

               OkMin=OkMax=true;
               if(OkType && CheckRange)
               {
                  val=ToDouble(val);

                  if("Min" in e)
                    OkMin = val>=e.Min;

                  if("Max" in e)
                    OkMax = val<=e.Max;
               }
            }
            else
            {
               OkType=OkMin=OkMax=true;
            }

            if(!OkRequired || !OkType || !OkMin || !OkMax)
              e.style.backgroundColor=aInvalidColor;
            else
              e.style.backgroundColor="";
         }
         else
           e.style.backgroundColor="";
      }
   }

   for(var iFrame=0; iFrame<aWin.frames.length; ++iFrame)
   {
      CheckEmpty(aWin.frames[iFrame],aInvalidColor);
   }
}

function delaySet(obj, val, mSec)
{
   hTimerFlashControl=setInterval(function(){MakeDalay(obj,val)},mSec);
}

function MakeDalay(obj, val)
{
   clearInterval(hTimerFlashControl);
   obj.style.backgroundColor=val;
}

function FlashControl(aWin, aInvalidColor, OnlyCalculate)
{
   var
     e,
     currColor,
     tmpObj;

   //if(OnlyCalculate==undefined)
   //  OnlyCalculate=false;

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
               if(OnlyCalculate
                  && (!("Calculate" in e)
                      || (("Calculate" in e) && !e.Calculate)))
                 continue;
                  
               if(tmpObj = (aWin.parent!=aWin.self) ? document.getElementById(aWin.name) : e)
               {
                  while(tmpObj=tmpObj.parentNode)
                  {
                     if(("className" in tmpObj)
                        && tmpObj.className.toLowerCase()=="tab-page")
                       tmpObj.tabPage.select();
                  }
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
      if(!FlashControl(aWin.frames[iFrame],aInvalidColor,OnlyCalculate))
        return(false);

   return(true);
}

function idxFrame(aFrame)
{
   var
     result=-1,
     i;

   if(typeof(RuleId)=="string")
   {
      for(i=0; i<frames.length; ++i)
         if(frames[i].name==aFrame)
         {
            result=i;
            break;
         }
   }
   else
   {
      if(aFrame.parent==aFrame.self)
        return(result);

      if(("name" in aFrame) && (aFrame.name.length!=0))
        for(i=0; aFrame.parent.frames.length; ++i)
           if(aFrame.parent.frames[i].name==aFrame.name)
           {
              result=i;
              break;
           }
   }

   return(result);
}

function SetCheckValid(obj, val)
{
   if("CheckValid" in obj)
   {
     obj.CheckValid=val;
     if(!val)
       obj.style.backgroundColor="";
   }

   if(("childNodes" in obj) && ("length" in obj.childNodes))
     for(var i=0; i<obj.childNodes.length; ++i)
        SetCheckValid(obj.childNodes[i],val);
}

function ResetValue(obj)
{
   var
     i;

   if("CheckValid" in obj)
   {
      switch(obj.type.toLowerCase())
      {
         case "text" :
         case "textarea" :
         {
            obj.value="";
            break;
         }
         case "select-one" :
         {
            var
              Exists=false,
              BlankOption=new Option(" "," ",true,true);

            for(i=0; i<obj.options.length; ++i)
            {
               if(IsBlank(obj.options[i].value))
               {
                  Exists=true;
                  break;  
               }
            }

            if(Exists)
              obj.selectedIndex=i;
            else
            {
               obj.options.add(BlankOption,0);
               obj.selectedIndex=0;

               for(i=0; i<DDLElement.length; ++i)
                  if(DDLElement[i]==obj.id)
                  {
                     DDLElement.splice(i,1);
                     break;
                  }
            }

            break;
         }
      }
   }

   if(("childNodes" in obj) && ("length" in obj.childNodes))
     for(i=0; i<obj.childNodes.length; ++i)
        ResetValue(obj.childNodes[i]);
}

function CheckEmptyDivCheckBox(obj)
{
   var
     Empty=true;

   if(("type" in obj) && (obj.type.toLowerCase()=="checkbox"))
   {
      Empty=!obj.checked;
      return(Empty);
   }

   if(("childNodes" in obj) && ("length" in obj.childNodes) && Empty)
     for(var i=0; i<obj.childNodes.length && Empty; ++i)
        Empty&=CheckEmptyDivCheckBox(obj.childNodes[i]);
   
   return(Empty);
}

function ResetDivCheckBox(obj)
{
   if(("type" in obj) && (obj.type.toLowerCase()=="checkbox"))
   {
      obj.checked=false;
      return;
   }

   if(("childNodes" in obj) && ("length" in obj.childNodes))
     for(var i=0; i<obj.childNodes.length; ++i)
        ResetDivCheckBox(obj.childNodes[i]);
}

function CheckValidDate(YearId, MonthId, DayId, aInvalidColor)
{
   var
     DayCtrl=document.getElementById(DayId),
     MonthCtrl=document.getElementById(MonthId),
     YearCtrl=document.getElementById(YearId),
     day=null,
     month=null,
     year=null,
     result=false;

   if(DayCtrl==null
      || DayCtrl==undefined
      || MonthCtrl==null
      || MonthCtrl==undefined
      || YearCtrl==null
      || YearCtrl==undefined)
   return(result);

   if(!IsInt(DayCtrl.value))
   {
     DayCtrl.style.backgroundColor=aInvalidColor;
     return(result);
   }
   day=ToInt(DayCtrl.value);

   if(!IsInt(MonthCtrl.value))
   {
     MonthCtrl.style.backgroundColor=aInvalidColor;
     return(result);
   }
   month=ToInt(MonthCtrl.value);

   if(!IsInt(YearCtrl.value))
   { 
     YearCtrl.style.backgroundColor=aInvalidColor;
     return(result);
   }
   year=ToInt(YearCtrl.value);

   switch(CheckDate(year,month,day))
   {
      case 0 :
      {
         result=true;
         break;
      }
      case 2 :
      {
         MonthCtrl.style.backgroundColor=aInvalidColor;
         break;
      }
      case 3 :
      {
         DayCtrl.style.backgroundColor=aInvalidColor;
         break;
      }
   }

   return(result);
}

function MergeDate(YearId, MonthId, DayId)
{
   var
     DayCtrl=document.getElementById(DayId),
     MonthCtrl=document.getElementById(MonthId),
     YearCtrl=document.getElementById(YearId),
     day=null,
     month=null,
     year=null,
     result=NaN;

   if(DayCtrl==null
      || DayCtrl==undefined
      || MonthCtrl==null
      || MonthCtrl==undefined
      || YearCtrl==null
      || YearCtrl==undefined)
   return(result);

   if(!IsInt(DayCtrl.value))
     return(result);
   day=ToInt(DayCtrl.value);

   if(!IsInt(MonthCtrl.value))
     return(result);
   month=ToInt(MonthCtrl.value);

   if(!IsInt(YearCtrl.value))
     return(result);
   year=ToInt(YearCtrl.value);

   if(CheckDate(year,month,day)==0)
     result=new Date(year,month-1,day);

   return(result);
}

function SplitDate(aDate, YearId, MonthId, DayId)
{
   var
     DayCtrl=document.getElementById(DayId),
     MonthCtrl=document.getElementById(MonthId),
     YearCtrl=document.getElementById(YearId);

   if(DayCtrl==null
      || DayCtrl==undefined
      || MonthCtrl==null
      || MonthCtrl==undefined
      || YearCtrl==null
      || YearCtrl==undefined)
   return;

   DayCtrl.value=PadL(aDate.getDate().toString(),2,"0");
   MonthCtrl.value=PadL((aDate.getMonth()+1).toString(),2,"0");
   YearCtrl.value=aDate.getFullYear().toString();
}

function SetDateColor(YearId, MonthId, DayId, aColorValue)
{
   var
     DayCtrl=document.getElementById(DayId),
     MonthCtrl=document.getElementById(MonthId),
     YearCtrl=document.getElementById(YearId);

   if(DayCtrl==null
      || DayCtrl==undefined
      || MonthCtrl==null
      || MonthCtrl==undefined
      || YearCtrl==null
      || YearCtrl==undefined)
   return;

   DayCtrl.style.backgroundColor=aColorValue;
   MonthCtrl.style.backgroundColor=aColorValue;
   YearCtrl.style.backgroundColor=aColorValue;
}

function offsetSummary(obj,side)
{
   var
     offSum=0,
     p=obj.offsetParent;

   switch(side.toLowerCase())
   {
      case "top" :
      {
         offSum+=obj.offsetTop;
         break;
      }
      case "left" :
      {
         offSum+=obj.offsetLeft;
         break;
      }
   }

   while(p)
   {
      switch(side.toLowerCase())
      {
         case "top" :
         {
            offSum+=p.offsetTop;
            break;
         }
         case "left" :
         {
            offSum+=p.offsetLeft;
            break;
         }
      }
      if(!p.offsetParent)
      {
         switch(side.toLowerCase())
         {
            case "top" :
            {
               offSum+=p.offsetTop;
               break;
            }
            case "left" :
            {
               offSum+=p.offsetLeft;
               break;
            }
         }
      }

      p=p.offsetParent;
   }

   return(offSum);
}

function SetBackgroundColor(objId, color)
{
   var
     Ctrl;

   if(Ctrl = typeof(objId)=="string" ? document.getElementById(objId) : objId)
     Ctrl.style.backgroundColor=color;
}

function ShowDiv(divId,aShow)
{
   var
     div=document.getElementById(divId),
     val=aShow ? "block" : "none";

   if(!div
      || (!aShow && div.style.display=="none")
      || (aShow && div.style.display=="block"))
   return;

   div.style.display=val;
}

function ReadCookie(aName)
{
	var
		AllCookies=document.cookie,
		pos,
		value=null;

	if(typeof(aName)!="string"
	|| !aName.length)
		return(value);

	aName+="=";
	if((pos=AllCookies.indexOf(aName))!=-1)
	{
		value=AllCookies.substring(pos+aName.length);
		if((pos=value.indexOf(";"))!=-1)
			value=value.substring(0,pos);  
	}

	return(value);
}

function WriteCookie(aName, aValue)
{
	var
		NextYear=new Date();

	if(typeof(aName)!="string"
	|| !aName.length
	|| typeof(aValue)!="string"
	|| !aValue.length)
		return;

	aName+="=";
	NextYear.setFullYear(NextYear.getFullYear()+1);
	document.cookie=aName+aValue+";expires="+NextYear.toGMTString()+";path=/";
}

function FindMaxId(aTableId, aMarkerName)
{
	var
		oTBody=TableBody(aTableId),
		Rows=oTBody.rows,
		Cells,
		Entry,
		tmpId,
		MaxId=-1;

	for(var row=0; row<Rows.length; ++row)
	{
		Cells=Rows[row].cells;
		for(var cell=0; cell<Cells.length; ++cell)
		{
			Entry=Cells[cell].childNodes;
			for(var e=0; e<Entry.length; ++e)
			{
				if(("id" in Entry[e])
					&& Entry[e])
				{
					if(Entry[e].id.substring(0,aMarkerName.length)==aMarkerName)
					{
						if((tmpId=Entry[e].id.substring(aMarkerName.length))!="")
						{
							tmpId=parseInt(tmpId,10);
							if(MaxId<tmpId)
								MaxId=tmpId;
						}
					}
				}
			}
		}
	}

	return(MaxId);
}

function FindTableParent(obj)
{
	var
		table=null,
		tmpObj=obj;

	do
	{
		if(tmpObj.nodeType==1 && tmpObj.nodeName.toLowerCase()=="table")
		{
			table=tmpObj;
			break;
		}
	}while(tmpObj=tmpObj.parentNode);

	return(table);
}

function FindMarker(aRow, aMarkerName)
{
	var
		Marker=null,
		Cells=aRow.cells,
		Entry;

	for(var c=0; c<Cells.length; ++c)
	{
		Entry=Cells[c].childNodes;
		for(var e=0; e<Entry.length; ++e)
		{
			if(Entry[e].id!=null && Entry[e].id!=undefined)
			{
				if(Entry[e].id.substring(0,aMarkerName.length)==aMarkerName)
				{
					Marker=Entry[e];
					break;
				}
			}
		}
		if(Marker!=null)
			break;
	}

	return(Marker);
}

function IsExistsInTable(aTableId, aId, CtrlSignature)
{
	var
		oTBody=TableBody(aTableId),
		Ctrl,
		Exists=false,
		MaxRow;

	MaxRow=FindMaxId(aTableId,CtrlSignature);

	for(var i=1; i<=MaxRow; ++i)
		if((Ctrl=document.getElementById(CtrlSignature+i)) && parseInt(Ctrl.value,10)==aId)
		{
			Exists=true;
			break;
		}

	return(Exists);
}

function ClearTable(aTableId, aFixedRows)
{
	var
		oTBody;

	if(oTBody=TableBody(aTableId))
		for(var i=oTBody.rows.length-aFixedRows; i>0; --i)
			oTBody.deleteRow(aFixedRows);
}

function GetCtrlsByIdName(aDocument, aCtrlId, aTag)
{
	var
		Ctrl,
		Ctrls=new Array(),
		CtrlsByTag;

	if(Ctrl=aDocument.getElementById(aCtrlId))
		Ctrls[0]=Ctrl;
	else
	{
		if(aDocument.all)
		{
			if(aTag)
			{
				CtrlsByTag=aDocument.getElementsByTagName(aTag);
				for(var i=0; i<CtrlsByTag.length; ++i)
					if(CtrlsByTag[i].name==aCtrlId
						|| CtrlsByTag[i].getAttribute("name")==aCtrlId)
					Ctrls.push(CtrlsByTag[i]);
			}
		}
		else
			Ctrls=aDocument.getElementsByName(aCtrlId);
	}

	return(Ctrls);
}

function GetCtrlValue(aCtrl)
{
	var
		OutputValue="";

	switch(aCtrl.nodeName.toLowerCase())
	{
		case "span" :
		{
			OutputValue=aCtrl.innerHTML;
			break;
		}
		default :
		{
			switch(aCtrl.type.toLowerCase())
			{
				case "text" :
				case "textarea" :
				{
					OutputValue=aCtrl.value;
					break;
				}
				case "select-one" :
				{
					OutputValue = aCtrl.options.length ? aCtrl.options[aCtrl.selectedIndex].text : "";
					break;
				}
			}
		}
	}

	return(OutputValue);
}

function SetCtrlValue(aCtrl, aValue)
{
	switch(aCtrl.nodeName.toLowerCase())
	{
		case "span" :
		{
			aCtrl.innerHTML=aValue;
			break;
		}
		default :
		{
			switch(aCtrl.type.toLowerCase())
			{
				case "text" :
				case "textarea" :
				{
					aCtrl.value=aValue;
					break;
				}
			}
		}
	}
}

function GetParentCell(obj)
{
	var
		Cell=null,
		tmpObj=obj;

	do
	{
		if(tmpObj.nodeType==1 && tmpObj.nodeName.toLowerCase()=="td")
		{
			Cell=tmpObj;
			break;
		}
	}while(tmpObj=tmpObj.parentNode);

	return(Cell);
}

function GetParentRow(obj)
{
	var
		Cell;

	return((Cell=GetParentCell(obj)) ? Cell.parentNode : Cell);
}

function RowGetElementsByName(aRow,aTag,aName)
{
	var
		OutputArray=new Array(),
		CtrlsByTag=aRow.getElementsByTagName(aTag);

	for(var i=0; i<CtrlsByTag.length; ++i)
		if(CtrlsByTag[i].name==aName
			|| CtrlsByTag[i].getAttribute("name")==aName)
		OutputArray.push(CtrlsByTag[i]);

	return(OutputArray);
}

function RowGetElementsByClassName(aRow,aTag,aClassName)
{
	var
		OutputArray=new Array(),
		CtrlsByTag;

	for(var i=0; i<aRow.cells.length; ++i)
	{
		CtrlsByTag=aRow.cells[i].getElementsByTagName(aTag);
		for(var ii=0; ii<CtrlsByTag.length; ++ii)
			if(CtrlsByTag[ii].className.substring(0,aClassName.length)==aClassName)
				OutputArray.push(CtrlsByTag[ii]);
	}

	return(OutputArray);
}
