var
	OutputDocument,
	FrameDefinitionName,
	FileDefinitionName,
	TemplateName,
	TemplateURL,
	OutputCtrlsRelations=new Array();

function Print2HTML(aOutputDocument, aFrameDefinitionName, aFileDefinitionName, aTemplateName, aTemplateURL)
{
	OutputDocument=aOutputDocument;
	FrameDefinitionName=aFrameDefinitionName;
	FileDefinitionName=aFileDefinitionName;
	TemplateName=aTemplateName;
	TemplateURL=aTemplateURL;

	LoadOutputCtrlsRelationsDefs(aOutputDocument,aFrameDefinitionName,aFileDefinitionName,aTemplateURL);
}

function LoadOutputCtrlsRelationsDefs(aOutputDocument, aFrameDefinitionName, aFileDefinitionName, aTemplateURL)
{
	var
		def;

	if(!(def=aOutputDocument.getElementById(aFrameDefinitionName)))
		return;

	if("attachEvent" in def)
		def.attachEvent("onload",GetOutputCtrlsRelations);
	else if("addEventListener" in def)
		def.addEventListener("load",GetOutputCtrlsRelations,false);
	else
		def.onload=GetOutputCtrlsRelations;

	def.src=aOutputDocument.location.protocol+"//"+aOutputDocument.location.host+"/"+aTemplateURL+(!IsBlank(aTemplateURL) ? "/" : "")+aFileDefinitionName;
}

function GetOutputCtrlsRelations()
{
	var
		def,
		OutputCtrlId,
		ob,
		tmpObj,
		RuleValues=new Array();

	if(!(def=OutputDocument.getElementById(FrameDefinitionName)))
		return;

	if("detachEvent" in def)
		def.detachEvent("onload",GetOutputCtrlsRelations);

	OutputCtrlsRelations.length=0;

	for(var i=0; i<def.contentWindow.document.body.childNodes.length; ++i)
	{
		if(def.contentWindow.document.body.childNodes[i].nodeType==1
		&& def.contentWindow.document.body.childNodes[i].nodeName.toLowerCase()=="table")
		{
			OutputCtrlId=def.contentWindow.document.body.childNodes[i].id;
			ob=new Object();
			for(tmpObj=firstRule(def.contentWindow.document.body.childNodes[i]); tmpObj; tmpObj=nextRule(tmpObj))
			{
				RuleValues.length=0;
				RuleValues=getRuleValues(tmpObj,RuleValues);

				if(RuleValues.length==0)
					continue;

				switch(tmpObj.id)
				{
					case "InputCtrlId" :
					{
						ob.InputId=RuleValues[0];
						break;
					}
					case "InTable" :
					{
						ob.InTable=eval(RuleValues[0]);
						break;
					}
					case "className" :
					{
						ob.className=RuleValues[0];
						break;
					}
					case "Frame" :
					{
						ob.Frame=RuleValues[0];
						break;
					}
				}
			}
			OutputCtrlsRelations[OutputCtrlId]=ob;
		}
	}

	OpenHTMLDocTemplate(OutputDocument.location.protocol+"//"+OutputDocument.location.host+"/"+TemplateURL+(!IsBlank(TemplateURL) ? "/" : "")+TemplateName);
}

function OpenHTMLDocTemplate(aTemplateURL)
{
	window.open(aTemplateURL,"Template","location=no,menubar=yes,scrollbars=yes,status=yes,resizable=1");
}

function Output2HTML(aInputDocument)
{
	var
		OutputCtrls,
		OutputValue,
		InputCtrls,
		OutputRow,
		OutputTablesValues=new Array(),
		OutputCtrlId,
		InputRowCtrls,
		tBody,
		NewRow,
		i,
		ii;

	for(OutputCtrlId in OutputCtrlsRelations)
	{
		OutputCtrls=GetCtrlsByIdName(OutputDocument,OutputCtrlId,"span");
		for(i=0; i<OutputCtrls.length; ++i)
		{
			if(OutputCtrlsRelations[OutputCtrlId].InTable)
			{
				if(OutputCtrlsRelations[OutputCtrlId].className
					&& OutputCtrls[i].className!=OutputCtrlsRelations[OutputCtrlId].className)
					continue;

				if(OutputRow=GetParentRow(OutputCtrls[i]))
				{
					if(!OutputTablesValues[OutputCtrlId])
						OutputTablesValues[OutputCtrlId]={IsOutput: false, Values: new Array()};
					OutputTablesValues[OutputCtrlId].Values[OutputRow.rowIndex]=GetCtrlValue(OutputCtrls[i]);
				}
			}
			else
			{
				OutputValue=GetCtrlValue(OutputCtrls[i]);
				InputCtrls=GetCtrlsByIdName(aInputDocument,OutputCtrlsRelations[OutputCtrlId].InputId);
				for(ii=0; ii<InputCtrls.length; ++ii)
					InputCtrls[ii].innerHTML=OutputValue;
			}
		}
	}

	for(OutputCtrlId in OutputTablesValues)
	{
		if(OutputTablesValues[OutputCtrlId].IsOutput)
			continue;

		InputCtrls=GetCtrlsByIdName(aInputDocument,OutputCtrlsRelations[OutputCtrlId].InputId,"span");
		if(!InputCtrls.length)
			continue;

		if(OutputRow=GetParentRow(InputCtrls[0]))
		{
			tBody=OutputRow.parentNode;

			InputRowCtrls=GetRowCtrls(OutputRow,OutputCtrlsRelations);
			if(!InputRowCtrls.length)
				continue;

			for(i=0; i<OutputTablesValues[OutputCtrlId].Values.length; ++i)
			{
				if(!OutputTablesValues[OutputCtrlId].Values[i])
					continue;

				NewRow=OutputRow.cloneNode(true);

				for(ii=0; ii<InputRowCtrls.length; ++ii)
				{
					InputCtrls=RowGetElementsByName(NewRow,"span",InputRowCtrls[ii].InputId);
					for(var iii=0; iii<InputCtrls.length; ++iii)
						InputCtrls[iii].innerHTML=OutputTablesValues[InputRowCtrls[ii].OutputCtrlId].Values[i];

					if(!OutputTablesValues[InputRowCtrls[ii].OutputCtrlId].IsOutput)
						OutputTablesValues[InputRowCtrls[ii].OutputCtrlId].IsOutput=true;
				}

				tBody.appendChild(NewRow);
			}
		}
	}
}

function GetRowCtrls(aRow,aOutputCtrlsRelations)
{
	var
		OutputArray=new Array(),
		Spans,
		re;

	for(var i=0; i<aRow.cells.length; ++i)
	{
		Spans=aRow.cells[i].innerHTML.match(/<span.*?>/ig);
		if(Spans.length==0)
			continue;

		for(var OutputCtrlId in aOutputCtrlsRelations)
		{
			if(!aOutputCtrlsRelations[OutputCtrlId].InTable)
				continue;

			re=new RegExp("name=\""+aOutputCtrlsRelations[OutputCtrlId].InputId+"\"","i");
			for(var ii=0; ii<Spans.length; ++ii)
				if(Spans[ii].search(re)!=-1)
					OutputArray.push({OutputCtrlId:OutputCtrlId, InputId:aOutputCtrlsRelations[OutputCtrlId].InputId});
		}
	}
	return(OutputArray);
}

function FillDocument()
{
	if(!("CtrlsValues" in this)
		|| !(CtrlsValues instanceof Array))
		return;

	var
		Ctrl,
		CtrlId,
		InputCtrls,
		OutputRow,
		tBody,
		NewRow,
		InputCtrlsII;

	for(CtrlId in CtrlsValues)
	{
		if(typeof(CtrlsValues[CtrlId])=="string")
		{
			if(Ctrl=document.getElementById(CtrlId))
				SetCtrlValue(Ctrl,CtrlsValues[CtrlId]);
		}
		else
		{
			if(CtrlsValues[CtrlId].IsOutput)
				continue;

			InputCtrls=GetCtrlsByIdName(document,CtrlId,"span");
			if(!InputCtrls.length)
				continue;

			if(OutputRow=GetParentRow(InputCtrls[0]))
			{
				tBody=OutputRow.parentNode;
				for(var i=0; i<CtrlsValues[CtrlId].Values.length; ++i)
				{
					if(!CtrlsValues[CtrlId].Values[i])
						continue;

					NewRow=OutputRow.cloneNode(true);
					for(var CtrlIdII in CtrlsValues)
					{
						if(typeof(CtrlsValues[CtrlIdII])=="string")
							continue;

						InputCtrlsII=RowGetElementsByName(NewRow,"span",CtrlIdII);
						for(var ii=0; ii<InputCtrlsII.length; ++ii)
						{
							SetCtrlValue(InputCtrlsII[ii],CtrlsValues[CtrlIdII].Values[i]);
							if(!CtrlsValues[CtrlIdII].IsOutput)
								CtrlsValues[CtrlIdII].IsOutput=true;
						}
					}
					tBody.appendChild(NewRow);
				}
			}
		}
	}
}