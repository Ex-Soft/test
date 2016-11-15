function getArgs()
{
	var
		args=new Object(),
		query=location.search.substring(1),
		pairs=query.split("&"),
		pos,
		argname,
		value;

	for(var i=0; i<pairs.length; ++i)
	{
		pos=pairs[i].indexOf("=");
		if(pos==-1)
			continue;
		argname=pairs[i].substring(0,pos);
		value=pairs[i].substring(pos+1);
		args[argname.toLowerCase()]=unescape(value);
		//args[argname.toLowerCase()]=decodeURIComponent(value);
	}

	return(args);
}
