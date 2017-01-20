var
	Ctrls=new Array();

function OnLoad()
{
	var
		Ctrl;

	ReadDefs("CtrlDefinitions");
	PrepareForm();

	if(Ctrl=document.getElementById("DivPreLoad"))
		Ctrl.style.display="none";
	if(Ctrl=document.getElementById("DivMainForm"))
		Ctrl.style.display="";
}

function firstControl(FrameDef)
{
	var
		Frame,
		Ctrl=null,
		CtrlFound=false;

	if(!(Frame = typeof(FrameDef)=="string" ? document.getElementById(FrameDef) : FrameDef))
		return(Ctrl);

	Ctrl=Frame.contentWindow.document.body.firstChild;
	while(!CtrlFound && Ctrl)
		if(!(CtrlFound = Ctrl.nodeType==1 && Ctrl.nodeName.toLowerCase()=="table"))
			Ctrl=Ctrl.nextSibling;

	return(Ctrl);
}

function nextControl(Ctrl, FrameDef)
{
	var
		Frame,
		CtrlFound=false;

	if(typeof(Ctrl)=="string")
	{
		if(FrameDef)
		{
			if(!(Frame = typeof(FrameDef)=="string" ? document.getElementById(FrameDef) : FrameDef))
				return(null);
			Ctrl=Frame.contentWindow.document.getElementById(Ctrl);
		}
		else
			Ctrl=null;
	}

	while(!CtrlFound && Ctrl)
	{
		if(Ctrl=Ctrl.nextSibling)
			CtrlFound = Ctrl.nodeType==1 && Ctrl.nodeName.toLowerCase()=="table";
	}

	return(Ctrl);
}

function TableBody(Table, FrameDef)
{
	var
		Frame,
		TableBody=null;

	if(typeof(Table)=="string")
	{
		if(FrameDef)
		{
			if(!(Frame = typeof(FrameDef)=="string" ? document.getElementById(FrameDef) : FrameDef))
				return(null);
			Table=Frame.contentWindow.document.getElementById(Table);
		}
		else
			Table=null;
	}

	if(!Table)
		return(TableBody);
  
	for(var i=0; i<Table.childNodes.length; ++i)
		if(Table.childNodes[i].nodeType==1 && Table.childNodes[i].nodeName.toLowerCase()=="tbody")
        	{
			TableBody=Table.childNodes[i];
			break;
		}
        
	return(TableBody);
}

function firstDef(Ctrl)
{
	var
		def=null,
		FoundDef=false;

	if(def=TableBody(Ctrl))
	{
		def=def.firstChild;
		while(!FoundDef && def)
		{
			if(!(FoundDef=def.nodeType==1 && def.nodeName.toLowerCase()=="tr"))
				def=def.nextSibling;
		}
	}

	return(def);
}

function nextDef(def)
{
	var
		FoundDef=false;

	while(!FoundDef && def)
	{
		if(def=def.nextSibling)
			FoundDef=def.nodeType==1 && def.nodeName.toLowerCase()=="tr";
	}

	return(def);
}

function previousDef(def)
{
	var
		FoundDef=false;

	while(!FoundDef && def)
	{
		if(def=def.previousSibling)
			FoundDef=def.nodeType==1 && def.nodeName.toLowerCase()=="tr";
	}

	return(def);
}

function getDefValues(oDef, arrValue)
{
	for(var td=0; td<oDef.cells.length; ++td)
		for(var i=0; i<oDef.cells[td].childNodes.length; ++i)
			if(oDef.cells[td].childNodes[i].nodeType==3 && oDef.cells[td].childNodes[i].nodeName.toLowerCase()=="#text")
				arrValue.push(oDef.cells[td].childNodes[i].nodeValue);

	return(arrValue);
}

function ReadDefs(FrameDef)
{
	var
		Ctrl,
		Def,
		DefValues=new Array(),
		tmpStr;

	if(!(Ctrl = typeof(FrameDef)=="string" ? document.getElementById(FrameDef) : FrameDef))
		return;

	for(Ctrl=firstControl(Ctrl); Ctrl; Ctrl=nextControl(Ctrl))
	{
		obj=new Object();
		obj.id=Ctrl.id;
		for(Def=firstDef(Ctrl); Def; Def=nextDef(Def))
		{
			DefValues.length=0;
			DefValues=getDefValues(Def,DefValues);
			if(DefValues.length==0)
				continue;

			switch(tmpStr=Def.id.toLowerCase())
			{
				case "type" :
				case "parent" :
				case "name" :
				case "value" :
				case "cssclass" :
				case "text" :
				case "textalign" :
				case "eventlistener" :
				case "eventfunction" :
				case "varname" :
				{
					eval("obj."+tmpStr+"=\""+DefValues[0]+"\"");
					break;
				}
				case "withbr" :
				case "iscalculated" :
				case "defaultvalue" :
				case "checkedvalue" :
				{
					eval("obj."+tmpStr+"="+DefValues[0].toLowerCase());
					break;
				}
			}
		}
		Ctrls.push(obj);
	}
}

function PrepareForm()
{
	var
		e,
		l,
		p;

	for(var i=0; i<Ctrls.length; ++i)
	{
		p = Ctrls[i].parent ? document.getElementById(Ctrls[i].parent) : document.forms[0];
		l = Ctrls[i].text ? document.createTextNode(Ctrls[i].text) : null;

		switch(Ctrls[i].type)
		{
			case "radio" :
			case "checkbox" :
			{
				p.innerHTML+="<input type=\""+Ctrls[i].type+"\" id=\""+Ctrls[i].id+"\""+(Ctrls[i].name ? " name=\""+Ctrls[i].name+"\"" : "")+(Ctrls[i].type=="radio" ? " value=\""+Ctrls[i].value+"\"" : "")+(Ctrls[i].eventlistener && Ctrls[i].eventfunction ? " on"+Ctrls[i].eventlistener+"=\""+Ctrls[i].eventfunction+"(this)\"" : "")+">";
				break;
			}
		}

		e=Ctrls[i].DOMptr=document.getElementById(Ctrls[i].id);

		if(Ctrls[i].cssclass)
			e.className=Ctrls[i].cssclass;

		if(l)
		{
			if(Ctrls[i].textalign && Ctrls[i].textalign.toLowerCase()=="left")
				p.insertBefore(l,e);
			else
				p.appendChild(l);
		}

		/*
		if(Ctrls[i].eventlistener
			&& Ctrls[i].eventfunction
			&& e)
			_addEventListener_(e,Ctrls[i].eventlistener,eval(Ctrls[i].eventfunction));
		*/

		/*if(Ctrls[i].eventlistener
			&& Ctrls[i].eventfunction
			&& e)
		{
			if("attachEvent" in e)
				e.attachEvent("on"+Ctrls[i].eventlistener,eval(Ctrls[i].eventfunction));
			else if("addEventListener" in e)
				e.addEventListener(Ctrls[i].eventlistener,eval(Ctrls[i].eventfunction),false);
			else
				eval("e.on"+Ctrls[i].eventlistener+"="+Ctrls[i].eventfunction);
		}*/

		if(Ctrls[i].withbr)
		{
			e=document.createElement('br');
			p.appendChild(e);
		}
	}
}

function AnyChange(obj/*e*/)
{
/*
	var
		obj;

	if(!e)
		e=window.event;

	if(e.srcElement)
		obj=e.srcElement;
	else
		obj=e.target;

alert(obj.value);

	if(e.stopPropagation)
		e.stopPropagation();
	else
		e.cancelBubble=true;
*/
	Calc();
}

function _addEventListener_(Ctrl, Listener, Func)
{
	if("attachEvent" in Ctrl)
		Ctrl.attachEvent(Listener,Func);
	else if("addEventListener" in Ctrl)
		Ctrl.addEventListener(Listener,Func,false);
	else
		eval("Ctrl.on"+Listener+"="+Func);
}

function Calc()
{
	for(var i=0; i<Ctrls.length; ++i)
	{
		if(!Ctrls[i].iscalculated)
			continue;

		switch(Ctrls[i].type)
		{
			case "radio" :
			{
				eval(Ctrls[i].varname+"="+(document.getElementById(Ctrls[i].id).checked /*Ctrls[i].DOMptr.checked*/ ? Ctrls[i].value : Ctrls[i].defaultvalue));
				break;
			}
			case "checkbox" :
			{
				eval(Ctrls[i].varname+"="+(document.getElementById(Ctrls[i].id).checked ? Ctrls[i].checkedvalue : Ctrls[i].defaultvalue));
				break;
			}
		}
	}

	document.getElementById("TextBoxResult").value=10*x1+20*x2+30*x3+40*x4+50*x5+1.1*y1+2.2*y2;
}