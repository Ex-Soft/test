/**
 * Class for construction the OData proxy for ExtJS 4.1.
 * @extends Ext.data.proxy.Ajax
 * @author Maicon Schelter
 * @example
 * Ext.create('Ext.data.Store',{
 * 		 autoLoad	: true
 * 		,autoSync	: true
 * 		,proxy : {
 * 			 type	: 'odata'
 * 			,url	: 'DTE/services/ListCars'
 * 			,params : {
 * 				type : 'DTE.Model.Cars'
 * 			}
 * 		}
 * 	});
 */
Ext.define('Ext.data.proxy.OData',{
	
	 extend				: 'Ext.data.proxy.Ajax'
	,alternateClassName	: 'Ext.data.OData'
	,alias				: 'proxy.odata'
	
	/**
	 * @cfg {Boolean} appendId
	 * Indicate if concat ID at URL request.
	 */
	,appendId			: true
	
	/**
	 * @cfg {Boolean} batchActions
	 * Indicate if execute the batch action of request.
	 */
	,batchActions		: false
	
	/**
	 * Method using with create the url of Ajax.
	 * @method buildUrl
	 * @param {Object} request Request options.
	 * @private
	 */
	,buildUrl : function(request)
	{
		var  me			= this
			,operation	= request.operation
			,records	= operation.records || []
			,record		= records[0]
			,format		= me.format
			,url		= me.getUrl(request)
			,id			= record && record.get('__metadata') ? record.get('__metadata').uri : operation.id;
		
		if(me.appendId && id)
		{
			url = Ext.util.Format.urlODataFormat(id);
		}
		
		if(format)
		{
			if(!url.match(/\.$/))
			{
				url += '.';
			}
			
			url += format;
		}
		
		request.url = url;
		
		return me.callParent(arguments);
	}
	
	,buildRequest : function(operation, callback, scope)
	{
		this.sortParam = (scope && scope.remoteSort ? '$orderby' : null);
		this.filterParam = (scope && scope.remoteFilter ? '$filter' : null);
		
		return Ext.data.proxy.Rest.superclass.buildRequest.apply(this, arguments);
	}
	
	/**
	 * Method using with create of sorters.
	 * @method encodeSorters
	 * @param {Array} sorters Request sorters.
	 * @private
	 */
	,encodeSorters : function(sorters)
	{
		var  min	= []
			,length	= sorters.length
			,i		= 0;
		
		for(; i<length; i++)
		{
			min[i] = sorters[i].property;
			
			if(sorters[i].direction.toLowerCase() == 'desc')
			{
				min[i] += ' desc';
			}
		}
		
		return min.join(',');
	}
	
	/**
	 * Method using with create of filters.
	 * @method encodeFilters
	 * @param {Array} filters Request filters.
	 * @private
	 */
	,encodeFilters : function(filters)
	{
		var  filter	= []
			,length	= filters.length
			,sq		= '\''
			,type	= ''
			,i;
		
		for(i=0; i<length; i++)
		{
			type = filters[i].type || '';
			
			switch(type)
			{
				case 'int':
					type	= '';
					sq		= '';
					break;
				case 'guid':
					type	= 'guid';
					sq		= '\'';
					break;
				default:
					type	= '';
					sq		= '\'';
					break;
			}
			
			filter[i] = filters[i].property + ' eq ' + type + sq + filters[i].value + sq;
		}
		
		return filter.join(' and ');
	}
},function()
{
	/**
	 * Override defaults property's of requests.
	 */
    Ext.apply(this.prototype,{
        actionMethods : {
             create : 'POST'
			,read   : 'GET'
			,update : 'MERGE'
			,destroy: 'DELETE'
        }
		,headers : {
			'Accept' : 'application/json'
		}
		,pageParam	: undefined
		,startParam	: '$skip'
		,limitParam	: '$top'
		,noCache	: false
    });
});

/**
 * Override of Ext.data.proxy.Server.
 * @extends Ext.data.proxy.Server
 * @author Maicon Schelter
 */
Ext.override(Ext.data.proxy.Server,{
	
	/**
	 * @cfg {Boolean} sorter
	 * Indicate if send the sorters to server at proxy.
	 */
	sorter : true
	
	/**
	 * Method using to process the response request of server.
	 * @method processResponse
	 * @param {Boolean} success Success param.
	 * @param {Object} operation Object operation of request.
	 * @param {Object} request Request configuration.
	 * @param {Object} response Object response of request.
	 * @param {Object} callback Function target at finally.
	 * @param {Object} scope Scope of callback function.
	 */
	,processResponse : function(success, operation, request, response, callback, scope)
	{
		var  me = this
			,reader
			,result;
		
		reader	= me.getReader();
		result	= reader.read(me.extractResponseData(response));
		
		Ext.apply(operation,{
			 response	: response
			,resultSet	: result
		});
		
		if(success === true)
		{
			if(result.success !== false)
			{
				operation.commitRecords(result.records);
				operation.setCompleted();
				operation.setSuccessful();
			}
			else
			{
				operation.setException(result.message);
				me.fireEvent('exception', this, response, operation);
			}
		}
		else
		{
			me.setException(operation, response);
			me.fireEvent('exception', this, response, operation);
		}
		
		if(typeof callback == 'function')
		{
			callback.call(scope || me, operation);
		}
		
		me.afterRequest(request, success);
	}
	
	/**
	 * Create the request proxy params.
	 * @method getParams
	 * @param {Object} operation Object operation config.
	 */
	,getParams : function(operation)
	{
		var  me				= this
			,params			= {}
			,isDef			= Ext.isDefined
			,groupers		= operation.groupers
			,sorters		= operation.sorters
			,filters		= operation.filters
			,page			= operation.page
			,start			= operation.start
			,limit			= operation.limit
			,simpleSortMode	= me.simpleSortMode
			,pageParam		= me.pageParam
			,startParam		= me.startParam
			,limitParam		= me.limitParam
			,groupParam		= me.groupParam
			,sortParam		= me.sortParam
			,filterParam	= me.filterParam
			,directionParam	= me.directionParam;
		
		if(pageParam && isDef(page))
		{
			params[pageParam] = page;
		}
		
		if(startParam && isDef(start))
		{
			params[startParam] = start;
		}
		
		if(limitParam && isDef(limit))
		{
			params[limitParam] = limit;
        }
		
		if(groupParam && groupers && groupers.length > 0)
		{
			params[groupParam] = me.encodeSorters(groupers);
        }
		
		if(this.sorter && sortParam && sorters && sorters.length > 0)
		{
			if(simpleSortMode)
			{
				params[sortParam]		= sorters[0].property;
				params[directionParam]	= sorters[0].direction;
			}
			else
			{
				params[sortParam] = me.encodeSorters(sorters);
			}
		}
		
		if(filterParam && filters && filters.length > 0)
		{
			params[filterParam] = me.encodeFilters(filters);
		}
		
		return params;
	}
});

/**
 * Override if Ext.data.AbstractStore.
 * @extends Ext.data.AbstractStore
 * @author Maicon Schelter
 */
Ext.override(Ext.data.AbstractStore,{
	
	/**
     * @cfg {Boolean} autoRevert
     * Indicate if rever store modified record case ocurrer a error.
     */
	autoRevert : true
	
	/**
	 * Method using to verify if are exists records modifieds in store.
	 * @method isModified
	 * @return {Boolean}
	 */
	,isModified : function()
	{
		var  me        = this
			,toCreate  = me.getNewRecords()
			,toUpdate  = me.getUpdatedRecords()
			,toDestroy = me.getRemovedRecords()
			,needsSync = false;
		
		if(toCreate.length > 0 || toUpdate.length > 0 || toDestroy.length > 0)
		{
			needsSync = true;
		}
		
		return needsSync;
    }
	
	/**
	 * Method using case ocurrer a error in store sync.
	 * @method onBatchException
	 * @param {Object} batch Object batch options of request.
	 * @param {Object} operation Object request config.
	 * @private
	 */
	,onBatchException : function(batch, operation)
	{
		if(this.autoRevert)
		{
			if(this.operation)
			{
				this.revertFailedOperation(operation);
			}
			else
			{
				for(var i=0; i<batch.operations.length; i++)
				{
					this.revertFailedOperation(batch.operations[i]);
				}
			}
		}
	}
	
	/**
	 * Method using to revert store records case ocurrer a error in store sync.
	 * @method revertFailedOperation
	 * @param {Object} operation Object request options.
	 */
	,revertFailedOperation : function(operation)
	{
		var records = operation.getRecords();
		
		if(records.length == 0)
		{
			return;
		}
		
		var store = this;
		
		switch(operation.action)
		{
			case "create":
				store.remove(records);
				break;
			
			case "update":
				Ext.each(records, function(item)
				{
					item.reject();
				},this);
				break;
			
			case "destroy":
				store.removed = [];
				store.loadRecords(records, {addRecords:true});
				break;
		}
	}
});

/**
 * Override of Ext.data.Connection.
 * @extends Ext.data.Connection
 * @author Maicon Schelter
 */
Ext.override(Ext.data.Connection,{
	
	/**
	 * Method using to send and request ajax data.
	 * @method request
	 * @param {Object} options Object request options.
	 */
	request : function(options)
	{
		options = options || {};
		
		var  me			= this
			,scope		= options.scope		|| window
			,username	= options.username	|| me.username
			,password	= options.password	|| me.password || ''
			,async
			,requestOptions
			,request
			,headers
			,xhr
			,expandParam;
		
		if(options.proxy && options.proxy.params && options.proxy.params.expand)
		{
			expandParam = options.proxy.params.expand;
		}
		else if(options.params && options.params.expand)
		{
			expandParam = options.params.expand;
			delete options.params.expand;
		}
		
		if(expandParam && options.method !== 'DELETE' && options.method !== 'MERGE')
		{
			if(Ext.isArray(expandParam))
			{
				expandParam = expandParam.join(',');
			}
			
			options.url = Ext.urlAppend(options.url, ('$expand=' + expandParam));
		}
		
		if(me.fireEvent('beforerequest', me, options) !== false)
		{
			requestOptions = me.setOptions(options, scope);
			
			if(this.isFormUpload(options) === true)
			{
				this.upload(options.form, requestOptions.url, requestOptions.data, options);
				return null;
			}
			
			if(options.autoAbort === true || me.autoAbort)
			{
				me.abort();
			}
			
			if((options.cors === true || me.cors === true) && Ext.isIe && Ext.ieVersion >= 8)
			{
				xhr = new XDomainRequest();
			}
			else
			{
				xhr = this.getXhrInstance();
			}
			
			async = options.async !== false ? (options.async || me.async) : false;
			
			if(username)
			{
				xhr.open(requestOptions.method, requestOptions.url, async, username, password);
			}
			else
			{
				xhr.open(requestOptions.method, requestOptions.url, async);
			}
			
			if(options.withCredentials === true || me.withCredentials === true)
			{
				xhr.withCredentials = true;
			}
			
			if(options.headers)
			{
				Ext.apply(options.headers, {'Accept':'application/json','Content-Type':'application/json'});
				
				if(options.method !== 'DELETE' && options.method !== 'MERGE')
				{
					delete options.headers['If-Match'];
				}
			}
			else
			{
				Ext.apply(options, {headers:{'Accept':'application/json','Content-Type':'application/json'}});
			}
			
			try
			{
				requestOptions.data = Ext.decode(requestOptions.data);
			}
			catch(ex)
			{
				requestOptions.data = Ext.urlDecode(requestOptions.data);
			}
			finally
			{
				if(requestOptions.data)
				{
					var type;
					
					if(requestOptions.data.__metadata)
					{
						if(requestOptions.data.__metadata.etag)
						{
							Ext.apply(options.headers, {'If-Match':requestOptions.data.__metadata.etag});
						}
						
						if(requestOptions.data.__metadata.type)
						{
							type = requestOptions.data.__metadata.type;
						}
					}
					else if(requestOptions.data.type)
					{
						type = requestOptions.data.type;
						delete requestOptions.data.type;
					}
					else if(scope.params && scope.params.type)
					{
						type = scope.params.type;
					}
					
					delete requestOptions.data.__metadata;
					
					if(!Ext.isEmpty(type))
					{
						Ext.apply(requestOptions.data,{'__metadata':{'type':type}});
					}
				}
				
				requestOptions.data = Ext.encode(requestOptions.data);
			}
			
			headers = me.setupHeaders(xhr, options, requestOptions.data, requestOptions.params);
			
			request = {
				 id		: ++Ext.data.Connection.requestId
				,xhr	: xhr
				,headers: headers
				,options: options
				,async	: async
				,timeout: setTimeout(function()
				{
					request.timedout = true;
					me.abort(request);
				}, options.timeout || me.timeout)
			};
			
			me.requests[request.id]	= request;
			me.latestId				= request.id;
			
            if(async)
			{
				xhr.onreadystatechange = Ext.Function.bind(me.onStateChange, me, [request]);
			}
			
			xhr.send(requestOptions.data);
			
			if(!async)
			{
				return this.onComplete(request);
			}
			
			return request;
		}
		else
		{
			Ext.callback(options.callback, options.scope, [options, undefined, undefined]);
			return null;
		}
	}
	
	/**
	 * Method using to treat ajax request returns.
	 * @method onComplete
	 * @param {Object} request Object request config.
	 */
	,onComplete : function(request)
	{
		var  me			= this
			,options	= request.options
			,result
			,success
			,response
			,code
			,etag;
		
        try
		{
			result = me.parseStatus(request.xhr.status);
		}
		catch(e)
		{
			result = {
				 success		: false
				,isException	: false
			};
        }
		
		success	= result.success;
		code	= request.xhr.status;
		etag	= request.xhr.getResponseHeader('Etag');
		
		if(success)
		{
			response = me.createResponse(request);
			me.fireEvent('requestcomplete', me, response, options);
			
			options.headers['If-Match'] = etag;
			Ext.callback(options.success, options.scope, [response, options]);
		}
		else
		{
			if(result.isException || request.aborted || request.timedout)
			{
				response = me.createException(request);
			}
			else
			{
				response = me.createResponse(request);
            }
			
			me.fireEvent('requestexception', me, response, options);
			Ext.callback(options.failure, options.scope, [response, options]);
		}
		
		Ext.callback(options.callback, options.scope, [options, success, response]);
		
		delete me.requests[request.id];
		return response;
	}
});